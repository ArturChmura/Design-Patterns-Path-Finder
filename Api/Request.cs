//This file should not be modified

using ProjOb_lab7.Interfaces;

namespace ProjOb_lab7.Api
{
    class Request
    {
        public string From { get; set; }
        public string To { get; set; }
        public string Solver { get; set; }
        public string Problem { get; set; }
        public Filter Filter { get; set; }
    }
}
