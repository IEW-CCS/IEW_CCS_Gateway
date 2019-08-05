using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Common;

namespace IEW.ObjectManager.Models
{
    
    public class IOT_DbContext : DbContext
    {

        static DbConnection CreateDbConnection(string providerName, string connectionString)
        {
            // Assume failure.
            DbConnection connection = null;

            // Create the DbProviderFactory and DbConnection.
            if (connectionString != null)
            {
                try
                {
                    DbProviderFactory factory =
                        DbProviderFactories.GetFactory(providerName);

                    connection = factory.CreateConnection();
                    connection.ConnectionString = connectionString;
                }
                catch (Exception ex)
                {
                    // Set the connection to null if it was created.
                    if (connection != null)
                    {
                        connection = null;
                    }
                    Console.WriteLine(ex.Message);
                }
            }
            // Return the connection.
            return connection;
        }

        // Constructor 
        public IOT_DbContext(string provider, string connectstring) : base(CreateDbConnection(provider, connectstring), true)
        {
        }

      
        public DbSet<IOT_ALERT> IOT_ALERT { get; set; }
        public DbSet<IOT_DEVICE> IOT_DEVICE { get; set; }
        public DbSet<IOT_DEVICE_TYPE> IOT_DEVICE_TYPE { get; set; }
        public DbSet<IOT_DEVICE_SPEC> IOT_DEVICE_SPEC { get; set; }
        public DbSet<IOT_LOCATION> IOT_LOCATION { get; set; }
        public DbSet<IOT_EDC_GLS_INFO> IOT_EDC_GLS_INFO { get; set; }
        public DbSet<IOT_GATEWAY> IOT_GATEWAY { get; set; }
        public DbSet<IOT_TAG_SET> IOT_TAG_SET { get; set; }
        public DbSet<IOT_DEVICE_TAG> IOT_DEVICE_TAG { get; set; }
        public DbSet<IOT_DEVICE_CALC_TAG> IOT_DEVICE_CALC_TAG { get; set; }
        public DbSet<IOT_TAG> IOT_TAG { get; set; }
        public DbSet<IOT_CALC_TAG> IOT_CALC_TAG { get; set; }
        public DbSet<IOT_EDC_HEADER_SET> IOT_EDC_HEADER_SET { get; set; }
        public DbSet<IOT_EDC_HEADER> IOT_EDC_HEADER { get; set; }
        public DbSet<IOT_EDC_XML_CONF> IOT_EDC_XML_CONF { get; set; }
        public DbSet<IOT_STATUS_MONITOR> IOT_STATUS_MONITOR { get; set; }
        
        public DbSet<IOT_DEVICE_EDC_LABEL> IOT_DEVICE_EDC_LABEL { get; set; }
        public DbSet<IOT_DEVICE_EDC> IOT_DEVICE_EDC { get; set; }
        public DbSet<IOT_DEVICE_EDC_001> IOT_DEVICE_EDC_001 { get; set; }
        public DbSet<IOT_DEVICE_EDC_002> IOT_DEVICE_EDC_002 { get; set; }
        public DbSet<IOT_DEVICE_EDC_003> IOT_DEVICE_EDC_003 { get; set; }
        public DbSet<IOT_DEVICE_EDC_004> IOT_DEVICE_EDC_004 { get; set; }
        public DbSet<IOT_DEVICE_EDC_005> IOT_DEVICE_EDC_005 { get; set; }
        public DbSet<IOT_DEVICE_EDC_006> IOT_DEVICE_EDC_006 { get; set; }
        public DbSet<IOT_DEVICE_EDC_007> IOT_DEVICE_EDC_007 { get; set; }
        public DbSet<IOT_DEVICE_EDC_008> IOT_DEVICE_EDC_008 { get; set; }
        public DbSet<IOT_DEVICE_EDC_009> IOT_DEVICE_EDC_009 { get; set; }
        public DbSet<IOT_DEVICE_EDC_010> IOT_DEVICE_EDC_010 { get; set; }
        public DbSet<IOT_DEVICE_EDC_011> IOT_DEVICE_EDC_011 { get; set; }
        public DbSet<IOT_DEVICE_EDC_012> IOT_DEVICE_EDC_012 { get; set; }
        public DbSet<IOT_DEVICE_EDC_013> IOT_DEVICE_EDC_013 { get; set; }
        public DbSet<IOT_DEVICE_EDC_014> IOT_DEVICE_EDC_014 { get; set; }
        public DbSet<IOT_DEVICE_EDC_015> IOT_DEVICE_EDC_015 { get; set; }
        public DbSet<IOT_DEVICE_EDC_016> IOT_DEVICE_EDC_016 { get; set; }
        public DbSet<IOT_DEVICE_EDC_017> IOT_DEVICE_EDC_017 { get; set; }
        public DbSet<IOT_DEVICE_EDC_018> IOT_DEVICE_EDC_018 { get; set; }
        public DbSet<IOT_DEVICE_EDC_019> IOT_DEVICE_EDC_019 { get; set; }
        public DbSet<IOT_DEVICE_EDC_020> IOT_DEVICE_EDC_020 { get; set; }
        public DbSet<IOT_DEVICE_EDC_021> IOT_DEVICE_EDC_021 { get; set; }
        public DbSet<IOT_DEVICE_EDC_022> IOT_DEVICE_EDC_022 { get; set; }
        public DbSet<IOT_DEVICE_EDC_023> IOT_DEVICE_EDC_023 { get; set; }
        public DbSet<IOT_DEVICE_EDC_024> IOT_DEVICE_EDC_024 { get; set; }
        public DbSet<IOT_DEVICE_EDC_025> IOT_DEVICE_EDC_025 { get; set; }
        public DbSet<IOT_DEVICE_EDC_026> IOT_DEVICE_EDC_026 { get; set; }
        public DbSet<IOT_DEVICE_EDC_027> IOT_DEVICE_EDC_027 { get; set; }
        public DbSet<IOT_DEVICE_EDC_028> IOT_DEVICE_EDC_028 { get; set; }
        public DbSet<IOT_DEVICE_EDC_029> IOT_DEVICE_EDC_029 { get; set; }
        public DbSet<IOT_DEVICE_EDC_030> IOT_DEVICE_EDC_030 { get; set; }
        public DbSet<IOT_DEVICE_EDC_031> IOT_DEVICE_EDC_031 { get; set; }
        public DbSet<IOT_DEVICE_EDC_032> IOT_DEVICE_EDC_032 { get; set; }
        public DbSet<IOT_DEVICE_EDC_033> IOT_DEVICE_EDC_033 { get; set; }
        public DbSet<IOT_DEVICE_EDC_034> IOT_DEVICE_EDC_034 { get; set; }
        public DbSet<IOT_DEVICE_EDC_035> IOT_DEVICE_EDC_035 { get; set; }
        public DbSet<IOT_DEVICE_EDC_036> IOT_DEVICE_EDC_036 { get; set; }
        public DbSet<IOT_DEVICE_EDC_037> IOT_DEVICE_EDC_037 { get; set; }
        public DbSet<IOT_DEVICE_EDC_038> IOT_DEVICE_EDC_038 { get; set; }
        public DbSet<IOT_DEVICE_EDC_039> IOT_DEVICE_EDC_039 { get; set; }
        public DbSet<IOT_DEVICE_EDC_040> IOT_DEVICE_EDC_040 { get; set; }
        public DbSet<IOT_DEVICE_EDC_041> IOT_DEVICE_EDC_041 { get; set; }
        public DbSet<IOT_DEVICE_EDC_042> IOT_DEVICE_EDC_042 { get; set; }
        public DbSet<IOT_DEVICE_EDC_043> IOT_DEVICE_EDC_043 { get; set; }
        public DbSet<IOT_DEVICE_EDC_044> IOT_DEVICE_EDC_044 { get; set; }
        public DbSet<IOT_DEVICE_EDC_045> IOT_DEVICE_EDC_045 { get; set; }
        public DbSet<IOT_DEVICE_EDC_046> IOT_DEVICE_EDC_046 { get; set; }
        public DbSet<IOT_DEVICE_EDC_047> IOT_DEVICE_EDC_047 { get; set; }
        public DbSet<IOT_DEVICE_EDC_048> IOT_DEVICE_EDC_048 { get; set; }
        public DbSet<IOT_DEVICE_EDC_049> IOT_DEVICE_EDC_049 { get; set; }
        public DbSet<IOT_DEVICE_EDC_050> IOT_DEVICE_EDC_050 { get; set; }
        public DbSet<IOT_DEVICE_EDC_051> IOT_DEVICE_EDC_051 { get; set; }
        public DbSet<IOT_DEVICE_EDC_052> IOT_DEVICE_EDC_052 { get; set; }
        public DbSet<IOT_DEVICE_EDC_053> IOT_DEVICE_EDC_053 { get; set; }
        public DbSet<IOT_DEVICE_EDC_054> IOT_DEVICE_EDC_054 { get; set; }
        public DbSet<IOT_DEVICE_EDC_055> IOT_DEVICE_EDC_055 { get; set; }
        public DbSet<IOT_DEVICE_EDC_056> IOT_DEVICE_EDC_056 { get; set; }
        public DbSet<IOT_DEVICE_EDC_057> IOT_DEVICE_EDC_057 { get; set; }
        public DbSet<IOT_DEVICE_EDC_058> IOT_DEVICE_EDC_058 { get; set; }
        public DbSet<IOT_DEVICE_EDC_059> IOT_DEVICE_EDC_059 { get; set; }
        public DbSet<IOT_DEVICE_EDC_060> IOT_DEVICE_EDC_060 { get; set; }
        public DbSet<IOT_DEVICE_EDC_061> IOT_DEVICE_EDC_061 { get; set; }
        public DbSet<IOT_DEVICE_EDC_062> IOT_DEVICE_EDC_062 { get; set; }
        public DbSet<IOT_DEVICE_EDC_063> IOT_DEVICE_EDC_063 { get; set; }
        public DbSet<IOT_DEVICE_EDC_064> IOT_DEVICE_EDC_064 { get; set; }
        public DbSet<IOT_DEVICE_EDC_065> IOT_DEVICE_EDC_065 { get; set; }
        public DbSet<IOT_DEVICE_EDC_066> IOT_DEVICE_EDC_066 { get; set; }
        public DbSet<IOT_DEVICE_EDC_067> IOT_DEVICE_EDC_067 { get; set; }
        public DbSet<IOT_DEVICE_EDC_068> IOT_DEVICE_EDC_068 { get; set; }
        public DbSet<IOT_DEVICE_EDC_069> IOT_DEVICE_EDC_069 { get; set; }
        public DbSet<IOT_DEVICE_EDC_070> IOT_DEVICE_EDC_070 { get; set; }
        public DbSet<IOT_DEVICE_EDC_071> IOT_DEVICE_EDC_071 { get; set; }
        public DbSet<IOT_DEVICE_EDC_072> IOT_DEVICE_EDC_072 { get; set; }
        public DbSet<IOT_DEVICE_EDC_073> IOT_DEVICE_EDC_073 { get; set; }
        public DbSet<IOT_DEVICE_EDC_074> IOT_DEVICE_EDC_074 { get; set; }
        public DbSet<IOT_DEVICE_EDC_075> IOT_DEVICE_EDC_075 { get; set; }
        public DbSet<IOT_DEVICE_EDC_076> IOT_DEVICE_EDC_076 { get; set; }
        public DbSet<IOT_DEVICE_EDC_077> IOT_DEVICE_EDC_077 { get; set; }
        public DbSet<IOT_DEVICE_EDC_078> IOT_DEVICE_EDC_078 { get; set; }
        public DbSet<IOT_DEVICE_EDC_079> IOT_DEVICE_EDC_079 { get; set; }
        public DbSet<IOT_DEVICE_EDC_080> IOT_DEVICE_EDC_080 { get; set; }
        public DbSet<IOT_DEVICE_EDC_081> IOT_DEVICE_EDC_081 { get; set; }
        public DbSet<IOT_DEVICE_EDC_082> IOT_DEVICE_EDC_082 { get; set; }
        public DbSet<IOT_DEVICE_EDC_083> IOT_DEVICE_EDC_083 { get; set; }
        public DbSet<IOT_DEVICE_EDC_084> IOT_DEVICE_EDC_084 { get; set; }
        public DbSet<IOT_DEVICE_EDC_085> IOT_DEVICE_EDC_085 { get; set; }
        public DbSet<IOT_DEVICE_EDC_086> IOT_DEVICE_EDC_086 { get; set; }
        public DbSet<IOT_DEVICE_EDC_087> IOT_DEVICE_EDC_087 { get; set; }
        public DbSet<IOT_DEVICE_EDC_088> IOT_DEVICE_EDC_088 { get; set; }
        public DbSet<IOT_DEVICE_EDC_089> IOT_DEVICE_EDC_089 { get; set; }
        public DbSet<IOT_DEVICE_EDC_090> IOT_DEVICE_EDC_090 { get; set; }
        public DbSet<IOT_DEVICE_EDC_091> IOT_DEVICE_EDC_091 { get; set; }
        public DbSet<IOT_DEVICE_EDC_092> IOT_DEVICE_EDC_092 { get; set; }
        public DbSet<IOT_DEVICE_EDC_093> IOT_DEVICE_EDC_093 { get; set; }
        public DbSet<IOT_DEVICE_EDC_094> IOT_DEVICE_EDC_094 { get; set; }
        public DbSet<IOT_DEVICE_EDC_095> IOT_DEVICE_EDC_095 { get; set; }
        public DbSet<IOT_DEVICE_EDC_096> IOT_DEVICE_EDC_096 { get; set; }
        public DbSet<IOT_DEVICE_EDC_097> IOT_DEVICE_EDC_097 { get; set; }
        public DbSet<IOT_DEVICE_EDC_098> IOT_DEVICE_EDC_098 { get; set; }
        public DbSet<IOT_DEVICE_EDC_099> IOT_DEVICE_EDC_099 { get; set; }
        public DbSet<IOT_DEVICE_EDC_100> IOT_DEVICE_EDC_100 { get; set; }
        public DbSet<IOT_DEVICE_EDC_101> IOT_DEVICE_EDC_101 { get; set; }
        public DbSet<IOT_DEVICE_EDC_102> IOT_DEVICE_EDC_102 { get; set; }
        public DbSet<IOT_DEVICE_EDC_103> IOT_DEVICE_EDC_103 { get; set; }
        public DbSet<IOT_DEVICE_EDC_104> IOT_DEVICE_EDC_104 { get; set; }
        public DbSet<IOT_DEVICE_EDC_105> IOT_DEVICE_EDC_105 { get; set; }
        public DbSet<IOT_DEVICE_EDC_106> IOT_DEVICE_EDC_106 { get; set; }
        public DbSet<IOT_DEVICE_EDC_107> IOT_DEVICE_EDC_107 { get; set; }
        public DbSet<IOT_DEVICE_EDC_108> IOT_DEVICE_EDC_108 { get; set; }
        public DbSet<IOT_DEVICE_EDC_109> IOT_DEVICE_EDC_109 { get; set; }
        public DbSet<IOT_DEVICE_EDC_110> IOT_DEVICE_EDC_110 { get; set; }
        public DbSet<IOT_DEVICE_EDC_111> IOT_DEVICE_EDC_111 { get; set; }
        public DbSet<IOT_DEVICE_EDC_112> IOT_DEVICE_EDC_112 { get; set; }
        public DbSet<IOT_DEVICE_EDC_113> IOT_DEVICE_EDC_113 { get; set; }
        public DbSet<IOT_DEVICE_EDC_114> IOT_DEVICE_EDC_114 { get; set; }
        public DbSet<IOT_DEVICE_EDC_115> IOT_DEVICE_EDC_115 { get; set; }
        public DbSet<IOT_DEVICE_EDC_116> IOT_DEVICE_EDC_116 { get; set; }
        public DbSet<IOT_DEVICE_EDC_117> IOT_DEVICE_EDC_117 { get; set; }
        public DbSet<IOT_DEVICE_EDC_118> IOT_DEVICE_EDC_118 { get; set; }
        public DbSet<IOT_DEVICE_EDC_119> IOT_DEVICE_EDC_119 { get; set; }
        public DbSet<IOT_DEVICE_EDC_120> IOT_DEVICE_EDC_120 { get; set; }
        public DbSet<IOT_DEVICE_EDC_121> IOT_DEVICE_EDC_121 { get; set; }
        public DbSet<IOT_DEVICE_EDC_122> IOT_DEVICE_EDC_122 { get; set; }
        public DbSet<IOT_DEVICE_EDC_123> IOT_DEVICE_EDC_123 { get; set; }
        public DbSet<IOT_DEVICE_EDC_124> IOT_DEVICE_EDC_124 { get; set; }
        public DbSet<IOT_DEVICE_EDC_125> IOT_DEVICE_EDC_125 { get; set; }
        public DbSet<IOT_DEVICE_EDC_126> IOT_DEVICE_EDC_126 { get; set; }
        public DbSet<IOT_DEVICE_EDC_127> IOT_DEVICE_EDC_127 { get; set; }
        public DbSet<IOT_DEVICE_EDC_128> IOT_DEVICE_EDC_128 { get; set; }


        public IList<IOT_DEVICE_EDC> QueryEDC_DB(IOT_DEVICE device, DateTime start_date, DateTime end_date)
        {

            IList<IOT_DEVICE_EDC> oIotDeviceEDCs = new List<IOT_DEVICE_EDC>();

            try
            {

                switch (device.device_no)
                {
                    case 1:
                        var vIoT_DeviceEDCs_001 = IOT_DEVICE_EDC_001.AsQueryable(); 
                        vIoT_DeviceEDCs_001 = vIoT_DeviceEDCs_001.Where(c => c.device_id == device.device_id && c.clm_date_time >= start_date && c.clm_date_time <= end_date);
                        vIoT_DeviceEDCs_001 = vIoT_DeviceEDCs_001.OrderBy(c => c.clm_date_time);
                        foreach (var vIoT_DeviceEDC in vIoT_DeviceEDCs_001)
                        {
                            IOT_DEVICE_EDC oIoT_DeviceEDC = new IOT_DEVICE_EDC();
                            oIoT_DeviceEDC.Clone(vIoT_DeviceEDC);
                            oIotDeviceEDCs.Add(oIoT_DeviceEDC);
                        }
                        break;
                    case 2:
                        var vIoT_DeviceEDCs_002 = IOT_DEVICE_EDC_002.AsQueryable(); 
                        vIoT_DeviceEDCs_002 = vIoT_DeviceEDCs_002.Where(c => c.device_id == device.device_id && c.clm_date_time >= start_date && c.clm_date_time <= end_date);
                        vIoT_DeviceEDCs_002 = vIoT_DeviceEDCs_002.OrderBy(c => c.clm_date_time);
                        foreach (var vIoT_DeviceEDC in vIoT_DeviceEDCs_002)
                        {
                            IOT_DEVICE_EDC oIoT_DeviceEDC = new IOT_DEVICE_EDC();
                            oIoT_DeviceEDC.Clone(vIoT_DeviceEDC);
                            oIotDeviceEDCs.Add(oIoT_DeviceEDC);
                        }

                        break;

                    case 3:
                        var vIoT_DeviceEDCs_003 = IOT_DEVICE_EDC_003.AsQueryable(); 
                        vIoT_DeviceEDCs_003 = vIoT_DeviceEDCs_003.Where(c => c.device_id == device.device_id && c.clm_date_time >= start_date && c.clm_date_time <= end_date);
                        vIoT_DeviceEDCs_003 = vIoT_DeviceEDCs_003.OrderBy(c => c.clm_date_time);
                        foreach (var vIoT_DeviceEDC in vIoT_DeviceEDCs_003)
                        {
                            IOT_DEVICE_EDC oIoT_DeviceEDC = new IOT_DEVICE_EDC();
                            oIoT_DeviceEDC.Clone(vIoT_DeviceEDC);
                            oIotDeviceEDCs.Add(oIoT_DeviceEDC);
                        }
                        break;

                    case 4:
                        var vIoT_DeviceEDCs_004 = IOT_DEVICE_EDC_004.AsQueryable(); 
                        vIoT_DeviceEDCs_004 = vIoT_DeviceEDCs_004.Where(c => c.device_id == device.device_id && c.clm_date_time >= start_date && c.clm_date_time <= end_date);
                        vIoT_DeviceEDCs_004 = vIoT_DeviceEDCs_004.OrderBy(c => c.clm_date_time);
                        foreach (var vIoT_DeviceEDC in vIoT_DeviceEDCs_004)
                        {
                            IOT_DEVICE_EDC oIoT_DeviceEDC = new IOT_DEVICE_EDC();
                            oIoT_DeviceEDC.Clone(vIoT_DeviceEDC);
                            oIotDeviceEDCs.Add(oIoT_DeviceEDC);
                        }
                        break;

                    case 5:
                        var vIoT_DeviceEDCs_005 = IOT_DEVICE_EDC_005.AsQueryable(); 
                        vIoT_DeviceEDCs_005 = vIoT_DeviceEDCs_005.Where(c => c.device_id == device.device_id && c.clm_date_time >= start_date && c.clm_date_time <= end_date);
                        vIoT_DeviceEDCs_005 = vIoT_DeviceEDCs_005.OrderBy(c => c.clm_date_time);
                        foreach (var vIoT_DeviceEDC in vIoT_DeviceEDCs_005)
                        {
                            IOT_DEVICE_EDC oIoT_DeviceEDC = new IOT_DEVICE_EDC();
                            oIoT_DeviceEDC.Clone(vIoT_DeviceEDC);
                            oIotDeviceEDCs.Add(oIoT_DeviceEDC);
                        }
                        break;

                    case 6:
                        var vIoT_DeviceEDCs_006 = IOT_DEVICE_EDC_006.AsQueryable(); 
                        vIoT_DeviceEDCs_006 = vIoT_DeviceEDCs_006.Where(c => c.device_id == device.device_id && c.clm_date_time >= start_date && c.clm_date_time <= end_date);
                        vIoT_DeviceEDCs_006 = vIoT_DeviceEDCs_006.OrderBy(c => c.clm_date_time);
                        foreach (var vIoT_DeviceEDC in vIoT_DeviceEDCs_006)
                        {
                            IOT_DEVICE_EDC oIoT_DeviceEDC = new IOT_DEVICE_EDC();
                            oIoT_DeviceEDC.Clone(vIoT_DeviceEDC);
                            oIotDeviceEDCs.Add(oIoT_DeviceEDC);
                        }
                        break;

                    case 7:
                        var vIoT_DeviceEDCs_007 = IOT_DEVICE_EDC_007.AsQueryable(); 
                        vIoT_DeviceEDCs_007 = vIoT_DeviceEDCs_007.Where(c => c.device_id == device.device_id && c.clm_date_time >= start_date && c.clm_date_time <= end_date);
                        vIoT_DeviceEDCs_007 = vIoT_DeviceEDCs_007.OrderBy(c => c.clm_date_time);
                        foreach (var vIoT_DeviceEDC in vIoT_DeviceEDCs_007)
                        {
                            IOT_DEVICE_EDC oIoT_DeviceEDC = new IOT_DEVICE_EDC();
                            oIoT_DeviceEDC.Clone(vIoT_DeviceEDC);
                            oIotDeviceEDCs.Add(oIoT_DeviceEDC);
                        }
                        break;

                    case 8:
                        var vIoT_DeviceEDCs_008 = IOT_DEVICE_EDC_008.AsQueryable(); 
                        vIoT_DeviceEDCs_008 = vIoT_DeviceEDCs_008.Where(c => c.device_id == device.device_id && c.clm_date_time >= start_date && c.clm_date_time <= end_date);
                        vIoT_DeviceEDCs_008 = vIoT_DeviceEDCs_008.OrderBy(c => c.clm_date_time);
                        foreach (var vIoT_DeviceEDC in vIoT_DeviceEDCs_008)
                        {
                            IOT_DEVICE_EDC oIoT_DeviceEDC = new IOT_DEVICE_EDC();
                            oIoT_DeviceEDC.Clone(vIoT_DeviceEDC);
                            oIotDeviceEDCs.Add(oIoT_DeviceEDC);
                        }
                        break;

                    case 9:
                        var vIoT_DeviceEDCs_009 = IOT_DEVICE_EDC_009.AsQueryable();
                        vIoT_DeviceEDCs_009 = vIoT_DeviceEDCs_009.Where(c => c.device_id == device.device_id && c.clm_date_time >= start_date && c.clm_date_time <= end_date);
                        vIoT_DeviceEDCs_009 = vIoT_DeviceEDCs_009.OrderBy(c => c.clm_date_time);
                        foreach (var vIoT_DeviceEDC in vIoT_DeviceEDCs_009)
                        {
                            IOT_DEVICE_EDC oIoT_DeviceEDC = new IOT_DEVICE_EDC();
                            oIoT_DeviceEDC.Clone(vIoT_DeviceEDC);
                            oIotDeviceEDCs.Add(oIoT_DeviceEDC);
                        }
                        break;
                    case 10:
                        var vIoT_DeviceEDCs_010 = IOT_DEVICE_EDC_010.AsQueryable();
                        vIoT_DeviceEDCs_010 = vIoT_DeviceEDCs_010.Where(c => c.device_id == device.device_id && c.clm_date_time >= start_date && c.clm_date_time <= end_date);
                        vIoT_DeviceEDCs_010 = vIoT_DeviceEDCs_010.OrderBy(c => c.clm_date_time);
                        foreach (var vIoT_DeviceEDC in vIoT_DeviceEDCs_010)
                        {
                            IOT_DEVICE_EDC oIoT_DeviceEDC = new IOT_DEVICE_EDC();
                            oIoT_DeviceEDC.Clone(vIoT_DeviceEDC);
                            oIotDeviceEDCs.Add(oIoT_DeviceEDC);
                        }
                        break;

                    case 11:
                        var vIoT_DeviceEDCs_011 = IOT_DEVICE_EDC_011.AsQueryable();
                        vIoT_DeviceEDCs_011 = vIoT_DeviceEDCs_011.Where(c => c.device_id == device.device_id && c.clm_date_time >= start_date && c.clm_date_time <= end_date);
                        vIoT_DeviceEDCs_011 = vIoT_DeviceEDCs_011.OrderBy(c => c.clm_date_time);
                        foreach (var vIoT_DeviceEDC in vIoT_DeviceEDCs_011)
                        {
                            IOT_DEVICE_EDC oIoT_DeviceEDC = new IOT_DEVICE_EDC();
                            oIoT_DeviceEDC.Clone(vIoT_DeviceEDC);
                            oIotDeviceEDCs.Add(oIoT_DeviceEDC);
                        }
                        break;
                    case 12:
                        var vIoT_DeviceEDCs_012 = IOT_DEVICE_EDC_012.AsQueryable();
                        vIoT_DeviceEDCs_012 = vIoT_DeviceEDCs_012.Where(c => c.device_id == device.device_id && c.clm_date_time >= start_date && c.clm_date_time <= end_date);
                        vIoT_DeviceEDCs_012 = vIoT_DeviceEDCs_012.OrderBy(c => c.clm_date_time);
                        foreach (var vIoT_DeviceEDC in vIoT_DeviceEDCs_012)
                        {
                            IOT_DEVICE_EDC oIoT_DeviceEDC = new IOT_DEVICE_EDC();
                            oIoT_DeviceEDC.Clone(vIoT_DeviceEDC);
                            oIotDeviceEDCs.Add(oIoT_DeviceEDC);
                        }

                        break;

                    case 13:
                        var vIoT_DeviceEDCs_013 = IOT_DEVICE_EDC_013.AsQueryable();
                        vIoT_DeviceEDCs_013 = vIoT_DeviceEDCs_013.Where(c => c.device_id == device.device_id && c.clm_date_time >= start_date && c.clm_date_time <= end_date);
                        vIoT_DeviceEDCs_013 = vIoT_DeviceEDCs_013.OrderBy(c => c.clm_date_time);
                        foreach (var vIoT_DeviceEDC in vIoT_DeviceEDCs_013)
                        {
                            IOT_DEVICE_EDC oIoT_DeviceEDC = new IOT_DEVICE_EDC();
                            oIoT_DeviceEDC.Clone(vIoT_DeviceEDC);
                            oIotDeviceEDCs.Add(oIoT_DeviceEDC);
                        }
                        break;

                    case 14:
                        var vIoT_DeviceEDCs_014 = IOT_DEVICE_EDC_014.AsQueryable();
                        vIoT_DeviceEDCs_014 = vIoT_DeviceEDCs_014.Where(c => c.device_id == device.device_id && c.clm_date_time >= start_date && c.clm_date_time <= end_date);
                        vIoT_DeviceEDCs_014 = vIoT_DeviceEDCs_014.OrderBy(c => c.clm_date_time);
                        foreach (var vIoT_DeviceEDC in vIoT_DeviceEDCs_014)
                        {
                            IOT_DEVICE_EDC oIoT_DeviceEDC = new IOT_DEVICE_EDC();
                            oIoT_DeviceEDC.Clone(vIoT_DeviceEDC);
                            oIotDeviceEDCs.Add(oIoT_DeviceEDC);
                        }
                        break;

                    case 15:
                        var vIoT_DeviceEDCs_015 = IOT_DEVICE_EDC_015.AsQueryable();
                        vIoT_DeviceEDCs_015 = vIoT_DeviceEDCs_015.Where(c => c.device_id == device.device_id && c.clm_date_time >= start_date && c.clm_date_time <= end_date);
                        vIoT_DeviceEDCs_015 = vIoT_DeviceEDCs_015.OrderBy(c => c.clm_date_time);
                        foreach (var vIoT_DeviceEDC in vIoT_DeviceEDCs_015)
                        {
                            IOT_DEVICE_EDC oIoT_DeviceEDC = new IOT_DEVICE_EDC();
                            oIoT_DeviceEDC.Clone(vIoT_DeviceEDC);
                            oIotDeviceEDCs.Add(oIoT_DeviceEDC);
                        }
                        break;

                    case 16:
                        var vIoT_DeviceEDCs_016 = IOT_DEVICE_EDC_016.AsQueryable();
                        vIoT_DeviceEDCs_016 = vIoT_DeviceEDCs_016.Where(c => c.device_id == device.device_id && c.clm_date_time >= start_date && c.clm_date_time <= end_date);
                        vIoT_DeviceEDCs_016 = vIoT_DeviceEDCs_016.OrderBy(c => c.clm_date_time);
                        foreach (var vIoT_DeviceEDC in vIoT_DeviceEDCs_016)
                        {
                            IOT_DEVICE_EDC oIoT_DeviceEDC = new IOT_DEVICE_EDC();
                            oIoT_DeviceEDC.Clone(vIoT_DeviceEDC);
                            oIotDeviceEDCs.Add(oIoT_DeviceEDC);
                        }
                        break;

                    case 17:
                        var vIoT_DeviceEDCs_017 = IOT_DEVICE_EDC_017.AsQueryable();
                        vIoT_DeviceEDCs_017 = vIoT_DeviceEDCs_017.Where(c => c.device_id == device.device_id && c.clm_date_time >= start_date && c.clm_date_time <= end_date);
                        vIoT_DeviceEDCs_017 = vIoT_DeviceEDCs_017.OrderBy(c => c.clm_date_time);
                        foreach (var vIoT_DeviceEDC in vIoT_DeviceEDCs_017)
                        {
                            IOT_DEVICE_EDC oIoT_DeviceEDC = new IOT_DEVICE_EDC();
                            oIoT_DeviceEDC.Clone(vIoT_DeviceEDC);
                            oIotDeviceEDCs.Add(oIoT_DeviceEDC);
                        }
                        break;

                    case 18:
                        var vIoT_DeviceEDCs_018 = IOT_DEVICE_EDC_018.AsQueryable();
                        vIoT_DeviceEDCs_018 = vIoT_DeviceEDCs_018.Where(c => c.device_id == device.device_id && c.clm_date_time >= start_date && c.clm_date_time <= end_date);
                        vIoT_DeviceEDCs_018 = vIoT_DeviceEDCs_018.OrderBy(c => c.clm_date_time);
                        foreach (var vIoT_DeviceEDC in vIoT_DeviceEDCs_018)
                        {
                            IOT_DEVICE_EDC oIoT_DeviceEDC = new IOT_DEVICE_EDC();
                            oIoT_DeviceEDC.Clone(vIoT_DeviceEDC);
                            oIotDeviceEDCs.Add(oIoT_DeviceEDC);
                        }
                        break;

                    case 19:
                        var vIoT_DeviceEDCs_019 = IOT_DEVICE_EDC_019.AsQueryable();
                        vIoT_DeviceEDCs_019 = vIoT_DeviceEDCs_019.Where(c => c.device_id == device.device_id && c.clm_date_time >= start_date && c.clm_date_time <= end_date);
                        vIoT_DeviceEDCs_019 = vIoT_DeviceEDCs_019.OrderBy(c => c.clm_date_time);
                        foreach (var vIoT_DeviceEDC in vIoT_DeviceEDCs_019)
                        {
                            IOT_DEVICE_EDC oIoT_DeviceEDC = new IOT_DEVICE_EDC();
                            oIoT_DeviceEDC.Clone(vIoT_DeviceEDC);
                            oIotDeviceEDCs.Add(oIoT_DeviceEDC);
                        }
                        break;
                    case 20:
                        var vIoT_DeviceEDCs_020 = IOT_DEVICE_EDC_020.AsQueryable();
                        vIoT_DeviceEDCs_020 = vIoT_DeviceEDCs_020.Where(c => c.device_id == device.device_id && c.clm_date_time >= start_date && c.clm_date_time <= end_date);
                        vIoT_DeviceEDCs_020 = vIoT_DeviceEDCs_020.OrderBy(c => c.clm_date_time);
                        foreach (var vIoT_DeviceEDC in vIoT_DeviceEDCs_020)
                        {
                            IOT_DEVICE_EDC oIoT_DeviceEDC = new IOT_DEVICE_EDC();
                            oIoT_DeviceEDC.Clone(vIoT_DeviceEDC);
                            oIotDeviceEDCs.Add(oIoT_DeviceEDC);
                        }
                        break;

                    case 21:
                        var vIoT_DeviceEDCs_021 = IOT_DEVICE_EDC_021.AsQueryable();
                        vIoT_DeviceEDCs_021 = vIoT_DeviceEDCs_021.Where(c => c.device_id == device.device_id && c.clm_date_time >= start_date && c.clm_date_time <= end_date);
                        vIoT_DeviceEDCs_021 = vIoT_DeviceEDCs_021.OrderBy(c => c.clm_date_time);
                        foreach (var vIoT_DeviceEDC in vIoT_DeviceEDCs_021)
                        {
                            IOT_DEVICE_EDC oIoT_DeviceEDC = new IOT_DEVICE_EDC();
                            oIoT_DeviceEDC.Clone(vIoT_DeviceEDC);
                            oIotDeviceEDCs.Add(oIoT_DeviceEDC);
                        }
                        break;
                    case 22:
                        var vIoT_DeviceEDCs_022 = IOT_DEVICE_EDC_022.AsQueryable();
                        vIoT_DeviceEDCs_022 = vIoT_DeviceEDCs_022.Where(c => c.device_id == device.device_id && c.clm_date_time >= start_date && c.clm_date_time <= end_date);
                        vIoT_DeviceEDCs_022 = vIoT_DeviceEDCs_022.OrderBy(c => c.clm_date_time);
                        foreach (var vIoT_DeviceEDC in vIoT_DeviceEDCs_022)
                        {
                            IOT_DEVICE_EDC oIoT_DeviceEDC = new IOT_DEVICE_EDC();
                            oIoT_DeviceEDC.Clone(vIoT_DeviceEDC);
                            oIotDeviceEDCs.Add(oIoT_DeviceEDC);
                        }

                        break;

                    case 23:
                        var vIoT_DeviceEDCs_023 = IOT_DEVICE_EDC_023.AsQueryable();
                        vIoT_DeviceEDCs_023 = vIoT_DeviceEDCs_023.Where(c => c.device_id == device.device_id && c.clm_date_time >= start_date && c.clm_date_time <= end_date);
                        vIoT_DeviceEDCs_023 = vIoT_DeviceEDCs_023.OrderBy(c => c.clm_date_time);
                        foreach (var vIoT_DeviceEDC in vIoT_DeviceEDCs_023)
                        {
                            IOT_DEVICE_EDC oIoT_DeviceEDC = new IOT_DEVICE_EDC();
                            oIoT_DeviceEDC.Clone(vIoT_DeviceEDC);
                            oIotDeviceEDCs.Add(oIoT_DeviceEDC);
                        }
                        break;

                    case 24:
                        var vIoT_DeviceEDCs_024 = IOT_DEVICE_EDC_024.AsQueryable();
                        vIoT_DeviceEDCs_024 = vIoT_DeviceEDCs_024.Where(c => c.device_id == device.device_id && c.clm_date_time >= start_date && c.clm_date_time <= end_date);
                        vIoT_DeviceEDCs_024 = vIoT_DeviceEDCs_024.OrderBy(c => c.clm_date_time);
                        foreach (var vIoT_DeviceEDC in vIoT_DeviceEDCs_024)
                        {
                            IOT_DEVICE_EDC oIoT_DeviceEDC = new IOT_DEVICE_EDC();
                            oIoT_DeviceEDC.Clone(vIoT_DeviceEDC);
                            oIotDeviceEDCs.Add(oIoT_DeviceEDC);
                        }
                        break;

                    case 25:
                        var vIoT_DeviceEDCs_025 = IOT_DEVICE_EDC_025.AsQueryable();
                        vIoT_DeviceEDCs_025 = vIoT_DeviceEDCs_025.Where(c => c.device_id == device.device_id && c.clm_date_time >= start_date && c.clm_date_time <= end_date);
                        vIoT_DeviceEDCs_025 = vIoT_DeviceEDCs_025.OrderBy(c => c.clm_date_time);
                        foreach (var vIoT_DeviceEDC in vIoT_DeviceEDCs_025)
                        {
                            IOT_DEVICE_EDC oIoT_DeviceEDC = new IOT_DEVICE_EDC();
                            oIoT_DeviceEDC.Clone(vIoT_DeviceEDC);
                            oIotDeviceEDCs.Add(oIoT_DeviceEDC);
                        }
                        break;

                    case 26:
                        var vIoT_DeviceEDCs_026 = IOT_DEVICE_EDC_026.AsQueryable();
                        vIoT_DeviceEDCs_026 = vIoT_DeviceEDCs_026.Where(c => c.device_id == device.device_id && c.clm_date_time >= start_date && c.clm_date_time <= end_date);
                        vIoT_DeviceEDCs_026 = vIoT_DeviceEDCs_026.OrderBy(c => c.clm_date_time);
                        foreach (var vIoT_DeviceEDC in vIoT_DeviceEDCs_026)
                        {
                            IOT_DEVICE_EDC oIoT_DeviceEDC = new IOT_DEVICE_EDC();
                            oIoT_DeviceEDC.Clone(vIoT_DeviceEDC);
                            oIotDeviceEDCs.Add(oIoT_DeviceEDC);
                        }
                        break;

                    case 27:
                        var vIoT_DeviceEDCs_027 = IOT_DEVICE_EDC_027.AsQueryable();
                        vIoT_DeviceEDCs_027 = vIoT_DeviceEDCs_027.Where(c => c.device_id == device.device_id && c.clm_date_time >= start_date && c.clm_date_time <= end_date);
                        vIoT_DeviceEDCs_027 = vIoT_DeviceEDCs_027.OrderBy(c => c.clm_date_time);
                        foreach (var vIoT_DeviceEDC in vIoT_DeviceEDCs_027)
                        {
                            IOT_DEVICE_EDC oIoT_DeviceEDC = new IOT_DEVICE_EDC();
                            oIoT_DeviceEDC.Clone(vIoT_DeviceEDC);
                            oIotDeviceEDCs.Add(oIoT_DeviceEDC);
                        }
                        break;

                    case 28:
                        var vIoT_DeviceEDCs_028 = IOT_DEVICE_EDC_028.AsQueryable();
                        vIoT_DeviceEDCs_028 = vIoT_DeviceEDCs_028.Where(c => c.device_id == device.device_id && c.clm_date_time >= start_date && c.clm_date_time <= end_date);
                        vIoT_DeviceEDCs_028 = vIoT_DeviceEDCs_028.OrderBy(c => c.clm_date_time);
                        foreach (var vIoT_DeviceEDC in vIoT_DeviceEDCs_028)
                        {
                            IOT_DEVICE_EDC oIoT_DeviceEDC = new IOT_DEVICE_EDC();
                            oIoT_DeviceEDC.Clone(vIoT_DeviceEDC);
                            oIotDeviceEDCs.Add(oIoT_DeviceEDC);
                        }
                        break;

                    case 29:
                        var vIoT_DeviceEDCs_029 = IOT_DEVICE_EDC_029.AsQueryable();
                        vIoT_DeviceEDCs_029 = vIoT_DeviceEDCs_029.Where(c => c.device_id == device.device_id && c.clm_date_time >= start_date && c.clm_date_time <= end_date);
                        vIoT_DeviceEDCs_029 = vIoT_DeviceEDCs_029.OrderBy(c => c.clm_date_time);
                        foreach (var vIoT_DeviceEDC in vIoT_DeviceEDCs_029)
                        {
                            IOT_DEVICE_EDC oIoT_DeviceEDC = new IOT_DEVICE_EDC();
                            oIoT_DeviceEDC.Clone(vIoT_DeviceEDC);
                            oIotDeviceEDCs.Add(oIoT_DeviceEDC);
                        }
                        break;
                    case 30:
                        var vIoT_DeviceEDCs_030 = IOT_DEVICE_EDC_030.AsQueryable();
                        vIoT_DeviceEDCs_030 = vIoT_DeviceEDCs_030.Where(c => c.device_id == device.device_id && c.clm_date_time >= start_date && c.clm_date_time <= end_date);
                        vIoT_DeviceEDCs_030 = vIoT_DeviceEDCs_030.OrderBy(c => c.clm_date_time);
                        foreach (var vIoT_DeviceEDC in vIoT_DeviceEDCs_030)
                        {
                            IOT_DEVICE_EDC oIoT_DeviceEDC = new IOT_DEVICE_EDC();
                            oIoT_DeviceEDC.Clone(vIoT_DeviceEDC);
                            oIotDeviceEDCs.Add(oIoT_DeviceEDC);
                        }
                        break;

                    case 31:
                        var vIoT_DeviceEDCs_031 = IOT_DEVICE_EDC_031.AsQueryable();
                        vIoT_DeviceEDCs_031 = vIoT_DeviceEDCs_031.Where(c => c.device_id == device.device_id && c.clm_date_time >= start_date && c.clm_date_time <= end_date);
                        vIoT_DeviceEDCs_031 = vIoT_DeviceEDCs_031.OrderBy(c => c.clm_date_time);
                        foreach (var vIoT_DeviceEDC in vIoT_DeviceEDCs_031)
                        {
                            IOT_DEVICE_EDC oIoT_DeviceEDC = new IOT_DEVICE_EDC();
                            oIoT_DeviceEDC.Clone(vIoT_DeviceEDC);
                            oIotDeviceEDCs.Add(oIoT_DeviceEDC);
                        }
                        break;
                    case 32:
                        var vIoT_DeviceEDCs_032 = IOT_DEVICE_EDC_032.AsQueryable();
                        vIoT_DeviceEDCs_032 = vIoT_DeviceEDCs_032.Where(c => c.device_id == device.device_id && c.clm_date_time >= start_date && c.clm_date_time <= end_date);
                        vIoT_DeviceEDCs_032 = vIoT_DeviceEDCs_032.OrderBy(c => c.clm_date_time);
                        foreach (var vIoT_DeviceEDC in vIoT_DeviceEDCs_032)
                        {
                            IOT_DEVICE_EDC oIoT_DeviceEDC = new IOT_DEVICE_EDC();
                            oIoT_DeviceEDC.Clone(vIoT_DeviceEDC);
                            oIotDeviceEDCs.Add(oIoT_DeviceEDC);
                        }

                        break;

                    case 33:
                        var vIoT_DeviceEDCs_033 = IOT_DEVICE_EDC_033.AsQueryable();
                        vIoT_DeviceEDCs_033 = vIoT_DeviceEDCs_033.Where(c => c.device_id == device.device_id && c.clm_date_time >= start_date && c.clm_date_time <= end_date);
                        vIoT_DeviceEDCs_033 = vIoT_DeviceEDCs_033.OrderBy(c => c.clm_date_time);
                        foreach (var vIoT_DeviceEDC in vIoT_DeviceEDCs_033)
                        {
                            IOT_DEVICE_EDC oIoT_DeviceEDC = new IOT_DEVICE_EDC();
                            oIoT_DeviceEDC.Clone(vIoT_DeviceEDC);
                            oIotDeviceEDCs.Add(oIoT_DeviceEDC);
                        }
                        break;

                    case 34:
                        var vIoT_DeviceEDCs_034 = IOT_DEVICE_EDC_034.AsQueryable();
                        vIoT_DeviceEDCs_034 = vIoT_DeviceEDCs_034.Where(c => c.device_id == device.device_id && c.clm_date_time >= start_date && c.clm_date_time <= end_date);
                        vIoT_DeviceEDCs_034 = vIoT_DeviceEDCs_034.OrderBy(c => c.clm_date_time);
                        foreach (var vIoT_DeviceEDC in vIoT_DeviceEDCs_034)
                        {
                            IOT_DEVICE_EDC oIoT_DeviceEDC = new IOT_DEVICE_EDC();
                            oIoT_DeviceEDC.Clone(vIoT_DeviceEDC);
                            oIotDeviceEDCs.Add(oIoT_DeviceEDC);
                        }
                        break;

                    case 35:
                        var vIoT_DeviceEDCs_035 = IOT_DEVICE_EDC_035.AsQueryable();
                        vIoT_DeviceEDCs_035 = vIoT_DeviceEDCs_035.Where(c => c.device_id == device.device_id && c.clm_date_time >= start_date && c.clm_date_time <= end_date);
                        vIoT_DeviceEDCs_035 = vIoT_DeviceEDCs_035.OrderBy(c => c.clm_date_time);
                        foreach (var vIoT_DeviceEDC in vIoT_DeviceEDCs_035)
                        {
                            IOT_DEVICE_EDC oIoT_DeviceEDC = new IOT_DEVICE_EDC();
                            oIoT_DeviceEDC.Clone(vIoT_DeviceEDC);
                            oIotDeviceEDCs.Add(oIoT_DeviceEDC);
                        }
                        break;

                    case 36:
                        var vIoT_DeviceEDCs_036 = IOT_DEVICE_EDC_036.AsQueryable();
                        vIoT_DeviceEDCs_036 = vIoT_DeviceEDCs_036.Where(c => c.device_id == device.device_id && c.clm_date_time >= start_date && c.clm_date_time <= end_date);
                        vIoT_DeviceEDCs_036 = vIoT_DeviceEDCs_036.OrderBy(c => c.clm_date_time);
                        foreach (var vIoT_DeviceEDC in vIoT_DeviceEDCs_036)
                        {
                            IOT_DEVICE_EDC oIoT_DeviceEDC = new IOT_DEVICE_EDC();
                            oIoT_DeviceEDC.Clone(vIoT_DeviceEDC);
                            oIotDeviceEDCs.Add(oIoT_DeviceEDC);
                        }
                        break;

                    case 37:
                        var vIoT_DeviceEDCs_037 = IOT_DEVICE_EDC_037.AsQueryable();
                        vIoT_DeviceEDCs_037 = vIoT_DeviceEDCs_037.Where(c => c.device_id == device.device_id && c.clm_date_time >= start_date && c.clm_date_time <= end_date);
                        vIoT_DeviceEDCs_037 = vIoT_DeviceEDCs_037.OrderBy(c => c.clm_date_time);
                        foreach (var vIoT_DeviceEDC in vIoT_DeviceEDCs_037)
                        {
                            IOT_DEVICE_EDC oIoT_DeviceEDC = new IOT_DEVICE_EDC();
                            oIoT_DeviceEDC.Clone(vIoT_DeviceEDC);
                            oIotDeviceEDCs.Add(oIoT_DeviceEDC);
                        }
                        break;

                    case 38:
                        var vIoT_DeviceEDCs_038 = IOT_DEVICE_EDC_038.AsQueryable();
                        vIoT_DeviceEDCs_038 = vIoT_DeviceEDCs_038.Where(c => c.device_id == device.device_id && c.clm_date_time >= start_date && c.clm_date_time <= end_date);
                        vIoT_DeviceEDCs_038 = vIoT_DeviceEDCs_038.OrderBy(c => c.clm_date_time);
                        foreach (var vIoT_DeviceEDC in vIoT_DeviceEDCs_038)
                        {
                            IOT_DEVICE_EDC oIoT_DeviceEDC = new IOT_DEVICE_EDC();
                            oIoT_DeviceEDC.Clone(vIoT_DeviceEDC);
                            oIotDeviceEDCs.Add(oIoT_DeviceEDC);
                        }
                        break;

                    case 39:
                        var vIoT_DeviceEDCs_039 = IOT_DEVICE_EDC_039.AsQueryable();
                        vIoT_DeviceEDCs_039 = vIoT_DeviceEDCs_039.Where(c => c.device_id == device.device_id && c.clm_date_time >= start_date && c.clm_date_time <= end_date);
                        vIoT_DeviceEDCs_039 = vIoT_DeviceEDCs_039.OrderBy(c => c.clm_date_time);
                        foreach (var vIoT_DeviceEDC in vIoT_DeviceEDCs_039)
                        {
                            IOT_DEVICE_EDC oIoT_DeviceEDC = new IOT_DEVICE_EDC();
                            oIoT_DeviceEDC.Clone(vIoT_DeviceEDC);
                            oIotDeviceEDCs.Add(oIoT_DeviceEDC);
                        }
                        break;
                    case 40:
                        var vIoT_DeviceEDCs_040 = IOT_DEVICE_EDC_040.AsQueryable();
                        vIoT_DeviceEDCs_040 = vIoT_DeviceEDCs_040.Where(c => c.device_id == device.device_id && c.clm_date_time >= start_date && c.clm_date_time <= end_date);
                        vIoT_DeviceEDCs_040 = vIoT_DeviceEDCs_040.OrderBy(c => c.clm_date_time);
                        foreach (var vIoT_DeviceEDC in vIoT_DeviceEDCs_040)
                        {
                            IOT_DEVICE_EDC oIoT_DeviceEDC = new IOT_DEVICE_EDC();
                            oIoT_DeviceEDC.Clone(vIoT_DeviceEDC);
                            oIotDeviceEDCs.Add(oIoT_DeviceEDC);
                        }
                        break;

                    case 41:
                        var vIoT_DeviceEDCs_041 = IOT_DEVICE_EDC_041.AsQueryable();
                        vIoT_DeviceEDCs_041 = vIoT_DeviceEDCs_041.Where(c => c.device_id == device.device_id && c.clm_date_time >= start_date && c.clm_date_time <= end_date);
                        vIoT_DeviceEDCs_041 = vIoT_DeviceEDCs_041.OrderBy(c => c.clm_date_time);
                        foreach (var vIoT_DeviceEDC in vIoT_DeviceEDCs_041)
                        {
                            IOT_DEVICE_EDC oIoT_DeviceEDC = new IOT_DEVICE_EDC();
                            oIoT_DeviceEDC.Clone(vIoT_DeviceEDC);
                            oIotDeviceEDCs.Add(oIoT_DeviceEDC);
                        }
                        break;
                    case 42:
                        var vIoT_DeviceEDCs_042 = IOT_DEVICE_EDC_042.AsQueryable();
                        vIoT_DeviceEDCs_042 = vIoT_DeviceEDCs_042.Where(c => c.device_id == device.device_id && c.clm_date_time >= start_date && c.clm_date_time <= end_date);
                        vIoT_DeviceEDCs_042 = vIoT_DeviceEDCs_042.OrderBy(c => c.clm_date_time);
                        foreach (var vIoT_DeviceEDC in vIoT_DeviceEDCs_042)
                        {
                            IOT_DEVICE_EDC oIoT_DeviceEDC = new IOT_DEVICE_EDC();
                            oIoT_DeviceEDC.Clone(vIoT_DeviceEDC);
                            oIotDeviceEDCs.Add(oIoT_DeviceEDC);
                        }

                        break;

                    case 43:
                        var vIoT_DeviceEDCs_043 = IOT_DEVICE_EDC_043.AsQueryable();
                        vIoT_DeviceEDCs_043 = vIoT_DeviceEDCs_043.Where(c => c.device_id == device.device_id && c.clm_date_time >= start_date && c.clm_date_time <= end_date);
                        vIoT_DeviceEDCs_043 = vIoT_DeviceEDCs_043.OrderBy(c => c.clm_date_time);
                        foreach (var vIoT_DeviceEDC in vIoT_DeviceEDCs_043)
                        {
                            IOT_DEVICE_EDC oIoT_DeviceEDC = new IOT_DEVICE_EDC();
                            oIoT_DeviceEDC.Clone(vIoT_DeviceEDC);
                            oIotDeviceEDCs.Add(oIoT_DeviceEDC);
                        }
                        break;

                    case 44:
                        var vIoT_DeviceEDCs_044 = IOT_DEVICE_EDC_044.AsQueryable();
                        vIoT_DeviceEDCs_044 = vIoT_DeviceEDCs_044.Where(c => c.device_id == device.device_id && c.clm_date_time >= start_date && c.clm_date_time <= end_date);
                        vIoT_DeviceEDCs_044 = vIoT_DeviceEDCs_044.OrderBy(c => c.clm_date_time);
                        foreach (var vIoT_DeviceEDC in vIoT_DeviceEDCs_044)
                        {
                            IOT_DEVICE_EDC oIoT_DeviceEDC = new IOT_DEVICE_EDC();
                            oIoT_DeviceEDC.Clone(vIoT_DeviceEDC);
                            oIotDeviceEDCs.Add(oIoT_DeviceEDC);
                        }
                        break;

                    case 45:
                        var vIoT_DeviceEDCs_045 = IOT_DEVICE_EDC_045.AsQueryable();
                        vIoT_DeviceEDCs_045 = vIoT_DeviceEDCs_045.Where(c => c.device_id == device.device_id && c.clm_date_time >= start_date && c.clm_date_time <= end_date);
                        vIoT_DeviceEDCs_045 = vIoT_DeviceEDCs_045.OrderBy(c => c.clm_date_time);
                        foreach (var vIoT_DeviceEDC in vIoT_DeviceEDCs_045)
                        {
                            IOT_DEVICE_EDC oIoT_DeviceEDC = new IOT_DEVICE_EDC();
                            oIoT_DeviceEDC.Clone(vIoT_DeviceEDC);
                            oIotDeviceEDCs.Add(oIoT_DeviceEDC);
                        }
                        break;

                    case 46:
                        var vIoT_DeviceEDCs_046 = IOT_DEVICE_EDC_046.AsQueryable();
                        vIoT_DeviceEDCs_046 = vIoT_DeviceEDCs_046.Where(c => c.device_id == device.device_id && c.clm_date_time >= start_date && c.clm_date_time <= end_date);
                        vIoT_DeviceEDCs_046 = vIoT_DeviceEDCs_046.OrderBy(c => c.clm_date_time);
                        foreach (var vIoT_DeviceEDC in vIoT_DeviceEDCs_046)
                        {
                            IOT_DEVICE_EDC oIoT_DeviceEDC = new IOT_DEVICE_EDC();
                            oIoT_DeviceEDC.Clone(vIoT_DeviceEDC);
                            oIotDeviceEDCs.Add(oIoT_DeviceEDC);
                        }
                        break;

                    case 47:
                        var vIoT_DeviceEDCs_047 = IOT_DEVICE_EDC_047.AsQueryable();
                        vIoT_DeviceEDCs_047 = vIoT_DeviceEDCs_047.Where(c => c.device_id == device.device_id && c.clm_date_time >= start_date && c.clm_date_time <= end_date);
                        vIoT_DeviceEDCs_047 = vIoT_DeviceEDCs_047.OrderBy(c => c.clm_date_time);
                        foreach (var vIoT_DeviceEDC in vIoT_DeviceEDCs_047)
                        {
                            IOT_DEVICE_EDC oIoT_DeviceEDC = new IOT_DEVICE_EDC();
                            oIoT_DeviceEDC.Clone(vIoT_DeviceEDC);
                            oIotDeviceEDCs.Add(oIoT_DeviceEDC);
                        }
                        break;

                    case 48:
                        var vIoT_DeviceEDCs_048 = IOT_DEVICE_EDC_048.AsQueryable();
                        vIoT_DeviceEDCs_048 = vIoT_DeviceEDCs_048.Where(c => c.device_id == device.device_id && c.clm_date_time >= start_date && c.clm_date_time <= end_date);
                        vIoT_DeviceEDCs_048 = vIoT_DeviceEDCs_048.OrderBy(c => c.clm_date_time);
                        foreach (var vIoT_DeviceEDC in vIoT_DeviceEDCs_048)
                        {
                            IOT_DEVICE_EDC oIoT_DeviceEDC = new IOT_DEVICE_EDC();
                            oIoT_DeviceEDC.Clone(vIoT_DeviceEDC);
                            oIotDeviceEDCs.Add(oIoT_DeviceEDC);
                        }
                        break;

                    case 49:
                        var vIoT_DeviceEDCs_049 = IOT_DEVICE_EDC_049.AsQueryable();
                        vIoT_DeviceEDCs_049 = vIoT_DeviceEDCs_049.Where(c => c.device_id == device.device_id && c.clm_date_time >= start_date && c.clm_date_time <= end_date);
                        vIoT_DeviceEDCs_049 = vIoT_DeviceEDCs_049.OrderBy(c => c.clm_date_time);
                        foreach (var vIoT_DeviceEDC in vIoT_DeviceEDCs_049)
                        {
                            IOT_DEVICE_EDC oIoT_DeviceEDC = new IOT_DEVICE_EDC();
                            oIoT_DeviceEDC.Clone(vIoT_DeviceEDC);
                            oIotDeviceEDCs.Add(oIoT_DeviceEDC);
                        }
                        break;
                    case 50:
                        var vIoT_DeviceEDCs_050 = IOT_DEVICE_EDC_050.AsQueryable();
                        vIoT_DeviceEDCs_050 = vIoT_DeviceEDCs_050.Where(c => c.device_id == device.device_id && c.clm_date_time >= start_date && c.clm_date_time <= end_date);
                        vIoT_DeviceEDCs_050 = vIoT_DeviceEDCs_050.OrderBy(c => c.clm_date_time);
                        foreach (var vIoT_DeviceEDC in vIoT_DeviceEDCs_050)
                        {
                            IOT_DEVICE_EDC oIoT_DeviceEDC = new IOT_DEVICE_EDC();
                            oIoT_DeviceEDC.Clone(vIoT_DeviceEDC);
                            oIotDeviceEDCs.Add(oIoT_DeviceEDC);
                        }
                        break;

                    case 61:
                        var vIoT_DeviceEDCs_061 = IOT_DEVICE_EDC_061.AsQueryable();
                        vIoT_DeviceEDCs_061 = vIoT_DeviceEDCs_061.Where(c => c.device_id == device.device_id && c.clm_date_time >= start_date && c.clm_date_time <= end_date);
                        vIoT_DeviceEDCs_061 = vIoT_DeviceEDCs_061.OrderBy(c => c.clm_date_time);
                        foreach (var vIoT_DeviceEDC in vIoT_DeviceEDCs_061)
                        {
                            IOT_DEVICE_EDC oIoT_DeviceEDC = new IOT_DEVICE_EDC();
                            oIoT_DeviceEDC.Clone(vIoT_DeviceEDC);
                            oIotDeviceEDCs.Add(oIoT_DeviceEDC);
                        }
                        break;
                    case 62:
                        var vIoT_DeviceEDCs_062 = IOT_DEVICE_EDC_062.AsQueryable();
                        vIoT_DeviceEDCs_062 = vIoT_DeviceEDCs_062.Where(c => c.device_id == device.device_id && c.clm_date_time >= start_date && c.clm_date_time <= end_date);
                        vIoT_DeviceEDCs_062 = vIoT_DeviceEDCs_062.OrderBy(c => c.clm_date_time);
                        foreach (var vIoT_DeviceEDC in vIoT_DeviceEDCs_062)
                        {
                            IOT_DEVICE_EDC oIoT_DeviceEDC = new IOT_DEVICE_EDC();
                            oIoT_DeviceEDC.Clone(vIoT_DeviceEDC);
                            oIotDeviceEDCs.Add(oIoT_DeviceEDC);
                        }

                        break;

                    case 63:
                        var vIoT_DeviceEDCs_063 = IOT_DEVICE_EDC_063.AsQueryable();
                        vIoT_DeviceEDCs_063 = vIoT_DeviceEDCs_063.Where(c => c.device_id == device.device_id && c.clm_date_time >= start_date && c.clm_date_time <= end_date);
                        vIoT_DeviceEDCs_063 = vIoT_DeviceEDCs_063.OrderBy(c => c.clm_date_time);
                        foreach (var vIoT_DeviceEDC in vIoT_DeviceEDCs_063)
                        {
                            IOT_DEVICE_EDC oIoT_DeviceEDC = new IOT_DEVICE_EDC();
                            oIoT_DeviceEDC.Clone(vIoT_DeviceEDC);
                            oIotDeviceEDCs.Add(oIoT_DeviceEDC);
                        }
                        break;

                    case 64:
                        var vIoT_DeviceEDCs_064 = IOT_DEVICE_EDC_064.AsQueryable();
                        vIoT_DeviceEDCs_064 = vIoT_DeviceEDCs_064.Where(c => c.device_id == device.device_id && c.clm_date_time >= start_date && c.clm_date_time <= end_date);
                        vIoT_DeviceEDCs_064 = vIoT_DeviceEDCs_064.OrderBy(c => c.clm_date_time);
                        foreach (var vIoT_DeviceEDC in vIoT_DeviceEDCs_064)
                        {
                            IOT_DEVICE_EDC oIoT_DeviceEDC = new IOT_DEVICE_EDC();
                            oIoT_DeviceEDC.Clone(vIoT_DeviceEDC);
                            oIotDeviceEDCs.Add(oIoT_DeviceEDC);
                        }
                        break;

                    case 65:
                        var vIoT_DeviceEDCs_065 = IOT_DEVICE_EDC_065.AsQueryable();
                        vIoT_DeviceEDCs_065 = vIoT_DeviceEDCs_065.Where(c => c.device_id == device.device_id && c.clm_date_time >= start_date && c.clm_date_time <= end_date);
                        vIoT_DeviceEDCs_065 = vIoT_DeviceEDCs_065.OrderBy(c => c.clm_date_time);
                        foreach (var vIoT_DeviceEDC in vIoT_DeviceEDCs_065)
                        {
                            IOT_DEVICE_EDC oIoT_DeviceEDC = new IOT_DEVICE_EDC();
                            oIoT_DeviceEDC.Clone(vIoT_DeviceEDC);
                            oIotDeviceEDCs.Add(oIoT_DeviceEDC);
                        }
                        break;

                    case 66:
                        var vIoT_DeviceEDCs_066 = IOT_DEVICE_EDC_066.AsQueryable();
                        vIoT_DeviceEDCs_066 = vIoT_DeviceEDCs_066.Where(c => c.device_id == device.device_id && c.clm_date_time >= start_date && c.clm_date_time <= end_date);
                        vIoT_DeviceEDCs_066 = vIoT_DeviceEDCs_066.OrderBy(c => c.clm_date_time);
                        foreach (var vIoT_DeviceEDC in vIoT_DeviceEDCs_066)
                        {
                            IOT_DEVICE_EDC oIoT_DeviceEDC = new IOT_DEVICE_EDC();
                            oIoT_DeviceEDC.Clone(vIoT_DeviceEDC);
                            oIotDeviceEDCs.Add(oIoT_DeviceEDC);
                        }
                        break;

                    case 67:
                        var vIoT_DeviceEDCs_067 = IOT_DEVICE_EDC_067.AsQueryable();
                        vIoT_DeviceEDCs_067 = vIoT_DeviceEDCs_067.Where(c => c.device_id == device.device_id && c.clm_date_time >= start_date && c.clm_date_time <= end_date);
                        vIoT_DeviceEDCs_067 = vIoT_DeviceEDCs_067.OrderBy(c => c.clm_date_time);
                        foreach (var vIoT_DeviceEDC in vIoT_DeviceEDCs_067)
                        {
                            IOT_DEVICE_EDC oIoT_DeviceEDC = new IOT_DEVICE_EDC();
                            oIoT_DeviceEDC.Clone(vIoT_DeviceEDC);
                            oIotDeviceEDCs.Add(oIoT_DeviceEDC);
                        }
                        break;

                    case 68:
                        var vIoT_DeviceEDCs_068 = IOT_DEVICE_EDC_068.AsQueryable();
                        vIoT_DeviceEDCs_068 = vIoT_DeviceEDCs_068.Where(c => c.device_id == device.device_id && c.clm_date_time >= start_date && c.clm_date_time <= end_date);
                        vIoT_DeviceEDCs_068 = vIoT_DeviceEDCs_068.OrderBy(c => c.clm_date_time);
                        foreach (var vIoT_DeviceEDC in vIoT_DeviceEDCs_068)
                        {
                            IOT_DEVICE_EDC oIoT_DeviceEDC = new IOT_DEVICE_EDC();
                            oIoT_DeviceEDC.Clone(vIoT_DeviceEDC);
                            oIotDeviceEDCs.Add(oIoT_DeviceEDC);
                        }
                        break;

                    case 69:
                        var vIoT_DeviceEDCs_069 = IOT_DEVICE_EDC_069.AsQueryable();
                        vIoT_DeviceEDCs_069 = vIoT_DeviceEDCs_069.Where(c => c.device_id == device.device_id && c.clm_date_time >= start_date && c.clm_date_time <= end_date);
                        vIoT_DeviceEDCs_069 = vIoT_DeviceEDCs_069.OrderBy(c => c.clm_date_time);
                        foreach (var vIoT_DeviceEDC in vIoT_DeviceEDCs_069)
                        {
                            IOT_DEVICE_EDC oIoT_DeviceEDC = new IOT_DEVICE_EDC();
                            oIoT_DeviceEDC.Clone(vIoT_DeviceEDC);
                            oIotDeviceEDCs.Add(oIoT_DeviceEDC);
                        }
                        break;
                    case 70:
                        var vIoT_DeviceEDCs_070 = IOT_DEVICE_EDC_070.AsQueryable();
                        vIoT_DeviceEDCs_070 = vIoT_DeviceEDCs_070.Where(c => c.device_id == device.device_id && c.clm_date_time >= start_date && c.clm_date_time <= end_date);
                        vIoT_DeviceEDCs_070 = vIoT_DeviceEDCs_070.OrderBy(c => c.clm_date_time);
                        foreach (var vIoT_DeviceEDC in vIoT_DeviceEDCs_070)
                        {
                            IOT_DEVICE_EDC oIoT_DeviceEDC = new IOT_DEVICE_EDC();
                            oIoT_DeviceEDC.Clone(vIoT_DeviceEDC);
                            oIotDeviceEDCs.Add(oIoT_DeviceEDC);
                        }
                        break;

                    case 71:
                        var vIoT_DeviceEDCs_071 = IOT_DEVICE_EDC_071.AsQueryable();
                        vIoT_DeviceEDCs_071 = vIoT_DeviceEDCs_071.Where(c => c.device_id == device.device_id && c.clm_date_time >= start_date && c.clm_date_time <= end_date);
                        vIoT_DeviceEDCs_071 = vIoT_DeviceEDCs_071.OrderBy(c => c.clm_date_time);
                        foreach (var vIoT_DeviceEDC in vIoT_DeviceEDCs_071)
                        {
                            IOT_DEVICE_EDC oIoT_DeviceEDC = new IOT_DEVICE_EDC();
                            oIoT_DeviceEDC.Clone(vIoT_DeviceEDC);
                            oIotDeviceEDCs.Add(oIoT_DeviceEDC);
                        }
                        break;
                    case 72:
                        var vIoT_DeviceEDCs_072 = IOT_DEVICE_EDC_072.AsQueryable();
                        vIoT_DeviceEDCs_072 = vIoT_DeviceEDCs_072.Where(c => c.device_id == device.device_id && c.clm_date_time >= start_date && c.clm_date_time <= end_date);
                        vIoT_DeviceEDCs_072 = vIoT_DeviceEDCs_072.OrderBy(c => c.clm_date_time);
                        foreach (var vIoT_DeviceEDC in vIoT_DeviceEDCs_072)
                        {
                            IOT_DEVICE_EDC oIoT_DeviceEDC = new IOT_DEVICE_EDC();
                            oIoT_DeviceEDC.Clone(vIoT_DeviceEDC);
                            oIotDeviceEDCs.Add(oIoT_DeviceEDC);
                        }

                        break;

                    case 73:
                        var vIoT_DeviceEDCs_073 = IOT_DEVICE_EDC_073.AsQueryable();
                        vIoT_DeviceEDCs_073 = vIoT_DeviceEDCs_073.Where(c => c.device_id == device.device_id && c.clm_date_time >= start_date && c.clm_date_time <= end_date);
                        vIoT_DeviceEDCs_073 = vIoT_DeviceEDCs_073.OrderBy(c => c.clm_date_time);
                        foreach (var vIoT_DeviceEDC in vIoT_DeviceEDCs_073)
                        {
                            IOT_DEVICE_EDC oIoT_DeviceEDC = new IOT_DEVICE_EDC();
                            oIoT_DeviceEDC.Clone(vIoT_DeviceEDC);
                            oIotDeviceEDCs.Add(oIoT_DeviceEDC);
                        }
                        break;

                    case 74:
                        var vIoT_DeviceEDCs_074 = IOT_DEVICE_EDC_074.AsQueryable();
                        vIoT_DeviceEDCs_074 = vIoT_DeviceEDCs_074.Where(c => c.device_id == device.device_id && c.clm_date_time >= start_date && c.clm_date_time <= end_date);
                        vIoT_DeviceEDCs_074 = vIoT_DeviceEDCs_074.OrderBy(c => c.clm_date_time);
                        foreach (var vIoT_DeviceEDC in vIoT_DeviceEDCs_074)
                        {
                            IOT_DEVICE_EDC oIoT_DeviceEDC = new IOT_DEVICE_EDC();
                            oIoT_DeviceEDC.Clone(vIoT_DeviceEDC);
                            oIotDeviceEDCs.Add(oIoT_DeviceEDC);
                        }
                        break;

                    case 75:
                        var vIoT_DeviceEDCs_075 = IOT_DEVICE_EDC_075.AsQueryable();
                        vIoT_DeviceEDCs_075 = vIoT_DeviceEDCs_075.Where(c => c.device_id == device.device_id && c.clm_date_time >= start_date && c.clm_date_time <= end_date);
                        vIoT_DeviceEDCs_075 = vIoT_DeviceEDCs_075.OrderBy(c => c.clm_date_time);
                        foreach (var vIoT_DeviceEDC in vIoT_DeviceEDCs_075)
                        {
                            IOT_DEVICE_EDC oIoT_DeviceEDC = new IOT_DEVICE_EDC();
                            oIoT_DeviceEDC.Clone(vIoT_DeviceEDC);
                            oIotDeviceEDCs.Add(oIoT_DeviceEDC);
                        }
                        break;

                    case 76:
                        var vIoT_DeviceEDCs_076 = IOT_DEVICE_EDC_076.AsQueryable();
                        vIoT_DeviceEDCs_076 = vIoT_DeviceEDCs_076.Where(c => c.device_id == device.device_id && c.clm_date_time >= start_date && c.clm_date_time <= end_date);
                        vIoT_DeviceEDCs_076 = vIoT_DeviceEDCs_076.OrderBy(c => c.clm_date_time);
                        foreach (var vIoT_DeviceEDC in vIoT_DeviceEDCs_076)
                        {
                            IOT_DEVICE_EDC oIoT_DeviceEDC = new IOT_DEVICE_EDC();
                            oIoT_DeviceEDC.Clone(vIoT_DeviceEDC);
                            oIotDeviceEDCs.Add(oIoT_DeviceEDC);
                        }
                        break;

                    case 77:
                        var vIoT_DeviceEDCs_077 = IOT_DEVICE_EDC_077.AsQueryable();
                        vIoT_DeviceEDCs_077 = vIoT_DeviceEDCs_077.Where(c => c.device_id == device.device_id && c.clm_date_time >= start_date && c.clm_date_time <= end_date);
                        vIoT_DeviceEDCs_077 = vIoT_DeviceEDCs_077.OrderBy(c => c.clm_date_time);
                        foreach (var vIoT_DeviceEDC in vIoT_DeviceEDCs_077)
                        {
                            IOT_DEVICE_EDC oIoT_DeviceEDC = new IOT_DEVICE_EDC();
                            oIoT_DeviceEDC.Clone(vIoT_DeviceEDC);
                            oIotDeviceEDCs.Add(oIoT_DeviceEDC);
                        }
                        break;

                    case 78:
                        var vIoT_DeviceEDCs_078 = IOT_DEVICE_EDC_078.AsQueryable();
                        vIoT_DeviceEDCs_078 = vIoT_DeviceEDCs_078.Where(c => c.device_id == device.device_id && c.clm_date_time >= start_date && c.clm_date_time <= end_date);
                        vIoT_DeviceEDCs_078 = vIoT_DeviceEDCs_078.OrderBy(c => c.clm_date_time);
                        foreach (var vIoT_DeviceEDC in vIoT_DeviceEDCs_078)
                        {
                            IOT_DEVICE_EDC oIoT_DeviceEDC = new IOT_DEVICE_EDC();
                            oIoT_DeviceEDC.Clone(vIoT_DeviceEDC);
                            oIotDeviceEDCs.Add(oIoT_DeviceEDC);
                        }
                        break;

                    case 79:
                        var vIoT_DeviceEDCs_079 = IOT_DEVICE_EDC_079.AsQueryable();
                        vIoT_DeviceEDCs_079 = vIoT_DeviceEDCs_079.Where(c => c.device_id == device.device_id && c.clm_date_time >= start_date && c.clm_date_time <= end_date);
                        vIoT_DeviceEDCs_079 = vIoT_DeviceEDCs_079.OrderBy(c => c.clm_date_time);
                        foreach (var vIoT_DeviceEDC in vIoT_DeviceEDCs_079)
                        {
                            IOT_DEVICE_EDC oIoT_DeviceEDC = new IOT_DEVICE_EDC();
                            oIoT_DeviceEDC.Clone(vIoT_DeviceEDC);
                            oIotDeviceEDCs.Add(oIoT_DeviceEDC);
                        }
                        break;
                    case 80:
                        var vIoT_DeviceEDCs_080 = IOT_DEVICE_EDC_080.AsQueryable();
                        vIoT_DeviceEDCs_080 = vIoT_DeviceEDCs_080.Where(c => c.device_id == device.device_id && c.clm_date_time >= start_date && c.clm_date_time <= end_date);
                        vIoT_DeviceEDCs_080 = vIoT_DeviceEDCs_080.OrderBy(c => c.clm_date_time);
                        foreach (var vIoT_DeviceEDC in vIoT_DeviceEDCs_080)
                        {
                            IOT_DEVICE_EDC oIoT_DeviceEDC = new IOT_DEVICE_EDC();
                            oIoT_DeviceEDC.Clone(vIoT_DeviceEDC);
                            oIotDeviceEDCs.Add(oIoT_DeviceEDC);
                        }
                        break;

                    case 81:
                        var vIoT_DeviceEDCs_081 = IOT_DEVICE_EDC_081.AsQueryable();
                        vIoT_DeviceEDCs_081 = vIoT_DeviceEDCs_081.Where(c => c.device_id == device.device_id && c.clm_date_time >= start_date && c.clm_date_time <= end_date);
                        vIoT_DeviceEDCs_081 = vIoT_DeviceEDCs_081.OrderBy(c => c.clm_date_time);
                        foreach (var vIoT_DeviceEDC in vIoT_DeviceEDCs_081)
                        {
                            IOT_DEVICE_EDC oIoT_DeviceEDC = new IOT_DEVICE_EDC();
                            oIoT_DeviceEDC.Clone(vIoT_DeviceEDC);
                            oIotDeviceEDCs.Add(oIoT_DeviceEDC);
                        }
                        break;
                    case 82:
                        var vIoT_DeviceEDCs_082 = IOT_DEVICE_EDC_082.AsQueryable();
                        vIoT_DeviceEDCs_082 = vIoT_DeviceEDCs_082.Where(c => c.device_id == device.device_id && c.clm_date_time >= start_date && c.clm_date_time <= end_date);
                        vIoT_DeviceEDCs_082 = vIoT_DeviceEDCs_082.OrderBy(c => c.clm_date_time);
                        foreach (var vIoT_DeviceEDC in vIoT_DeviceEDCs_082)
                        {
                            IOT_DEVICE_EDC oIoT_DeviceEDC = new IOT_DEVICE_EDC();
                            oIoT_DeviceEDC.Clone(vIoT_DeviceEDC);
                            oIotDeviceEDCs.Add(oIoT_DeviceEDC);
                        }

                        break;

                    case 83:
                        var vIoT_DeviceEDCs_083 = IOT_DEVICE_EDC_083.AsQueryable();
                        vIoT_DeviceEDCs_083 = vIoT_DeviceEDCs_083.Where(c => c.device_id == device.device_id && c.clm_date_time >= start_date && c.clm_date_time <= end_date);
                        vIoT_DeviceEDCs_083 = vIoT_DeviceEDCs_083.OrderBy(c => c.clm_date_time);
                        foreach (var vIoT_DeviceEDC in vIoT_DeviceEDCs_083)
                        {
                            IOT_DEVICE_EDC oIoT_DeviceEDC = new IOT_DEVICE_EDC();
                            oIoT_DeviceEDC.Clone(vIoT_DeviceEDC);
                            oIotDeviceEDCs.Add(oIoT_DeviceEDC);
                        }
                        break;

                    case 84:
                        var vIoT_DeviceEDCs_084 = IOT_DEVICE_EDC_084.AsQueryable();
                        vIoT_DeviceEDCs_084 = vIoT_DeviceEDCs_084.Where(c => c.device_id == device.device_id && c.clm_date_time >= start_date && c.clm_date_time <= end_date);
                        vIoT_DeviceEDCs_084 = vIoT_DeviceEDCs_084.OrderBy(c => c.clm_date_time);
                        foreach (var vIoT_DeviceEDC in vIoT_DeviceEDCs_084)
                        {
                            IOT_DEVICE_EDC oIoT_DeviceEDC = new IOT_DEVICE_EDC();
                            oIoT_DeviceEDC.Clone(vIoT_DeviceEDC);
                            oIotDeviceEDCs.Add(oIoT_DeviceEDC);
                        }
                        break;

                    case 85:
                        var vIoT_DeviceEDCs_085 = IOT_DEVICE_EDC_085.AsQueryable();
                        vIoT_DeviceEDCs_085 = vIoT_DeviceEDCs_085.Where(c => c.device_id == device.device_id && c.clm_date_time >= start_date && c.clm_date_time <= end_date);
                        vIoT_DeviceEDCs_085 = vIoT_DeviceEDCs_085.OrderBy(c => c.clm_date_time);
                        foreach (var vIoT_DeviceEDC in vIoT_DeviceEDCs_085)
                        {
                            IOT_DEVICE_EDC oIoT_DeviceEDC = new IOT_DEVICE_EDC();
                            oIoT_DeviceEDC.Clone(vIoT_DeviceEDC);
                            oIotDeviceEDCs.Add(oIoT_DeviceEDC);
                        }
                        break;

                    case 86:
                        var vIoT_DeviceEDCs_086 = IOT_DEVICE_EDC_086.AsQueryable();
                        vIoT_DeviceEDCs_086 = vIoT_DeviceEDCs_086.Where(c => c.device_id == device.device_id && c.clm_date_time >= start_date && c.clm_date_time <= end_date);
                        vIoT_DeviceEDCs_086 = vIoT_DeviceEDCs_086.OrderBy(c => c.clm_date_time);
                        foreach (var vIoT_DeviceEDC in vIoT_DeviceEDCs_086)
                        {
                            IOT_DEVICE_EDC oIoT_DeviceEDC = new IOT_DEVICE_EDC();
                            oIoT_DeviceEDC.Clone(vIoT_DeviceEDC);
                            oIotDeviceEDCs.Add(oIoT_DeviceEDC);
                        }
                        break;

                    case 87:
                        var vIoT_DeviceEDCs_087 = IOT_DEVICE_EDC_087.AsQueryable();
                        vIoT_DeviceEDCs_087 = vIoT_DeviceEDCs_087.Where(c => c.device_id == device.device_id && c.clm_date_time >= start_date && c.clm_date_time <= end_date);
                        vIoT_DeviceEDCs_087 = vIoT_DeviceEDCs_087.OrderBy(c => c.clm_date_time);
                        foreach (var vIoT_DeviceEDC in vIoT_DeviceEDCs_087)
                        {
                            IOT_DEVICE_EDC oIoT_DeviceEDC = new IOT_DEVICE_EDC();
                            oIoT_DeviceEDC.Clone(vIoT_DeviceEDC);
                            oIotDeviceEDCs.Add(oIoT_DeviceEDC);
                        }
                        break;

                    case 88:
                        var vIoT_DeviceEDCs_088 = IOT_DEVICE_EDC_088.AsQueryable();
                        vIoT_DeviceEDCs_088 = vIoT_DeviceEDCs_088.Where(c => c.device_id == device.device_id && c.clm_date_time >= start_date && c.clm_date_time <= end_date);
                        vIoT_DeviceEDCs_088 = vIoT_DeviceEDCs_088.OrderBy(c => c.clm_date_time);
                        foreach (var vIoT_DeviceEDC in vIoT_DeviceEDCs_088)
                        {
                            IOT_DEVICE_EDC oIoT_DeviceEDC = new IOT_DEVICE_EDC();
                            oIoT_DeviceEDC.Clone(vIoT_DeviceEDC);
                            oIotDeviceEDCs.Add(oIoT_DeviceEDC);
                        }
                        break;

                    case 89:
                        var vIoT_DeviceEDCs_089 = IOT_DEVICE_EDC_089.AsQueryable();
                        vIoT_DeviceEDCs_089 = vIoT_DeviceEDCs_089.Where(c => c.device_id == device.device_id && c.clm_date_time >= start_date && c.clm_date_time <= end_date);
                        vIoT_DeviceEDCs_089 = vIoT_DeviceEDCs_089.OrderBy(c => c.clm_date_time);
                        foreach (var vIoT_DeviceEDC in vIoT_DeviceEDCs_089)
                        {
                            IOT_DEVICE_EDC oIoT_DeviceEDC = new IOT_DEVICE_EDC();
                            oIoT_DeviceEDC.Clone(vIoT_DeviceEDC);
                            oIotDeviceEDCs.Add(oIoT_DeviceEDC);
                        }
                        break;
                    case 90:
                        var vIoT_DeviceEDCs_090 = IOT_DEVICE_EDC_090.AsQueryable();
                        vIoT_DeviceEDCs_090 = vIoT_DeviceEDCs_090.Where(c => c.device_id == device.device_id && c.clm_date_time >= start_date && c.clm_date_time <= end_date);
                        vIoT_DeviceEDCs_090 = vIoT_DeviceEDCs_090.OrderBy(c => c.clm_date_time);
                        foreach (var vIoT_DeviceEDC in vIoT_DeviceEDCs_090)
                        {
                            IOT_DEVICE_EDC oIoT_DeviceEDC = new IOT_DEVICE_EDC();
                            oIoT_DeviceEDC.Clone(vIoT_DeviceEDC);
                            oIotDeviceEDCs.Add(oIoT_DeviceEDC);
                        }
                        break;

                    case 91:
                        var vIoT_DeviceEDCs_091 = IOT_DEVICE_EDC_091.AsQueryable();
                        vIoT_DeviceEDCs_091 = vIoT_DeviceEDCs_091.Where(c => c.device_id == device.device_id && c.clm_date_time >= start_date && c.clm_date_time <= end_date);
                        vIoT_DeviceEDCs_091 = vIoT_DeviceEDCs_091.OrderBy(c => c.clm_date_time);
                        foreach (var vIoT_DeviceEDC in vIoT_DeviceEDCs_091)
                        {
                            IOT_DEVICE_EDC oIoT_DeviceEDC = new IOT_DEVICE_EDC();
                            oIoT_DeviceEDC.Clone(vIoT_DeviceEDC);
                            oIotDeviceEDCs.Add(oIoT_DeviceEDC);
                        }
                        break;
                    case 92:
                        var vIoT_DeviceEDCs_092 = IOT_DEVICE_EDC_092.AsQueryable();
                        vIoT_DeviceEDCs_092 = vIoT_DeviceEDCs_092.Where(c => c.device_id == device.device_id && c.clm_date_time >= start_date && c.clm_date_time <= end_date);
                        vIoT_DeviceEDCs_092 = vIoT_DeviceEDCs_092.OrderBy(c => c.clm_date_time);
                        foreach (var vIoT_DeviceEDC in vIoT_DeviceEDCs_092)
                        {
                            IOT_DEVICE_EDC oIoT_DeviceEDC = new IOT_DEVICE_EDC();
                            oIoT_DeviceEDC.Clone(vIoT_DeviceEDC);
                            oIotDeviceEDCs.Add(oIoT_DeviceEDC);
                        }

                        break;

                    case 93:
                        var vIoT_DeviceEDCs_093 = IOT_DEVICE_EDC_093.AsQueryable();
                        vIoT_DeviceEDCs_093 = vIoT_DeviceEDCs_093.Where(c => c.device_id == device.device_id && c.clm_date_time >= start_date && c.clm_date_time <= end_date);
                        vIoT_DeviceEDCs_093 = vIoT_DeviceEDCs_093.OrderBy(c => c.clm_date_time);
                        foreach (var vIoT_DeviceEDC in vIoT_DeviceEDCs_093)
                        {
                            IOT_DEVICE_EDC oIoT_DeviceEDC = new IOT_DEVICE_EDC();
                            oIoT_DeviceEDC.Clone(vIoT_DeviceEDC);
                            oIotDeviceEDCs.Add(oIoT_DeviceEDC);
                        }
                        break;

                    case 94:
                        var vIoT_DeviceEDCs_094 = IOT_DEVICE_EDC_094.AsQueryable();
                        vIoT_DeviceEDCs_094 = vIoT_DeviceEDCs_094.Where(c => c.device_id == device.device_id && c.clm_date_time >= start_date && c.clm_date_time <= end_date);
                        vIoT_DeviceEDCs_094 = vIoT_DeviceEDCs_094.OrderBy(c => c.clm_date_time);
                        foreach (var vIoT_DeviceEDC in vIoT_DeviceEDCs_094)
                        {
                            IOT_DEVICE_EDC oIoT_DeviceEDC = new IOT_DEVICE_EDC();
                            oIoT_DeviceEDC.Clone(vIoT_DeviceEDC);
                            oIotDeviceEDCs.Add(oIoT_DeviceEDC);
                        }
                        break;

                    case 95:
                        var vIoT_DeviceEDCs_095 = IOT_DEVICE_EDC_095.AsQueryable();
                        vIoT_DeviceEDCs_095 = vIoT_DeviceEDCs_095.Where(c => c.device_id == device.device_id && c.clm_date_time >= start_date && c.clm_date_time <= end_date);
                        vIoT_DeviceEDCs_095 = vIoT_DeviceEDCs_095.OrderBy(c => c.clm_date_time);
                        foreach (var vIoT_DeviceEDC in vIoT_DeviceEDCs_095)
                        {
                            IOT_DEVICE_EDC oIoT_DeviceEDC = new IOT_DEVICE_EDC();
                            oIoT_DeviceEDC.Clone(vIoT_DeviceEDC);
                            oIotDeviceEDCs.Add(oIoT_DeviceEDC);
                        }
                        break;

                    case 96:
                        var vIoT_DeviceEDCs_096 = IOT_DEVICE_EDC_096.AsQueryable();
                        vIoT_DeviceEDCs_096 = vIoT_DeviceEDCs_096.Where(c => c.device_id == device.device_id && c.clm_date_time >= start_date && c.clm_date_time <= end_date);
                        vIoT_DeviceEDCs_096 = vIoT_DeviceEDCs_096.OrderBy(c => c.clm_date_time);
                        foreach (var vIoT_DeviceEDC in vIoT_DeviceEDCs_096)
                        {
                            IOT_DEVICE_EDC oIoT_DeviceEDC = new IOT_DEVICE_EDC();
                            oIoT_DeviceEDC.Clone(vIoT_DeviceEDC);
                            oIotDeviceEDCs.Add(oIoT_DeviceEDC);
                        }
                        break;

                    case 97:
                        var vIoT_DeviceEDCs_097 = IOT_DEVICE_EDC_097.AsQueryable();
                        vIoT_DeviceEDCs_097 = vIoT_DeviceEDCs_097.Where(c => c.device_id == device.device_id && c.clm_date_time >= start_date && c.clm_date_time <= end_date);
                        vIoT_DeviceEDCs_097 = vIoT_DeviceEDCs_097.OrderBy(c => c.clm_date_time);
                        foreach (var vIoT_DeviceEDC in vIoT_DeviceEDCs_097)
                        {
                            IOT_DEVICE_EDC oIoT_DeviceEDC = new IOT_DEVICE_EDC();
                            oIoT_DeviceEDC.Clone(vIoT_DeviceEDC);
                            oIotDeviceEDCs.Add(oIoT_DeviceEDC);
                        }
                        break;

                    case 98:
                        var vIoT_DeviceEDCs_098 = IOT_DEVICE_EDC_098.AsQueryable();
                        vIoT_DeviceEDCs_098 = vIoT_DeviceEDCs_098.Where(c => c.device_id == device.device_id && c.clm_date_time >= start_date && c.clm_date_time <= end_date);
                        vIoT_DeviceEDCs_098 = vIoT_DeviceEDCs_098.OrderBy(c => c.clm_date_time);
                        foreach (var vIoT_DeviceEDC in vIoT_DeviceEDCs_098)
                        {
                            IOT_DEVICE_EDC oIoT_DeviceEDC = new IOT_DEVICE_EDC();
                            oIoT_DeviceEDC.Clone(vIoT_DeviceEDC);
                            oIotDeviceEDCs.Add(oIoT_DeviceEDC);
                        }
                        break;

                    case 99:
                        var vIoT_DeviceEDCs_099 = IOT_DEVICE_EDC_099.AsQueryable();
                        vIoT_DeviceEDCs_099 = vIoT_DeviceEDCs_099.Where(c => c.device_id == device.device_id && c.clm_date_time >= start_date && c.clm_date_time <= end_date);
                        vIoT_DeviceEDCs_099 = vIoT_DeviceEDCs_099.OrderBy(c => c.clm_date_time);
                        foreach (var vIoT_DeviceEDC in vIoT_DeviceEDCs_099)
                        {
                            IOT_DEVICE_EDC oIoT_DeviceEDC = new IOT_DEVICE_EDC();
                            oIoT_DeviceEDC.Clone(vIoT_DeviceEDC);
                            oIotDeviceEDCs.Add(oIoT_DeviceEDC);
                        }
                        break;
                    case 100:
                        var vIoT_DeviceEDCs_100 = IOT_DEVICE_EDC_100.AsQueryable();
                        vIoT_DeviceEDCs_100 = vIoT_DeviceEDCs_100.Where(c => c.device_id == device.device_id && c.clm_date_time >= start_date && c.clm_date_time <= end_date);
                        vIoT_DeviceEDCs_100 = vIoT_DeviceEDCs_100.OrderBy(c => c.clm_date_time);
                        foreach (var vIoT_DeviceEDC in vIoT_DeviceEDCs_100)
                        {
                            IOT_DEVICE_EDC oIoT_DeviceEDC = new IOT_DEVICE_EDC();
                            oIoT_DeviceEDC.Clone(vIoT_DeviceEDC);
                            oIotDeviceEDCs.Add(oIoT_DeviceEDC);
                        }
                        break;

                    case 101:
                        var vIoT_DeviceEDCs_101 = IOT_DEVICE_EDC_101.AsQueryable();
                        vIoT_DeviceEDCs_101 = vIoT_DeviceEDCs_101.Where(c => c.device_id == device.device_id && c.clm_date_time >= start_date && c.clm_date_time <= end_date);
                        vIoT_DeviceEDCs_101 = vIoT_DeviceEDCs_101.OrderBy(c => c.clm_date_time);
                        foreach (var vIoT_DeviceEDC in vIoT_DeviceEDCs_101)
                        {
                            IOT_DEVICE_EDC oIoT_DeviceEDC = new IOT_DEVICE_EDC();
                            oIoT_DeviceEDC.Clone(vIoT_DeviceEDC);
                            oIotDeviceEDCs.Add(oIoT_DeviceEDC);
                        }
                        break;
                    case 102:
                        var vIoT_DeviceEDCs_102 = IOT_DEVICE_EDC_102.AsQueryable();
                        vIoT_DeviceEDCs_102 = vIoT_DeviceEDCs_102.Where(c => c.device_id == device.device_id && c.clm_date_time >= start_date && c.clm_date_time <= end_date);
                        vIoT_DeviceEDCs_102 = vIoT_DeviceEDCs_102.OrderBy(c => c.clm_date_time);
                        foreach (var vIoT_DeviceEDC in vIoT_DeviceEDCs_102)
                        {
                            IOT_DEVICE_EDC oIoT_DeviceEDC = new IOT_DEVICE_EDC();
                            oIoT_DeviceEDC.Clone(vIoT_DeviceEDC);
                            oIotDeviceEDCs.Add(oIoT_DeviceEDC);
                        }

                        break;

                    case 103:
                        var vIoT_DeviceEDCs_103 = IOT_DEVICE_EDC_103.AsQueryable();
                        vIoT_DeviceEDCs_103 = vIoT_DeviceEDCs_103.Where(c => c.device_id == device.device_id && c.clm_date_time >= start_date && c.clm_date_time <= end_date);
                        vIoT_DeviceEDCs_103 = vIoT_DeviceEDCs_103.OrderBy(c => c.clm_date_time);
                        foreach (var vIoT_DeviceEDC in vIoT_DeviceEDCs_103)
                        {
                            IOT_DEVICE_EDC oIoT_DeviceEDC = new IOT_DEVICE_EDC();
                            oIoT_DeviceEDC.Clone(vIoT_DeviceEDC);
                            oIotDeviceEDCs.Add(oIoT_DeviceEDC);
                        }
                        break;

                    case 104:
                        var vIoT_DeviceEDCs_104 = IOT_DEVICE_EDC_104.AsQueryable();
                        vIoT_DeviceEDCs_104 = vIoT_DeviceEDCs_104.Where(c => c.device_id == device.device_id && c.clm_date_time >= start_date && c.clm_date_time <= end_date);
                        vIoT_DeviceEDCs_104 = vIoT_DeviceEDCs_104.OrderBy(c => c.clm_date_time);
                        foreach (var vIoT_DeviceEDC in vIoT_DeviceEDCs_104)
                        {
                            IOT_DEVICE_EDC oIoT_DeviceEDC = new IOT_DEVICE_EDC();
                            oIoT_DeviceEDC.Clone(vIoT_DeviceEDC);
                            oIotDeviceEDCs.Add(oIoT_DeviceEDC);
                        }
                        break;

                    case 105:
                        var vIoT_DeviceEDCs_105 = IOT_DEVICE_EDC_105.AsQueryable();
                        vIoT_DeviceEDCs_105 = vIoT_DeviceEDCs_105.Where(c => c.device_id == device.device_id && c.clm_date_time >= start_date && c.clm_date_time <= end_date);
                        vIoT_DeviceEDCs_105 = vIoT_DeviceEDCs_105.OrderBy(c => c.clm_date_time);
                        foreach (var vIoT_DeviceEDC in vIoT_DeviceEDCs_105)
                        {
                            IOT_DEVICE_EDC oIoT_DeviceEDC = new IOT_DEVICE_EDC();
                            oIoT_DeviceEDC.Clone(vIoT_DeviceEDC);
                            oIotDeviceEDCs.Add(oIoT_DeviceEDC);
                        }
                        break;

                    case 106:
                        var vIoT_DeviceEDCs_106 = IOT_DEVICE_EDC_106.AsQueryable();
                        vIoT_DeviceEDCs_106 = vIoT_DeviceEDCs_106.Where(c => c.device_id == device.device_id && c.clm_date_time >= start_date && c.clm_date_time <= end_date);
                        vIoT_DeviceEDCs_106 = vIoT_DeviceEDCs_106.OrderBy(c => c.clm_date_time);
                        foreach (var vIoT_DeviceEDC in vIoT_DeviceEDCs_106)
                        {
                            IOT_DEVICE_EDC oIoT_DeviceEDC = new IOT_DEVICE_EDC();
                            oIoT_DeviceEDC.Clone(vIoT_DeviceEDC);
                            oIotDeviceEDCs.Add(oIoT_DeviceEDC);
                        }
                        break;

                    case 107:
                        var vIoT_DeviceEDCs_107 = IOT_DEVICE_EDC_107.AsQueryable();
                        vIoT_DeviceEDCs_107 = vIoT_DeviceEDCs_107.Where(c => c.device_id == device.device_id && c.clm_date_time >= start_date && c.clm_date_time <= end_date);
                        vIoT_DeviceEDCs_107 = vIoT_DeviceEDCs_107.OrderBy(c => c.clm_date_time);
                        foreach (var vIoT_DeviceEDC in vIoT_DeviceEDCs_107)
                        {
                            IOT_DEVICE_EDC oIoT_DeviceEDC = new IOT_DEVICE_EDC();
                            oIoT_DeviceEDC.Clone(vIoT_DeviceEDC);
                            oIotDeviceEDCs.Add(oIoT_DeviceEDC);
                        }
                        break;

                    case 108:
                        var vIoT_DeviceEDCs_108 = IOT_DEVICE_EDC_108.AsQueryable();
                        vIoT_DeviceEDCs_108 = vIoT_DeviceEDCs_108.Where(c => c.device_id == device.device_id && c.clm_date_time >= start_date && c.clm_date_time <= end_date);
                        vIoT_DeviceEDCs_108 = vIoT_DeviceEDCs_108.OrderBy(c => c.clm_date_time);
                        foreach (var vIoT_DeviceEDC in vIoT_DeviceEDCs_108)
                        {
                            IOT_DEVICE_EDC oIoT_DeviceEDC = new IOT_DEVICE_EDC();
                            oIoT_DeviceEDC.Clone(vIoT_DeviceEDC);
                            oIotDeviceEDCs.Add(oIoT_DeviceEDC);
                        }
                        break;

                    case 109:
                        var vIoT_DeviceEDCs_109 = IOT_DEVICE_EDC_109.AsQueryable();
                        vIoT_DeviceEDCs_109 = vIoT_DeviceEDCs_109.Where(c => c.device_id == device.device_id && c.clm_date_time >= start_date && c.clm_date_time <= end_date);
                        vIoT_DeviceEDCs_109 = vIoT_DeviceEDCs_109.OrderBy(c => c.clm_date_time);
                        foreach (var vIoT_DeviceEDC in vIoT_DeviceEDCs_109)
                        {
                            IOT_DEVICE_EDC oIoT_DeviceEDC = new IOT_DEVICE_EDC();
                            oIoT_DeviceEDC.Clone(vIoT_DeviceEDC);
                            oIotDeviceEDCs.Add(oIoT_DeviceEDC);
                        }
                        break;

                    case 110:
                        var vIoT_DeviceEDCs_110 = IOT_DEVICE_EDC_110.AsQueryable();
                        vIoT_DeviceEDCs_110 = vIoT_DeviceEDCs_110.Where(c => c.device_id == device.device_id && c.clm_date_time >= start_date && c.clm_date_time <= end_date);
                        vIoT_DeviceEDCs_110 = vIoT_DeviceEDCs_110.OrderBy(c => c.clm_date_time);
                        foreach (var vIoT_DeviceEDC in vIoT_DeviceEDCs_110)
                        {
                            IOT_DEVICE_EDC oIoT_DeviceEDC = new IOT_DEVICE_EDC();
                            oIoT_DeviceEDC.Clone(vIoT_DeviceEDC);
                            oIotDeviceEDCs.Add(oIoT_DeviceEDC);
                        }
                        break;

                    case 111:
                        var vIoT_DeviceEDCs_111 = IOT_DEVICE_EDC_111.AsQueryable();
                        vIoT_DeviceEDCs_111 = vIoT_DeviceEDCs_111.Where(c => c.device_id == device.device_id && c.clm_date_time >= start_date && c.clm_date_time <= end_date);
                        vIoT_DeviceEDCs_111 = vIoT_DeviceEDCs_111.OrderBy(c => c.clm_date_time);
                        foreach (var vIoT_DeviceEDC in vIoT_DeviceEDCs_111)
                        {
                            IOT_DEVICE_EDC oIoT_DeviceEDC = new IOT_DEVICE_EDC();
                            oIoT_DeviceEDC.Clone(vIoT_DeviceEDC);
                            oIotDeviceEDCs.Add(oIoT_DeviceEDC);
                        }
                        break;
                    case 112:
                        var vIoT_DeviceEDCs_112 = IOT_DEVICE_EDC_112.AsQueryable();
                        vIoT_DeviceEDCs_112 = vIoT_DeviceEDCs_112.Where(c => c.device_id == device.device_id && c.clm_date_time >= start_date && c.clm_date_time <= end_date);
                        vIoT_DeviceEDCs_112 = vIoT_DeviceEDCs_112.OrderBy(c => c.clm_date_time);
                        foreach (var vIoT_DeviceEDC in vIoT_DeviceEDCs_112)
                        {
                            IOT_DEVICE_EDC oIoT_DeviceEDC = new IOT_DEVICE_EDC();
                            oIoT_DeviceEDC.Clone(vIoT_DeviceEDC);
                            oIotDeviceEDCs.Add(oIoT_DeviceEDC);
                        }

                        break;

                    case 113:
                        var vIoT_DeviceEDCs_113 = IOT_DEVICE_EDC_113.AsQueryable();
                        vIoT_DeviceEDCs_113 = vIoT_DeviceEDCs_113.Where(c => c.device_id == device.device_id && c.clm_date_time >= start_date && c.clm_date_time <= end_date);
                        vIoT_DeviceEDCs_113 = vIoT_DeviceEDCs_113.OrderBy(c => c.clm_date_time);
                        foreach (var vIoT_DeviceEDC in vIoT_DeviceEDCs_113)
                        {
                            IOT_DEVICE_EDC oIoT_DeviceEDC = new IOT_DEVICE_EDC();
                            oIoT_DeviceEDC.Clone(vIoT_DeviceEDC);
                            oIotDeviceEDCs.Add(oIoT_DeviceEDC);
                        }
                        break;

                    case 114:
                        var vIoT_DeviceEDCs_114 = IOT_DEVICE_EDC_114.AsQueryable();
                        vIoT_DeviceEDCs_114 = vIoT_DeviceEDCs_114.Where(c => c.device_id == device.device_id && c.clm_date_time >= start_date && c.clm_date_time <= end_date);
                        vIoT_DeviceEDCs_114 = vIoT_DeviceEDCs_114.OrderBy(c => c.clm_date_time);
                        foreach (var vIoT_DeviceEDC in vIoT_DeviceEDCs_114)
                        {
                            IOT_DEVICE_EDC oIoT_DeviceEDC = new IOT_DEVICE_EDC();
                            oIoT_DeviceEDC.Clone(vIoT_DeviceEDC);
                            oIotDeviceEDCs.Add(oIoT_DeviceEDC);
                        }
                        break;

                    case 115:
                        var vIoT_DeviceEDCs_115 = IOT_DEVICE_EDC_115.AsQueryable();
                        vIoT_DeviceEDCs_115 = vIoT_DeviceEDCs_115.Where(c => c.device_id == device.device_id && c.clm_date_time >= start_date && c.clm_date_time <= end_date);
                        vIoT_DeviceEDCs_115 = vIoT_DeviceEDCs_115.OrderBy(c => c.clm_date_time);
                        foreach (var vIoT_DeviceEDC in vIoT_DeviceEDCs_115)
                        {
                            IOT_DEVICE_EDC oIoT_DeviceEDC = new IOT_DEVICE_EDC();
                            oIoT_DeviceEDC.Clone(vIoT_DeviceEDC);
                            oIotDeviceEDCs.Add(oIoT_DeviceEDC);
                        }
                        break;

                    case 116:
                        var vIoT_DeviceEDCs_116 = IOT_DEVICE_EDC_116.AsQueryable();
                        vIoT_DeviceEDCs_116 = vIoT_DeviceEDCs_116.Where(c => c.device_id == device.device_id && c.clm_date_time >= start_date && c.clm_date_time <= end_date);
                        vIoT_DeviceEDCs_116 = vIoT_DeviceEDCs_116.OrderBy(c => c.clm_date_time);
                        foreach (var vIoT_DeviceEDC in vIoT_DeviceEDCs_116)
                        {
                            IOT_DEVICE_EDC oIoT_DeviceEDC = new IOT_DEVICE_EDC();
                            oIoT_DeviceEDC.Clone(vIoT_DeviceEDC);
                            oIotDeviceEDCs.Add(oIoT_DeviceEDC);
                        }
                        break;

                    case 117:
                        var vIoT_DeviceEDCs_117 = IOT_DEVICE_EDC_117.AsQueryable();
                        vIoT_DeviceEDCs_117 = vIoT_DeviceEDCs_117.Where(c => c.device_id == device.device_id && c.clm_date_time >= start_date && c.clm_date_time <= end_date);
                        vIoT_DeviceEDCs_117 = vIoT_DeviceEDCs_117.OrderBy(c => c.clm_date_time);
                        foreach (var vIoT_DeviceEDC in vIoT_DeviceEDCs_117)
                        {
                            IOT_DEVICE_EDC oIoT_DeviceEDC = new IOT_DEVICE_EDC();
                            oIoT_DeviceEDC.Clone(vIoT_DeviceEDC);
                            oIotDeviceEDCs.Add(oIoT_DeviceEDC);
                        }
                        break;

                    case 118:
                        var vIoT_DeviceEDCs_118 = IOT_DEVICE_EDC_118.AsQueryable();
                        vIoT_DeviceEDCs_118 = vIoT_DeviceEDCs_118.Where(c => c.device_id == device.device_id && c.clm_date_time >= start_date && c.clm_date_time <= end_date);
                        vIoT_DeviceEDCs_118 = vIoT_DeviceEDCs_118.OrderBy(c => c.clm_date_time);
                        foreach (var vIoT_DeviceEDC in vIoT_DeviceEDCs_118)
                        {
                            IOT_DEVICE_EDC oIoT_DeviceEDC = new IOT_DEVICE_EDC();
                            oIoT_DeviceEDC.Clone(vIoT_DeviceEDC);
                            oIotDeviceEDCs.Add(oIoT_DeviceEDC);
                        }
                        break;

                    case 119:
                        var vIoT_DeviceEDCs_119 = IOT_DEVICE_EDC_119.AsQueryable();
                        vIoT_DeviceEDCs_119 = vIoT_DeviceEDCs_119.Where(c => c.device_id == device.device_id && c.clm_date_time >= start_date && c.clm_date_time <= end_date);
                        vIoT_DeviceEDCs_119 = vIoT_DeviceEDCs_119.OrderBy(c => c.clm_date_time);
                        foreach (var vIoT_DeviceEDC in vIoT_DeviceEDCs_119)
                        {
                            IOT_DEVICE_EDC oIoT_DeviceEDC = new IOT_DEVICE_EDC();
                            oIoT_DeviceEDC.Clone(vIoT_DeviceEDC);
                            oIotDeviceEDCs.Add(oIoT_DeviceEDC);
                        }
                        break;
                    case 120:
                        var vIoT_DeviceEDCs_120 = IOT_DEVICE_EDC_120.AsQueryable();
                        vIoT_DeviceEDCs_120 = vIoT_DeviceEDCs_120.Where(c => c.device_id == device.device_id && c.clm_date_time >= start_date && c.clm_date_time <= end_date);
                        vIoT_DeviceEDCs_120 = vIoT_DeviceEDCs_120.OrderBy(c => c.clm_date_time);
                        foreach (var vIoT_DeviceEDC in vIoT_DeviceEDCs_120)
                        {
                            IOT_DEVICE_EDC oIoT_DeviceEDC = new IOT_DEVICE_EDC();
                            oIoT_DeviceEDC.Clone(vIoT_DeviceEDC);
                            oIotDeviceEDCs.Add(oIoT_DeviceEDC);
                        }
                        break;

                    case 121:
                        var vIoT_DeviceEDCs_121 = IOT_DEVICE_EDC_121.AsQueryable();
                        vIoT_DeviceEDCs_121 = vIoT_DeviceEDCs_121.Where(c => c.device_id == device.device_id && c.clm_date_time >= start_date && c.clm_date_time <= end_date);
                        vIoT_DeviceEDCs_121 = vIoT_DeviceEDCs_121.OrderBy(c => c.clm_date_time);
                        foreach (var vIoT_DeviceEDC in vIoT_DeviceEDCs_121)
                        {
                            IOT_DEVICE_EDC oIoT_DeviceEDC = new IOT_DEVICE_EDC();
                            oIoT_DeviceEDC.Clone(vIoT_DeviceEDC);
                            oIotDeviceEDCs.Add(oIoT_DeviceEDC);
                        }
                        break;
                    case 122:
                        var vIoT_DeviceEDCs_122 = IOT_DEVICE_EDC_122.AsQueryable();
                        vIoT_DeviceEDCs_122 = vIoT_DeviceEDCs_122.Where(c => c.device_id == device.device_id && c.clm_date_time >= start_date && c.clm_date_time <= end_date);
                        vIoT_DeviceEDCs_122 = vIoT_DeviceEDCs_122.OrderBy(c => c.clm_date_time);
                        foreach (var vIoT_DeviceEDC in vIoT_DeviceEDCs_122)
                        {
                            IOT_DEVICE_EDC oIoT_DeviceEDC = new IOT_DEVICE_EDC();
                            oIoT_DeviceEDC.Clone(vIoT_DeviceEDC);
                            oIotDeviceEDCs.Add(oIoT_DeviceEDC);
                        }

                        break;

                    case 123:
                        var vIoT_DeviceEDCs_123 = IOT_DEVICE_EDC_123.AsQueryable();
                        vIoT_DeviceEDCs_123 = vIoT_DeviceEDCs_123.Where(c => c.device_id == device.device_id && c.clm_date_time >= start_date && c.clm_date_time <= end_date);
                        vIoT_DeviceEDCs_123 = vIoT_DeviceEDCs_123.OrderBy(c => c.clm_date_time);
                        foreach (var vIoT_DeviceEDC in vIoT_DeviceEDCs_123)
                        {
                            IOT_DEVICE_EDC oIoT_DeviceEDC = new IOT_DEVICE_EDC();
                            oIoT_DeviceEDC.Clone(vIoT_DeviceEDC);
                            oIotDeviceEDCs.Add(oIoT_DeviceEDC);
                        }
                        break;

                    case 124:
                        var vIoT_DeviceEDCs_124 = IOT_DEVICE_EDC_124.AsQueryable();
                        vIoT_DeviceEDCs_124 = vIoT_DeviceEDCs_124.Where(c => c.device_id == device.device_id && c.clm_date_time >= start_date && c.clm_date_time <= end_date);
                        vIoT_DeviceEDCs_124 = vIoT_DeviceEDCs_124.OrderBy(c => c.clm_date_time);
                        foreach (var vIoT_DeviceEDC in vIoT_DeviceEDCs_124)
                        {
                            IOT_DEVICE_EDC oIoT_DeviceEDC = new IOT_DEVICE_EDC();
                            oIoT_DeviceEDC.Clone(vIoT_DeviceEDC);
                            oIotDeviceEDCs.Add(oIoT_DeviceEDC);
                        }
                        break;

                    case 125:
                        var vIoT_DeviceEDCs_125 = IOT_DEVICE_EDC_125.AsQueryable();
                        vIoT_DeviceEDCs_125 = vIoT_DeviceEDCs_125.Where(c => c.device_id == device.device_id && c.clm_date_time >= start_date && c.clm_date_time <= end_date);
                        vIoT_DeviceEDCs_125 = vIoT_DeviceEDCs_125.OrderBy(c => c.clm_date_time);
                        foreach (var vIoT_DeviceEDC in vIoT_DeviceEDCs_125)
                        {
                            IOT_DEVICE_EDC oIoT_DeviceEDC = new IOT_DEVICE_EDC();
                            oIoT_DeviceEDC.Clone(vIoT_DeviceEDC);
                            oIotDeviceEDCs.Add(oIoT_DeviceEDC);
                        }
                        break;

                    case 126:
                        var vIoT_DeviceEDCs_126 = IOT_DEVICE_EDC_126.AsQueryable();
                        vIoT_DeviceEDCs_126 = vIoT_DeviceEDCs_126.Where(c => c.device_id == device.device_id && c.clm_date_time >= start_date && c.clm_date_time <= end_date);
                        vIoT_DeviceEDCs_126 = vIoT_DeviceEDCs_126.OrderBy(c => c.clm_date_time);
                        foreach (var vIoT_DeviceEDC in vIoT_DeviceEDCs_126)
                        {
                            IOT_DEVICE_EDC oIoT_DeviceEDC = new IOT_DEVICE_EDC();
                            oIoT_DeviceEDC.Clone(vIoT_DeviceEDC);
                            oIotDeviceEDCs.Add(oIoT_DeviceEDC);
                        }
                        break;

                    case 127:
                        var vIoT_DeviceEDCs_127 = IOT_DEVICE_EDC_127.AsQueryable();
                        vIoT_DeviceEDCs_127 = vIoT_DeviceEDCs_127.Where(c => c.device_id == device.device_id && c.clm_date_time >= start_date && c.clm_date_time <= end_date);
                        vIoT_DeviceEDCs_127 = vIoT_DeviceEDCs_127.OrderBy(c => c.clm_date_time);
                        foreach (var vIoT_DeviceEDC in vIoT_DeviceEDCs_127)
                        {
                            IOT_DEVICE_EDC oIoT_DeviceEDC = new IOT_DEVICE_EDC();
                            oIoT_DeviceEDC.Clone(vIoT_DeviceEDC);
                            oIotDeviceEDCs.Add(oIoT_DeviceEDC);
                        }
                        break;

                    case 128:
                        var vIoT_DeviceEDCs_128 = IOT_DEVICE_EDC_128.AsQueryable();
                        vIoT_DeviceEDCs_128 = vIoT_DeviceEDCs_128.Where(c => c.device_id == device.device_id && c.clm_date_time >= start_date && c.clm_date_time <= end_date);
                        vIoT_DeviceEDCs_128 = vIoT_DeviceEDCs_128.OrderBy(c => c.clm_date_time);
                        foreach (var vIoT_DeviceEDC in vIoT_DeviceEDCs_128)
                        {
                            IOT_DEVICE_EDC oIoT_DeviceEDC = new IOT_DEVICE_EDC();
                            oIoT_DeviceEDC.Clone(vIoT_DeviceEDC);
                            oIotDeviceEDCs.Add(oIoT_DeviceEDC);
                        }
                        break;
                    default:
                        //
                        break;
                }



            }
            catch (Exception ex)
            {
                string err_msg = ex.Message;
                return (oIotDeviceEDCs);
            }

            return (oIotDeviceEDCs);
        }

        public IOT_DEVICE_EDC GetLatestEDC_ByDevice(IOT_DEVICE device)
        {

            IList<IOT_DEVICE_EDC> oIotDeviceEDCs = new List<IOT_DEVICE_EDC>();
            IOT_DEVICE_EDC oIoT_DeviceEDC = new IOT_DEVICE_EDC();

            try
            {

                switch (device.device_no)
                {
                    case 1:
                        var vIoT_DeviceEDCs_001 = IOT_DEVICE_EDC_001.AsQueryable(); ;
                        vIoT_DeviceEDCs_001 = vIoT_DeviceEDCs_001.Where(c => c.device_id == device.device_id );
                        vIoT_DeviceEDCs_001 = vIoT_DeviceEDCs_001.OrderByDescending(c => c.clm_date_time);
                        IOT_DEVICE_EDC_001 oIoT_DeviceEDC_001 = new IOT_DEVICE_EDC_001();
                        oIoT_DeviceEDC_001 = vIoT_DeviceEDCs_001.FirstOrDefault();
                        oIoT_DeviceEDC.Clone(oIoT_DeviceEDC_001);

                        break;
                    case 2:
                        var vIoT_DeviceEDCs_002 = IOT_DEVICE_EDC_002.AsQueryable(); ;
                        vIoT_DeviceEDCs_002 = vIoT_DeviceEDCs_002.Where(c => c.device_id == device.device_id );
                        vIoT_DeviceEDCs_002 = vIoT_DeviceEDCs_002.OrderByDescending(c => c.clm_date_time);
                        IOT_DEVICE_EDC_002 oIoT_DeviceEDC_002 = new IOT_DEVICE_EDC_002();
                        oIoT_DeviceEDC_002 = vIoT_DeviceEDCs_002.FirstOrDefault();
                        oIoT_DeviceEDC.Clone(oIoT_DeviceEDC_002);

                        break;

                    case 3:
                        var vIoT_DeviceEDCs_003 = IOT_DEVICE_EDC_003.AsQueryable(); ;
                        vIoT_DeviceEDCs_003 = vIoT_DeviceEDCs_003.Where(c => c.device_id == device.device_id );
                        vIoT_DeviceEDCs_003 = vIoT_DeviceEDCs_003.OrderByDescending(c => c.clm_date_time);
                        IOT_DEVICE_EDC_003 oIoT_DeviceEDC_003 = new IOT_DEVICE_EDC_003();
                        oIoT_DeviceEDC_003 = vIoT_DeviceEDCs_003.FirstOrDefault();
                        oIoT_DeviceEDC.Clone(oIoT_DeviceEDC_003);

                        break;

                    case 4:
                        var vIoT_DeviceEDCs_004 = IOT_DEVICE_EDC_004.AsQueryable(); ;
                        vIoT_DeviceEDCs_004 = vIoT_DeviceEDCs_004.Where(c => c.device_id == device.device_id); 
                        vIoT_DeviceEDCs_004 = vIoT_DeviceEDCs_004.OrderByDescending(c => c.clm_date_time);
                        IOT_DEVICE_EDC_004 oIoT_DeviceEDC_004 = new IOT_DEVICE_EDC_004();
                        oIoT_DeviceEDC_004 = vIoT_DeviceEDCs_004.FirstOrDefault();
                        oIoT_DeviceEDC.Clone(oIoT_DeviceEDC_004);

                        break;

                    case 5:
                        var vIoT_DeviceEDCs_005 = IOT_DEVICE_EDC_005.AsQueryable(); ;
                        vIoT_DeviceEDCs_005 = vIoT_DeviceEDCs_005.Where(c => c.device_id == device.device_id );
                        vIoT_DeviceEDCs_005 = vIoT_DeviceEDCs_005.OrderByDescending(c => c.clm_date_time);
                        IOT_DEVICE_EDC_005 oIoT_DeviceEDC_005 = new IOT_DEVICE_EDC_005();
                        oIoT_DeviceEDC_005 = vIoT_DeviceEDCs_005.FirstOrDefault();
                        oIoT_DeviceEDC.Clone(oIoT_DeviceEDC_005);

                        break;

                    case 6:
                        var vIoT_DeviceEDCs_006 = IOT_DEVICE_EDC_006.AsQueryable(); ;
                        vIoT_DeviceEDCs_006 = vIoT_DeviceEDCs_006.Where(c => c.device_id == device.device_id );
                        vIoT_DeviceEDCs_006 = vIoT_DeviceEDCs_006.OrderByDescending(c => c.clm_date_time);
                        IOT_DEVICE_EDC_006 oIoT_DeviceEDC_006 = new IOT_DEVICE_EDC_006();
                        oIoT_DeviceEDC_006 = vIoT_DeviceEDCs_006.FirstOrDefault();
                        oIoT_DeviceEDC.Clone(oIoT_DeviceEDC_006);

                        break;

                    case 7:
                        var vIoT_DeviceEDCs_007 = IOT_DEVICE_EDC_007.AsQueryable(); ;
                        vIoT_DeviceEDCs_007 = vIoT_DeviceEDCs_007.Where(c => c.device_id == device.device_id );
                        vIoT_DeviceEDCs_007 = vIoT_DeviceEDCs_007.OrderByDescending(c => c.clm_date_time);
                        IOT_DEVICE_EDC_007 oIoT_DeviceEDC_007 = new IOT_DEVICE_EDC_007();
                        oIoT_DeviceEDC_007 = vIoT_DeviceEDCs_007.FirstOrDefault();
                        oIoT_DeviceEDC.Clone(oIoT_DeviceEDC_007);

                        break;

                    case 8:
                        var vIoT_DeviceEDCs_008 = IOT_DEVICE_EDC_008.AsQueryable(); ;
                        vIoT_DeviceEDCs_008 = vIoT_DeviceEDCs_008.Where(c => c.device_id == device.device_id );
                        vIoT_DeviceEDCs_008 = vIoT_DeviceEDCs_008.OrderByDescending(c => c.clm_date_time);
                        IOT_DEVICE_EDC_008 oIoT_DeviceEDC_008 = new IOT_DEVICE_EDC_008();
                        oIoT_DeviceEDC_008 = vIoT_DeviceEDCs_008.FirstOrDefault();
                        oIoT_DeviceEDC.Clone(oIoT_DeviceEDC_008);

                        break;

                    case 9:
                        var vIoT_DeviceEDCs_009 = IOT_DEVICE_EDC_009.AsQueryable();
                        vIoT_DeviceEDCs_009 = vIoT_DeviceEDCs_009.Where(c => c.device_id == device.device_id );
                        vIoT_DeviceEDCs_009 = vIoT_DeviceEDCs_009.OrderByDescending(c => c.clm_date_time);
                        IOT_DEVICE_EDC_009 oIoT_DeviceEDC_009 = new IOT_DEVICE_EDC_009();
                        oIoT_DeviceEDC_009 = vIoT_DeviceEDCs_009.FirstOrDefault();
                        oIoT_DeviceEDC.Clone(oIoT_DeviceEDC_009);

                        break;
                    case 10:
                        var vIoT_DeviceEDCs_010 = IOT_DEVICE_EDC_010.AsQueryable();
                        vIoT_DeviceEDCs_010 = vIoT_DeviceEDCs_010.Where(c => c.device_id == device.device_id );
                        vIoT_DeviceEDCs_010 = vIoT_DeviceEDCs_010.OrderByDescending(c => c.clm_date_time);
                        IOT_DEVICE_EDC_010 oIoT_DeviceEDC_010 = new IOT_DEVICE_EDC_010();
                        oIoT_DeviceEDC_010 = vIoT_DeviceEDCs_010.FirstOrDefault();
                        oIoT_DeviceEDC.Clone(oIoT_DeviceEDC_010);

                        break;

                    case 11:
                        var vIoT_DeviceEDCs_011 = IOT_DEVICE_EDC_011.AsQueryable(); ;
                        vIoT_DeviceEDCs_011 = vIoT_DeviceEDCs_011.Where(c => c.device_id == device.device_id);
                        vIoT_DeviceEDCs_011 = vIoT_DeviceEDCs_011.OrderByDescending(c => c.clm_date_time);
                        IOT_DEVICE_EDC_011 oIoT_DeviceEDC_011 = new IOT_DEVICE_EDC_011();
                        oIoT_DeviceEDC_011 = vIoT_DeviceEDCs_011.FirstOrDefault();
                        oIoT_DeviceEDC.Clone(oIoT_DeviceEDC_011);

                        break;

                    case 12:
                        var vIoT_DeviceEDCs_012 = IOT_DEVICE_EDC_012.AsQueryable(); ;
                        vIoT_DeviceEDCs_012 = vIoT_DeviceEDCs_012.Where(c => c.device_id == device.device_id);
                        vIoT_DeviceEDCs_012 = vIoT_DeviceEDCs_012.OrderByDescending(c => c.clm_date_time);
                        IOT_DEVICE_EDC_012 oIoT_DeviceEDC_012 = new IOT_DEVICE_EDC_012();
                        oIoT_DeviceEDC_012 = vIoT_DeviceEDCs_012.FirstOrDefault();
                        oIoT_DeviceEDC.Clone(oIoT_DeviceEDC_012);

                        break;

                    case 13:
                        var vIoT_DeviceEDCs_013 = IOT_DEVICE_EDC_013.AsQueryable(); ;
                        vIoT_DeviceEDCs_013 = vIoT_DeviceEDCs_013.Where(c => c.device_id == device.device_id);
                        vIoT_DeviceEDCs_013 = vIoT_DeviceEDCs_013.OrderByDescending(c => c.clm_date_time);
                        IOT_DEVICE_EDC_013 oIoT_DeviceEDC_013 = new IOT_DEVICE_EDC_013();
                        oIoT_DeviceEDC_013 = vIoT_DeviceEDCs_013.FirstOrDefault();
                        oIoT_DeviceEDC.Clone(oIoT_DeviceEDC_013);

                        break;

                    case 14:
                        var vIoT_DeviceEDCs_014 = IOT_DEVICE_EDC_014.AsQueryable(); ;
                        vIoT_DeviceEDCs_014 = vIoT_DeviceEDCs_014.Where(c => c.device_id == device.device_id);
                        vIoT_DeviceEDCs_014 = vIoT_DeviceEDCs_014.OrderByDescending(c => c.clm_date_time);
                        IOT_DEVICE_EDC_014 oIoT_DeviceEDC_014 = new IOT_DEVICE_EDC_014();
                        oIoT_DeviceEDC_014 = vIoT_DeviceEDCs_014.FirstOrDefault();
                        oIoT_DeviceEDC.Clone(oIoT_DeviceEDC_014);

                        break;

                    case 15:
                        var vIoT_DeviceEDCs_015 = IOT_DEVICE_EDC_015.AsQueryable(); ;
                        vIoT_DeviceEDCs_015 = vIoT_DeviceEDCs_015.Where(c => c.device_id == device.device_id);
                        vIoT_DeviceEDCs_015 = vIoT_DeviceEDCs_015.OrderByDescending(c => c.clm_date_time);
                        IOT_DEVICE_EDC_015 oIoT_DeviceEDC_015 = new IOT_DEVICE_EDC_015();
                        oIoT_DeviceEDC_015 = vIoT_DeviceEDCs_015.FirstOrDefault();
                        oIoT_DeviceEDC.Clone(oIoT_DeviceEDC_015);

                        break;

                    case 16:
                        var vIoT_DeviceEDCs_016 = IOT_DEVICE_EDC_016.AsQueryable(); ;
                        vIoT_DeviceEDCs_016 = vIoT_DeviceEDCs_016.Where(c => c.device_id == device.device_id);
                        vIoT_DeviceEDCs_016 = vIoT_DeviceEDCs_016.OrderByDescending(c => c.clm_date_time);
                        IOT_DEVICE_EDC_016 oIoT_DeviceEDC_016 = new IOT_DEVICE_EDC_016();
                        oIoT_DeviceEDC_016 = vIoT_DeviceEDCs_016.FirstOrDefault();
                        oIoT_DeviceEDC.Clone(oIoT_DeviceEDC_016);

                        break;

                    case 17:
                        var vIoT_DeviceEDCs_017 = IOT_DEVICE_EDC_017.AsQueryable(); ;
                        vIoT_DeviceEDCs_017 = vIoT_DeviceEDCs_017.Where(c => c.device_id == device.device_id);
                        vIoT_DeviceEDCs_017 = vIoT_DeviceEDCs_017.OrderByDescending(c => c.clm_date_time);
                        IOT_DEVICE_EDC_017 oIoT_DeviceEDC_017 = new IOT_DEVICE_EDC_017();
                        oIoT_DeviceEDC_017 = vIoT_DeviceEDCs_017.FirstOrDefault();
                        oIoT_DeviceEDC.Clone(oIoT_DeviceEDC_017);

                        break;

                    case 18:
                        var vIoT_DeviceEDCs_018 = IOT_DEVICE_EDC_018.AsQueryable(); ;
                        vIoT_DeviceEDCs_018 = vIoT_DeviceEDCs_018.Where(c => c.device_id == device.device_id);
                        vIoT_DeviceEDCs_018 = vIoT_DeviceEDCs_018.OrderByDescending(c => c.clm_date_time);
                        IOT_DEVICE_EDC_018 oIoT_DeviceEDC_018 = new IOT_DEVICE_EDC_018();
                        oIoT_DeviceEDC_018 = vIoT_DeviceEDCs_018.FirstOrDefault();
                        oIoT_DeviceEDC.Clone(oIoT_DeviceEDC_018);

                        break;

                    case 19:
                        var vIoT_DeviceEDCs_019 = IOT_DEVICE_EDC_019.AsQueryable();
                        vIoT_DeviceEDCs_019 = vIoT_DeviceEDCs_019.Where(c => c.device_id == device.device_id);
                        vIoT_DeviceEDCs_019 = vIoT_DeviceEDCs_019.OrderByDescending(c => c.clm_date_time);
                        IOT_DEVICE_EDC_019 oIoT_DeviceEDC_019 = new IOT_DEVICE_EDC_019();
                        oIoT_DeviceEDC_019 = vIoT_DeviceEDCs_019.FirstOrDefault();
                        oIoT_DeviceEDC.Clone(oIoT_DeviceEDC_019);

                        break;

                    case 20:
                        var vIoT_DeviceEDCs_020 = IOT_DEVICE_EDC_020.AsQueryable();
                        vIoT_DeviceEDCs_020 = vIoT_DeviceEDCs_020.Where(c => c.device_id == device.device_id);
                        vIoT_DeviceEDCs_020 = vIoT_DeviceEDCs_020.OrderByDescending(c => c.clm_date_time);
                        IOT_DEVICE_EDC_020 oIoT_DeviceEDC_020 = new IOT_DEVICE_EDC_020();
                        oIoT_DeviceEDC_020 = vIoT_DeviceEDCs_020.FirstOrDefault();
                        oIoT_DeviceEDC.Clone(oIoT_DeviceEDC_020);

                        break;

                    case 21:
                        var vIoT_DeviceEDCs_021 = IOT_DEVICE_EDC_021.AsQueryable(); ;
                        vIoT_DeviceEDCs_021 = vIoT_DeviceEDCs_021.Where(c => c.device_id == device.device_id);
                        vIoT_DeviceEDCs_021 = vIoT_DeviceEDCs_021.OrderByDescending(c => c.clm_date_time);
                        IOT_DEVICE_EDC_021 oIoT_DeviceEDC_021 = new IOT_DEVICE_EDC_021();
                        oIoT_DeviceEDC_021 = vIoT_DeviceEDCs_021.FirstOrDefault();
                        oIoT_DeviceEDC.Clone(oIoT_DeviceEDC_021);

                        break;

                    case 22:
                        var vIoT_DeviceEDCs_022 = IOT_DEVICE_EDC_022.AsQueryable(); ;
                        vIoT_DeviceEDCs_022 = vIoT_DeviceEDCs_022.Where(c => c.device_id == device.device_id);
                        vIoT_DeviceEDCs_022 = vIoT_DeviceEDCs_022.OrderByDescending(c => c.clm_date_time);
                        IOT_DEVICE_EDC_022 oIoT_DeviceEDC_022 = new IOT_DEVICE_EDC_022();
                        oIoT_DeviceEDC_022 = vIoT_DeviceEDCs_022.FirstOrDefault();
                        oIoT_DeviceEDC.Clone(oIoT_DeviceEDC_022);

                        break;

                    case 23:
                        var vIoT_DeviceEDCs_023 = IOT_DEVICE_EDC_023.AsQueryable(); ;
                        vIoT_DeviceEDCs_023 = vIoT_DeviceEDCs_023.Where(c => c.device_id == device.device_id);
                        vIoT_DeviceEDCs_023 = vIoT_DeviceEDCs_023.OrderByDescending(c => c.clm_date_time);
                        IOT_DEVICE_EDC_023 oIoT_DeviceEDC_023 = new IOT_DEVICE_EDC_023();
                        oIoT_DeviceEDC_023 = vIoT_DeviceEDCs_023.FirstOrDefault();
                        oIoT_DeviceEDC.Clone(oIoT_DeviceEDC_023);

                        break;

                    case 24:
                        var vIoT_DeviceEDCs_024 = IOT_DEVICE_EDC_024.AsQueryable(); ;
                        vIoT_DeviceEDCs_024 = vIoT_DeviceEDCs_024.Where(c => c.device_id == device.device_id);
                        vIoT_DeviceEDCs_024 = vIoT_DeviceEDCs_024.OrderByDescending(c => c.clm_date_time);
                        IOT_DEVICE_EDC_024 oIoT_DeviceEDC_024 = new IOT_DEVICE_EDC_024();
                        oIoT_DeviceEDC_024 = vIoT_DeviceEDCs_024.FirstOrDefault();
                        oIoT_DeviceEDC.Clone(oIoT_DeviceEDC_024);

                        break;

                    case 25:
                        var vIoT_DeviceEDCs_025 = IOT_DEVICE_EDC_025.AsQueryable(); ;
                        vIoT_DeviceEDCs_025 = vIoT_DeviceEDCs_025.Where(c => c.device_id == device.device_id);
                        vIoT_DeviceEDCs_025 = vIoT_DeviceEDCs_025.OrderByDescending(c => c.clm_date_time);
                        IOT_DEVICE_EDC_025 oIoT_DeviceEDC_025 = new IOT_DEVICE_EDC_025();
                        oIoT_DeviceEDC_025 = vIoT_DeviceEDCs_025.FirstOrDefault();
                        oIoT_DeviceEDC.Clone(oIoT_DeviceEDC_025);

                        break;

                    case 26:
                        var vIoT_DeviceEDCs_026 = IOT_DEVICE_EDC_026.AsQueryable(); ;
                        vIoT_DeviceEDCs_026 = vIoT_DeviceEDCs_026.Where(c => c.device_id == device.device_id);
                        vIoT_DeviceEDCs_026 = vIoT_DeviceEDCs_026.OrderByDescending(c => c.clm_date_time);
                        IOT_DEVICE_EDC_026 oIoT_DeviceEDC_026 = new IOT_DEVICE_EDC_026();
                        oIoT_DeviceEDC_026 = vIoT_DeviceEDCs_026.FirstOrDefault();
                        oIoT_DeviceEDC.Clone(oIoT_DeviceEDC_026);

                        break;

                    case 27:
                        var vIoT_DeviceEDCs_027 = IOT_DEVICE_EDC_027.AsQueryable(); ;
                        vIoT_DeviceEDCs_027 = vIoT_DeviceEDCs_027.Where(c => c.device_id == device.device_id);
                        vIoT_DeviceEDCs_027 = vIoT_DeviceEDCs_027.OrderByDescending(c => c.clm_date_time);
                        IOT_DEVICE_EDC_027 oIoT_DeviceEDC_027 = new IOT_DEVICE_EDC_027();
                        oIoT_DeviceEDC_027 = vIoT_DeviceEDCs_027.FirstOrDefault();
                        oIoT_DeviceEDC.Clone(oIoT_DeviceEDC_027);

                        break;

                    case 28:
                        var vIoT_DeviceEDCs_028 = IOT_DEVICE_EDC_028.AsQueryable(); ;
                        vIoT_DeviceEDCs_028 = vIoT_DeviceEDCs_028.Where(c => c.device_id == device.device_id);
                        vIoT_DeviceEDCs_028 = vIoT_DeviceEDCs_028.OrderByDescending(c => c.clm_date_time);
                        IOT_DEVICE_EDC_028 oIoT_DeviceEDC_028 = new IOT_DEVICE_EDC_028();
                        oIoT_DeviceEDC_028 = vIoT_DeviceEDCs_028.FirstOrDefault();
                        oIoT_DeviceEDC.Clone(oIoT_DeviceEDC_028);

                        break;

                    case 29:
                        var vIoT_DeviceEDCs_029 = IOT_DEVICE_EDC_029.AsQueryable();
                        vIoT_DeviceEDCs_029 = vIoT_DeviceEDCs_029.Where(c => c.device_id == device.device_id);
                        vIoT_DeviceEDCs_029 = vIoT_DeviceEDCs_029.OrderByDescending(c => c.clm_date_time);
                        IOT_DEVICE_EDC_029 oIoT_DeviceEDC_029 = new IOT_DEVICE_EDC_029();
                        oIoT_DeviceEDC_029 = vIoT_DeviceEDCs_029.FirstOrDefault();
                        oIoT_DeviceEDC.Clone(oIoT_DeviceEDC_029);

                        break;

                    case 30:
                        var vIoT_DeviceEDCs_030 = IOT_DEVICE_EDC_030.AsQueryable();
                        vIoT_DeviceEDCs_030 = vIoT_DeviceEDCs_030.Where(c => c.device_id == device.device_id);
                        vIoT_DeviceEDCs_030 = vIoT_DeviceEDCs_030.OrderByDescending(c => c.clm_date_time);
                        IOT_DEVICE_EDC_030 oIoT_DeviceEDC_030 = new IOT_DEVICE_EDC_030();
                        oIoT_DeviceEDC_030 = vIoT_DeviceEDCs_030.FirstOrDefault();
                        oIoT_DeviceEDC.Clone(oIoT_DeviceEDC_030);

                        break;

                    case 31:
                        var vIoT_DeviceEDCs_031 = IOT_DEVICE_EDC_031.AsQueryable(); ;
                        vIoT_DeviceEDCs_031 = vIoT_DeviceEDCs_031.Where(c => c.device_id == device.device_id);
                        vIoT_DeviceEDCs_031 = vIoT_DeviceEDCs_031.OrderByDescending(c => c.clm_date_time);
                        IOT_DEVICE_EDC_031 oIoT_DeviceEDC_031 = new IOT_DEVICE_EDC_031();
                        oIoT_DeviceEDC_031 = vIoT_DeviceEDCs_031.FirstOrDefault();
                        oIoT_DeviceEDC.Clone(oIoT_DeviceEDC_031);

                        break;

                    case 32:
                        var vIoT_DeviceEDCs_032 = IOT_DEVICE_EDC_032.AsQueryable(); ;
                        vIoT_DeviceEDCs_032 = vIoT_DeviceEDCs_032.Where(c => c.device_id == device.device_id);
                        vIoT_DeviceEDCs_032 = vIoT_DeviceEDCs_032.OrderByDescending(c => c.clm_date_time);
                        IOT_DEVICE_EDC_032 oIoT_DeviceEDC_032 = new IOT_DEVICE_EDC_032();
                        oIoT_DeviceEDC_032 = vIoT_DeviceEDCs_032.FirstOrDefault();
                        oIoT_DeviceEDC.Clone(oIoT_DeviceEDC_032);

                        break;

                    case 33:
                        var vIoT_DeviceEDCs_033 = IOT_DEVICE_EDC_033.AsQueryable(); ;
                        vIoT_DeviceEDCs_033 = vIoT_DeviceEDCs_033.Where(c => c.device_id == device.device_id);
                        vIoT_DeviceEDCs_033 = vIoT_DeviceEDCs_033.OrderByDescending(c => c.clm_date_time);
                        IOT_DEVICE_EDC_033 oIoT_DeviceEDC_033 = new IOT_DEVICE_EDC_033();
                        oIoT_DeviceEDC_033 = vIoT_DeviceEDCs_033.FirstOrDefault();
                        oIoT_DeviceEDC.Clone(oIoT_DeviceEDC_033);

                        break;

                    case 34:
                        var vIoT_DeviceEDCs_034 = IOT_DEVICE_EDC_034.AsQueryable(); ;
                        vIoT_DeviceEDCs_034 = vIoT_DeviceEDCs_034.Where(c => c.device_id == device.device_id);
                        vIoT_DeviceEDCs_034 = vIoT_DeviceEDCs_034.OrderByDescending(c => c.clm_date_time);
                        IOT_DEVICE_EDC_034 oIoT_DeviceEDC_034 = new IOT_DEVICE_EDC_034();
                        oIoT_DeviceEDC_034 = vIoT_DeviceEDCs_034.FirstOrDefault();
                        oIoT_DeviceEDC.Clone(oIoT_DeviceEDC_034);

                        break;

                    case 35:
                        var vIoT_DeviceEDCs_035 = IOT_DEVICE_EDC_035.AsQueryable(); ;
                        vIoT_DeviceEDCs_035 = vIoT_DeviceEDCs_035.Where(c => c.device_id == device.device_id);
                        vIoT_DeviceEDCs_035 = vIoT_DeviceEDCs_035.OrderByDescending(c => c.clm_date_time);
                        IOT_DEVICE_EDC_035 oIoT_DeviceEDC_035 = new IOT_DEVICE_EDC_035();
                        oIoT_DeviceEDC_035 = vIoT_DeviceEDCs_035.FirstOrDefault();
                        oIoT_DeviceEDC.Clone(oIoT_DeviceEDC_035);

                        break;

                    case 36:
                        var vIoT_DeviceEDCs_036 = IOT_DEVICE_EDC_036.AsQueryable(); ;
                        vIoT_DeviceEDCs_036 = vIoT_DeviceEDCs_036.Where(c => c.device_id == device.device_id);
                        vIoT_DeviceEDCs_036 = vIoT_DeviceEDCs_036.OrderByDescending(c => c.clm_date_time);
                        IOT_DEVICE_EDC_036 oIoT_DeviceEDC_036 = new IOT_DEVICE_EDC_036();
                        oIoT_DeviceEDC_036 = vIoT_DeviceEDCs_036.FirstOrDefault();
                        oIoT_DeviceEDC.Clone(oIoT_DeviceEDC_036);

                        break;

                    case 37:
                        var vIoT_DeviceEDCs_037 = IOT_DEVICE_EDC_037.AsQueryable(); ;
                        vIoT_DeviceEDCs_037 = vIoT_DeviceEDCs_037.Where(c => c.device_id == device.device_id);
                        vIoT_DeviceEDCs_037 = vIoT_DeviceEDCs_037.OrderByDescending(c => c.clm_date_time);
                        IOT_DEVICE_EDC_037 oIoT_DeviceEDC_037 = new IOT_DEVICE_EDC_037();
                        oIoT_DeviceEDC_037 = vIoT_DeviceEDCs_037.FirstOrDefault();
                        oIoT_DeviceEDC.Clone(oIoT_DeviceEDC_037);

                        break;

                    case 38:
                        var vIoT_DeviceEDCs_038 = IOT_DEVICE_EDC_038.AsQueryable(); ;
                        vIoT_DeviceEDCs_038 = vIoT_DeviceEDCs_038.Where(c => c.device_id == device.device_id);
                        vIoT_DeviceEDCs_038 = vIoT_DeviceEDCs_038.OrderByDescending(c => c.clm_date_time);
                        IOT_DEVICE_EDC_038 oIoT_DeviceEDC_038 = new IOT_DEVICE_EDC_038();
                        oIoT_DeviceEDC_038 = vIoT_DeviceEDCs_038.FirstOrDefault();
                        oIoT_DeviceEDC.Clone(oIoT_DeviceEDC_038);

                        break;

                    case 39:
                        var vIoT_DeviceEDCs_039 = IOT_DEVICE_EDC_039.AsQueryable();
                        vIoT_DeviceEDCs_039 = vIoT_DeviceEDCs_039.Where(c => c.device_id == device.device_id);
                        vIoT_DeviceEDCs_039 = vIoT_DeviceEDCs_039.OrderByDescending(c => c.clm_date_time);
                        IOT_DEVICE_EDC_039 oIoT_DeviceEDC_039 = new IOT_DEVICE_EDC_039();
                        oIoT_DeviceEDC_039 = vIoT_DeviceEDCs_039.FirstOrDefault();
                        oIoT_DeviceEDC.Clone(oIoT_DeviceEDC_039);

                        break;

                    case 40:
                        var vIoT_DeviceEDCs_040 = IOT_DEVICE_EDC_040.AsQueryable();
                        vIoT_DeviceEDCs_040 = vIoT_DeviceEDCs_040.Where(c => c.device_id == device.device_id);
                        vIoT_DeviceEDCs_040 = vIoT_DeviceEDCs_040.OrderByDescending(c => c.clm_date_time);
                        IOT_DEVICE_EDC_040 oIoT_DeviceEDC_040 = new IOT_DEVICE_EDC_040();
                        oIoT_DeviceEDC_040 = vIoT_DeviceEDCs_040.FirstOrDefault();
                        oIoT_DeviceEDC.Clone(oIoT_DeviceEDC_040);

                        break;

                    case 41:
                        var vIoT_DeviceEDCs_041 = IOT_DEVICE_EDC_041.AsQueryable(); ;
                        vIoT_DeviceEDCs_041 = vIoT_DeviceEDCs_041.Where(c => c.device_id == device.device_id);
                        vIoT_DeviceEDCs_041 = vIoT_DeviceEDCs_041.OrderByDescending(c => c.clm_date_time);
                        IOT_DEVICE_EDC_041 oIoT_DeviceEDC_041 = new IOT_DEVICE_EDC_041();
                        oIoT_DeviceEDC_041 = vIoT_DeviceEDCs_041.FirstOrDefault();
                        oIoT_DeviceEDC.Clone(oIoT_DeviceEDC_041);

                        break;

                    case 42:
                        var vIoT_DeviceEDCs_042 = IOT_DEVICE_EDC_042.AsQueryable(); ;
                        vIoT_DeviceEDCs_042 = vIoT_DeviceEDCs_042.Where(c => c.device_id == device.device_id);
                        vIoT_DeviceEDCs_042 = vIoT_DeviceEDCs_042.OrderByDescending(c => c.clm_date_time);
                        IOT_DEVICE_EDC_042 oIoT_DeviceEDC_042 = new IOT_DEVICE_EDC_042();
                        oIoT_DeviceEDC_042 = vIoT_DeviceEDCs_042.FirstOrDefault();
                        oIoT_DeviceEDC.Clone(oIoT_DeviceEDC_042);

                        break;

                    case 43:
                        var vIoT_DeviceEDCs_043 = IOT_DEVICE_EDC_043.AsQueryable(); ;
                        vIoT_DeviceEDCs_043 = vIoT_DeviceEDCs_043.Where(c => c.device_id == device.device_id);
                        vIoT_DeviceEDCs_043 = vIoT_DeviceEDCs_043.OrderByDescending(c => c.clm_date_time);
                        IOT_DEVICE_EDC_043 oIoT_DeviceEDC_043 = new IOT_DEVICE_EDC_043();
                        oIoT_DeviceEDC_043 = vIoT_DeviceEDCs_043.FirstOrDefault();
                        oIoT_DeviceEDC.Clone(oIoT_DeviceEDC_043);

                        break;

                    case 44:
                        var vIoT_DeviceEDCs_044 = IOT_DEVICE_EDC_044.AsQueryable(); ;
                        vIoT_DeviceEDCs_044 = vIoT_DeviceEDCs_044.Where(c => c.device_id == device.device_id);
                        vIoT_DeviceEDCs_044 = vIoT_DeviceEDCs_044.OrderByDescending(c => c.clm_date_time);
                        IOT_DEVICE_EDC_044 oIoT_DeviceEDC_044 = new IOT_DEVICE_EDC_044();
                        oIoT_DeviceEDC_044 = vIoT_DeviceEDCs_044.FirstOrDefault();
                        oIoT_DeviceEDC.Clone(oIoT_DeviceEDC_044);

                        break;

                    case 45:
                        var vIoT_DeviceEDCs_045 = IOT_DEVICE_EDC_045.AsQueryable(); ;
                        vIoT_DeviceEDCs_045 = vIoT_DeviceEDCs_045.Where(c => c.device_id == device.device_id);
                        vIoT_DeviceEDCs_045 = vIoT_DeviceEDCs_045.OrderByDescending(c => c.clm_date_time);
                        IOT_DEVICE_EDC_045 oIoT_DeviceEDC_045 = new IOT_DEVICE_EDC_045();
                        oIoT_DeviceEDC_045 = vIoT_DeviceEDCs_045.FirstOrDefault();
                        oIoT_DeviceEDC.Clone(oIoT_DeviceEDC_045);

                        break;

                    case 46:
                        var vIoT_DeviceEDCs_046 = IOT_DEVICE_EDC_046.AsQueryable(); ;
                        vIoT_DeviceEDCs_046 = vIoT_DeviceEDCs_046.Where(c => c.device_id == device.device_id);
                        vIoT_DeviceEDCs_046 = vIoT_DeviceEDCs_046.OrderByDescending(c => c.clm_date_time);
                        IOT_DEVICE_EDC_046 oIoT_DeviceEDC_046 = new IOT_DEVICE_EDC_046();
                        oIoT_DeviceEDC_046 = vIoT_DeviceEDCs_046.FirstOrDefault();
                        oIoT_DeviceEDC.Clone(oIoT_DeviceEDC_046);

                        break;

                    case 47:
                        var vIoT_DeviceEDCs_047 = IOT_DEVICE_EDC_047.AsQueryable(); ;
                        vIoT_DeviceEDCs_047 = vIoT_DeviceEDCs_047.Where(c => c.device_id == device.device_id);
                        vIoT_DeviceEDCs_047 = vIoT_DeviceEDCs_047.OrderByDescending(c => c.clm_date_time);
                        IOT_DEVICE_EDC_047 oIoT_DeviceEDC_047 = new IOT_DEVICE_EDC_047();
                        oIoT_DeviceEDC_047 = vIoT_DeviceEDCs_047.FirstOrDefault();
                        oIoT_DeviceEDC.Clone(oIoT_DeviceEDC_047);

                        break;

                    case 48:
                        var vIoT_DeviceEDCs_048 = IOT_DEVICE_EDC_048.AsQueryable(); ;
                        vIoT_DeviceEDCs_048 = vIoT_DeviceEDCs_048.Where(c => c.device_id == device.device_id);
                        vIoT_DeviceEDCs_048 = vIoT_DeviceEDCs_048.OrderByDescending(c => c.clm_date_time);
                        IOT_DEVICE_EDC_048 oIoT_DeviceEDC_048 = new IOT_DEVICE_EDC_048();
                        oIoT_DeviceEDC_048 = vIoT_DeviceEDCs_048.FirstOrDefault();
                        oIoT_DeviceEDC.Clone(oIoT_DeviceEDC_048);

                        break;

                    case 49:
                        var vIoT_DeviceEDCs_049 = IOT_DEVICE_EDC_049.AsQueryable();
                        vIoT_DeviceEDCs_049 = vIoT_DeviceEDCs_049.Where(c => c.device_id == device.device_id);
                        vIoT_DeviceEDCs_049 = vIoT_DeviceEDCs_049.OrderByDescending(c => c.clm_date_time);
                        IOT_DEVICE_EDC_049 oIoT_DeviceEDC_049 = new IOT_DEVICE_EDC_049();
                        oIoT_DeviceEDC_049 = vIoT_DeviceEDCs_049.FirstOrDefault();
                        oIoT_DeviceEDC.Clone(oIoT_DeviceEDC_049);

                        break;

                    case 50:
                        var vIoT_DeviceEDCs_050 = IOT_DEVICE_EDC_050.AsQueryable();
                        vIoT_DeviceEDCs_050 = vIoT_DeviceEDCs_050.Where(c => c.device_id == device.device_id);
                        vIoT_DeviceEDCs_050 = vIoT_DeviceEDCs_050.OrderByDescending(c => c.clm_date_time);
                        IOT_DEVICE_EDC_050 oIoT_DeviceEDC_050 = new IOT_DEVICE_EDC_050();
                        oIoT_DeviceEDC_050 = vIoT_DeviceEDCs_050.FirstOrDefault();
                        oIoT_DeviceEDC.Clone(oIoT_DeviceEDC_050);

                        break;

                    case 51:
                        var vIoT_DeviceEDCs_051 = IOT_DEVICE_EDC_051.AsQueryable(); ;
                        vIoT_DeviceEDCs_051 = vIoT_DeviceEDCs_051.Where(c => c.device_id == device.device_id);
                        vIoT_DeviceEDCs_051 = vIoT_DeviceEDCs_051.OrderByDescending(c => c.clm_date_time);
                        IOT_DEVICE_EDC_051 oIoT_DeviceEDC_051 = new IOT_DEVICE_EDC_051();
                        oIoT_DeviceEDC_051 = vIoT_DeviceEDCs_051.FirstOrDefault();
                        oIoT_DeviceEDC.Clone(oIoT_DeviceEDC_051);

                        break;

                    case 52:
                        var vIoT_DeviceEDCs_052 = IOT_DEVICE_EDC_052.AsQueryable(); ;
                        vIoT_DeviceEDCs_052 = vIoT_DeviceEDCs_052.Where(c => c.device_id == device.device_id);
                        vIoT_DeviceEDCs_052 = vIoT_DeviceEDCs_052.OrderByDescending(c => c.clm_date_time);
                        IOT_DEVICE_EDC_052 oIoT_DeviceEDC_052 = new IOT_DEVICE_EDC_052();
                        oIoT_DeviceEDC_052 = vIoT_DeviceEDCs_052.FirstOrDefault();
                        oIoT_DeviceEDC.Clone(oIoT_DeviceEDC_052);

                        break;

                    case 53:
                        var vIoT_DeviceEDCs_053 = IOT_DEVICE_EDC_053.AsQueryable(); ;
                        vIoT_DeviceEDCs_053 = vIoT_DeviceEDCs_053.Where(c => c.device_id == device.device_id);
                        vIoT_DeviceEDCs_053 = vIoT_DeviceEDCs_053.OrderByDescending(c => c.clm_date_time);
                        IOT_DEVICE_EDC_053 oIoT_DeviceEDC_053 = new IOT_DEVICE_EDC_053();
                        oIoT_DeviceEDC_053 = vIoT_DeviceEDCs_053.FirstOrDefault();
                        oIoT_DeviceEDC.Clone(oIoT_DeviceEDC_053);

                        break;

                    case 54:
                        var vIoT_DeviceEDCs_054 = IOT_DEVICE_EDC_054.AsQueryable(); ;
                        vIoT_DeviceEDCs_054 = vIoT_DeviceEDCs_054.Where(c => c.device_id == device.device_id);
                        vIoT_DeviceEDCs_054 = vIoT_DeviceEDCs_054.OrderByDescending(c => c.clm_date_time);
                        IOT_DEVICE_EDC_054 oIoT_DeviceEDC_054 = new IOT_DEVICE_EDC_054();
                        oIoT_DeviceEDC_054 = vIoT_DeviceEDCs_054.FirstOrDefault();
                        oIoT_DeviceEDC.Clone(oIoT_DeviceEDC_054);

                        break;

                    case 55:
                        var vIoT_DeviceEDCs_055 = IOT_DEVICE_EDC_055.AsQueryable(); ;
                        vIoT_DeviceEDCs_055 = vIoT_DeviceEDCs_055.Where(c => c.device_id == device.device_id);
                        vIoT_DeviceEDCs_055 = vIoT_DeviceEDCs_055.OrderByDescending(c => c.clm_date_time);
                        IOT_DEVICE_EDC_055 oIoT_DeviceEDC_055 = new IOT_DEVICE_EDC_055();
                        oIoT_DeviceEDC_055 = vIoT_DeviceEDCs_055.FirstOrDefault();
                        oIoT_DeviceEDC.Clone(oIoT_DeviceEDC_055);

                        break;

                    case 56:
                        var vIoT_DeviceEDCs_056 = IOT_DEVICE_EDC_056.AsQueryable(); ;
                        vIoT_DeviceEDCs_056 = vIoT_DeviceEDCs_056.Where(c => c.device_id == device.device_id);
                        vIoT_DeviceEDCs_056 = vIoT_DeviceEDCs_056.OrderByDescending(c => c.clm_date_time);
                        IOT_DEVICE_EDC_056 oIoT_DeviceEDC_056 = new IOT_DEVICE_EDC_056();
                        oIoT_DeviceEDC_056 = vIoT_DeviceEDCs_056.FirstOrDefault();
                        oIoT_DeviceEDC.Clone(oIoT_DeviceEDC_056);

                        break;

                    case 57:
                        var vIoT_DeviceEDCs_057 = IOT_DEVICE_EDC_057.AsQueryable(); ;
                        vIoT_DeviceEDCs_057 = vIoT_DeviceEDCs_057.Where(c => c.device_id == device.device_id);
                        vIoT_DeviceEDCs_057 = vIoT_DeviceEDCs_057.OrderByDescending(c => c.clm_date_time);
                        IOT_DEVICE_EDC_057 oIoT_DeviceEDC_057 = new IOT_DEVICE_EDC_057();
                        oIoT_DeviceEDC_057 = vIoT_DeviceEDCs_057.FirstOrDefault();
                        oIoT_DeviceEDC.Clone(oIoT_DeviceEDC_057);

                        break;

                    case 58:
                        var vIoT_DeviceEDCs_058 = IOT_DEVICE_EDC_058.AsQueryable(); ;
                        vIoT_DeviceEDCs_058 = vIoT_DeviceEDCs_058.Where(c => c.device_id == device.device_id);
                        vIoT_DeviceEDCs_058 = vIoT_DeviceEDCs_058.OrderByDescending(c => c.clm_date_time);
                        IOT_DEVICE_EDC_058 oIoT_DeviceEDC_058 = new IOT_DEVICE_EDC_058();
                        oIoT_DeviceEDC_058 = vIoT_DeviceEDCs_058.FirstOrDefault();
                        oIoT_DeviceEDC.Clone(oIoT_DeviceEDC_058);

                        break;

                    case 59:
                        var vIoT_DeviceEDCs_059 = IOT_DEVICE_EDC_059.AsQueryable();
                        vIoT_DeviceEDCs_059 = vIoT_DeviceEDCs_059.Where(c => c.device_id == device.device_id);
                        vIoT_DeviceEDCs_059 = vIoT_DeviceEDCs_059.OrderByDescending(c => c.clm_date_time);
                        IOT_DEVICE_EDC_059 oIoT_DeviceEDC_059 = new IOT_DEVICE_EDC_059();
                        oIoT_DeviceEDC_059 = vIoT_DeviceEDCs_059.FirstOrDefault();
                        oIoT_DeviceEDC.Clone(oIoT_DeviceEDC_059);

                        break;
                    case 60:
                        var vIoT_DeviceEDCs_060 = IOT_DEVICE_EDC_060.AsQueryable();
                        vIoT_DeviceEDCs_060 = vIoT_DeviceEDCs_060.Where(c => c.device_id == device.device_id);
                        vIoT_DeviceEDCs_060 = vIoT_DeviceEDCs_060.OrderByDescending(c => c.clm_date_time);
                        IOT_DEVICE_EDC_060 oIoT_DeviceEDC_060 = new IOT_DEVICE_EDC_060();
                        oIoT_DeviceEDC_060 = vIoT_DeviceEDCs_060.FirstOrDefault();
                        oIoT_DeviceEDC.Clone(oIoT_DeviceEDC_060);

                        break;

                    case 61:
                        var vIoT_DeviceEDCs_061 = IOT_DEVICE_EDC_061.AsQueryable(); ;
                        vIoT_DeviceEDCs_061 = vIoT_DeviceEDCs_061.Where(c => c.device_id == device.device_id);
                        vIoT_DeviceEDCs_061 = vIoT_DeviceEDCs_061.OrderByDescending(c => c.clm_date_time);
                        IOT_DEVICE_EDC_061 oIoT_DeviceEDC_061 = new IOT_DEVICE_EDC_061();
                        oIoT_DeviceEDC_061 = vIoT_DeviceEDCs_061.FirstOrDefault();
                        oIoT_DeviceEDC.Clone(oIoT_DeviceEDC_061);

                        break;

                    case 62:
                        var vIoT_DeviceEDCs_062 = IOT_DEVICE_EDC_062.AsQueryable(); ;
                        vIoT_DeviceEDCs_062 = vIoT_DeviceEDCs_062.Where(c => c.device_id == device.device_id);
                        vIoT_DeviceEDCs_062 = vIoT_DeviceEDCs_062.OrderByDescending(c => c.clm_date_time);
                        IOT_DEVICE_EDC_062 oIoT_DeviceEDC_062 = new IOT_DEVICE_EDC_062();
                        oIoT_DeviceEDC_062 = vIoT_DeviceEDCs_062.FirstOrDefault();
                        oIoT_DeviceEDC.Clone(oIoT_DeviceEDC_062);

                        break;

                    case 63:
                        var vIoT_DeviceEDCs_063 = IOT_DEVICE_EDC_063.AsQueryable(); ;
                        vIoT_DeviceEDCs_063 = vIoT_DeviceEDCs_063.Where(c => c.device_id == device.device_id);
                        vIoT_DeviceEDCs_063 = vIoT_DeviceEDCs_063.OrderByDescending(c => c.clm_date_time);
                        IOT_DEVICE_EDC_063 oIoT_DeviceEDC_063 = new IOT_DEVICE_EDC_063();
                        oIoT_DeviceEDC_063 = vIoT_DeviceEDCs_063.FirstOrDefault();
                        oIoT_DeviceEDC.Clone(oIoT_DeviceEDC_063);

                        break;

                    case 64:
                        var vIoT_DeviceEDCs_064 = IOT_DEVICE_EDC_064.AsQueryable(); ;
                        vIoT_DeviceEDCs_064 = vIoT_DeviceEDCs_064.Where(c => c.device_id == device.device_id);
                        vIoT_DeviceEDCs_064 = vIoT_DeviceEDCs_064.OrderByDescending(c => c.clm_date_time);
                        IOT_DEVICE_EDC_064 oIoT_DeviceEDC_064 = new IOT_DEVICE_EDC_064();
                        oIoT_DeviceEDC_064 = vIoT_DeviceEDCs_064.FirstOrDefault();
                        oIoT_DeviceEDC.Clone(oIoT_DeviceEDC_064);

                        break;

                    case 65:
                        var vIoT_DeviceEDCs_065 = IOT_DEVICE_EDC_065.AsQueryable(); ;
                        vIoT_DeviceEDCs_065 = vIoT_DeviceEDCs_065.Where(c => c.device_id == device.device_id);
                        vIoT_DeviceEDCs_065 = vIoT_DeviceEDCs_065.OrderByDescending(c => c.clm_date_time);
                        IOT_DEVICE_EDC_065 oIoT_DeviceEDC_065 = new IOT_DEVICE_EDC_065();
                        oIoT_DeviceEDC_065 = vIoT_DeviceEDCs_065.FirstOrDefault();
                        oIoT_DeviceEDC.Clone(oIoT_DeviceEDC_065);

                        break;

                    case 66:
                        var vIoT_DeviceEDCs_066 = IOT_DEVICE_EDC_066.AsQueryable(); ;
                        vIoT_DeviceEDCs_066 = vIoT_DeviceEDCs_066.Where(c => c.device_id == device.device_id);
                        vIoT_DeviceEDCs_066 = vIoT_DeviceEDCs_066.OrderByDescending(c => c.clm_date_time);
                        IOT_DEVICE_EDC_066 oIoT_DeviceEDC_066 = new IOT_DEVICE_EDC_066();
                        oIoT_DeviceEDC_066 = vIoT_DeviceEDCs_066.FirstOrDefault();
                        oIoT_DeviceEDC.Clone(oIoT_DeviceEDC_066);

                        break;

                    case 67:
                        var vIoT_DeviceEDCs_067 = IOT_DEVICE_EDC_067.AsQueryable(); ;
                        vIoT_DeviceEDCs_067 = vIoT_DeviceEDCs_067.Where(c => c.device_id == device.device_id);
                        vIoT_DeviceEDCs_067 = vIoT_DeviceEDCs_067.OrderByDescending(c => c.clm_date_time);
                        IOT_DEVICE_EDC_067 oIoT_DeviceEDC_067 = new IOT_DEVICE_EDC_067();
                        oIoT_DeviceEDC_067 = vIoT_DeviceEDCs_067.FirstOrDefault();
                        oIoT_DeviceEDC.Clone(oIoT_DeviceEDC_067);

                        break;

                    case 68:
                        var vIoT_DeviceEDCs_068 = IOT_DEVICE_EDC_068.AsQueryable(); ;
                        vIoT_DeviceEDCs_068 = vIoT_DeviceEDCs_068.Where(c => c.device_id == device.device_id);
                        vIoT_DeviceEDCs_068 = vIoT_DeviceEDCs_068.OrderByDescending(c => c.clm_date_time);
                        IOT_DEVICE_EDC_068 oIoT_DeviceEDC_068 = new IOT_DEVICE_EDC_068();
                        oIoT_DeviceEDC_068 = vIoT_DeviceEDCs_068.FirstOrDefault();
                        oIoT_DeviceEDC.Clone(oIoT_DeviceEDC_068);

                        break;

                    case 69:
                        var vIoT_DeviceEDCs_069 = IOT_DEVICE_EDC_069.AsQueryable();
                        vIoT_DeviceEDCs_069 = vIoT_DeviceEDCs_069.Where(c => c.device_id == device.device_id);
                        vIoT_DeviceEDCs_069 = vIoT_DeviceEDCs_069.OrderByDescending(c => c.clm_date_time);
                        IOT_DEVICE_EDC_069 oIoT_DeviceEDC_069 = new IOT_DEVICE_EDC_069();
                        oIoT_DeviceEDC_069 = vIoT_DeviceEDCs_069.FirstOrDefault();
                        oIoT_DeviceEDC.Clone(oIoT_DeviceEDC_069);

                        break;

                    case 70:
                        var vIoT_DeviceEDCs_070 = IOT_DEVICE_EDC_070.AsQueryable();
                        vIoT_DeviceEDCs_070 = vIoT_DeviceEDCs_070.Where(c => c.device_id == device.device_id);
                        vIoT_DeviceEDCs_070 = vIoT_DeviceEDCs_070.OrderByDescending(c => c.clm_date_time);
                        IOT_DEVICE_EDC_070 oIoT_DeviceEDC_070 = new IOT_DEVICE_EDC_070();
                        oIoT_DeviceEDC_070 = vIoT_DeviceEDCs_070.FirstOrDefault();
                        oIoT_DeviceEDC.Clone(oIoT_DeviceEDC_070);

                        break;

                    case 71:
                        var vIoT_DeviceEDCs_071 = IOT_DEVICE_EDC_071.AsQueryable(); ;
                        vIoT_DeviceEDCs_071 = vIoT_DeviceEDCs_071.Where(c => c.device_id == device.device_id);
                        vIoT_DeviceEDCs_071 = vIoT_DeviceEDCs_071.OrderByDescending(c => c.clm_date_time);
                        IOT_DEVICE_EDC_071 oIoT_DeviceEDC_071 = new IOT_DEVICE_EDC_071();
                        oIoT_DeviceEDC_071 = vIoT_DeviceEDCs_071.FirstOrDefault();
                        oIoT_DeviceEDC.Clone(oIoT_DeviceEDC_071);

                        break;

                    case 72:
                        var vIoT_DeviceEDCs_072 = IOT_DEVICE_EDC_072.AsQueryable(); ;
                        vIoT_DeviceEDCs_072 = vIoT_DeviceEDCs_072.Where(c => c.device_id == device.device_id);
                        vIoT_DeviceEDCs_072 = vIoT_DeviceEDCs_072.OrderByDescending(c => c.clm_date_time);
                        IOT_DEVICE_EDC_072 oIoT_DeviceEDC_072 = new IOT_DEVICE_EDC_072();
                        oIoT_DeviceEDC_072 = vIoT_DeviceEDCs_072.FirstOrDefault();
                        oIoT_DeviceEDC.Clone(oIoT_DeviceEDC_072);

                        break;

                    case 73:
                        var vIoT_DeviceEDCs_073 = IOT_DEVICE_EDC_073.AsQueryable(); ;
                        vIoT_DeviceEDCs_073 = vIoT_DeviceEDCs_073.Where(c => c.device_id == device.device_id);
                        vIoT_DeviceEDCs_073 = vIoT_DeviceEDCs_073.OrderByDescending(c => c.clm_date_time);
                        IOT_DEVICE_EDC_073 oIoT_DeviceEDC_073 = new IOT_DEVICE_EDC_073();
                        oIoT_DeviceEDC_073 = vIoT_DeviceEDCs_073.FirstOrDefault();
                        oIoT_DeviceEDC.Clone(oIoT_DeviceEDC_073);

                        break;

                    case 74:
                        var vIoT_DeviceEDCs_074 = IOT_DEVICE_EDC_074.AsQueryable(); ;
                        vIoT_DeviceEDCs_074 = vIoT_DeviceEDCs_074.Where(c => c.device_id == device.device_id);
                        vIoT_DeviceEDCs_074 = vIoT_DeviceEDCs_074.OrderByDescending(c => c.clm_date_time);
                        IOT_DEVICE_EDC_074 oIoT_DeviceEDC_074 = new IOT_DEVICE_EDC_074();
                        oIoT_DeviceEDC_074 = vIoT_DeviceEDCs_074.FirstOrDefault();
                        oIoT_DeviceEDC.Clone(oIoT_DeviceEDC_074);

                        break;

                    case 75:
                        var vIoT_DeviceEDCs_075 = IOT_DEVICE_EDC_075.AsQueryable(); ;
                        vIoT_DeviceEDCs_075 = vIoT_DeviceEDCs_075.Where(c => c.device_id == device.device_id);
                        vIoT_DeviceEDCs_075 = vIoT_DeviceEDCs_075.OrderByDescending(c => c.clm_date_time);
                        IOT_DEVICE_EDC_075 oIoT_DeviceEDC_075 = new IOT_DEVICE_EDC_075();
                        oIoT_DeviceEDC_075 = vIoT_DeviceEDCs_075.FirstOrDefault();
                        oIoT_DeviceEDC.Clone(oIoT_DeviceEDC_075);

                        break;

                    case 76:
                        var vIoT_DeviceEDCs_076 = IOT_DEVICE_EDC_076.AsQueryable(); ;
                        vIoT_DeviceEDCs_076 = vIoT_DeviceEDCs_076.Where(c => c.device_id == device.device_id);
                        vIoT_DeviceEDCs_076 = vIoT_DeviceEDCs_076.OrderByDescending(c => c.clm_date_time);
                        IOT_DEVICE_EDC_076 oIoT_DeviceEDC_076 = new IOT_DEVICE_EDC_076();
                        oIoT_DeviceEDC_076 = vIoT_DeviceEDCs_076.FirstOrDefault();
                        oIoT_DeviceEDC.Clone(oIoT_DeviceEDC_076);

                        break;

                    case 77:
                        var vIoT_DeviceEDCs_077 = IOT_DEVICE_EDC_077.AsQueryable(); ;
                        vIoT_DeviceEDCs_077 = vIoT_DeviceEDCs_077.Where(c => c.device_id == device.device_id);
                        vIoT_DeviceEDCs_077 = vIoT_DeviceEDCs_077.OrderByDescending(c => c.clm_date_time);
                        IOT_DEVICE_EDC_077 oIoT_DeviceEDC_077 = new IOT_DEVICE_EDC_077();
                        oIoT_DeviceEDC_077 = vIoT_DeviceEDCs_077.FirstOrDefault();
                        oIoT_DeviceEDC.Clone(oIoT_DeviceEDC_077);

                        break;

                    case 78:
                        var vIoT_DeviceEDCs_078 = IOT_DEVICE_EDC_078.AsQueryable(); ;
                        vIoT_DeviceEDCs_078 = vIoT_DeviceEDCs_078.Where(c => c.device_id == device.device_id);
                        vIoT_DeviceEDCs_078 = vIoT_DeviceEDCs_078.OrderByDescending(c => c.clm_date_time);
                        IOT_DEVICE_EDC_078 oIoT_DeviceEDC_078 = new IOT_DEVICE_EDC_078();
                        oIoT_DeviceEDC_078 = vIoT_DeviceEDCs_078.FirstOrDefault();
                        oIoT_DeviceEDC.Clone(oIoT_DeviceEDC_078);

                        break;

                    case 79:
                        var vIoT_DeviceEDCs_079 = IOT_DEVICE_EDC_079.AsQueryable();
                        vIoT_DeviceEDCs_079 = vIoT_DeviceEDCs_079.Where(c => c.device_id == device.device_id);
                        vIoT_DeviceEDCs_079 = vIoT_DeviceEDCs_079.OrderByDescending(c => c.clm_date_time);
                        IOT_DEVICE_EDC_079 oIoT_DeviceEDC_079 = new IOT_DEVICE_EDC_079();
                        oIoT_DeviceEDC_079 = vIoT_DeviceEDCs_079.FirstOrDefault();
                        oIoT_DeviceEDC.Clone(oIoT_DeviceEDC_079);

                        break;

                    case 80:
                        var vIoT_DeviceEDCs_080 = IOT_DEVICE_EDC_080.AsQueryable();
                        vIoT_DeviceEDCs_080 = vIoT_DeviceEDCs_080.Where(c => c.device_id == device.device_id);
                        vIoT_DeviceEDCs_080 = vIoT_DeviceEDCs_080.OrderByDescending(c => c.clm_date_time);
                        IOT_DEVICE_EDC_080 oIoT_DeviceEDC_080 = new IOT_DEVICE_EDC_080();
                        oIoT_DeviceEDC_080 = vIoT_DeviceEDCs_080.FirstOrDefault();
                        oIoT_DeviceEDC.Clone(oIoT_DeviceEDC_080);

                        break;

                    case 81:
                        var vIoT_DeviceEDCs_081 = IOT_DEVICE_EDC_081.AsQueryable(); ;
                        vIoT_DeviceEDCs_081 = vIoT_DeviceEDCs_081.Where(c => c.device_id == device.device_id);
                        vIoT_DeviceEDCs_081 = vIoT_DeviceEDCs_081.OrderByDescending(c => c.clm_date_time);
                        IOT_DEVICE_EDC_081 oIoT_DeviceEDC_081 = new IOT_DEVICE_EDC_081();
                        oIoT_DeviceEDC_081 = vIoT_DeviceEDCs_081.FirstOrDefault();
                        oIoT_DeviceEDC.Clone(oIoT_DeviceEDC_081);

                        break;

                    case 82:
                        var vIoT_DeviceEDCs_082 = IOT_DEVICE_EDC_082.AsQueryable(); ;
                        vIoT_DeviceEDCs_082 = vIoT_DeviceEDCs_082.Where(c => c.device_id == device.device_id);
                        vIoT_DeviceEDCs_082 = vIoT_DeviceEDCs_082.OrderByDescending(c => c.clm_date_time);
                        IOT_DEVICE_EDC_082 oIoT_DeviceEDC_082 = new IOT_DEVICE_EDC_082();
                        oIoT_DeviceEDC_082 = vIoT_DeviceEDCs_082.FirstOrDefault();
                        oIoT_DeviceEDC.Clone(oIoT_DeviceEDC_082);

                        break;

                    case 83:
                        var vIoT_DeviceEDCs_083 = IOT_DEVICE_EDC_083.AsQueryable(); ;
                        vIoT_DeviceEDCs_083 = vIoT_DeviceEDCs_083.Where(c => c.device_id == device.device_id);
                        vIoT_DeviceEDCs_083 = vIoT_DeviceEDCs_083.OrderByDescending(c => c.clm_date_time);
                        IOT_DEVICE_EDC_083 oIoT_DeviceEDC_083 = new IOT_DEVICE_EDC_083();
                        oIoT_DeviceEDC_083 = vIoT_DeviceEDCs_083.FirstOrDefault();
                        oIoT_DeviceEDC.Clone(oIoT_DeviceEDC_083);

                        break;

                    case 84:
                        var vIoT_DeviceEDCs_084 = IOT_DEVICE_EDC_084.AsQueryable(); ;
                        vIoT_DeviceEDCs_084 = vIoT_DeviceEDCs_084.Where(c => c.device_id == device.device_id);
                        vIoT_DeviceEDCs_084 = vIoT_DeviceEDCs_084.OrderByDescending(c => c.clm_date_time);
                        IOT_DEVICE_EDC_084 oIoT_DeviceEDC_084 = new IOT_DEVICE_EDC_084();
                        oIoT_DeviceEDC_084 = vIoT_DeviceEDCs_084.FirstOrDefault();
                        oIoT_DeviceEDC.Clone(oIoT_DeviceEDC_084);

                        break;

                    case 85:
                        var vIoT_DeviceEDCs_085 = IOT_DEVICE_EDC_085.AsQueryable(); ;
                        vIoT_DeviceEDCs_085 = vIoT_DeviceEDCs_085.Where(c => c.device_id == device.device_id);
                        vIoT_DeviceEDCs_085 = vIoT_DeviceEDCs_085.OrderByDescending(c => c.clm_date_time);
                        IOT_DEVICE_EDC_085 oIoT_DeviceEDC_085 = new IOT_DEVICE_EDC_085();
                        oIoT_DeviceEDC_085 = vIoT_DeviceEDCs_085.FirstOrDefault();
                        oIoT_DeviceEDC.Clone(oIoT_DeviceEDC_085);

                        break;

                    case 86:
                        var vIoT_DeviceEDCs_086 = IOT_DEVICE_EDC_086.AsQueryable(); ;
                        vIoT_DeviceEDCs_086 = vIoT_DeviceEDCs_086.Where(c => c.device_id == device.device_id);
                        vIoT_DeviceEDCs_086 = vIoT_DeviceEDCs_086.OrderByDescending(c => c.clm_date_time);
                        IOT_DEVICE_EDC_086 oIoT_DeviceEDC_086 = new IOT_DEVICE_EDC_086();
                        oIoT_DeviceEDC_086 = vIoT_DeviceEDCs_086.FirstOrDefault();
                        oIoT_DeviceEDC.Clone(oIoT_DeviceEDC_086);

                        break;

                    case 87:
                        var vIoT_DeviceEDCs_087 = IOT_DEVICE_EDC_087.AsQueryable(); ;
                        vIoT_DeviceEDCs_087 = vIoT_DeviceEDCs_087.Where(c => c.device_id == device.device_id);
                        vIoT_DeviceEDCs_087 = vIoT_DeviceEDCs_087.OrderByDescending(c => c.clm_date_time);
                        IOT_DEVICE_EDC_087 oIoT_DeviceEDC_087 = new IOT_DEVICE_EDC_087();
                        oIoT_DeviceEDC_087 = vIoT_DeviceEDCs_087.FirstOrDefault();
                        oIoT_DeviceEDC.Clone(oIoT_DeviceEDC_087);

                        break;

                    case 88:
                        var vIoT_DeviceEDCs_088 = IOT_DEVICE_EDC_088.AsQueryable(); ;
                        vIoT_DeviceEDCs_088 = vIoT_DeviceEDCs_088.Where(c => c.device_id == device.device_id);
                        vIoT_DeviceEDCs_088 = vIoT_DeviceEDCs_088.OrderByDescending(c => c.clm_date_time);
                        IOT_DEVICE_EDC_088 oIoT_DeviceEDC_088 = new IOT_DEVICE_EDC_088();
                        oIoT_DeviceEDC_088 = vIoT_DeviceEDCs_088.FirstOrDefault();
                        oIoT_DeviceEDC.Clone(oIoT_DeviceEDC_088);

                        break;

                    case 89:
                        var vIoT_DeviceEDCs_089 = IOT_DEVICE_EDC_089.AsQueryable();
                        vIoT_DeviceEDCs_089 = vIoT_DeviceEDCs_089.Where(c => c.device_id == device.device_id);
                        vIoT_DeviceEDCs_089 = vIoT_DeviceEDCs_089.OrderByDescending(c => c.clm_date_time);
                        IOT_DEVICE_EDC_089 oIoT_DeviceEDC_089 = new IOT_DEVICE_EDC_089();
                        oIoT_DeviceEDC_089 = vIoT_DeviceEDCs_089.FirstOrDefault();
                        oIoT_DeviceEDC.Clone(oIoT_DeviceEDC_089);

                        break;

                    case 90:
                        var vIoT_DeviceEDCs_090 = IOT_DEVICE_EDC_090.AsQueryable();
                        vIoT_DeviceEDCs_090 = vIoT_DeviceEDCs_090.Where(c => c.device_id == device.device_id);
                        vIoT_DeviceEDCs_090 = vIoT_DeviceEDCs_090.OrderByDescending(c => c.clm_date_time);
                        IOT_DEVICE_EDC_090 oIoT_DeviceEDC_090 = new IOT_DEVICE_EDC_090();
                        oIoT_DeviceEDC_090 = vIoT_DeviceEDCs_090.FirstOrDefault();
                        oIoT_DeviceEDC.Clone(oIoT_DeviceEDC_090);

                        break;

                    case 91:
                        var vIoT_DeviceEDCs_091 = IOT_DEVICE_EDC_091.AsQueryable(); ;
                        vIoT_DeviceEDCs_091 = vIoT_DeviceEDCs_091.Where(c => c.device_id == device.device_id);
                        vIoT_DeviceEDCs_091 = vIoT_DeviceEDCs_091.OrderByDescending(c => c.clm_date_time);
                        IOT_DEVICE_EDC_091 oIoT_DeviceEDC_091 = new IOT_DEVICE_EDC_091();
                        oIoT_DeviceEDC_091 = vIoT_DeviceEDCs_091.FirstOrDefault();
                        oIoT_DeviceEDC.Clone(oIoT_DeviceEDC_091);

                        break;

                    case 92:
                        var vIoT_DeviceEDCs_092 = IOT_DEVICE_EDC_092.AsQueryable(); ;
                        vIoT_DeviceEDCs_092 = vIoT_DeviceEDCs_092.Where(c => c.device_id == device.device_id);
                        vIoT_DeviceEDCs_092 = vIoT_DeviceEDCs_092.OrderByDescending(c => c.clm_date_time);
                        IOT_DEVICE_EDC_092 oIoT_DeviceEDC_092 = new IOT_DEVICE_EDC_092();
                        oIoT_DeviceEDC_092 = vIoT_DeviceEDCs_092.FirstOrDefault();
                        oIoT_DeviceEDC.Clone(oIoT_DeviceEDC_092);

                        break;

                    case 93:
                        var vIoT_DeviceEDCs_093 = IOT_DEVICE_EDC_093.AsQueryable(); ;
                        vIoT_DeviceEDCs_093 = vIoT_DeviceEDCs_093.Where(c => c.device_id == device.device_id);
                        vIoT_DeviceEDCs_093 = vIoT_DeviceEDCs_093.OrderByDescending(c => c.clm_date_time);
                        IOT_DEVICE_EDC_093 oIoT_DeviceEDC_093 = new IOT_DEVICE_EDC_093();
                        oIoT_DeviceEDC_093 = vIoT_DeviceEDCs_093.FirstOrDefault();
                        oIoT_DeviceEDC.Clone(oIoT_DeviceEDC_093);

                        break;

                    case 94:
                        var vIoT_DeviceEDCs_094 = IOT_DEVICE_EDC_094.AsQueryable(); ;
                        vIoT_DeviceEDCs_094 = vIoT_DeviceEDCs_094.Where(c => c.device_id == device.device_id);
                        vIoT_DeviceEDCs_094 = vIoT_DeviceEDCs_094.OrderByDescending(c => c.clm_date_time);
                        IOT_DEVICE_EDC_094 oIoT_DeviceEDC_094 = new IOT_DEVICE_EDC_094();
                        oIoT_DeviceEDC_094 = vIoT_DeviceEDCs_094.FirstOrDefault();
                        oIoT_DeviceEDC.Clone(oIoT_DeviceEDC_094);

                        break;

                    case 95:
                        var vIoT_DeviceEDCs_095 = IOT_DEVICE_EDC_095.AsQueryable(); ;
                        vIoT_DeviceEDCs_095 = vIoT_DeviceEDCs_095.Where(c => c.device_id == device.device_id);
                        vIoT_DeviceEDCs_095 = vIoT_DeviceEDCs_095.OrderByDescending(c => c.clm_date_time);
                        IOT_DEVICE_EDC_095 oIoT_DeviceEDC_095 = new IOT_DEVICE_EDC_095();
                        oIoT_DeviceEDC_095 = vIoT_DeviceEDCs_095.FirstOrDefault();
                        oIoT_DeviceEDC.Clone(oIoT_DeviceEDC_095);

                        break;

                    case 96:
                        var vIoT_DeviceEDCs_096 = IOT_DEVICE_EDC_096.AsQueryable(); ;
                        vIoT_DeviceEDCs_096 = vIoT_DeviceEDCs_096.Where(c => c.device_id == device.device_id);
                        vIoT_DeviceEDCs_096 = vIoT_DeviceEDCs_096.OrderByDescending(c => c.clm_date_time);
                        IOT_DEVICE_EDC_096 oIoT_DeviceEDC_096 = new IOT_DEVICE_EDC_096();
                        oIoT_DeviceEDC_096 = vIoT_DeviceEDCs_096.FirstOrDefault();
                        oIoT_DeviceEDC.Clone(oIoT_DeviceEDC_096);

                        break;

                    case 97:
                        var vIoT_DeviceEDCs_097 = IOT_DEVICE_EDC_097.AsQueryable(); ;
                        vIoT_DeviceEDCs_097 = vIoT_DeviceEDCs_097.Where(c => c.device_id == device.device_id);
                        vIoT_DeviceEDCs_097 = vIoT_DeviceEDCs_097.OrderByDescending(c => c.clm_date_time);
                        IOT_DEVICE_EDC_097 oIoT_DeviceEDC_097 = new IOT_DEVICE_EDC_097();
                        oIoT_DeviceEDC_097 = vIoT_DeviceEDCs_097.FirstOrDefault();
                        oIoT_DeviceEDC.Clone(oIoT_DeviceEDC_097);

                        break;

                    case 98:
                        var vIoT_DeviceEDCs_098 = IOT_DEVICE_EDC_098.AsQueryable(); ;
                        vIoT_DeviceEDCs_098 = vIoT_DeviceEDCs_098.Where(c => c.device_id == device.device_id);
                        vIoT_DeviceEDCs_098 = vIoT_DeviceEDCs_098.OrderByDescending(c => c.clm_date_time);
                        IOT_DEVICE_EDC_098 oIoT_DeviceEDC_098 = new IOT_DEVICE_EDC_098();
                        oIoT_DeviceEDC_098 = vIoT_DeviceEDCs_098.FirstOrDefault();
                        oIoT_DeviceEDC.Clone(oIoT_DeviceEDC_098);

                        break;

                    case 99:
                        var vIoT_DeviceEDCs_099 = IOT_DEVICE_EDC_099.AsQueryable();
                        vIoT_DeviceEDCs_099 = vIoT_DeviceEDCs_099.Where(c => c.device_id == device.device_id);
                        vIoT_DeviceEDCs_099 = vIoT_DeviceEDCs_099.OrderByDescending(c => c.clm_date_time);
                        IOT_DEVICE_EDC_099 oIoT_DeviceEDC_099 = new IOT_DEVICE_EDC_099();
                        oIoT_DeviceEDC_099 = vIoT_DeviceEDCs_099.FirstOrDefault();
                        oIoT_DeviceEDC.Clone(oIoT_DeviceEDC_099);

                        break;

                    case 100:
                        var vIoT_DeviceEDCs_100 = IOT_DEVICE_EDC_100.AsQueryable();
                        vIoT_DeviceEDCs_100 = vIoT_DeviceEDCs_100.Where(c => c.device_id == device.device_id);
                        vIoT_DeviceEDCs_100 = vIoT_DeviceEDCs_100.OrderByDescending(c => c.clm_date_time);
                        IOT_DEVICE_EDC_100 oIoT_DeviceEDC_100 = new IOT_DEVICE_EDC_100();
                        oIoT_DeviceEDC_100 = vIoT_DeviceEDCs_100.FirstOrDefault();
                        oIoT_DeviceEDC.Clone(oIoT_DeviceEDC_100);

                        break;

                    case 101:
                        var vIoT_DeviceEDCs_101 = IOT_DEVICE_EDC_101.AsQueryable(); ;
                        vIoT_DeviceEDCs_101 = vIoT_DeviceEDCs_101.Where(c => c.device_id == device.device_id);
                        vIoT_DeviceEDCs_101 = vIoT_DeviceEDCs_101.OrderByDescending(c => c.clm_date_time);
                        IOT_DEVICE_EDC_101 oIoT_DeviceEDC_101 = new IOT_DEVICE_EDC_101();
                        oIoT_DeviceEDC_101 = vIoT_DeviceEDCs_101.FirstOrDefault();
                        oIoT_DeviceEDC.Clone(oIoT_DeviceEDC_101);

                        break;

                    case 102:
                        var vIoT_DeviceEDCs_102 = IOT_DEVICE_EDC_102.AsQueryable(); ;
                        vIoT_DeviceEDCs_102 = vIoT_DeviceEDCs_102.Where(c => c.device_id == device.device_id);
                        vIoT_DeviceEDCs_102 = vIoT_DeviceEDCs_102.OrderByDescending(c => c.clm_date_time);
                        IOT_DEVICE_EDC_102 oIoT_DeviceEDC_102 = new IOT_DEVICE_EDC_102();
                        oIoT_DeviceEDC_102 = vIoT_DeviceEDCs_102.FirstOrDefault();
                        oIoT_DeviceEDC.Clone(oIoT_DeviceEDC_102);

                        break;

                    case 103:
                        var vIoT_DeviceEDCs_103 = IOT_DEVICE_EDC_103.AsQueryable(); ;
                        vIoT_DeviceEDCs_103 = vIoT_DeviceEDCs_103.Where(c => c.device_id == device.device_id);
                        vIoT_DeviceEDCs_103 = vIoT_DeviceEDCs_103.OrderByDescending(c => c.clm_date_time);
                        IOT_DEVICE_EDC_103 oIoT_DeviceEDC_103 = new IOT_DEVICE_EDC_103();
                        oIoT_DeviceEDC_103 = vIoT_DeviceEDCs_103.FirstOrDefault();
                        oIoT_DeviceEDC.Clone(oIoT_DeviceEDC_103);

                        break;

                    case 104:
                        var vIoT_DeviceEDCs_104 = IOT_DEVICE_EDC_104.AsQueryable(); ;
                        vIoT_DeviceEDCs_104 = vIoT_DeviceEDCs_104.Where(c => c.device_id == device.device_id);
                        vIoT_DeviceEDCs_104 = vIoT_DeviceEDCs_104.OrderByDescending(c => c.clm_date_time);
                        IOT_DEVICE_EDC_104 oIoT_DeviceEDC_104 = new IOT_DEVICE_EDC_104();
                        oIoT_DeviceEDC_104 = vIoT_DeviceEDCs_104.FirstOrDefault();
                        oIoT_DeviceEDC.Clone(oIoT_DeviceEDC_104);

                        break;

                    case 105:
                        var vIoT_DeviceEDCs_105 = IOT_DEVICE_EDC_105.AsQueryable(); ;
                        vIoT_DeviceEDCs_105 = vIoT_DeviceEDCs_105.Where(c => c.device_id == device.device_id);
                        vIoT_DeviceEDCs_105 = vIoT_DeviceEDCs_105.OrderByDescending(c => c.clm_date_time);
                        IOT_DEVICE_EDC_105 oIoT_DeviceEDC_105 = new IOT_DEVICE_EDC_105();
                        oIoT_DeviceEDC_105 = vIoT_DeviceEDCs_105.FirstOrDefault();
                        oIoT_DeviceEDC.Clone(oIoT_DeviceEDC_105);

                        break;

                    case 106:
                        var vIoT_DeviceEDCs_106 = IOT_DEVICE_EDC_106.AsQueryable(); ;
                        vIoT_DeviceEDCs_106 = vIoT_DeviceEDCs_106.Where(c => c.device_id == device.device_id);
                        vIoT_DeviceEDCs_106 = vIoT_DeviceEDCs_106.OrderByDescending(c => c.clm_date_time);
                        IOT_DEVICE_EDC_106 oIoT_DeviceEDC_106 = new IOT_DEVICE_EDC_106();
                        oIoT_DeviceEDC_106 = vIoT_DeviceEDCs_106.FirstOrDefault();
                        oIoT_DeviceEDC.Clone(oIoT_DeviceEDC_106);

                        break;

                    case 107:
                        var vIoT_DeviceEDCs_107 = IOT_DEVICE_EDC_107.AsQueryable(); ;
                        vIoT_DeviceEDCs_107 = vIoT_DeviceEDCs_107.Where(c => c.device_id == device.device_id);
                        vIoT_DeviceEDCs_107 = vIoT_DeviceEDCs_107.OrderByDescending(c => c.clm_date_time);
                        IOT_DEVICE_EDC_107 oIoT_DeviceEDC_107 = new IOT_DEVICE_EDC_107();
                        oIoT_DeviceEDC_107 = vIoT_DeviceEDCs_107.FirstOrDefault();
                        oIoT_DeviceEDC.Clone(oIoT_DeviceEDC_107);

                        break;

                    case 108:
                        var vIoT_DeviceEDCs_108 = IOT_DEVICE_EDC_108.AsQueryable(); ;
                        vIoT_DeviceEDCs_108 = vIoT_DeviceEDCs_108.Where(c => c.device_id == device.device_id);
                        vIoT_DeviceEDCs_108 = vIoT_DeviceEDCs_108.OrderByDescending(c => c.clm_date_time);
                        IOT_DEVICE_EDC_108 oIoT_DeviceEDC_108 = new IOT_DEVICE_EDC_108();
                        oIoT_DeviceEDC_108 = vIoT_DeviceEDCs_108.FirstOrDefault();
                        oIoT_DeviceEDC.Clone(oIoT_DeviceEDC_108);

                        break;

                    case 109:
                        var vIoT_DeviceEDCs_109 = IOT_DEVICE_EDC_109.AsQueryable();
                        vIoT_DeviceEDCs_109 = vIoT_DeviceEDCs_109.Where(c => c.device_id == device.device_id);
                        vIoT_DeviceEDCs_109 = vIoT_DeviceEDCs_109.OrderByDescending(c => c.clm_date_time);
                        IOT_DEVICE_EDC_109 oIoT_DeviceEDC_109 = new IOT_DEVICE_EDC_109();
                        oIoT_DeviceEDC_109 = vIoT_DeviceEDCs_109.FirstOrDefault();
                        oIoT_DeviceEDC.Clone(oIoT_DeviceEDC_109);

                        break;

                    case 110:
                        var vIoT_DeviceEDCs_110 = IOT_DEVICE_EDC_110.AsQueryable();
                        vIoT_DeviceEDCs_110 = vIoT_DeviceEDCs_110.Where(c => c.device_id == device.device_id);
                        vIoT_DeviceEDCs_110 = vIoT_DeviceEDCs_110.OrderByDescending(c => c.clm_date_time);
                        IOT_DEVICE_EDC_110 oIoT_DeviceEDC_110 = new IOT_DEVICE_EDC_110();
                        oIoT_DeviceEDC_110 = vIoT_DeviceEDCs_110.FirstOrDefault();
                        oIoT_DeviceEDC.Clone(oIoT_DeviceEDC_110);

                        break;

                    case 111:
                        var vIoT_DeviceEDCs_111 = IOT_DEVICE_EDC_111.AsQueryable(); ;
                        vIoT_DeviceEDCs_111 = vIoT_DeviceEDCs_111.Where(c => c.device_id == device.device_id);
                        vIoT_DeviceEDCs_111 = vIoT_DeviceEDCs_111.OrderByDescending(c => c.clm_date_time);
                        IOT_DEVICE_EDC_111 oIoT_DeviceEDC_111 = new IOT_DEVICE_EDC_111();
                        oIoT_DeviceEDC_111 = vIoT_DeviceEDCs_111.FirstOrDefault();
                        oIoT_DeviceEDC.Clone(oIoT_DeviceEDC_111);

                        break;

                    case 112:
                        var vIoT_DeviceEDCs_112 = IOT_DEVICE_EDC_112.AsQueryable(); ;
                        vIoT_DeviceEDCs_112 = vIoT_DeviceEDCs_112.Where(c => c.device_id == device.device_id);
                        vIoT_DeviceEDCs_112 = vIoT_DeviceEDCs_112.OrderByDescending(c => c.clm_date_time);
                        IOT_DEVICE_EDC_112 oIoT_DeviceEDC_112 = new IOT_DEVICE_EDC_112();
                        oIoT_DeviceEDC_112 = vIoT_DeviceEDCs_112.FirstOrDefault();
                        oIoT_DeviceEDC.Clone(oIoT_DeviceEDC_112);

                        break;

                    case 113:
                        var vIoT_DeviceEDCs_113 = IOT_DEVICE_EDC_113.AsQueryable(); ;
                        vIoT_DeviceEDCs_113 = vIoT_DeviceEDCs_113.Where(c => c.device_id == device.device_id);
                        vIoT_DeviceEDCs_113 = vIoT_DeviceEDCs_113.OrderByDescending(c => c.clm_date_time);
                        IOT_DEVICE_EDC_113 oIoT_DeviceEDC_113 = new IOT_DEVICE_EDC_113();
                        oIoT_DeviceEDC_113 = vIoT_DeviceEDCs_113.FirstOrDefault();
                        oIoT_DeviceEDC.Clone(oIoT_DeviceEDC_113);

                        break;

                    case 114:
                        var vIoT_DeviceEDCs_114 = IOT_DEVICE_EDC_114.AsQueryable(); ;
                        vIoT_DeviceEDCs_114 = vIoT_DeviceEDCs_114.Where(c => c.device_id == device.device_id);
                        vIoT_DeviceEDCs_114 = vIoT_DeviceEDCs_114.OrderByDescending(c => c.clm_date_time);
                        IOT_DEVICE_EDC_114 oIoT_DeviceEDC_114 = new IOT_DEVICE_EDC_114();
                        oIoT_DeviceEDC_114 = vIoT_DeviceEDCs_114.FirstOrDefault();
                        oIoT_DeviceEDC.Clone(oIoT_DeviceEDC_114);

                        break;

                    case 115:
                        var vIoT_DeviceEDCs_115 = IOT_DEVICE_EDC_115.AsQueryable(); ;
                        vIoT_DeviceEDCs_115 = vIoT_DeviceEDCs_115.Where(c => c.device_id == device.device_id);
                        vIoT_DeviceEDCs_115 = vIoT_DeviceEDCs_115.OrderByDescending(c => c.clm_date_time);
                        IOT_DEVICE_EDC_115 oIoT_DeviceEDC_115 = new IOT_DEVICE_EDC_115();
                        oIoT_DeviceEDC_115 = vIoT_DeviceEDCs_115.FirstOrDefault();
                        oIoT_DeviceEDC.Clone(oIoT_DeviceEDC_115);

                        break;

                    case 116:
                        var vIoT_DeviceEDCs_116 = IOT_DEVICE_EDC_116.AsQueryable(); ;
                        vIoT_DeviceEDCs_116 = vIoT_DeviceEDCs_116.Where(c => c.device_id == device.device_id);
                        vIoT_DeviceEDCs_116 = vIoT_DeviceEDCs_116.OrderByDescending(c => c.clm_date_time);
                        IOT_DEVICE_EDC_116 oIoT_DeviceEDC_116 = new IOT_DEVICE_EDC_116();
                        oIoT_DeviceEDC_116 = vIoT_DeviceEDCs_116.FirstOrDefault();
                        oIoT_DeviceEDC.Clone(oIoT_DeviceEDC_116);

                        break;

                    case 117:
                        var vIoT_DeviceEDCs_117 = IOT_DEVICE_EDC_117.AsQueryable(); ;
                        vIoT_DeviceEDCs_117 = vIoT_DeviceEDCs_117.Where(c => c.device_id == device.device_id);
                        vIoT_DeviceEDCs_117 = vIoT_DeviceEDCs_117.OrderByDescending(c => c.clm_date_time);
                        IOT_DEVICE_EDC_117 oIoT_DeviceEDC_117 = new IOT_DEVICE_EDC_117();
                        oIoT_DeviceEDC_117 = vIoT_DeviceEDCs_117.FirstOrDefault();
                        oIoT_DeviceEDC.Clone(oIoT_DeviceEDC_117);

                        break;

                    case 118:
                        var vIoT_DeviceEDCs_118 = IOT_DEVICE_EDC_118.AsQueryable(); ;
                        vIoT_DeviceEDCs_118 = vIoT_DeviceEDCs_118.Where(c => c.device_id == device.device_id);
                        vIoT_DeviceEDCs_118 = vIoT_DeviceEDCs_118.OrderByDescending(c => c.clm_date_time);
                        IOT_DEVICE_EDC_118 oIoT_DeviceEDC_118 = new IOT_DEVICE_EDC_118();
                        oIoT_DeviceEDC_118 = vIoT_DeviceEDCs_118.FirstOrDefault();
                        oIoT_DeviceEDC.Clone(oIoT_DeviceEDC_118);

                        break;

                    case 119:
                        var vIoT_DeviceEDCs_119 = IOT_DEVICE_EDC_119.AsQueryable();
                        vIoT_DeviceEDCs_119 = vIoT_DeviceEDCs_119.Where(c => c.device_id == device.device_id);
                        vIoT_DeviceEDCs_119 = vIoT_DeviceEDCs_119.OrderByDescending(c => c.clm_date_time);
                        IOT_DEVICE_EDC_119 oIoT_DeviceEDC_119 = new IOT_DEVICE_EDC_119();
                        oIoT_DeviceEDC_119 = vIoT_DeviceEDCs_119.FirstOrDefault();
                        oIoT_DeviceEDC.Clone(oIoT_DeviceEDC_119);

                        break;
                    case 120:
                        var vIoT_DeviceEDCs_120 = IOT_DEVICE_EDC_120.AsQueryable();
                        vIoT_DeviceEDCs_120 = vIoT_DeviceEDCs_120.Where(c => c.device_id == device.device_id);
                        vIoT_DeviceEDCs_120 = vIoT_DeviceEDCs_120.OrderByDescending(c => c.clm_date_time);
                        IOT_DEVICE_EDC_120 oIoT_DeviceEDC_120 = new IOT_DEVICE_EDC_120();
                        oIoT_DeviceEDC_120 = vIoT_DeviceEDCs_120.FirstOrDefault();
                        oIoT_DeviceEDC.Clone(oIoT_DeviceEDC_120);

                        break;

                    case 121:
                        var vIoT_DeviceEDCs_121 = IOT_DEVICE_EDC_121.AsQueryable(); ;
                        vIoT_DeviceEDCs_121 = vIoT_DeviceEDCs_121.Where(c => c.device_id == device.device_id);
                        vIoT_DeviceEDCs_121 = vIoT_DeviceEDCs_121.OrderByDescending(c => c.clm_date_time);
                        IOT_DEVICE_EDC_121 oIoT_DeviceEDC_121 = new IOT_DEVICE_EDC_121();
                        oIoT_DeviceEDC_121 = vIoT_DeviceEDCs_121.FirstOrDefault();
                        oIoT_DeviceEDC.Clone(oIoT_DeviceEDC_121);

                        break;

                    case 122:
                        var vIoT_DeviceEDCs_122 = IOT_DEVICE_EDC_122.AsQueryable(); ;
                        vIoT_DeviceEDCs_122 = vIoT_DeviceEDCs_122.Where(c => c.device_id == device.device_id);
                        vIoT_DeviceEDCs_122 = vIoT_DeviceEDCs_122.OrderByDescending(c => c.clm_date_time);
                        IOT_DEVICE_EDC_122 oIoT_DeviceEDC_122 = new IOT_DEVICE_EDC_122();
                        oIoT_DeviceEDC_122 = vIoT_DeviceEDCs_122.FirstOrDefault();
                        oIoT_DeviceEDC.Clone(oIoT_DeviceEDC_122);

                        break;

                    case 123:
                        var vIoT_DeviceEDCs_123 = IOT_DEVICE_EDC_123.AsQueryable(); ;
                        vIoT_DeviceEDCs_123 = vIoT_DeviceEDCs_123.Where(c => c.device_id == device.device_id);
                        vIoT_DeviceEDCs_123 = vIoT_DeviceEDCs_123.OrderByDescending(c => c.clm_date_time);
                        IOT_DEVICE_EDC_123 oIoT_DeviceEDC_123 = new IOT_DEVICE_EDC_123();
                        oIoT_DeviceEDC_123 = vIoT_DeviceEDCs_123.FirstOrDefault();
                        oIoT_DeviceEDC.Clone(oIoT_DeviceEDC_123);

                        break;

                    case 124:
                        var vIoT_DeviceEDCs_124 = IOT_DEVICE_EDC_124.AsQueryable(); ;
                        vIoT_DeviceEDCs_124 = vIoT_DeviceEDCs_124.Where(c => c.device_id == device.device_id);
                        vIoT_DeviceEDCs_124 = vIoT_DeviceEDCs_124.OrderByDescending(c => c.clm_date_time);
                        IOT_DEVICE_EDC_124 oIoT_DeviceEDC_124 = new IOT_DEVICE_EDC_124();
                        oIoT_DeviceEDC_124 = vIoT_DeviceEDCs_124.FirstOrDefault();
                        oIoT_DeviceEDC.Clone(oIoT_DeviceEDC_124);

                        break;

                    case 125:
                        var vIoT_DeviceEDCs_125 = IOT_DEVICE_EDC_125.AsQueryable(); ;
                        vIoT_DeviceEDCs_125 = vIoT_DeviceEDCs_125.Where(c => c.device_id == device.device_id);
                        vIoT_DeviceEDCs_125 = vIoT_DeviceEDCs_125.OrderByDescending(c => c.clm_date_time);
                        IOT_DEVICE_EDC_125 oIoT_DeviceEDC_125 = new IOT_DEVICE_EDC_125();
                        oIoT_DeviceEDC_125 = vIoT_DeviceEDCs_125.FirstOrDefault();
                        oIoT_DeviceEDC.Clone(oIoT_DeviceEDC_125);

                        break;

                    case 126:
                        var vIoT_DeviceEDCs_126 = IOT_DEVICE_EDC_126.AsQueryable(); ;
                        vIoT_DeviceEDCs_126 = vIoT_DeviceEDCs_126.Where(c => c.device_id == device.device_id);
                        vIoT_DeviceEDCs_126 = vIoT_DeviceEDCs_126.OrderByDescending(c => c.clm_date_time);
                        IOT_DEVICE_EDC_126 oIoT_DeviceEDC_126 = new IOT_DEVICE_EDC_126();
                        oIoT_DeviceEDC_126 = vIoT_DeviceEDCs_126.FirstOrDefault();
                        oIoT_DeviceEDC.Clone(oIoT_DeviceEDC_126);

                        break;

                    case 127:
                        var vIoT_DeviceEDCs_127 = IOT_DEVICE_EDC_127.AsQueryable(); ;
                        vIoT_DeviceEDCs_127 = vIoT_DeviceEDCs_127.Where(c => c.device_id == device.device_id);
                        vIoT_DeviceEDCs_127 = vIoT_DeviceEDCs_127.OrderByDescending(c => c.clm_date_time);
                        IOT_DEVICE_EDC_127 oIoT_DeviceEDC_127 = new IOT_DEVICE_EDC_127();
                        oIoT_DeviceEDC_127 = vIoT_DeviceEDCs_127.FirstOrDefault();
                        oIoT_DeviceEDC.Clone(oIoT_DeviceEDC_127);

                        break;

                    case 128:
                        var vIoT_DeviceEDCs_128 = IOT_DEVICE_EDC_128.AsQueryable(); ;
                        vIoT_DeviceEDCs_128 = vIoT_DeviceEDCs_128.Where(c => c.device_id == device.device_id);
                        vIoT_DeviceEDCs_128 = vIoT_DeviceEDCs_128.OrderByDescending(c => c.clm_date_time);
                        IOT_DEVICE_EDC_128 oIoT_DeviceEDC_128 = new IOT_DEVICE_EDC_128();
                        oIoT_DeviceEDC_128 = vIoT_DeviceEDCs_128.FirstOrDefault();
                        oIoT_DeviceEDC.Clone(oIoT_DeviceEDC_128);

                        break;

                    default:
                        //
                        break;
                }



            }
            catch (Exception ex)
            {
                string err_msg = ex.Message;
                return (oIoT_DeviceEDC);
            }

            return (oIoT_DeviceEDC);
        }
    }

    
}