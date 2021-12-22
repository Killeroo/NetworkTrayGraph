using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Chasovoy
{
    class GraphBitmapFactory
    {
        public int MaxDataValue { get; set; } = 5000;
       
        internal const int GRAPH_AREA_START_X = 1;
        internal const int GRAPH_AREA_START_Y = 14;
        internal const int GRAPH_MAX_COLUMN_SIZE = 14;

        public Bitmap CreateGraph(Queue<int> data)
        {
            Bitmap pic = new Bitmap(16, 16);
            Graphics graphics = Graphics.FromImage(pic);

            Pen borderPen = new Pen(Color.Gray);
            Pen graphPen = new Pen(Color.Green);

            // Create background and border
            graphics.FillRectangle(Brushes.White, new Rectangle(new Point(0, 0), new Size(15, 15)));
            graphics.DrawRectangle(borderPen, new Rectangle(new Point(0, 0), new Size(15, 15)));

            // Draw each graph column
            int currentCol = 0;
            foreach (var item in data)
            {
                int columnSize = 0;

                // Work out size of column
                if (item > MaxDataValue)
                    columnSize = GRAPH_MAX_COLUMN_SIZE;
                else
                    columnSize = (int)Math.Round(Helper.Map(item, 0, MaxDataValue, 1, GRAPH_MAX_COLUMN_SIZE));

                // Add column to bitmap 
                graphics.DrawLine(
                    graphPen, 
                    GRAPH_AREA_START_X + currentCol,
                    GRAPH_AREA_START_Y,
                    GRAPH_AREA_START_X + currentCol,
                    GRAPH_MAX_COLUMN_SIZE - columnSize);

                currentCol++;
            }

            return pic;
        }
    }
}
