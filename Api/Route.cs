﻿//This file should not be modified

namespace ProjOb_lab7.Api
{
    public class Route
    {
        public City From { get; set; }
        public City To { get; set; }
        public double Cost { get; set; }
        public double TravelTime { get; set; }
        public VehicleType VehicleType { get; set; }
    }
}
