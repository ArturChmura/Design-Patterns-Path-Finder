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
    class HasRestaurantIterator : IDatabaseIterator<Route>
    { 
        IDatabaseIterator<Route> iter;
        public HasRestaurantIterator(IDatabaseIterator<Route> iter)
        {
            this.iter = iter;
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
                if ( route.To.HasRestaurant &&  route.From.HasRestaurant)
                {
                    return true;
                }
            }

            return false;
        }

    }
    class HasRestaurantDatabase : IGraphDatabase
    {
        IGraphDatabase database;
        bool hasRestaurant;
        public HasRestaurantDatabase(IGraphDatabase database,bool hasRestaurant)
        {
            this.database = database;
            this.hasRestaurant = hasRestaurant;
        }
        public City GetByName(string cityName)
        {
            if(hasRestaurant)
            {
                City city = database.GetByName(cityName);
                if (city!= null && city.HasRestaurant)
                {
                    return city;
                }
                return null;
            }
            return database.GetByName(cityName);

        }

        public IDatabaseIterator<Route> GetRoutesFrom(City from)
        {
            if (hasRestaurant)
            {
                return new HasRestaurantIterator(database.GetRoutesFrom(from));
            }
            return database.GetRoutesFrom(from);
        }
    }
}
