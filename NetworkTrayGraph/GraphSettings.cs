using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Drawing;
using System.IO;

namespace NetworkTrayGraph
{

    public enum NetworkSpeed
    {
        B,
        KB,
        MB,
        GB
    }

    public enum GraphScale
    {
        Linear,
        Logarithmic
    }

    
    /// <summary>
    /// Stores settings used by application
    /// </summary>
    public class GraphSettings
    {
        public Color ReceiveColor = Color.DarkGreen;
        public Color SentColor = Color.OrangeRed;
        //public Color ReceiveHighlightColor = Color.ForestGreen;
        //public Color SendHighlightColor = Color.DarkRed;

        public int UpdateInterval = 10000;
        public int MaxDisplayValue = 1000;
        public Dictionary<string, bool> EnabledInterfaces;

        public GraphScale Scale = GraphScale.Logarithmic;
        public NetworkSpeed DisplayValue = NetworkSpeed.KB; // Not used

        /// <summary>
        /// Converts the settings object to a base64 encoded string
        /// </summary>
        /// <returns></returns>
        public string ToString()
        {
            using (MemoryStream stream = new MemoryStream())
            using (BinaryWriter writer = new BinaryWriter(stream))
            {
                writer.Write(ReceiveColor.R);
                writer.Write(ReceiveColor.G);
                writer.Write(ReceiveColor.B);

                writer.Write(SentColor.R);
                writer.Write(SentColor.G);
                writer.Write(SentColor.B);

                writer.Write(UpdateInterval);
                writer.Write(MaxDisplayValue);
                writer.Write((byte)Scale);
                writer.Write((byte)DisplayValue);

                byte[] data = stream.ToArray();
                return Convert.ToBase64String(data);
            }
        }

        /// <summary>
        /// Converts a base64 encoded string to a settings object
        /// </summary>
        /// <param name="data"></param>
        public void FromString(string data)
        {
            byte[] convertedData = Convert.FromBase64String(data);

            using (MemoryStream stream = new MemoryStream(convertedData))
            using (BinaryReader reader = new BinaryReader(stream))
            {
                byte receiveColorR = reader.ReadByte();
                byte receiveColorG = reader.ReadByte();
                byte receiveColorB = reader.ReadByte();
                ReceiveColor = Color.FromArgb(receiveColorR, receiveColorG, receiveColorB);

                byte sentColorR = reader.ReadByte();
                byte sentColorG = reader.ReadByte();
                byte sentColorB = reader.ReadByte();
                SentColor = Color.FromArgb(sentColorR, sentColorG, sentColorB);

                UpdateInterval = reader.ReadInt32();
                MaxDisplayValue = reader.ReadInt32();
                Scale = (GraphScale)reader.ReadByte();
                DisplayValue = (NetworkSpeed)reader.ReadByte();

            }
        }
    }
}
