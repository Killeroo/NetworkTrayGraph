using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkTrayGraph
{
    public static class Helper
    {
        public static float Map(float value, float valueMin, float valueMax, float outMin, float outMax)
        {
            if (value > valueMax) return outMax;

            return (value - valueMin) / (valueMax - valueMin) * (outMax - outMin) + outMin;
        }

        public static long ToKilobytes(long bytes)
        {
            return bytes / 1024;
        }

        public static long ToMegabytes(long bytes)
        {
            return bytes / 1024 / 1024;
        }

        public static long ToGigabytes(long bytes)
        {
            return bytes / 1024 / 1024 / 1024;
        }

        public static float ToKilobytes(float bytes)
        {
            return (float) Math.Round(bytes / 1024, 1);
        }

        public static float ToMegabytes(float bytes)
        {
            return (float)Math.Round(bytes / 1024 / 1024, 1);
        }

        public static float ToGigabytes(float bytes)
        {
            return (float)Math.Round(bytes / 1024 / 1024 / 1024, 1);
        }
    }
}
