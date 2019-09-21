using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitoringModels.Clients
{
    public class ModelHost
    {
        // ID
        public System.Guid Host_ID { get; set; }
        // IP adress
        public string IP { get; set; }
        // DNS name of the host-name
        public string DNS_Name { get; set; }
        // Display name of the host-name
        public string Display_Name { get; set; }
        // Network state 
        public bool State { get; set; }
        // Last successful connection (ping)
        public System.DateTime Last_Appeal { get; set; }


        public ModelHost(string ip, string DNS_Name, string Display_Name, bool state)
        {
            this.IP = ip;
            this.DNS_Name = DNS_Name;
            this.Display_Name = Display_Name;
            this.State = state;
            this.Last_Appeal = DateTime.Now;
        }

        public ModelHost()
        {

        }
    }
}
