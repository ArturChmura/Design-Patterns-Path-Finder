//This file contains fragments that You have to fulfill
//  Potwierdzam samodzielność powyższej pracy oraz niekorzystanie przeze mnie z niedozwolonych źródeł
//  Artur Chmura

using ProjOb_lab7.Api;
using ProjOb_lab7.Data;
using System.Collections.Generic;
using ProjOb_lab7.Iterators;
using System.Runtime.Versioning;
using ProjOb_lab7.Problems;

namespace ProjOb_lab7.Algorithms
{
    public class DFS : ISolver
    {
        public string Name { get { return "DFS"; } }
        public bool TrySolveProblem(TimeProblem timeProblem, out IEnumerable<Route> routes)
        {
            routes = Solve(timeProblem.Graph, timeProblem.Graph.GetByName(timeProblem.From), timeProblem.Graph.GetByName(timeProblem.To));
            return true;
        }

        public bool TrySolveProblem(CostProblem costProblem, out IEnumerable<Route> routes)
        {
            routes = Solve(costProblem.Graph, costProblem.Graph.GetByName(costProblem.From), costProblem.Graph.GetByName(costProblem.To));
            return true;
        }

        public  IEnumerable<Route> Solve(IGraphDatabase graph, City from, City to)
        {
            Dictionary<City, Route> routes = new Dictionary<City, Route>();
            routes[from] = null;
            Stack<City> stack = new Stack<City>();
            stack.Push(from);
            do
            {
                City city = stack.Pop();
                IDatabaseIterator<Route> iter = graph.GetRoutesFrom(city);
                while (iter.HasNext())
                {
                    Route route = iter.GetCurrent(); /* Change to current Route*/
                    if (routes.ContainsKey(route.To))
                    {
                        continue;
                    }
                    routes[route.To] = route;
                    if (route.To == to)
                    {
                        break;
                    }
                    stack.Push(route.To);
                }
            } while (stack.Count > 0);
            if (!routes.ContainsKey(to))
            {
                return null;
            }
            List<Route> result = new List<Route>();
            for (Route route = routes[to]; route != null; route = routes[route.From])
            {
                result.Add(route);
            }
            result.Reverse();
            return result;
        }


    }
}
