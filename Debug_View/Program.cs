using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Monitoring_DB;
using MonitoringBL.HostActions;
using AutoMapper;

namespace Debug_View
{
    class Program
    {
        static void Main(string[] args)
        {
            //// Place it to the startup
            //var config = new MapperConfiguration(cfg => {
            //    cfg.CreateMap<ModelHost, Host>();
            //});

            //IMapper iMapper = config.CreateMapper();
            //config.AssertConfigurationIsValid();
            //// use DI (http://docs.automapper.org/en/latest/Dependency-injection.html) or create the mapper yourself

            HostInitiation initiation = new HostInitiation("192.168.0.104", "My test");

            Console.WriteLine(initiation.SaveToDb());

            using (MonitoringContainer db = new MonitoringContainer())
            {
                var hosts = db.HostSet;
                foreach (Host u in hosts)
                    Console.WriteLine($"{u.Display_Name}, {u.DNS_Name}, {u.Last_Appeal} {u.Host_ID}");
            }

            Console.Read();
        }
    }
}