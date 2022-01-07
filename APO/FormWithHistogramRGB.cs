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
    public partial class FormWithHistogramRGB : Form
    {

        private Graphics graphics;
        private HistogramRGB histogram;
        private Bitmap histogramImage;
        Graphics graphicsImage;
        String color;

        public FormWithHistogramRGB(HistogramRGB histogram, string source)
        {
            InitializeComponent();
            
            Text = "Histogram obrazu " + source;

            ClientSize = new Size(788, 329);
            histogramPanel.Size = new Size(768, 256);

            //Element rysujący
            graphics = histogramPanel.CreateGraphics();

            //Nowy obraz na którym zostanei narysowany histogram
            histogramImage = new Bitmap(768, 256);
            graphicsImage = Graphics.FromImage(histogramImage);
            this.histogram = histogram;
        }

        //Odpowiada za rozrysowanei kanału czerwonego
        private void drawImageR()
        {
            //Wyczyszczenie obrazu z wcześniej narysowanych histogramów
            graphicsImage.Clear(Color.White);
            double[] values = new double[256];

            //Wyliczenie wartości do narysowania, przeskalowanych wedle maksymalnej wartości w histogramie dla tego kanału
            for (int i = 0; i < 256; ++i)
            {
                values[i] = (double)histogram.HistogramTableR[i] / (double)histogram.MaxForColor("red");
            }

            //Kolor
            Pen pen = Pens.Red;

            int columnBreak = 1;

            //Rysowanie kolejnych wartości na obrazie
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
                }
                else
                {
                    columnBreak = 1;
                }
            }
        }

        //Odpowiada za rozrysowanei kanału zielonego. Podobnie jak kanał czerwony
        private void drawImageG()
        {
            graphicsImage.Clear(Color.White);
            double[] values = new double[256];
            for (int i = 0; i < 256; ++i)
            {
                values[i] = (double)histogram.HistogramTableG[i] / (double)histogram.MaxForColor("green");
            }
            Pen pen = Pens.Green;
            int columnBreak = 1;
            for (int i = 0; i < 768; ++i)
            {
                int j = (int)Math.Floor(i / 3d);
                int ceiling = 256 - (int)(256d * values[j]);
                if (columnBreak % 3 != 0)
                {
                    graphicsImage.DrawLine(pen, new Point(i, 255), new Point(i, ceiling));
                    ++columnBreak;
                }
                else
                {
                    columnBreak = 1;
                }
            }
        }

        //Odpowiada za rozrysowanei kanału niebisiego. Podobnie jak kanał czerwony
        private void drawImageB()
        {
            graphicsImage.Clear(Color.White);
            double[] values = new double[256];
            for (int i = 0; i < 256; ++i)
            {
                values[i] = (double)histogram.HistogramTableB[i] / (double)histogram.MaxForColor("blue");
            }
            Pen pen = Pens.Blue;
            int columnBreak = 1;
            for (int i = 0; i < 768; ++i)
            {
                int j = (int)Math.Floor(i / 3d);
                int ceiling = 256 - (int)(256d * values[j]);
                if (columnBreak % 3 != 0)
                {
                    graphicsImage.DrawLine(pen, new Point(i, 255), new Point(i, ceiling));
                    ++columnBreak;
                }
                else
                {
                    columnBreak = 1;
                }
            }
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
            NOPixelsLabel.Text = getValueForColor(color, positionX);
            ColorValueLabel.Text = positionX.ToString();
        }

        //Zmiana rysowanego kanału histogramu
        private void ButtonR_Click(object sender, EventArgs e)
        {
            color = "red";
            drawImageR();
            histogramPanel.Invalidate();
        }

        private void ButtonG_Click(object sender, EventArgs e)
        {
            color = "green";
            drawImageG();
            histogramPanel.Invalidate();
        }

        private void ButtonB_Click(object sender, EventArgs e)
        {
            color = "blue";
            drawImageB();
            histogramPanel.Invalidate();
        }

        //Zwraca wartość danej kolumny dla podanej pozycji (indeksu kolumny)
        private string getValueForColor(String color, int position)
        {
            switch (color)
            {
                case "red":
                    return histogram.HistogramTableR[position].ToString();
                case "green":
                    return histogram.HistogramTableG[position].ToString();
                case "blue":
                    return histogram.HistogramTableB[position].ToString();
            }
            return "";
        }
    }
}
