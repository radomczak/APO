using Emgu.CV;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;


namespace APO {
    public class FastBitmap : IDisposable {
        private Bitmap bitmap;
        private BitmapData bitmapData;
        private int stride;
        private int width;
        private int height;
        private PixelFormat format = PixelFormat.Format32bppArgb;

        public Bitmap Bitmap {
            get { return bitmap; }
            set { bitmap = value; }
        }

        public int Width {
            get {
                return width;
            }
        }

        public int Height {
            get
            { return height; }
        }

        public Size Size {
            get
            { return new Size(width, height); }
        }

        public static int PixelBytes {
            get { return 4; }
        }

        public Color this[int x, int y]
        {
            get
            {
                while (x < 0)
                    x += Width;
                while (x >= Width)
                    x -= Width;
                while (y < 0)
                    y += Height;
                while (y >= Height)
                    y -= Height;
                unsafe
                {
                    int* ptr = (int*)(((int*)bitmapData.Scan0) + (y * stride) + x);
                    return Color.FromArgb(*ptr);
                }
            }
            set
            {
                while (x < 0)
                    x += Width;
                while (x >= Width)
                    x -= Width;
                while (y < 0)
                    y += Height;
                while (y >= Height)
                    y -= Height;
                unsafe
                {
                    int* ptr = (int*)(((int*)bitmapData.Scan0) + (y * stride) + x);
                    *ptr = value.ToArgb();
                }
            }
        }

        public FastBitmap(int width, int height) {
            this.width = width;
            this.height = height;
            bitmap = new Bitmap(width, height, format);
            Lock();
            this.stride = bitmapData.Stride / PixelBytes;
        }

        public FastBitmap(Bitmap bitmap) {
            if (bitmap == null) {
                throw new ArgumentNullException("Can't create FastMap (bitmap is null)");
            }
            width = bitmap.Width;
            height = bitmap.Height;

            if (bitmap.PixelFormat == format)
                this.bitmap = bitmap;
            else
                this.bitmap = bitmap.Clone(new Rectangle(0, 0, width, height), format);

            Lock();
            this.stride = bitmapData.Stride / PixelBytes;
        }

        public object Clone()
        {
            Unlock();
            FastBitmap fbmp = new FastBitmap(bitmap.Clone(new Rectangle(0, 0, width, height), format));
            Lock();
            return fbmp;
        }

        public void Draw(Graphics graphics, int x, int y) {
            Unlock();
            graphics.DrawImage(bitmap, x, y);
            Lock();
        }

        public void Save(Stream stream, ImageFormat format) {
            bitmap.Save(stream, format);
        }

        public void Save(string filename, ImageFormat format) {
            bitmap.Save(filename, format);
        }

        public void Lock() {
            if (bitmapData != null)
                return;
            Rectangle rect = new Rectangle(0, 0, width, height);
            bitmapData = bitmap.LockBits(rect, ImageLockMode.ReadWrite, format);
        }

        public Bitmap Unlock() {
            if (bitmapData != null) {
                bitmap.UnlockBits(bitmapData);
                bitmapData = null;
            }
            return bitmap;
        }

        public void Dispose() {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing) {
            if (disposing) {
                Unlock();
                if (bitmap != null) {
                    bitmap.Dispose();
                }
            }
            bitmapData = null;
            bitmap = null;
        }

        public void RGBtoGray()
        {
            int R;
            int G;
            int B;
            int v;
            for (int i = 0; i < width; ++i)
            {
                for (int j = 0; j < height; ++j)
                {
                    R = this[i, j].R;
                    G = this[i, j].G;
                    B = this[i, j].B;
                    v = (int)((double)R * 0.3d + (double)G * 0.6d + (double)B * 0.1d);
                    Color newPixel = Color.FromArgb(v, v, v);
                    this[i, j] = newPixel;
                }
            }
        }

    }
}
