﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Monitoring_DB;
using MonitoringModels.Clients;
using AutoMapper;

namespace Debug_View
{
    class Program
    {
        static void Main(string[] args)
        {
            // Place it to the startup
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<ModelHost, Host>();
            });

            IMapper iMapper = config.CreateMapper();
            var source = new ModelHost("101231", "MyTestDNSName", "MyTestDisplayName", true);
            var destination = iMapper.Map<ModelHost, Host>(source);


            config.AssertConfigurationIsValid();
            // use DI (http://docs.automapper.org/en/latest/Dependency-injection.html) or create the mapper yourself


            using (Monitoring_DB.MonitoringContainer db = new MonitoringContainer())
            {
                // добавление элементов
                db.HostSet.Add(iMapper.Map<ModelHost, Host>(new ModelHost("101231", "MyTestDNSName", "MyTestDisplayName", true)));
                db.SaveChanges();
                // получение элементов
                var hosts = db.HostSet;
                foreach (Host u in hosts)
                    Console.WriteLine($"{u.Display_Name}, {u.DNS_Name}, {u.Last_Appeal}");
            }
            Console.Read();
        }
    }
}