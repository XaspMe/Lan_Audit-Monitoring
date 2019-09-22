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
    class HostInitiation
    {
        private ModelHost modelHost { get; set;}

        /// <summary>
        /// Initialize 
        /// </summary>
        /// <param name="adress"></param>
        public void Start(string adress)
        {
            modelHost = new ModelHost();

            if (!string.IsNullOrWhiteSpace(adress))
            {
                if (IsIp(adress))
                {
                    modelHost.IP = adress;
                    if (this.Available())
                    {
                        modelHost.DNS_Name = GetDnsNameByIp(adress);
                    }
                }
                else
                {
                    modelHost.DNS_Name = adress;
                    if (Available())
                    {
                        modelHost.IP = GetIPbyName(adress);
                    }
                }
            }
            else
            {
                throw new ArgumentException("Adress cannot be null.");
            }
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
