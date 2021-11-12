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

            graphics = histogramPanel.CreateGraphics();
            histogramImage = new Bitmap(768, 256);
            graphicsImage = Graphics.FromImage(histogramImage);
            this.histogram = histogram;
        }

        private void drawImageR()
        {
            graphicsImage.Clear(Color.White);
            double[] values = new double[256];
            for (int i = 0; i < 256; ++i)
            {
                values[i] = (double)histogram.HistogramTableR[i] / (double)histogram.MaxForColor("red");
            }
            Pen pen = Pens.Red;
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

        private void histogramPanel_Paint(object sender, PaintEventArgs e)
        {
            graphics.DrawImage(histogramImage, new Point());
        }

        private void histogramPanel_MouseMove(object sender, MouseEventArgs e)
        {
            int positionX = (int)Math.Floor(e.X / 3d);
            NOPixelsLabel.Text = getValueForColor(color, positionX);
            ColorValueLabel.Text = positionX.ToString();
        }

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
