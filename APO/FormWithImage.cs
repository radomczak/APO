using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APO
{   
    //Jeden z ważniejszych formularzy. Przechowuje obraz i odpowiada za jego zapis i odczyt
    public partial class FormWithImage : Form
    {
        //Zmienne na ścieżkę obrazu, mapęBitową obrazu, wyświetlanie obrazu i monochromatyczność
        private string source;
        private FastBitmap fastBitmap;
        private Graphics graphics;
        private bool isMono;

        public FormWithImage()
        {
            InitializeComponent();
        }

        //Gettery

        //Zwraca histogram monochromatyczny dla tego obrazu
        public HistogramGreyscale HistogramG
        {
            get { return new HistogramGreyscale(fastBitmap, isMono); }
        }

        //Zwraca histogram dla trzech kanałów tego obrazu
        public HistogramRGB HistogramRGB
        {
            get { return new HistogramRGB(fastBitmap); }
        }

        public string Source
        {
            get { return source; }
        }

        public FastBitmap FastBitmap
        {
            get { return fastBitmap; }
            set { fastBitmap = value; }
        }

        public bool IsMono
        {
            get { return isMono; }
        }

        //Tworzy obraz i wyświetla go na formularzu
        public FormWithImage(String fileName)
        {
            InitializeComponent();
            //Szczytanie ścieżki obrazu i zmiana nazwy okna formularza z obrazem
            this.source = fileName;
            this.Text = source;

            //Odczyt obrazu ze ścieżki
            StreamReader reader = new StreamReader(source);
            Bitmap bitmap = (Bitmap)Bitmap.FromStream(reader.BaseStream);
            
            //Kopia obrazu na podstawie parametrów pierwszego
            Bitmap bmpTemp2 = new Bitmap(bitmap.Size.Width, bitmap.Size.Height);
            bmpTemp2.SetResolution(bitmap.HorizontalResolution, bitmap.VerticalResolution);
            Graphics gr = Graphics.FromImage(bmpTemp2);
            
            //Narysowanie wczytanego obrazu na kopii i pozbycie się oryginału
            gr.DrawImage(bitmap, new Point());
            bitmap.Dispose();
            reader.Close();

            //Stworzenie obiektu klasy FastBitmap do szybkiej operacji na obrazie  i zmiana wielkości okna
            fastBitmap = new FastBitmap(bmpTemp2);
            fastBitmap.Bitmap.SetResolution(96, 96);
            imagePanel.Size = fastBitmap.Size;
            ClientSize = fastBitmap.Size;
            graphics = this.imagePanel.CreateGraphics();
            CheckIfMono(fastBitmap);
        }

        //Zapisanie obrazu
        public void Save()
        {
            Save(source);
        }


        //Zapisanie obrazu z wybranym rozszerzeniem
        public void Save(String filename)
        {
            StreamWriter writer = new StreamWriter(filename);
            ImageFormat format;
            switch (Path.GetExtension(filename).ToLower())
            {
                case ".jpg":
                case ".jpeg":
                    format = ImageFormat.Jpeg;
                    break;
                case ".gif":
                    format = ImageFormat.Gif;
                    break;
                case ".png":
                    format = ImageFormat.Png;
                    break;
                case ".tiff":
                    format = ImageFormat.Tiff;
                    break;
                default:
                    format = ImageFormat.Bmp;
                    break;
            }
            fastBitmap.Save(writer.BaseStream, format);
            writer.Close();
        }

        //Odpowiada za narysowanie obrazu na panelu w formularzu
        private void imagePanel_Paint(object sender, PaintEventArgs e)
        {
            fastBitmap.Draw(graphics, 0, 0);
        }

        //Wywoływana przy zamknięciu formularza. Wysyła informację do głównego formularza o sprawdzenie czy nie ma potrzeby wyłączenia kontrolek
        private void FormWithImage_FormClosed(object sender, FormClosedEventArgs e)
        {
            Main mainForm = (Main)this.MdiParent;
            mainForm.DissableButtonsIfNeeded();
        }

        //Porównanie kanałów i ich wartości. Jeśli wyszstkie pixela mają te same wartości na trzech kanałach obraz uznajemy za monochromatyczny 
        private void CheckIfMono(FastBitmap bmp)
        {
            bool result = true;
            
            for (int i = 0; i < bmp.Size.Width; ++i)
            {
                for (int j = 0; j < bmp.Size.Height; ++j)
                {
                    if (!(bmp[i, j].R == bmp[i, j].G && bmp[i, j].G == bmp[i, j].B))
                        result = false;
                }
            }
            isMono = result;
        }

        //Zmiana obrazu na monochromatyczny
        public void RGBtoGray()
        {
            fastBitmap.RGBtoGray();
            isMono = true;
        }

        //Ponowne dostosowanie rozmiaru okna formularza do obrazu
        public void Resize()
        {
            imagePanel.Size = fastBitmap.Size;
            ClientSize = fastBitmap.Size;
        }
    }
}
