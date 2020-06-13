//This file Can be modified
//  Potwierdzam samodzielność powyższej pracy oraz niekorzystanie przeze mnie z niedozwolonych źródeł
//  Artur Chmura

using ProjOb_lab7.Algorithms;
using ProjOb_lab7.Api;
using ProjOb_lab7.Data;
using System.Collections.Generic;
using System.Transactions;

namespace ProjOb_lab7.Interfaces
{
    interface IRouteProblem
	{
        IGraphDatabase Graph { get; set; }
        public bool TrySolveBySolver(ISolver solver,out IEnumerable<Route> routes);
	}
}
