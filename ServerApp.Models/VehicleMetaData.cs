using System;
using System.Collections.Generic;
using System.Text;

namespace ServerApp.Models
{
    public class VehicleMetaData
    {
        public List<Vehicle> data { get; set; } 
        public List<string> categories { get; set; }
    }
}
