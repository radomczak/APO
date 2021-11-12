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
            ClientSize = new Size(788, 299);
            histogramPanel.Size = new Size(768, 256);

            graphics = histogramPanel.CreateGraphics();

            double[] values = new double[256];
            for (int i = 0; i < 256; ++i)
            {
                values[i] = (double)histogram.HistogramTable[i] / (double)histogram.Max;
            }

            histogramImage = new Bitmap(768, 256);
            Graphics graphicsImage = Graphics.FromImage(histogramImage);

            graphicsImage.Clear(Color.White);
            Pen pen = Pens.Blue;
            int columnBreak = 1;
            for (int i = 0; i < 768; ++i)
            {
                int j = (int)Math.Floor(i / 3d);
                int ceiling = 256 - (int)(256d * values[j]);
                if (columnBreak % 3 != 0) { 
                    graphicsImage.DrawLine(pen, new Point(i, 255), new Point(i, ceiling));
                    ++columnBreak;
                } else {
                    columnBreak = 1;
                    pen = changePenColor(pen);
                }
            }

            this.histogram = histogram;
        }

        private void histogramPanel_Paint(object sender, PaintEventArgs e)
        {
            graphics.DrawImage(histogramImage, new Point());
        }

        private void histogramPanel_MouseMove(object sender, MouseEventArgs e)
        {
            int positionX = (int)Math.Floor(e.X / 3d);
            NOPixelsLabel.Text = histogram.HistogramTable[positionX].ToString();
            ColorValueLabel.Text = positionX.ToString();
        }

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
