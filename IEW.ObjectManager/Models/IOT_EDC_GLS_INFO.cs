using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace IEW.ObjectManager.Models
{
    public class IOT_EDC_GLS_INFO
    {
        public int id { get; set; }
        public string device_type { get; set; }
        public string eqp_id { get; set; }
        public string sub_eqp_id { get; set; }
        public string glass_id { get; set; }
        public string group_id { get; set; }
        public string lot_id { get; set; }
        public string product_id { get; set; }
        public string pfcd { get; set; }
        public string ec_code { get; set; }
        public string route_no { get; set; }
        public string route_version { get; set; }
        public string owner { get; set; }
        public string recipe_id { get; set; }
        public string operation { get; set; }
        public string ope_id { get; set; }
        public string ope_no { get; set; }
        public string proc_id { get; set; }
        public string rtc_flag { get; set; }
        public string pnp { get; set; }
        public string chamber { get; set; }
        public string cassette_id { get; set; }
        public string mes_link_key { get; set; }
        public DateTime clm_date_time { get; set; }
        public string clm_user { get; set; }
    }
}

