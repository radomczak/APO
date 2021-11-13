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
    public partial class PreviewWithSlider : Form
    {
        public enum Operations { Binarization, Thresholding, Posterize, StretchP1P2, Canny };

        private FormWithImage formWithImage;
        private FastBitmap originalImage;
        private FastBitmap newImage;
        private Graphics graphics1;
        private Graphics graphics2;
        private Operations operation;

        public FastBitmap NewImage
        {
            get
            {
                return newImage;
            }
        }

        public PreviewWithSlider(FormWithImage form, Operations operation)
        {
            InitializeComponent();
            this.formWithImage = form;
            this.operation = operation;
            originalImage = formWithImage.FastBitmap;
            newImage = (FastBitmap)formWithImage.FastBitmap.Clone(); ;
            graphics1 = this.panel1.CreateGraphics();
            graphics2 = this.panel2.CreateGraphics();
            swtichModeTo(operation);

        }

        private void swtichModeTo(Operations operation)
        {
            switch (operation)
            {
                case Operations.Binarization:
                    label1.Visible = true;
                    trackBar1.Visible = true;

                    fromLabel.Visible = false;
                    toLabel.Visible = false;
                    fromTrackBar.Visible = false;
                    toTrackBar.Visible = false;
                    trackBar2.Visible = false;
                    label2.Visible = false;
                    increaseButton.Visible = false;
                    decreaseButton.Visible = false;
                    break;
                case Operations.Canny:
                case Operations.Thresholding:
                case Operations.StretchP1P2:
                    fromLabel.Visible = true;
                    toLabel.Visible = true;
                    fromTrackBar.Visible = true;
                    toTrackBar.Visible = true;

                    label1.Visible = false;
                    trackBar1.Visible = false;
                    trackBar2.Visible = false;
                    label2.Visible = false;
                    increaseButton.Visible = false;
                    decreaseButton.Visible = false;
                    break;
                case Operations.Posterize:
                    label2.Visible = true;
                    trackBar2.Visible = true;
                    increaseButton.Visible = true;
                    decreaseButton.Visible = true;

                    fromLabel.Visible = false;
                    toLabel.Visible = false;
                    fromTrackBar.Visible = false;
                    toTrackBar.Visible = false;
                    trackBar1.Visible = false;
                    label1.Visible = false;
                    break;
            }
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            label1.Text = trackBar1.Value.ToString();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            newImage.Draw(graphics2, 0, 0);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            originalImage.Draw(graphics1, 0, 0);
        }

        private void trackBar1_MouseUp(object sender, MouseEventArgs e)
        {
            int value = trackBar1.Value;

            newImage = ImageProcessor.ProcessAndReturnImage(formWithImage, ImageProcessor.Operations.Binarization, value);

            this.Refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int value;
            int from = fromTrackBar.Value;
            int to = toTrackBar.Value;

            switch (operation)
            {
                case Operations.Binarization:
                    value = trackBar1.Value;
                    newImage = ImageProcessor.ProcessAndReturnImage(formWithImage, ImageProcessor.Operations.Binarization, value);
                    break;
                case Operations.Thresholding:
                    newImage = ImageProcessor.ProcessAndReturnImage(formWithImage, ImageProcessor.Operations.Thresholding, from, to);
                    break;
                case Operations.Posterize:
                    value = trackBar2.Value;
                    newImage = ImageProcessor.ProcessAndReturnImage(formWithImage, ImageProcessor.Operations.Posterize, value);
                    break;
                case Operations.StretchP1P2:
                    newImage = ImageProcessor.ProcessAndReturnImage(formWithImage, ImageProcessor.Operations.StretchP1P2, from, to);
                    break;
                case Operations.Canny:
                    break;
            }
        }

        private void fromTrackBar_MouseUp(object sender, MouseEventArgs e)
        {
            int from = fromTrackBar.Value;
            int to = toTrackBar.Value;
            if(operation.Equals(Operations.Thresholding))
                newImage = ImageProcessor.ProcessAndReturnImage(formWithImage, ImageProcessor.Operations.Thresholding, from, to);
            if (operation.Equals(Operations.StretchP1P2))
                newImage = ImageProcessor.ProcessAndReturnImage(formWithImage, ImageProcessor.Operations.StretchP1P2, from, to);
            this.Refresh();
        }

        private void toTrackBar_MouseUp(object sender, MouseEventArgs e)
        {
            int to = toTrackBar.Value;
            int from = fromTrackBar.Value;

            if (operation.Equals(Operations.Thresholding))
                newImage = ImageProcessor.ProcessAndReturnImage(formWithImage, ImageProcessor.Operations.Thresholding, from, to);
            if (operation.Equals(Operations.StretchP1P2))
                newImage = ImageProcessor.ProcessAndReturnImage(formWithImage, ImageProcessor.Operations.StretchP1P2, from, to);

            this.Refresh();
        }

        private void fromTrackBar_ValueChanged(object sender, EventArgs e)
        {
            fromLabel.Text = fromTrackBar.Value.ToString();
        }

        private void toTrackBar_ValueChanged(object sender, EventArgs e)
        {
            toLabel.Text = toTrackBar.Value.ToString();
        }

        private void trackBar2_MouseUp(object sender, MouseEventArgs e)
        {
            posterize();
        }

        private void trackBar2_ValueChanged(object sender, EventArgs e)
        {
            label2.Text = trackBar2.Value.ToString();
        }

        private void decreaseButton_Click(object sender, EventArgs e)
        {
            if (trackBar2.Value > 2)
                trackBar2.Value -= 1;

            posterize();
        }

        private void increaseButton_Click(object sender, EventArgs e)
        {
            if (trackBar2.Value < 255)
                trackBar2.Value += 1;

            posterize();
        }

        private void posterize()
        {
            int value = trackBar2.Value;

            newImage = ImageProcessor.ProcessAndReturnImage(formWithImage, ImageProcessor.Operations.Posterize, value);

            this.Refresh();
        }
    }
}
