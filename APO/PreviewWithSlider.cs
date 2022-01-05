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
    //Formularz do wykonania kilku operacji, z wykorzystaniem podglądu obrazu wynikowego.
    ////Formularz zawiera kilka nakładajacych się na siebie kontrolek, które są widoczne w zależności od wybranej operacji
    public partial class PreviewWithSlider : Form
    {
        //Możliwe operacje
        public enum Operations { Binarization, Thresholding, Posterize, StretchP1P2, Canny };

        //Zmienne do przechowywania obrazów, ich danych i wybranej operacji
        private FormWithImage formWithImage;
        private FastBitmap originalImage;
        private FastBitmap newImage;
        private Graphics graphics1;
        private Graphics graphics2;
        private Operations operation;

        //Getter
        public FastBitmap NewImage
        {
            get
            {
                return newImage;
            }
        }

        //Kontruktor. Klonuje przekazyny obraz dla podglądu i uaktywnia odpowiednie kontrolki dla przekazanej operacji
        public PreviewWithSlider(FormWithImage form, Operations operation)
        {
            InitializeComponent();
            this.formWithImage = form;
            this.operation = operation;
            originalImage = formWithImage.FastBitmap;
            newImage = formWithImage.FastBitmap.Clone(); ;
            graphics1 = this.panel1.CreateGraphics();
            graphics2 = this.panel2.CreateGraphics();
            swtichModeTo(operation);

        }

        //Uaktywnia odpowiednie kontrolki dla przekazanej operacji
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


        //Funckje obsługujące kontrolki i informację wyświetlajace się na formularzu (grafiki i stopień / poziom / zakres)
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

        //Zamknięcie formularza (anulowanie operacji)
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Po potwierdzeniu wykonania operacji, zostaje wysłane żądanie przetworzenia obrazu do klasy ImageProcessor,
        //gdzie po przetworzeniu obraz jest zwracany i jest tworzony nowy obraz wynikowy
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

        //Do wygenerowania podglądu, każda zmiana na sukwaku wymagane przetworzenie obrazu przez klase ImageProcessor
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

        //Do wygenerowania podglądu, każda zmiana na suwaku wymagane przetworzenie obrazu przez klase ImageProcessor
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

        //Obsługa reszty zdarzeń kontrolek w formularzu, zapewniająca poprawne zmienianie się inforamcji na formularzu, które widzi użytkownik
        //Zmiana wartości na suwakach również wywołuje klasę ImageProcessor w celu wygenerowania podglądu
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

        //Podgląd dla operacji posteryzacji
        private void posterize()
        {
            int value = trackBar2.Value;

            newImage = ImageProcessor.ProcessAndReturnImage(formWithImage, ImageProcessor.Operations.Posterize, value);

            this.Refresh();
        }
    }
}
