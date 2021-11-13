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
    public partial class FormWithImage : Form
    {
        private string source;
        private FastBitmap fastBitmap;
        private Graphics graphics;
        private bool isMono;

        public FormWithImage()
        {
            InitializeComponent();
        }

        public HistogramGreyscale HistogramG
        {
            get { return new HistogramGreyscale(fastBitmap, isMono); }
        }

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

        public FormWithImage(String fileName)
        {
            InitializeComponent();
            this.source = fileName;
            this.Text = source;

            StreamReader reader = new StreamReader(source);
            Bitmap bitmap = (Bitmap)Bitmap.FromStream(reader.BaseStream);
            Bitmap bmpTemp2 = new Bitmap(bitmap.Size.Width, bitmap.Size.Height);
            bmpTemp2.SetResolution(bitmap.HorizontalResolution, bitmap.VerticalResolution);
            Graphics gr = Graphics.FromImage(bmpTemp2);
            
            gr.DrawImage(bitmap, new Point());
            bitmap.Dispose();
            reader.Close();

            fastBitmap = new FastBitmap(bmpTemp2);
            fastBitmap.Bitmap.SetResolution(96, 96);
            imagePanel.Size = fastBitmap.Size;
            ClientSize = fastBitmap.Size;
            graphics = this.imagePanel.CreateGraphics();
            CheckIfMono(fastBitmap);
        }

        public void Save()
        {
            Save(source);
        }

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

        private void imagePanel_Paint(object sender, PaintEventArgs e)
        {
            fastBitmap.Draw(graphics, 0, 0);
        }

        private void FormWithImage_FormClosed(object sender, FormClosedEventArgs e)
        {
            Main mainForm = (Main)this.MdiParent;
            mainForm.DissableButtonsIfNeeded();
        }

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

        public void RGBtoGray()
        {
            fastBitmap.RGBtoGray();
            isMono = true;
        }
    }
}
