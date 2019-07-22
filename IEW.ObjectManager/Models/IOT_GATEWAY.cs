using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IEW.ObjectManager.Models
{
    public class IOT_GATEWAY
    {
        public int id { get; set; }
        public string gateway_id { get; set; }
        public string gateway_ip { get; set; }
        public string location { get; set; }
        public string  virtual_flag { get; set; }
        public string  virtual_publish_topic { get; set; }
        public DateTime clm_date_time { get; set; }
        public string clm_user { get; set; }
        
        public IOT_GATEWAY() { }
        
    }
}
