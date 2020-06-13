//  Potwierdzam samodzielność powyższej pracy oraz niekorzystanie przeze mnie z niedozwolonych źródeł
//  Artur Chmura

using ProjOb_lab7.Interfaces;
using ProjOb_lab7.Problems;
using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace ProjOb_lab7.Factories
{
    static class ProblemFactory
    {
        static public IRouteProblem MakeProblem(string problemName,string from, string to)
        {
            if(problemName == "Cost")
            {
                return new CostProblem(from, to);
            }
            if(problemName == "Time")
            {
                return new TimeProblem(from, to);
            }
            throw new ArgumentException($"{problemName} is not a known problem");
        }
    }
}
