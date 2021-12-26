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
        public Color ReceivedBodyColor = Color.Green;
        public Color SentBodyColor = Color.OrangeRed;
        public Color ReceivedHighlightColor = Color.FromArgb(34, 83, 34);
        public Color SentHighlightColor = Color.DarkRed;

        public int UpdateInterval = 1000;
        public int InterfaceCheckInterval = 30000;
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
                writer.Write(ReceivedBodyColor.R);
                writer.Write(ReceivedBodyColor.G);
                writer.Write(ReceivedBodyColor.B);

                writer.Write(ReceivedHighlightColor.R);
                writer.Write(ReceivedHighlightColor.G);
                writer.Write(ReceivedHighlightColor.B);

                writer.Write(SentBodyColor.R);
                writer.Write(SentBodyColor.G);
                writer.Write(SentBodyColor.B);

                writer.Write(SentHighlightColor.R);
                writer.Write(SentHighlightColor.G);
                writer.Write(SentHighlightColor.B);

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
                byte receivedBodyColorR = reader.ReadByte();
                byte receivedBodyColorG = reader.ReadByte();
                byte receivedBodyColorB = reader.ReadByte();
                ReceivedBodyColor = Color.FromArgb(receivedBodyColorR, receivedBodyColorG, receivedBodyColorB);

                byte receivedHighlightColorR = reader.ReadByte();
                byte receivedHighlightColorG = reader.ReadByte();
                byte receivedHighlightColorB = reader.ReadByte();
                ReceivedHighlightColor = Color.FromArgb(receivedHighlightColorR, receivedHighlightColorG, receivedHighlightColorB);

                byte sentColorR = reader.ReadByte();
                byte sentColorG = reader.ReadByte();
                byte sentColorB = reader.ReadByte();
                SentBodyColor = Color.FromArgb(sentColorR, sentColorG, sentColorB);

                byte sentHighlightColorR = reader.ReadByte();
                byte sentHighlightColorG = reader.ReadByte();
                byte sentHighlightColorB = reader.ReadByte();
                SentHighlightColor = Color.FromArgb(sentHighlightColorR, sentHighlightColorG, sentHighlightColorB);

                UpdateInterval = reader.ReadInt32();
                MaxDisplayValue = reader.ReadInt32();
                Scale = (GraphScale)reader.ReadByte();
                DisplayValue = (NetworkSpeed)reader.ReadByte();

            }
        }
    }
}
