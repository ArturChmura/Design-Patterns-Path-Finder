//  Potwierdzam samodzielność powyższej pracy oraz niekorzystanie przeze mnie z niedozwolonych źródeł
//  Artur Chmura

using ProjOb_lab7.Api;
using ProjOb_lab7.Data;
using ProjOb_lab7.Iterators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjOb_lab7.Filters
{
    class VehicleIterator : IDatabaseIterator<Route>
    {
        List<IDatabaseIterator<Route>> iterators;
        IEnumerable<VehicleType> allowedVehicle;
        int i = 0;
        public VehicleIterator(IEnumerable<IDatabaseIterator<Route>> iterators, IEnumerable<VehicleType> allowedVehicle)
        {
            this.iterators = iterators.ToList<IDatabaseIterator<Route>>();
            this.allowedVehicle = allowedVehicle;
        }
        public Route GetCurrent()
        {
            return iterators[i].GetCurrent();
        }

        public bool HasNext()
        {

            while (i < iterators.Count)
            {
                if (iterators[i].HasNext())
                {
                    if(allowedVehicle.Contains(iterators[i].GetCurrent().VehicleType))
                    return true;
                }
                i++;
            }

            return false;
        }

    }

    class VehicleDatabase : IGraphDatabase
    {

        IEnumerable<IGraphDatabase> databases;
        IEnumerable<VehicleType> allowedVehicles;
        public VehicleDatabase(IEnumerable<IGraphDatabase> databases, IEnumerable<VehicleType> allowedVehicles)
        {
            this.databases = databases;
            this.allowedVehicles = allowedVehicles;
        }
        public City GetByName(string cityName)
        {
            foreach (IGraphDatabase database in databases)
            {
                City city = database.GetByName(cityName);
                if (city != null &&  !string.IsNullOrEmpty(city.Name))
                {
                    return city;
                }
            }
            return null;


        }

        public IDatabaseIterator<Route> GetRoutesFrom(City from)
        {
            List<IDatabaseIterator<Route>> lists = new List<IDatabaseIterator<Route>>();
            foreach (IGraphDatabase database in databases)
            {
                lists.Add(database.GetRoutesFrom(from));
            }
            return new VehicleIterator(lists,allowedVehicles);
        }
    }
}
