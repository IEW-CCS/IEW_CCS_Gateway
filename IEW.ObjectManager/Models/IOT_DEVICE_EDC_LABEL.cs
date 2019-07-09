using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace IEW.ObjectManager.Models
{
    public class IOT_DEVICE_EDC_LABEL
    {
        public int id { get; set; }
        public string device_id { get; set; }
        public string data_name { get; set; }
        public int data_index { get; set; }
        public double lcl { get; set; }
        public double ucl { get; set; }
        public double lspec { get; set; }
        public double uspec { get; set; }
        public DateTime clm_date_time { get; set; }
        public string clm_user { get; set; }
        
        
    }
}
