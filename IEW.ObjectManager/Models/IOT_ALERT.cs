using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace IEW.ObjectManager.Models
{
    public class IOT_ALERT
    {
        public int id { get; set; }
        public string device_id { get; set; }
        public string alert_id { get; set; }
        public string alert_lvl { get; set; }
        public string alert_msg { get; set; }
        public DateTime rpt_date_time { get; set; }
        public string rpt_user { get; set; }
        public DateTime review_date_time { get; set; }
        public string review_user { get; set; }

        public List<IOT_ALERT> getNotYetConfirmAlerts(IOT_DbContext _db)
        {
            var vIotAlerts = _db.IOT_ALERT.AsQueryable();
            vIotAlerts = vIotAlerts.Where(c => c.review_user == null);
            vIotAlerts = vIotAlerts.OrderByDescending(c => c.rpt_date_time);

            return (vIotAlerts.ToList());
        }
    }
}
