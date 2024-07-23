using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeviceDataProcessingTakeHome.Models
{
    public class Device
    {
        public int DeviceID { get; set; }
        public string Name { get; set; }
        public DateTime StartDateTime { get; set; }
        public List<SensorData> SensorData { get; set; }
    }
}
