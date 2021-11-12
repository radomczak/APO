using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APO
{
    public class HistogramRGB
    {
        private int[] histogramTableR = new int[256];
        private int[] histogramTableG = new int[256];
        private int[] histogramTableB = new int[256];

        public int[] HistogramTableR
        {
            get { return histogramTableR; }
        }

        public int[] HistogramTableG
        {
            get { return histogramTableG; }
        }

        public int[] HistogramTableB
        {
            get { return histogramTableB; }
        }

        public HistogramRGB(FastBitmap bmp)
        {
            for (int i = 0; i < bmp.Size.Width; ++i)
            {
                for (int j = 0; j < bmp.Size.Height; ++j)
                {
                    histogramTableR[bmp[i, j].R]++;
                    histogramTableG[bmp[i, j].G]++;
                    histogramTableB[bmp[i, j].B]++;
                }
            }
        }

        public int MaxForColor(String color)
        {
            switch(color)
            {
                case "red":
                    return histogramTableR.Max();
                case "green":
                    return histogramTableG.Max();
                case "blue":
                    return histogramTableB.Max();
            }
            return -1;
        }

    }
}
