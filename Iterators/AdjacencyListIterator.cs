﻿//  Potwierdzam samodzielność powyższej pracy oraz niekorzystanie przeze mnie z niedozwolonych źródeł
//  Artur Chmura

using ProjOb_lab7.Api;
using ProjOb_lab7.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjOb_lab7.Iterators
{
    class AdjacencyListIterator : IDatabaseIterator<Route>
    {
        List<Route> routes;
        int i = -1;
        public AdjacencyListIterator(List<Route> routes)
        {
            if (routes == null)
            {
                this.routes = new List<Route>(); 
            }
            else
            {
                this.routes = routes;
            }
        }
        public Route GetCurrent()
        {
            return routes[i];
        }

        public bool HasNext()
        {
            i++;
            if(i>=routes.Count)
            {
                return false;
            }
            return true;
        }
    }
}
