using Entities;
using Karakurt.MailManager;
using ModbusLibrary;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace TestConsole
{
    class Program
    {
        
        static void Main(string[] args)
        {
            /*CsvReporter reporter;
            ModbusTcpClient client = new ModbusTcpClient("192.168.0.24", 502,2);
            
            client.Connect();

            Unit unit = new Unit()
            {
               // BusbarVoltage = client.GetHoldingRegisterData(1),
               // BusbarSetVoltage = 158,
                // BrmHighReactivePower = client.GetHoldingRegisterData(531),
                // BrmLowReactivePower = client.GetHoldingRegisterData(533),
                // BrmTotalReactivePower = client.GetHoldingRegisterData(535),
                //Unit1ActivePower = client.GetHoldingRegisterData(516) / 1000000,
                // Unit1ReactivePower = client.GetHoldingRegisterData(518) / 1000000,
                // Unit1Voltage = client.GetHoldingRegisterData(522) /1000,
                //Unit1Mode = client.GetHoldingRegisterData(537),
                //Unit2ActivePower = client.GetHoldingRegisterData(508) / 1000000,
                // Unit2ReactivePower = client.GetHoldingRegisterData(510) / 1000000,
                // Unit2Voltage = client.GetHoldingRegisterData(514) / 1000,
                //Unit2Mode = client.GetHoldingRegisterData(539),
                //Unit3ActivePower = client.GetHoldingRegisterData(500) / 1000000,
                //Unit3ReactivePower = client.GetHoldingRegisterData(502) / 1000000,
                // Unit3Voltage = client.GetHoldingRegisterData(506) / 1000,
                // Unit3Mode = client.GetHoldingRegisterData(541)
            };

            //client.Disconnect();
            //Console.WriteLine(unit.BusbarVoltage + " " + unit.BusbarSetVoltage + " ");
           

            //MailSender.Send("");*/

            string path = @"C:\Users\Public\Documents\Reports\";
            string textFile = path + "test.txt";
            DateTime past = DateTime.Now.AddDays(-1);
            string zipFile = path + $"RGVK_KARAKURT_{past.ToString("yyyyMMdd")}.zip";

            var archive = ZipFile.Open(zipFile, ZipArchiveMode.Create);
            archive.CreateEntryFromFile(textFile, Path.GetFileName(textFile));
            archive.Dispose();

            /*var mailToList = ConfigurationManager.AppSettings["mailToList"].Split(',').ToList();

            foreach (var mailTo in mailToList)
            {
                Console.WriteLine(mailTo);
            }*/

            //Console.WriteLine(AppDomain.CurrentDomain.BaseDirectory);

            /*JObject jObject = JObject.Parse(File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "config.json"));

            Console.WriteLine(jObject["testMailTo"]);*/

            //string path = AppDomain.CurrentDomain.BaseDirectory + "counter.txt";

            /*if (!File.Exists(path))
            {
                using (StreamWriter streamWriter = File.CreateText(path))
                {
                    streamWriter.WriteLine("Hello");
                }
            }
            else
            {
                using (StreamWriter streamWriter = new StreamWriter(path))
                {
                    streamWriter.WriteLine("Thanks");
                }
            }*/

            /*using (StreamReader streamReader = new StreamReader(path))
            {
                string line = streamReader.ReadLine();
                Console.WriteLine(line);
            }*/

            int result = CalculateCounter();
            Console.WriteLine(result);
            // Console.ReadLine();
            
            Console.ReadLine();

        }

        static private int CalculateCounter()
        {
            int hour = DateTime.Now.Hour;
            int minute = DateTime.Now.Minute;

            return (hour * 60) + minute;
        }
    }
}
