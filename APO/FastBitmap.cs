using Emgu.CV;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;


namespace APO {
    //Klasa do szybkiego przetwarzania obrazów
    public class FastBitmap : IDisposable {
        //Zmienne przetrzymujące dane i cechy obrazu
        private Bitmap bitmap;
        private BitmapData bitmapData;
        private int stride;
        private int width;
        private int height;
        private PixelFormat format = PixelFormat.Format32bppArgb;
        
        //GETTERY I SETTERY
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

        //Metoda do szybkiego odczytu lub zapisu danych na obrazie. Metoda działa na zasadzie wskaźników do konkretnego pixela (fragmentu danych obrazu)
        public Color this[int x, int y]
        {
            get
            {
                //Zabezpiecznie argumentów x i y przed wyjściem poza zakres
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
                    //pobranie koloru. Używając bitmapData.Scan0 otrzymujemy wskaźnik na początek bloku danych obrazu,
                    //po czym zwiększamy ten wskaźnik o wartość wedle poniższego wzoru by otrzymać pixel z punktu x,y
                    int* ptr = (int*)(((int*)bitmapData.Scan0) + (y * stride) + x);
                    return Color.FromArgb(*ptr);
                }
            }
            set
            {
                //Zabezpiecznie argumentów x i y przed wyjściem poza zakres
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
                    //Nadpisanie koloru. Używając bitmapData.Scan0 otrzymujemy wskaźnik na początek bloku danych obrazu,
                    //po czym zwiększamy ten wskaźnik o wartość wedle poniższego wzoru by otrzymać pixel z punktu x,y
                    int* ptr = (int*)(((int*)bitmapData.Scan0) + (y * stride) + x);
                    *ptr = value.ToArgb();
                }
            }
        }
        //Stworzenie obiektu tej klasy na podstawie zwykłej mapy bitowej. Działa na zasadzie zapisania bitmapy i jej cech i korzystanie z metod szybkeigo zapisu i odczytu danych na tej bitmapie
        public FastBitmap(Bitmap bitmap) {
            //Zabezpieczenie przed pustym argumentem
            if (bitmap == null) {
                throw new ArgumentNullException("Can't create FastMap (bitmap is null)");
            }
            //Zapisanie cech obrazu
            width = bitmap.Width;
            height = bitmap.Height;

            //Weryfikacja formatu
            if (bitmap.PixelFormat == format)
                this.bitmap = bitmap;
            else
                this.bitmap = bitmap.Clone(new Rectangle(0, 0, width, height), format);
            //Zablokowanie edycji
            Lock();
            this.stride = bitmapData.Stride / PixelBytes;
        }

        //Utworzenie nowej szybkiej mapy bitowej na podstawie obecnej
        public FastBitmap Clone()
        {
            Unlock();
            FastBitmap fbmp = new FastBitmap(bitmap.Clone(new Rectangle(0, 0, width, height), format));
            Lock();
            return fbmp;
        }

        //Narysowanie mapy bitowej
        public void Draw(Graphics graphics, int x, int y) {
            Unlock();
            graphics.DrawImage(bitmap, x, y);
            Lock();
        }

        //Zapis
        public void Save(Stream stream, ImageFormat format) {
            bitmap.Save(stream, format);
        }

        //Blokowanie i odblokowywanie edycji z użyciem wbudowanych metod bitmapy
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

        //Konwersja obrazu na monochromatyczny z użyciem wzoru z wagami dla poszczególnych kanałów
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

        public void Dispose() {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if(disposing)
            {
                Unlock();
                if (bitmap != null)
                    bitmap.Dispose();
            }
            bitmapData = null;
            bitmap = null;
        }

    }
}
