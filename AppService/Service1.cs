using CsvLibrary;
using Entities;
using ModbusLibrary;
using System;
using System.Diagnostics;
using System.ServiceProcess;
using System.Threading.Tasks;
using System.Timers;


namespace AppService
{
    public partial class Service1 : ServiceBase
    {
        Timer _sfkTimer;
        ModbusTcpClient _client;
        CsvReporter _reporter;
        
        public Service1()
        {
            InitializeComponent();
            _sfkTimer = new Timer();
            _reporter = new CsvReporter();
            _client = new ModbusTcpClient("172.16.4.100", 502);
          
        }

        protected override void OnStart(string[] args)
        {                     
            _sfkTimer.Interval = 996;
            _sfkTimer.Elapsed += _sfkTimer_Elapsed;
            _sfkTimer.Start();
        }
        private int CalculateCounterSecond()
        {
            int hour = DateTime.Now.Hour;
            int minute = DateTime.Now.Minute;
            int second = DateTime.Now.Second;
            int total = (hour * 3600) + (minute * 60) + second;
            return total;
        }

        private async void _sfkTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            await Task.Run(() =>
                { 
                try
                {
                   // _client.Connect();

                   SfkReport sfkReport = new SfkReport()
                    {
                       /* FRE_HZ = _client.GetHoldingRegisterData(1036),
                        BRM_GUC_REF_DEG_MW = _client.GetHoldingRegisterData(1028),
                        BRM_AKT_CIK_GUCU_BRUTMW = _client.GetHoldingRegisterData(1030),
                        BRM_AKT_CIK_GUCU_NETMW = _client.GetHoldingRegisterData(1032),
                        BRM_PFK_TPLM_NOM_GUCMW = _client.GetHoldingRegisterData(1034),
                        BRM_SEK_MAK_MW = _client.GetHoldingRegisterData(1014),
                        BRM_SEK_MIN_MW = _client.GetHoldingRegisterData(1018),
                        BRM_PRI_MAKC_MW = _client.GetHoldingRegisterData(1016),
                        BRM_PRI_MINC_MW = _client.GetHoldingRegisterData(1020),
                        BRM_GNCL_KPR_MW_HZ = _client.GetHoldingRegisterData(1012),
                        BRM_SFK_REZ_MIK_MW = _client.GetHoldingRegisterData(1026),
                        BRM_PFK_REZ_MIK_MW = _client.GetHoldingRegisterData(1024),
                        AGC_AKT = Convert.ToInt32(_client.GetHoldingRegisterData(1010)),
                        PFCO_AKT = Convert.ToInt32(_client.GetHoldingRegisterData(1022))*/
                    };

                   // _client.Disconnect();
                   int currentCounterSecond = CalculateCounterSecond();
                   bool isNew = _reporter.WriteSfkData(sfkReport, currentCounterSecond);
                }


                catch (Exception ex)
                {
                }
              });
        }

        protected override void OnStop()
        {
            _sfkTimer.Stop();
            _sfkTimer.Dispose();
        }
    }
}
