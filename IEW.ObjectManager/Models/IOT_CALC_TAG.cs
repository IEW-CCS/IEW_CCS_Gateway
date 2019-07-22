using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IEW.ObjectManager.Models
{
    public class IOT_CALC_TAG
    {
       

        public int id { get; set; }
        public string tag_set_id { get; set; }
        public string cal_tag_id { get; set; }
        public string cal_tag_desc { get; set; }
        public string data_type { get; set; }
        public string expression { get; set; }
        public string value { get; set; }
        public string param_a { get; set; }
        public string param_b { get; set; }
        public string param_c { get; set; }
        public string param_d { get; set; }
        public string param_e { get; set; }
        public string param_f { get; set; }
        public string param_g { get; set; }
        public string param_h { get; set; }
        public DateTime clm_date_time { get; set; }
        public string clm_user { get; set; }

        public IOT_CALC_TAG() { }

    }
}
