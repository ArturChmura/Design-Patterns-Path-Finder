//This file should not be modified

using System.Collections.Generic;

namespace ProjOb_lab7.Api
{
    class Filter
    {
        public int MinPopulation { get; set; }
        public bool RestaurantRequired { get; set; }
        public ISet<VehicleType> AllowedVehicles { get; set; }
    }
}
