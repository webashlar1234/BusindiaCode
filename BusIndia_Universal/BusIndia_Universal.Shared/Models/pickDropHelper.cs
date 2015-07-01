using System;
using System.Collections.Generic;
using System.Text;

namespace BusIndia_Universal.Models
{
 public   class pickDropHelper
    {
        public static getSeatlayout objGetSeatLayout { get; set; }
        public static GetAvailableService objGetAvailableService { get; set; }
        public static PickupDropoffRequest objGetPickDrop { get; set; }
        public static getBusSearch objgetBusSearch { get; set; }
        public static PickupDropoffReturn objGetPickDropReturn { get; set; }
        public static GetAvailableServicesReturn objGetASReturn { get; set; }
      
    }
}
