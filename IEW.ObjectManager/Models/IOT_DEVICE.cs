using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IEW.ObjectManager.Models
{
    public class IOT_DEVICE
    {
        public int id { get; set; }
        public string device_id { get; set; }
        public string device_desc { get; set; }
        public string device_type { get; set; }
        public string status { get; set; }
        public string location { get; set; }
        public double value { get; set; }
        public double lcl { get; set; }
        public double ucl { get; set; }
        public double lspec { get; set; }
        public double uspec { get; set; }
        public DateTime clm_date_time { get; set; }
        public string clm_user { get; set; }
        public int rpt_interval { get; set; }
        public int col_interval { get; set; }
        public string ooc_flg { get; set; }
        public string oos_flg { get; set; }
        public string alarm_flg { get; set; }
        public string eqp_id { get; set; }
        public string sub_eqp_id { get; set; }
        public int device_no { get; set; }
        public double pos_latitude { get; set; }
        public double pos_longitude { get; set; }
        public string gateway_id { get; set; }
        public string plc_ip_address { get; set; }
        public string plc_port_id { get; set; }
        public string ble_mac { get; set; }
        public string ble_service_uuid { get; set; }


        public IOT_DEVICE() { }

        public int getNewTableNO(IOT_DbContext _db)
        {
            int iTableNo = 1;
            var vIoT_Devices = _db.IOT_DEVICE.AsQueryable();
            vIoT_Devices = vIoT_Devices.OrderByDescending(c => c.device_no);
            IOT_DEVICE oIoT_Device = vIoT_Devices.FirstOrDefault();

            if(oIoT_Device != null){

                iTableNo = oIoT_Device.device_no + 1;

                if (iTableNo>128){
                    iTableNo = 999;
                }
            }

            return (iTableNo);
        }
    }
}
