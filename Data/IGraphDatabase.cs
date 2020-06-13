//This file contains fragments that You have to fulfill
//  Potwierdzam samodzielność powyższej pracy oraz niekorzystanie przeze mnie z niedozwolonych źródeł
//  Artur Chmura

using ProjOb_lab7.Api;
using System.Collections.Generic;
using ProjOb_lab7.Iterators;

namespace ProjOb_lab7.Data
{
    public interface IGraphDatabase
    {
        IDatabaseIterator<Route> GetRoutesFrom(City from);
        City GetByName(string cityName);
    }
}
