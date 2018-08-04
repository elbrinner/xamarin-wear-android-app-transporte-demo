using System;
using System.Collections.Generic;

namespace transporte.Service.Models
{
    public class TransporteResponse
    {
        public string stopName { get; set; }
        public string stopNumber { get; set; }
        public List<Line> lines { get; set; }
        public string stopType { get; set; }
    }
}
