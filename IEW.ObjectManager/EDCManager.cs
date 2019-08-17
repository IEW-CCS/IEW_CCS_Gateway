﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using System.Xml.Linq;

namespace IEW.ObjectManager
{

    public class EDCPartaker
    {
        public string serial_id { get; set; }
        public string gateway_id { get; set; }
        public string device_id { get; set; }

        public string report_tpye { get; set; }
        public double report_interval { get; set; }
        public DateTime timestapm { get; set; }

        public string ReportEDCPath { get; set; }

        public List<cls_EDC_Head_Item> edchead_info;
        public List<cls_EDC_Body_Item> edcitem_info;
        public List<string> interval_function ;


        public EDCPartaker()
        {

        }
        public EDCPartaker(cls_EDC_Info EDCInfo)
        {
            this.serial_id = EDCInfo.serial_id;
            this.gateway_id = EDCInfo.gateway_id;
            this.device_id = EDCInfo.device_id;

            this.report_tpye = EDCInfo.report_tpye;
            this.report_interval = EDCInfo.report_interval;
            this.timestapm = DateTime.Now;
            this.ReportEDCPath = EDCInfo.ReportEDCPath;

            this.interval_function =  EDCInfo.interval_function.ToList();
            this.edchead_info = EDCInfo.edchead_info.ToList();
            this.edcitem_info = new List<cls_EDC_Body_Item>();

        }
        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public string xml_string()
        {
            XDocument xmlDocument = new XDocument(
               new XDeclaration("1.0", "utf-8", ""),
              // new XComment("Creating an XML Tree using LINQ to XML"),
               new XElement("EDC",
                      from header in this.edchead_info
                      select new XElement(header.head_name, header.value),

                      new XElement("datas",
                      from item in this.edcitem_info
                      select new XElement("iary", "",
                                 new XElement("item_name", item.item_name),
                                 new XElement("item_type", item.item_type),
                                 new XElement("item_value", item.item_value)))
           ));
            return xmlDocument.ToString();
        }
    }

    public class cls_EDC_Info
    {
        public string     serial_id   { get; set; }
        public string     gateway_id  { get; set; }
        public string     device_id   { get; set; }

        public string     report_tpye     { get; set; }       //  trigger/interval
        public double     report_interval { get; set; }       //  以秒為單位 
        public DateTime   timestamp       { get; set; }

        public string     ReportEDCPath   { get; set; }
        public bool       enable          { get; set; }

        //------ 設定 使用 ----- item 1 report EDC item name   items2 device tag class name;
        public List<Tuple<string, string>> tag_info = new List<Tuple<string, string>>();
        public List<Tuple<string, string>> calc_tag_info = new List<Tuple<string, string>>();
        public List<string> interval_function = new List<string>(); //AVG, MAX, MIN

        //------ Report EDC 使用 -----
        public List<cls_EDC_Head_Item> edchead_info = new List<cls_EDC_Head_Item>();

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }

    public class EDCManager
    {
        public int serial_id_index;
        public List<cls_EDC_Info> gateway_edc = new List<cls_EDC_Info>();
        public event EventHandler eventAddEDCXml;

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public void OnAddEDCXmlEventCall(EventArgs e)
        {
            if (this.eventAddEDCXml != null)
            {
                eventAddEDCXml(this, e);
            }
        }

        public int get_last_serial_id()
        {
            return serial_id_index;
        }
    }

    public class cls_EDC_Head_Item
    {
        public string head_name { get; set; }
        public int length { get; set; }
        public string value { get; set; }
    }

    public class cls_EDC_Body_Item
    {
        public string item_name  { get; set; }
        public string item_type  { get; set; }
        public string item_value { get; set; }
    }

    public class cls_EDC_Header
    {
        public string set_name;
        public string set_description;
        public List<cls_EDC_Head_Item> head_set = new List<cls_EDC_Head_Item>();
    }

    public class EDCHeaderSet
    {
        public List<cls_EDC_Header> head_set_list = new List<cls_EDC_Header>();
        public event EventHandler eventAddHeaderSet;

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public void OnAddHeaderSetEventCall(EventArgs e)
        {
            if (this.eventAddHeaderSet != null)
            {
                eventAddHeaderSet(this, e);
            }
        }
    }
}
