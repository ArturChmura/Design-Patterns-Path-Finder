//  Potwierdzam samodzielność powyższej pracy oraz niekorzystanie przeze mnie z niedozwolonych źródeł
//  Artur Chmura

using ProjOb_lab7.Api;
using ProjOb_lab7.Data;
using ProjOb_lab7.Problems;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjOb_lab7.Algorithms
{
    public interface ISolver
    {
        public string Name { get; }
        bool TrySolveProblem(TimeProblem timeProblem, out IEnumerable<Route> routes);
        bool TrySolveProblem(CostProblem costProblem, out IEnumerable<Route> routes);
    }
   
}
