using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chasovoy
{
    public static class Helper
    {
        public static float Map(float value, float valueMin, float valueMax, float outMin, float outMax)
        {
            return (value - valueMin) / (valueMax - valueMin) * (outMax - outMin) + outMin;
        }
    }
}
