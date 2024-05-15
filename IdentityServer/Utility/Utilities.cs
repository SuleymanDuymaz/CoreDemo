using System.Collections.Generic;
using System.Net;
using System;
using System.Management;

namespace Is4RoleDemo.Utility
{
    public static class Utilities
    {
        public static string GetMACAddress()
        {
            ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection moc = mc.GetInstances();
            string MACAddress = String.Empty;
            foreach (ManagementObject mo in moc)
            {
                if (MACAddress == String.Empty)
                {
                    if ((bool)mo["IPEnabled"] == true)
                    {
                        MACAddress = mo["MacAddress"].ToString();
                        break;
                    }
                }
                // mo.Dispose();
            }
            moc.Dispose();
            MACAddress = MACAddress.Replace(":", "");
            return MACAddress;
        }
        public static string GetIpAddress()
        {
            List<string> ipAddressList = new List<string>();

            string hostName = Dns.GetHostName();
            string myIP = Dns.GetHostByName(hostName).AddressList[1].ToString();

            ipAddressList.Add(hostName);
            ipAddressList.Add(myIP);
            return ipAddressList[1];

        }
        public static DateTime GetDate()
        {
            return DateTime.Now;
        }
    }
}
