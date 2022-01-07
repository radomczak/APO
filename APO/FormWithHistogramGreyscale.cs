using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APO
{
    public partial class FormWithHistogramGreyscale : Form
    {
        private Graphics graphics;
        private HistogramGreyscale histogram;
        private Bitmap histogramImage;

        public FormWithHistogramGreyscale(HistogramGreyscale histogram, string source)
        {
            InitializeComponent();
            Text = "Histogram obrazu " + source;

            //Rozmiar okna i obrazu
            ClientSize = new Size(788, 299);
            histogramPanel.Size = new Size(768, 256);

            graphics = histogramPanel.CreateGraphics();

            //Wyliczenie wartości do narysowania, przeskalowanych wedle maksymalnej wartości w histogramie
            double[] values = new double[256];
            for (int i = 0; i < 256; ++i)
            {
                values[i] = (double)histogram.HistogramTable[i] / (double)histogram.Max;
            }

            histogramImage = new Bitmap(768, 256);
            Graphics graphicsImage = Graphics.FromImage(histogramImage);

            //Wypełnienie kolorem białym
            graphicsImage.Clear(Color.White);
            Pen pen = Pens.Blue;
            int columnBreak = 1;

            //Rysowanie kolumn
            for (int i = 0; i < 768; ++i)
            {
                //zmienna j służy jako indeks dla wartości pixeli.
                int j = (int)Math.Floor(i / 3d);

                //Wyliczenie pozycji Y dla punktu końcowego kolumny
                int ceiling = 256 - (int)(256d * values[j]);

                //2/3 odpowiada za kolumnę.
                //1/3 służy do oddzielenia tych kolumn
                if (columnBreak % 3 != 0) 
                {
                    //Narysowanie linii - kolumny od punktu 1 do punktu 2.
                    //Układ jest rozpatrywany od lewego górnego rogu dlatego punkt początkowy by znalazł się na dole ma wartości x,255
                    //Punkt końcowy ma tą samą wartość x i wcześniej wyliczoną wartość "sufitu" dla kolumny. Ponieważ patrzymy od góry ta wartość jest mniejsza niż 255
                    graphicsImage.DrawLine(pen, new Point(i, 255), new Point(i, ceiling));
                    ++columnBreak;
                } else {
                    columnBreak = 1;
                    pen = changePenColor(pen);
                }
            }

            this.histogram = histogram;
        }

        //Odpowiada za rysowanie na panelu
        private void histogramPanel_Paint(object sender, PaintEventArgs e)
        {
            graphics.DrawImage(histogramImage, new Point());
        }

        //Zczytuje pozycję myszki i podaje wartość odpowiedniej kolumny wedle zmiennych x i y kursora
        private void histogramPanel_MouseMove(object sender, MouseEventArgs e)
        {
            int positionX = (int)Math.Floor(e.X / 3d);
            NOPixelsLabel.Text = histogram.HistogramTable[positionX].ToString();
            ColorValueLabel.Text = positionX.ToString();
        }

        //Zmiena koloru pędzla do rysowania
        private Pen changePenColor(Pen pen)
        {
            if(pen.Equals(Pens.Blue))
            {
                return Pens.RoyalBlue;
            } else
            {
                return Pens.Blue;
            }
        }
    }
}
