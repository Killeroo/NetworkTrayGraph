using System;
using System.Net;
using System.Linq;
using System.Net.NetworkInformation;
using System.Collections.Generic;

namespace Chasovoy
{
    public class NetworkMonitor
    {
        public Dictionary<string, (long recv, long sent, long lastRecv, long lastSent)> InterfaceStats { get; set; } =
            new Dictionary<string, (long recv, long sent, long lastRecv, long lastSent)>();

        public NetworkMonitor() { }

        public void Update()
        {
            // TODO: Check periodically if new network interfaces have been added
            foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {
                long recv = nic.GetIPv4Statistics().BytesReceived;
                long sent = nic.GetIPv4Statistics().BytesSent;
                string name = nic.Name;

                if (!InterfaceStats.ContainsKey(nic.Name))
                {
                    InterfaceStats.Add(
                        nic.Name,
                        (recv, sent, 0, 0)
                    );
                }
                else
                {
                    var values = InterfaceStats[name];
                    values.lastRecv = InterfaceStats[name].recv;
                    values.lastSent = InterfaceStats[name].sent;
                    values.sent = sent;
                    values.recv = recv;
                    InterfaceStats[name] = values; // Don't think this is really needed

                }
            }
        }

    }
}
