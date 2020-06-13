//This file contains fragments that You have to fulfill
//  Potwierdzam samodzielność powyższej pracy oraz niekorzystanie przeze mnie z niedozwolonych źródeł
//  Artur Chmura

using ProjOb_lab7.Api;
using ProjOb_lab7.Data;
using ProjOb_lab7.Iterators;
using ProjOb_lab7.Problems;
using System.Collections.Generic;

namespace ProjOb_lab7.Algorithms
{
    public class BFS : ISolver
    {
        public string Name { get { return "BFS"; } }

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
            Queue<City> queue = new Queue<City>();
            queue.Enqueue(from);
            do
            {
                City city = queue.Dequeue();
                /*
				 * For each outgoing route from city...
				 */
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
                    queue.Enqueue(route.To);
                }
            } while (queue.Count > 0);
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
