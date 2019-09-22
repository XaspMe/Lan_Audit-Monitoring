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


            //using (Monitoring_DB.MonitoringContainer db = new MonitoringContainer())
            //{
            //    // добавление элементов
            //    db.HostSet.Add(iMapper.Map<ModelHost, Host>(new ModelHost("101231", "MyTestDNSName", "MyTestDisplayName", true)));
            //    db.SaveChanges();
            //    // получение элементов
            //    var hosts = db.HostSet;
            //    foreach (Host u in hosts)
            //        Console.WriteLine($"{u.Display_Name}, {u.DNS_Name}, {u.Last_Appeal} {u.Host_ID}");
            //}
            HostInitiation initiation = new HostInitiation("192.168.0.104", "MyTestPc");
            Console.WriteLine(initiation.modelHost.Last_Appeal);
            Console.WriteLine(initiation.modelHost.Host_ID);
            Console.WriteLine(initiation.modelHost.IP);
            Console.WriteLine(initiation.modelHost.DNS_Name);
            Console.WriteLine(initiation.modelHost.State);


            Console.Read();
        }
    }
}
