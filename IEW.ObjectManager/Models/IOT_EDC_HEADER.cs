using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IEW.ObjectManager.Models
{
    public class IOT_EDC_HEADER
    {
        public int id { get; set; }
        public string edc_header_set_id { get; set; }
        public string edc_header_id { get; set; }
        public string length { get; set; }
        public string value { get; set; }

        public DateTime clm_date_time { get; set; }
        public string clm_user { get; set; }

        public IOT_EDC_HEADER() { }

    }
}
