using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeviceDataProcessingTakeHome.Models
{
    public class Foo1
    {
        public int PartnerId { get; set; }
        public string PartnerName { get; set; }
        public List<Tracker> Trackers { get; set; }
    }
}
