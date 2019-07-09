using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace IEW.ObjectManager.Models
{
    public class IOT_DEVICE_SPEC
    {
        public int id { get; set; }
        public string device_type { get; set; }
        public double lcl { get; set; }
        public double ucl { get; set; }
        public double lspec { get; set; }
        public double uspec { get; set; }
        public DateTime clm_date_time { get; set; }
        public string clm_user { get; set; }
        public int rpt_interval { get; set; }
        public int col_interval { get; set; }
    }
}
