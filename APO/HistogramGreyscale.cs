using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace APO
{
    public class HistogramGreyscale
    {
        private int[] histogramTable = new int[256];
        private int max;
        private double avg;

        public int[] HistogramTable
        {
            get { return histogramTable; }
        }

        public int Max
        {
            get { return max; }
        }

        public double Average
        {
            get { return avg; }
        }


        public HistogramGreyscale(FastBitmap bmp,bool isMono)
        {
            int R;
            int G;
            int B;
            int value;

            if (isMono)
            {
                for (int i = 0; i < bmp.Size.Width; ++i)
                {
                    for (int j = 0; j < bmp.Size.Height; ++j)
                    {
                        value = bmp[i, j].R;
                        histogramTable[value]++;
                    }
                }
            }
            else
            {
                for (int i = 0; i < bmp.Size.Width; ++i)
                {
                    for (int j = 0; j < bmp.Size.Height; ++j)
                    {
                        R = bmp[i, j].R;
                        G = bmp[i, j].G;
                        B = bmp[i, j].B;
                        value = (int)((double)R * 0.3d + (double)G * 0.6d + (double)B * 0.1d);
                        histogramTable[value]++;
                    }
                }
            }
            max = histogramTable.Max();
            avg = histogramTable.Average();
        }
    }
}
