using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeviceDataProcessingTakeHome.Models
{
    public class SensorData
    {
        public string SensorType { get; set; }
        public DateTime DateTime { get; set; }
        public double Value { get; set; }
    }
}
