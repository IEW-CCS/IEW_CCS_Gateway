using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IEW.ObjectManager.Models
{
    public class IOT_EDC_XML_CONF
    {
        public int id { get; set; }
        public string serial_id { get; set; }
        public string gateway_id { get; set; }
        public string device_id { get; set; }
        public string edc_header_set_id { get; set; }
        public string report_type { get; set; }
        public double report_interval { get; set; }
        public string report_edc_path { get; set; }
        public string avg_flag { get; set; }
        public string max_flag { get; set; }
        public string min_flag { get; set; }
        public string enable { get; set; }

        public DateTime clm_date_time { get; set; }
        public string clm_user { get; set; }

        public IOT_EDC_XML_CONF() { }

    }
}
