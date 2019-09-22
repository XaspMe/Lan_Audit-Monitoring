using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MonitoringModels.Clients;
using Monitoring_DB;

namespace MonitoringBL
{
    public static class AutomapperConfiguration
    {
        public static IMapper iMapper { get; set; }

        private static MapperConfiguration Configuration { get; set; }

        static AutomapperConfiguration()
        {
            Configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ModelHost, Host>();
                cfg.CreateMap<Host, ModelHost>();
            });
            iMapper = Configuration.CreateMapper();
        }
    }
}
