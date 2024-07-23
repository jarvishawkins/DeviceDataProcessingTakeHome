using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeviceDataProcessingTakeHome.Models
{
    public class Tracker
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public DateTime ShipmentStartDtm { get; set; }
        public List<Sensor> Sensors { get; set; }
    }
}
