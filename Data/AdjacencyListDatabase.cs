﻿//This file contains fragments that You have to fulfill
//  Potwierdzam samodzielność powyższej pracy oraz niekorzystanie przeze mnie z niedozwolonych źródeł
//  Artur Chmura

using ProjOb_lab7.Api;
using System.Collections.Generic;
using ProjOb_lab7.Iterators;

namespace ProjOb_lab7.Data
{
    class AdjacencyListDatabase : IGraphDatabase
    {
        private Dictionary<string, City> cityDictionary = new Dictionary<string, City>();
        private Dictionary<City, List<Route>> routes = new Dictionary<City, List<Route>>();

        private void AddCity(City city)
        {
            if (!cityDictionary.ContainsKey(city.Name))
                cityDictionary[city.Name] = city;
        }
        public AdjacencyListDatabase(IEnumerable<Route> routes)
        {
            foreach (Route route in routes)
            {
                AddCity(route.From);
                AddCity(route.To);
                if (!this.routes.ContainsKey(route.From))
                {
                    this.routes[route.From] = new List<Route>();
                }
                this.routes[route.From].Add(route);
            }
        }
        public AdjacencyListDatabase()
        {
        }
        public void AddRoute(City from, City to, double cost, double travelTime, VehicleType vehicle)
        {
            AddCity(from);
            AddCity(to);
            if (!routes.ContainsKey(from))
            {
                routes[from] = new List<Route>();
            }
            routes[from].Add(new Route { From = from, To = to, Cost = cost, TravelTime = travelTime, VehicleType = vehicle });
        }

        public IDatabaseIterator<Route> GetRoutesFrom(City from)
        {
            /*
			 * Fill this fragment and return Type.
			 * Modyfing existing code in this class is forbidden.
			 * Adding new elements (fields, private classes) to this class is allowed.
			 */
            routes.TryGetValue(from, out List<Route> list);


            return new AdjacencyListIterator(list);

        }

        public City GetByName(string cityName)
        {
            return cityDictionary.GetValueOrDefault(cityName);
        }
    }
}
