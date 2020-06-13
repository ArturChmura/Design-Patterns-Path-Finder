//  Potwierdzam samodzielność powyższej pracy oraz niekorzystanie przeze mnie z niedozwolonych źródeł
//  Artur Chmura

using ProjOb_lab7.Api;
using ProjOb_lab7.Data;
using ProjOb_lab7.Iterators;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjOb_lab7.Filters
{
    class PopulationIterator : IDatabaseIterator<Route>
    {
        IDatabaseIterator<Route> iter;
        int minPopulation;
        public PopulationIterator(IDatabaseIterator<Route> iter, int minPopulation)
        {
            this.iter = iter;
            this.minPopulation = minPopulation;
        }
        public Route GetCurrent()
        {
            return iter.GetCurrent();
        }

        public bool HasNext()
        {
            while (iter.HasNext())
            {
                Route route = iter.GetCurrent();
                if (minPopulation <= route.To.Population && minPopulation <= route.From.Population)
                {
                    return true;
                }
            }

            return false;
        }

    }

    class PopulationDatabase : IGraphDatabase
    {
        IGraphDatabase database;
        int minPopulation;
        public PopulationDatabase(IGraphDatabase database, int minPopulation)
        {
            this.database = database;
            this.minPopulation = minPopulation;
        }
        public City GetByName(string cityName)
        {
            City city = database.GetByName(cityName);
            if ( city!= null && city.Population >= minPopulation)
            {
                return city;
            }
            return null;
        }

        public IDatabaseIterator<Route> GetRoutesFrom(City from)
        {
            return new PopulationIterator(database.GetRoutesFrom(from), minPopulation);
        }
    }
}
