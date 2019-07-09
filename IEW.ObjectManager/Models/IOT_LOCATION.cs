using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace IEW.ObjectManager.Models
{
    public class IOT_LOCATION
    {
        public int id { get; set; }
        public string location { get; set; }
        public string location_desc { get; set; }
        public DateTime clm_date_time { get; set; }
        public string clm_user { get; set; }
    }
}
