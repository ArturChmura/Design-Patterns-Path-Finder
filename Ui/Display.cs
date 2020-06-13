//  Potwierdzam samodzielność powyższej pracy oraz niekorzystanie przeze mnie z niedozwolonych źródeł
//  Artur Chmura

using ProjOb_lab7.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjOb_lab7.Ui
{
    class DisplayXML : IDisplay
    {
        public void Print(IEnumerable<Route> routes)
        {
            if(routes == null)
            {
                return;
            }
            Route firstRoute;
            try
            {
                firstRoute = routes.First();
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("Could not find routes");
                return;
            }
            double totalTime = 0.0;
            double totalCost = 0.0;
            Console.WriteLine("<City/>");
            Console.WriteLine("<Name>" + firstRoute.From.Name + "</Name>");
            Console.WriteLine("<Population>" + firstRoute.From.Population + "</Population>");
            Console.WriteLine("<HasRestaurant>" + firstRoute.From.HasRestaurant + "</HasRestaurant>");
            foreach (Route route in routes)
            {
                Console.WriteLine();
                Console.WriteLine("<Route/>");
                Console.WriteLine("<Vehicle>" + route.VehicleType.ToString() + "</Vehicle>");
                Console.WriteLine("<Cost>" + route.Cost.ToString("n2")  + "</Cost>");
                Console.WriteLine("<TravelTime>" + route.TravelTime + "</TravelTime>");

                totalCost += route.Cost;
                totalTime += route.TravelTime;

                Console.WriteLine();
                Console.WriteLine("<City/>");
                Console.WriteLine("<Name>" + route.To.Name + "</Name>");
                Console.WriteLine("<Population>" + route.To.Population + "</Population>");
                Console.WriteLine("<HasRestaurant>" + route.To.HasRestaurant + "</HasRestaurant>");

            }
            Console.WriteLine();
            Console.WriteLine("<totalTime>" + totalTime.ToString("n2") + "</totalTime>");
            Console.WriteLine("<totalCost>" + totalCost.ToString("n2") + "</totalCost>");
        }
    }

    class DisplayKeyValue : IDisplay
    {
        public void Print(IEnumerable<Route> routes)
        {
            if (routes == null)
            {
                return;
            }
            Route firstRoute;
            try
            {
                firstRoute = routes.First();
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("Could not find routes");
                return;
            }
            double totalTime = 0.0;
            double totalCost = 0.0;

            Console.WriteLine("=City=");
            Console.WriteLine("Name=" + firstRoute.From.Name);
            Console.WriteLine("Population=" + firstRoute.From.Population);
            Console.WriteLine("HasRestaurant=" + firstRoute.From.HasRestaurant);
            foreach (Route route in routes)
            {
                Console.WriteLine();
                Console.WriteLine("=Route=");
                Console.WriteLine("Vehicle=" + route.VehicleType.ToString());
                Console.WriteLine("Cost=" + route.Cost.ToString("n2"));
                Console.WriteLine("TravelTime=" + route.TravelTime);

                totalCost += route.Cost;
                totalTime += route.TravelTime;

                Console.WriteLine();
                Console.WriteLine("=City=");
                Console.WriteLine("Name=" + route.To.Name);
                Console.WriteLine("Population=" + route.To.Population);
                Console.WriteLine("HasRestaurant=" + route.To.HasRestaurant);

            }
            Console.WriteLine();
            Console.WriteLine($"totalTime=" + totalTime.ToString("n2"));
            Console.WriteLine("totalCost=" + totalCost.ToString("n2"));
        }
    }
}
