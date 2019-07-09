using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IEW.ObjectManager.Models
{
    public class IOT_TAG
    {
        public int id { get; set; }
        public string tag_set_id { get; set; }
        public string tag_id { get; set; }
        public string tag_desc { get; set; }
        public string data_type { get; set; }
        public string data_unit { get; set; }
        public string uuid_address { get; set; }
        public string value { get; set; }
        public double scale { get; set; }
        public double offset { get; set; }
        public string report_flag { get; set; }
        public string db_report_flag { get; set; }
        
        public DateTime clm_date_time { get; set; }
        public string clm_user { get; set; }

        public IOT_TAG() { }

    }
}
