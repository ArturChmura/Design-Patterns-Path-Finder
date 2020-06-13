//This file Can be modified
//  Potwierdzam samodzielność powyższej pracy oraz niekorzystanie przeze mnie z niedozwolonych źródeł
//  Artur Chmura

using ProjOb_lab7.Algorithms;
using ProjOb_lab7.Api;
using ProjOb_lab7.Data;
using ProjOb_lab7.Interfaces;
using System.Collections.Generic;

namespace ProjOb_lab7.Problems
{
    public class TimeProblem : IRouteProblem
    {
        public IGraphDatabase Graph { get; set; }


        public string From, To;
        public TimeProblem(string from, string to)
        {
            From = from;
            To = to;
        }

        public bool TrySolveBySolver(ISolver solver, out IEnumerable<Route> routes)
        {
            return solver.TrySolveProblem(this, out routes);

        }
    }
}
