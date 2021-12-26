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
        /// <param name="receivedData">List of recieve bytes</param>
        /// <param name="sentData">List of sent bytes</param>
        /// <param name="settings"></param>
        /// <returns></returns>
        public Bitmap CreateBitmap(List<long> receivedData, List<long> sentData, GraphSettings settings)
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

            receivedData = receivedData.Select(convertBytes).ToList();
            sentData = sentData.Select(convertBytes).ToList();

            // Check is we need to increase or decrease the scale
            int maxYValue = 0;
            if (settings.Scale == GraphScale.Logarithmic)
            {
                long receiveTotal = 0;
                long sentTotal = 0;
                foreach (var item in receivedData)
                    receiveTotal += item;
                foreach (var item in sentData)
                    sentTotal += item;

                bool scaleUp = false;
                bool scaleDown = false;

                // Only adjust the scale based on the bigger set of data
                if (receiveTotal > sentTotal)
                {
                    foreach (var item in receivedData)
                    {
                        if (item > _graphLogarithmicScale[_currentScaleIndex])
                        {
                            scaleUp = true;
                            break;
                        }
                    }

                    foreach (var item in receivedData)
                    {
                        if (item < _graphLogarithmicScale[_currentScaleIndex]/2)
                        {
                            scaleDown = true;
                        }
                        else
                        {
                            scaleDown = false;
                            break;
                        }
                    }

                }
                else
                {
                    foreach (var item in sentData)
                    {
                        if (item > _graphLogarithmicScale[_currentScaleIndex])
                        {
                            scaleUp = true;
                            break;
                        }
                    }

                    foreach (var item in sentData)
                    {
                        if (item < _graphLogarithmicScale[_currentScaleIndex]/2)
                        {
                            scaleDown = true;
                        }
                        else
                        {
                            scaleDown = false;
                            break;
                        }
                    }
                }

                if (scaleUp)
                {
                    if (_currentScaleIndex != _graphLogarithmicScale.Count - 1)
                    {
                        _currentScaleIndex++;
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

            DrawColumns(receivedData, settings, maxYValue, settings.ReceivedBodyColor, settings.ReceivedHighlightColor, ref pic);
            DrawColumns(sentData, settings, maxYValue, settings.SentBodyColor, settings.SentHighlightColor, ref pic);

            return pic;
        }

        private void DrawColumns(List<long> data, GraphSettings settings, int maxYValue, Color bodyColor, Color highlightColor, ref Bitmap bitmap)
        {
            int currentCol = 0;
            for (int i = 0; i < data.Count; i++)
            {
                long item = data[i];
                int columnSize = 0;

                // Work out size of column
                if (item > maxYValue)
                    columnSize = GRAPH_MAX_COLUMN_SIZE - 1;
                else
                    columnSize = (int)Math.Round(Helper.Map(item, 0, maxYValue, 0, GRAPH_MAX_COLUMN_SIZE));

                // Draw body of graph column
                for (int y = 0; y < columnSize; y++)
                {
                    bitmap.SetPixel(GRAPH_AREA_START_X + currentCol, 14 - y, bodyColor);
                }

                int highlightColumnSize = 0;
                int highlightColumnStart = 0;
                if (i == 0 && data.Count > 1)
                {
                    if (data[i] > data[i + 1])
                    {
                        if (data[i + 1] == 0)
                        {
                            highlightColumnSize = (int)Math.Round(Helper.Map(data[i], 0, maxYValue, 0, GRAPH_MAX_COLUMN_SIZE));
                            highlightColumnStart = 0;
                        }
                        else
                        {
                            int nextColumnSize = (int)Math.Round(Helper.Map(data[i + 1], 0, maxYValue, 0, GRAPH_MAX_COLUMN_SIZE));
                            highlightColumnSize = columnSize - nextColumnSize;
                            highlightColumnStart = nextColumnSize;
                        }
                    }
                    //else
                    //{
                    //    int nextColumnSize = (int)Math.Round(Helper.Map(data[i + 1], 0, maxYValue, 0, GRAPH_MAX_COLUMN_SIZE));
                    //    highlightColumnSize = nextColumnSize / 2;
                    //    highlightColumnStart = columnSize;
                    //}
                }
                else if (i == data.Count - 1 && data.Count > 1)
                {
                    if (data[i] > data[i - 1])
                    {
                        int nextColumnSize = (int)Math.Round(Helper.Map(data[i - 1], 0, maxYValue, 0, GRAPH_MAX_COLUMN_SIZE));
                        highlightColumnSize = columnSize - nextColumnSize;
                        highlightColumnStart = nextColumnSize;
                    }
                }
                else if (data.Count > 2)
                {
                    if (data[i - 1] < data[i] && data[i] > data[i + 1])
                    {
                        if (data[i - 1] < data[i + 1])
                        {
                            int nextColumnSize = (int)Math.Round(Helper.Map(data[i - 1], 0, maxYValue, 0, GRAPH_MAX_COLUMN_SIZE));
                            highlightColumnSize = columnSize - nextColumnSize;
                            highlightColumnStart = nextColumnSize;

                        }
                        else
                        {
                            int nextColumnSize = (int)Math.Round(Helper.Map(data[i + 1], 0, maxYValue, 0, GRAPH_MAX_COLUMN_SIZE));
                            highlightColumnSize = columnSize - nextColumnSize;
                            highlightColumnStart = nextColumnSize;
                        }
                    }
                    else if (data[i - 1] < data[i])
                    {
                        int nextColumnSize = (int)Math.Round(Helper.Map(data[i - 1], 0, maxYValue, 0, GRAPH_MAX_COLUMN_SIZE));
                        highlightColumnSize = columnSize - nextColumnSize;
                        highlightColumnStart = nextColumnSize;
                    }
                    else if (data[i] > data[i + 1])
                    {
                        int nextColumnSize = (int)Math.Round(Helper.Map(data[i + 1], 0, maxYValue, 0, GRAPH_MAX_COLUMN_SIZE));
                        highlightColumnSize = columnSize - nextColumnSize;
                        highlightColumnStart = nextColumnSize;
                    }
                }

                // Draw the highlight around the graph
                for (int y = 0; y < highlightColumnSize; y++)
                {
                    bitmap.SetPixel(GRAPH_AREA_START_X + currentCol, (14 - highlightColumnStart) - y, highlightColor);
                }

                // always add a highlight at the top of any column
                if (columnSize > 0)
                    bitmap.SetPixel(GRAPH_AREA_START_X + currentCol, 14 - (columnSize - 1), highlightColor);

                if (columnSize > 1)
                    bitmap.SetPixel(GRAPH_AREA_START_X + currentCol, 14 - (columnSize - 2), highlightColor);


                currentCol++;
            }
        }
    }

    //Text icon: https://stackoverflow.com/a/36379999
}
