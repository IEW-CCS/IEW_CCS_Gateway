using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEW.ObjectManager
{
    public class VersionManager
    {
        public ConcurrentDictionary<string, List<cls_Version_Info>> version_list = new ConcurrentDictionary<string, List<cls_Version_Info>>();

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }

    public class OTAManager
    {
        public cls_FTP_Server ftp_info = new cls_FTP_Server();
        public List<cls_OTA_Gateway_Info> ota_iot_list = new List<cls_OTA_Gateway_Info>();
        public List<cls_OTA_Gateway_Info> ota_worker_list = new List<cls_OTA_Gateway_Info>();
        public List<cls_OTA_Device_Info> ota_firmware_list = new List<cls_OTA_Device_Info>();
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }

    public class cls_FTP_Server
    {
        public string server_ip { get; set; }
        public string server_port { get; set; }
        public string user_id { get; set; }
        public string password { get; set; }
    }

    public class cls_Version_Info
    {
        public string ap_type { get; set; } // "IOT", "WORKER", "FIRMWARE"
        public string ap_version { get; set; }
        public string ap_upload_path_name { get; set; }
        public string ap_store_path_name { get; set; }
        public string md5_string { get; set; }
        public string ap_description { get; set; }
        public DateTime update_time { get; set; }
    }

    public class cls_OTA_Gateway_Info
    {
        public string gateway_id { get; set; }
        public string ap_type { get; set; } // "IOT", "WORKER"
        public string ap_version { get; set; } //Current Version
        public string ap_store_path_name { get; set; }
        public string md5_string { get; set; }
        public string ap_description { get; set; }
        public string update_status { get; set; }
        public string status_message { get; set; }
        public DateTime last_update_time { get; set; }
    }

    public class cls_OTA_Device_Info
    {
        public string gateway_id { get; set; }
        public string device_id { get; set; }
        public string ap_type { get; set; } //  "FIRMWARE"
        public string ap_version { get; set; } //Current Version
        public string ap_store_path_name { get; set; }
        public string md5_string { get; set; }
        public string ap_description { get; set; }
        public string update_status { get; set; }
        public string status_message { get; set; }
        public DateTime last_update_time { get; set; }
    }
}