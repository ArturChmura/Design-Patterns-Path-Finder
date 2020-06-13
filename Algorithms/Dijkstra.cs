//This file contains fragments that You have to fulfill
//  Potwierdzam samodzielność powyższej pracy oraz niekorzystanie przeze mnie z niedozwolonych źródeł
//  Artur Chmura

using ProjOb_lab7.Api;
using ProjOb_lab7.Data;
using ProjOb_lab7.Iterators;
using ProjOb_lab7.Problems;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

namespace ProjOb_lab7.Algorithms
{
    public abstract class Dijkstra : ISolver
    {

        public  string Name { get { return "Dijkstra"; } }
        public abstract bool TrySolveProblem(TimeProblem timeProblem, out IEnumerable<Route> routes);

        public abstract bool TrySolveProblem(CostProblem costProblem, out IEnumerable<Route> routes);

        public  IEnumerable<Route> Solve(IGraphDatabase graph, City from, City to)
        {
            Dictionary<City, (double dist, Route last)> distances = new Dictionary<City, (double dist, Route last)>();
            HashSet<City> visitedCitites = new HashSet<City>();
            distances[from] = (0, null);
            City minCity = from;
            while (minCity != to)
            {
                /*
				 * For each outgoing route from minCity...
				 */
                IDatabaseIterator<Route> iter = graph.GetRoutesFrom(minCity);
                while (iter.HasNext())
                {
                    Route route = iter.GetCurrent(); /* Change to current Route*/
                    if (visitedCitites.Contains(route.To))
                    {
                        continue;
                    }
                    double dist = distances[minCity].dist + OptimizingValueFunc(route);
                    if (!distances.ContainsKey(route.To))
                    {
                        distances[route.To] = (dist, route);
                    }
                    else
                    {
                        if (dist < distances[route.To].dist)
                        {
                            distances[route.To] = (dist, route);
                        }
                    }
                }
                visitedCitites.Add(minCity);
                minCity = null;
                foreach (var (city, (dist, route)) in distances)
                {
                    if (visitedCitites.Contains(city))
                    {
                        continue;
                    }
                    if (minCity == null || dist < distances[city].dist)
                    {
                        minCity = city;
                    }
                }
                if (minCity == null)
                {
                    return null;
                }
            }
            List<Route> result = new List<Route>();
            for (Route route = distances[to].last; route != null; route = distances[route.From].last)
            {
                result.Add(route);
            }
            result.Reverse();
            return result;
        }

        protected abstract double OptimizingValueFunc(Route route);
    }

    class DijkstraCost : Dijkstra
    {

        public override bool TrySolveProblem(TimeProblem timeProblem, out IEnumerable<Route> routes)
        {
            routes = null;
            return false;
            
        }

        public override bool TrySolveProblem(CostProblem costProblem, out IEnumerable<Route> routes)
        {
            routes = Solve(costProblem.Graph, costProblem.Graph.GetByName(costProblem.From), costProblem.Graph.GetByName(costProblem.To));
            return true;
        }

        protected override double OptimizingValueFunc(Route route)
        {
            return route.Cost;
        }
    }

    class DijkstraTime : Dijkstra
    {
        public override bool TrySolveProblem(TimeProblem timeProblem, out IEnumerable<Route> routes)
        {
            routes = Solve(timeProblem.Graph, timeProblem.Graph.GetByName(timeProblem.From), timeProblem.Graph.GetByName(timeProblem.To));
            return true;
        }

        public override bool TrySolveProblem(CostProblem timeProblem, out IEnumerable<Route> routes)
        {
            routes = null;
            return false;
        }

        protected override double OptimizingValueFunc(Route route)
        {
            return route.TravelTime;
        }
    }
}
