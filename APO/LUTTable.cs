using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APO
{
    public class LUTTable
    {
        private int[,] table;
        private int width;
        private int height;

        public LUTTable(FastBitmap bmp)
        {

        }
        public int Width
        {
            get { return width; }
        }

        public int Height
        {
            get { return height; }
        }

        public int this[int x, int y]
        {
            get
            {
               return table[x,y];
            }
            set
            {
                table[x, y] = value;
            }
        }
    }
}
