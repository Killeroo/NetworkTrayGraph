using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace NetworkTrayGraph
{
    /// <summary>
    /// Responsible for creating any graphs for the application
    /// </summary>
    class GraphBuilder
    {
        public int MaxDataValue { get; set; } = 5000;

        internal const int GRAPH_AREA_START_X = 1;
        internal const int GRAPH_AREA_START_Y = 15;//4;
        internal const int GRAPH_MAX_COLUMN_SIZE = 14;

        private int _currentScaleIndex = 0;

        private static List<int> _graphLogarithmicScale = new List<int>()
        {
            250,
            500,
            1000,
            2000,
            4000,
            8000,
            16000,
            32000,
            64000,
            128000,
            256000,
            512000,
            1024000,
            2048000,
            4096000,
            8192000,
            16384000
        };

        /// <summary>
        /// Creates a graph bitmap from sent and recieved data. The bitmap is 16x16, the size of icons that are allowed in the system tray
        /// </summary>
        /// <param name="receiveData">List of recieve bytes</param>
        /// <param name="sentData">List of sent bytes</param>
        /// <param name="settings"></param>
        /// <returns></returns>
        public Bitmap CreateBitmap(List<long> receiveData, List<long> sentData, GraphSettings settings)
        {
            // Convert to whatever format we are using
            Func<long, long> convertBytes = bytes =>
            {
                switch (settings.DisplayValue)
                {
                    case NetworkSpeed.KB:
                        return Helper.ToKilobytes(bytes);
                    case NetworkSpeed.MB:
                        return Helper.ToMegabytes(bytes);
                    case NetworkSpeed.GB:
                        return Helper.ToGigabytes(bytes);
                    default:
                        return bytes;
                }
            };

            receiveData = receiveData.Select(convertBytes).ToList();
            sentData = sentData.Select(convertBytes).ToList();

            //List<int> receiveColumns = new List<int>();
            //List<int> sendColumns = new List<int>();
            //foreach (var item in receiveData)
            //{
            //    int columnSize = 0;

            //    if (item > settings.MaxDisplayValue)
            //        columnSize = GRAPH_MAX_COLUMN_SIZE - 1; // - 1 pixels to stop the column from drawing over the border
            //    else
            //        columnSize = (int)Math.Round(Helper.Map(item, 0, settings.MaxDisplayValue, 0, GRAPH_MAX_COLUMN_SIZE));

            //    receiveColumns.Add(columnSize);
            //}
            //foreach (var item in sentData)
            //{
            //    int columnSize = 0;

            //    if (item > settings.MaxDisplayValue)
            //        columnSize = GRAPH_MAX_COLUMN_SIZE - 1; // - 1 pixels to stop the column from drawing over the border
            //    else
            //        columnSize = (int)Math.Round(Helper.Map(item, 0, settings.MaxDisplayValue, 0, GRAPH_MAX_COLUMN_SIZE));

            //    sendColumns.Add(columnSize);
            //}

            // Check is we need to increase or decrease the scale
            int maxYValue = 0;
            if (settings.Scale == GraphScale.Logarithmic)
            {
                bool scaleUp = false;
                foreach (var item in sentData)
                {
                    if (item > _graphLogarithmicScale[_currentScaleIndex])
                    {
                        scaleUp = true;
                        break;
                    }
                }
                foreach (var item in receiveData)
                {
                    if (item > _graphLogarithmicScale[_currentScaleIndex])
                    {
                        scaleUp = true;
                        break;
                    }
                }

                if (scaleUp)
                {
                    if (_currentScaleIndex != _graphLogarithmicScale.Count - 1)
                    {
                        _currentScaleIndex++;
                    }
                }

                bool scaleDown = false;
                foreach (var item in sentData)
                {
                    if (item < _graphLogarithmicScale[_currentScaleIndex])
                    {
                        scaleDown = true;
                    }
                    else
                    {
                        scaleDown = false;
                        break;
                    }
                }
                foreach (var item in receiveData)
                {
                    if (item < _graphLogarithmicScale[_currentScaleIndex])
                    {
                        scaleDown = true;
                    }
                    else
                    {
                        scaleDown = false;
                        break;
                    }
                }

                if (scaleDown)
                {
                    if (_currentScaleIndex != 0)
                    {
                        _currentScaleIndex--;
                    }
                }

                maxYValue = _graphLogarithmicScale[_currentScaleIndex];

            }
            else
            {
                maxYValue = settings.MaxDisplayValue;
            }

            Bitmap pic = new Bitmap(16, 16);
            Graphics graphics = Graphics.FromImage(pic);

            // Create background and border
            Pen borderPen = new Pen(Color.Gray);
            graphics.FillRectangle(Brushes.White, new Rectangle(new Point(0, 0), new Size(15, 15)));
            graphics.DrawRectangle(borderPen, new Rectangle(new Point(0, 0), new Size(15, 15)));

            // Draw each graph column
            int currentCol = 0;
            for (int i = 0; i < receiveData.Count; i++)
            {
                long item = receiveData[i];
                int columnSize = 0;

                // Work out size of column
                if (item > maxYValue)
                    columnSize = GRAPH_MAX_COLUMN_SIZE - 1; // - 1 pixels to stop the column from drawing over the border
                else
                    columnSize = (int)Math.Round(Helper.Map(item, 0, maxYValue, 0, GRAPH_MAX_COLUMN_SIZE));

                // Draw column to bitmap 
                for (int y = 0; y < columnSize; y++)
                {
                    pic.SetPixel(GRAPH_AREA_START_X + currentCol, 14 - y, settings.ReceiveColor);
                }

                currentCol++;
            }

            // Draw each graph column
            currentCol = 0;
            foreach (var item in sentData)
            {
                int columnSize = 0;

                // Work out size of column
                if (item > maxYValue)
                    columnSize = GRAPH_MAX_COLUMN_SIZE - 1;
                else
                    columnSize = (int)Math.Round(Helper.Map(item, 0, maxYValue, 0, GRAPH_MAX_COLUMN_SIZE));

                for (int y = 0; y < columnSize; y++)
                {
                    pic.SetPixel(GRAPH_AREA_START_X + currentCol, 14 - y, settings.SentColor);
                }

                currentCol++;
            }

            return pic;
        }
    }

    //Text icon: https://stackoverflow.com/a/36379999
}
