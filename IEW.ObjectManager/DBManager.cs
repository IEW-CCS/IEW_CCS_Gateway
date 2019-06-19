using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace IEW.ObjectManager
{

    public class DBManager
    {
        public int serial_id_index;
        public List<cls_DB_Info> dbconfig_list = new List<cls_DB_Info>();

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }

    public class cls_DB_Info
    {
        public string serial_id { get; set; }
        public string gateway_id { get; set; }
        public string device_id { get; set; }
        public string db_type { get; set; }
        public string data_source { get; set; }
        public string port_id { get; set; }
        public string db_name { get; set; }
        public string user_name { get; set; }
        public string password { get; set; }
        public string provider_name { get; set; }
        public bool enable { get; set; }
        public string connection_string { get; set; }
        public List<Tuple<string, string>> tag_info = new List<Tuple<string, string>>();
        public List<Tuple<string, string>> calc_tag_info = new List<Tuple<string, string>>();
    }
}
