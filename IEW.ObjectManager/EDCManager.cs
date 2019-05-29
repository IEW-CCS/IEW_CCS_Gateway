using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEW.ObjectManager
{

    public class cls_EDC_Info
    {
        public string serial_id { get; set; }
        public string gateway_id { get; set; }
        public string device_id { get; set; }

        public string report_tpye { get; set; }    //目前使用Interval 未來考慮有event trigger...
        public double report_interval { get; set; }   // 以秒為單位
        public DateTime LastReportDatetime { get; set; }

        public bool triggered { get; set; }        // 保留未來給event triger使用

        public string baseEDCPath { get; set; }    //EDC 寫入相關資訊
        public string ReportEDCPath { get; set; }
        public bool enable { get; set; }

        public List<Tuple<string, string>> tag_info = new List<Tuple<string, string>>();

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }

    public class EDCManager
    {
        public List<cls_EDC_Info> gateway_edc = new List<cls_EDC_Info>();
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }

    public class cls_EDC_Head_Item
    {
        public string head_name { get; set; }
        public int length { get; set; }
        public string value { get; set; }
    }

    public class cls_EDC_Head_Set
    {
        public string set_name;
        public string set_description;
        public List<cls_EDC_Head_Item> head_set = new List<cls_EDC_Head_Item>();
    }
}
