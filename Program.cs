//  Potwierdzam samodzielność powyższej pracy oraz niekorzystanie przeze mnie z niedozwolonych źródeł
//  Artur Chmura

using ProjOb_lab7.Api;
using ProjOb_lab7.Data;
using ProjOb_lab7.Ui;
using ProjOb_lab7.Form;
using System;
using System.Collections.Generic;
using System.IO;
using ProjOb_lab7.Filters;
using ProjOb_lab7.Algorithms;
using System.Xml;
using System.Data;
using System.Threading;
using ProjOb_lab7.Factories;
using ProjOb_lab7.Interfaces;
using ProjOb_lab7.Problems;

namespace ProjOb_lab7
{
    class Program
    {

        static IEnumerable<Route> ServeRequest(Request request)
        {
            if (!CheckRequest(request))
            {
                return null;
            }
            (IGraphDatabase cars, IGraphDatabase trains) = MockData.InitDatabases();
            List<IGraphDatabase> databases = new List<IGraphDatabase>();
            databases.Add(cars);
            databases.Add(trains);

            IGraphDatabase database = new VehicleDatabase(databases,request.Filter.AllowedVehicles);
            database = new PopulationDatabase(database, request.Filter.MinPopulation);
            database = new HasRestaurantDatabase(database, request.Filter.RestaurantRequired);

            List<ISolver> solvers = new List<ISolver>();
            solvers.Add(new BFS());
            solvers.Add(new DFS());
            solvers.Add(new DijkstraCost());
            solvers.Add(new DijkstraTime());

            IRouteProblem problem = ProblemFactory.MakeProblem(request.Problem, request.From, request.To);
            problem.Graph = database;
            foreach (ISolver solver in solvers)
            {
                if (solver.Name == request.Solver && problem.TrySolveBySolver(solver, out IEnumerable<Route> routes))
                {
                    return routes;
                }
            }
            Console.WriteLine("Cannot find algorithm to solve this problem");
            return null;
        }

        private static bool CheckRequest(Request request)
        {

            if (string.IsNullOrEmpty(request.From))
            {
                Console.WriteLine("\"From\" connot be empty");
                return false;
            }
            if (string.IsNullOrEmpty(request.To))
            {
                Console.WriteLine("\"To\" connot be empty");
                return false;
            }
            if (request.Filter.MinPopulation < 0)
            {
                Console.WriteLine("\"MinPopulation\" connot be negative value");
                return false;
            }
            if (request.Filter.AllowedVehicles.Count <= 0)
            {
                Console.WriteLine("\"AllowedVehicles\" must countain at least 1 value");
                return false;
            }

            return true;
        }

        static void Main(string[] args)
        {

            Console.WriteLine("---- Xml Interface ----");
            ISystem xmlSystem = SystemFactory.GetSystemXML();
            Execute(xmlSystem, "xml_input.txt");
            Console.WriteLine();

            Console.WriteLine("---- KeyValue Interface ----");
            Console.WriteLine("---- Xml Interface ----");
            ISystem keyValueSystem = SystemFactory.GetSystemKeyValue();
            Execute(keyValueSystem, "key_value_input.txt");
            Console.WriteLine();
        }


        static void Execute(ISystem system, string path)
        {
            IEnumerable<IEnumerable<string>> allInputs = ReadInputs(path);
            foreach (var inputs in allInputs)
            {
                foreach (string input in inputs)
                {
                    system.Form.Insert(input);
                }
                var request = RequestMapper.Map(system.Form);
                var result = ServeRequest(request);
                system.Display.Print(result);
                Console.WriteLine("==============================================================");
            }
        }

        private static IEnumerable<IEnumerable<string>> ReadInputs(string path)
        {
            using (StreamReader file = new StreamReader(path))
            {
                List<List<string>> allInputs = new List<List<string>>();
                while (!file.EndOfStream)
                {
                    string line = file.ReadLine();
                    List<string> inputs = new List<string>();
                    while (!string.IsNullOrEmpty(line))
                    {
                        inputs.Add(line);
                        line = file.ReadLine();
                    }
                    if (inputs.Count > 0)
                    {
                        allInputs.Add(inputs);
                    }
                }
                return allInputs;
            }
        }
    }
}
