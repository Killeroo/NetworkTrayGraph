using System;
using System.Net;
using System.Linq;
using System.Net.NetworkInformation;
using System.Collections.Generic;

namespace NetworkTrayGraph
{

    public class InterfaceStatistics
    {
        public string Name;
        public string Id;
        public OperationalStatus Status;

        public long ReceivedBytes;
        public long SentBytes;

        public long LastReceivedBytes;
        public long LastSentBytes;

        public int BytesReceivedPerSecond;
        public int BytesSentPerSecond;

        public InterfaceStatistics() { }
        public InterfaceStatistics(InterfaceStatistics old)
        {
            Name = old.Name;
            Id = old.Id;
            Status = old.Status;

            SentBytes = old.SentBytes;
            ReceivedBytes = old.ReceivedBytes;
            LastSentBytes = old.LastSentBytes;
            LastReceivedBytes = old.LastReceivedBytes;

            BytesReceivedPerSecond = old.BytesReceivedPerSecond;
            BytesSentPerSecond = old.BytesSentPerSecond;
        }
    }

    /// <summary>
    /// Network monitor updates and stores data about all network interfaces on the computer. The update function is called by the main application
    /// and fetches the most recent bytes sent and received by the interface
    /// </summary>
    public class NetworkMonitor
    {
        public Dictionary<string, InterfaceStatistics> InterfaceStats { get; private set; } = new Dictionary<string, InterfaceStatistics>();

        private List<NetworkInterface> _availableInterfaces = new List<NetworkInterface>();

        public NetworkMonitor() { }

        public List<string> GetAvailableInterfaceNames()
        {
            // Update our internal list of adapters first
            UpdateAvailableAdapters();
            
            // Return the name to the caller
            return _availableInterfaces.Select(x => x.Name).ToList();
        }

        /// <summary>
        /// Removes old interfaces from the InterfaceStats Dictionary that aren't available or enabled anymore
        /// </summary>
        /// <param name="settings"></param>
        public void PruneInterfaceStatistics(GraphSettings settings)
        {
            List<string> enabledAdapterNames = settings.EnabledInterfaces.Where(i => i.Value == true).Select(x => x.Key).ToList();
            List<string> keysToRemove = new List<string>();

            foreach (var stat in InterfaceStats)
            {
                if (!enabledAdapterNames.Contains(stat.Key) || !_availableInterfaces.Select(x => x.Name).Contains(stat.Key))
                    keysToRemove.Add(stat.Key);
            }

            foreach (var key in keysToRemove)
            {
                InterfaceStats.Remove(key);
            }
        }

        /// <summary>
        /// Updates the InterfaceStats dictionary with the most current sent and received bytes, this is used to calculate that adapters
        /// bytes per second, which is displayed on the graph
        /// </summary>
        /// <param name="settings"></param>
        public void Update(GraphSettings settings)
        {
            List<string> enabledAdapterNames = settings.EnabledInterfaces.Where(i => i.Value == true).Select(x => x.Key).ToList();

            // Loop through available and enabled adapters
            foreach (NetworkInterface nic in _availableInterfaces.Where(x => enabledAdapterNames.Contains(x.Name)))
            {
                string adapterName = nic.Name;

                if (!InterfaceStats.ContainsKey(adapterName))
                {
                    InterfaceStats.Add(adapterName, CreateAdapterStatistics(nic));
                }
                else
                {
                    InterfaceStats[adapterName] = UpdateAdapterStatistics(nic, InterfaceStats[adapterName], settings.UpdateInterval); ;
                }
            }
        }

        private void UpdateAvailableAdapters()
        {
            _availableInterfaces = NetworkInterface.GetAllNetworkInterfaces().ToList();
        }

        private InterfaceStatistics CreateAdapterStatistics(NetworkInterface @interface)
        {
            IPv4InterfaceStatistics interfaceStats = @interface.GetIPv4Statistics();

            InterfaceStatistics stats = new InterfaceStatistics()
            {
                Name = @interface.Name,
                Id = @interface.Id,
                Status = @interface.OperationalStatus,

                SentBytes = interfaceStats.BytesSent,
                ReceivedBytes = interfaceStats.BytesReceived,
                LastSentBytes = interfaceStats.BytesSent,
                LastReceivedBytes = interfaceStats.BytesReceived,

                BytesReceivedPerSecond = 0,
                BytesSentPerSecond = 0
            };

            return stats;
        }

        private InterfaceStatistics UpdateAdapterStatistics(NetworkInterface @interface, InterfaceStatistics oldStats, int updateIntervalMs)
        {
            IPv4InterfaceStatistics interfaceIPv4Stats = @interface.GetIPv4Statistics();
            InterfaceStatistics newStats = new InterfaceStatistics(oldStats);

            newStats.Status = @interface.OperationalStatus;

            newStats.LastSentBytes = oldStats.SentBytes;
            newStats.LastReceivedBytes = oldStats.ReceivedBytes;

            newStats.SentBytes = interfaceIPv4Stats.BytesSent;
            newStats.ReceivedBytes = interfaceIPv4Stats.BytesReceived;

            try
            {
                newStats.BytesSentPerSecond = Convert.ToInt32((newStats.SentBytes - newStats.LastSentBytes) * (updateIntervalMs / 1000));
                newStats.BytesReceivedPerSecond = Convert.ToInt32((newStats.ReceivedBytes - newStats.LastReceivedBytes) * (updateIntervalMs / 1000));
            }
            catch(Exception) 
            {
                newStats.BytesSentPerSecond = 0;
                newStats.BytesReceivedPerSecond = 0;
            }
            
            return newStats;
        }
    }
}
