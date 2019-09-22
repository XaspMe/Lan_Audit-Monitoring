using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonitoringModels.Clients;
using System.Text.RegularExpressions;
using System.Net;

namespace MonitoringBL.HostActions
{
    public class HostInitiation
    {
        public ModelHost modelHost { get; set; }

        public HostInitiation(string adress, string displaName)
        {
            initialize(adress, displaName);
        }


        /// <summary>
        /// Initialize 
        /// </summary>
        /// <param name="adress"></param>
        private void initialize(string adress, string displayName)
        {
            if (string.IsNullOrWhiteSpace(adress))
            {
                throw new ArgumentException("Null or white space", nameof(adress));
            }

            if (string.IsNullOrWhiteSpace(displayName))
            {
                throw new ArgumentException("Null or white space", nameof(displayName));
            }

            modelHost = new ModelHost();

            // Set ip or dns

            if (IsIp(adress))
            {
                modelHost.IP = adress;
                if (this.Available())
                {
                    modelHost.State = true;
                    modelHost.DNS_Name = GetDnsNameByIp(adress);
                }
                else
                    modelHost.State = false;
            }
            else
            {
                modelHost.DNS_Name = adress;
                if (Available())
                {
                    modelHost.State = true;
                    modelHost.IP = GetIPbyName(adress);
                }
                else
                    modelHost.State = false;
            }

            modelHost.Display_Name = displayName;
            modelHost.Last_Appeal = DateTime.Now;
        }

        private bool Available(int time = 50)
        {
            // TODO: Вынести в конфиги время ожидания пинга.
            try
            {
                return new System.Net.NetworkInformation.Ping().Send(
                                    String.IsNullOrWhiteSpace(modelHost.IP) ? modelHost.DNS_Name : modelHost.IP, time)
                                    .Status.ToString() != "TimedOut" ? true : false;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Set ip adress to host from dns name.
        /// </summary>
        private string GetIPbyName(string host)
        {
            return Dns.GetHostAddresses(host).Where(x => !x.IsIPv6LinkLocal).SingleOrDefault().ToString();
        }

        /// <summary>
        /// Set dns name to host from IP.
        /// </summary>
        private string GetDnsNameByIp(string ip)
        {
            try
            {
                return Dns.GetHostEntry(IPAddress.Parse(ip)).HostName.Split('.')[0].ToString();
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Determine whether the string is IP.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private bool IsIp(string input)
        {
            string pat = @"^(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)(\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)){3}$";
            return new Regex(pat).IsMatch(input);
        }
    }
}
