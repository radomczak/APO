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
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            saveFileDialog1.Filter = "Obraz BMP|*.bmp|Obraz TIFF|*.tiff|Obraz PNG|*.png|Obraz JPG|*.jpg";
            openFileDialog1.Filter = "Obrazy(*.BMP;*.TIFF;*.PNG;*.JPG)|*.BMP;*.TIFF;*.PNG;*.JPG;*.JPEG|Wszystkie pliki(*.*)|*.*";
            IsMdiContainer = true;
        }

        private void infoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String appInfo = "Autor: Radosław Popielarski\nGrupa: IZ07IO1\nRok: 2021/2022\nPrzedmiot: Algorytmy przetwarzania obrazów (APO)\n";
            MessageBox.Show(appInfo, "Informacje", MessageBoxButtons.OK);
        }

        private void NewImage(string filename)
        {
            FormWithImage form = new FormWithImage(filename);
            form.MdiParent = this;
            EnableButtons();
            form.Show();
        }


        private void EnableButtons()
        {
            zamknijToolStripMenuItem.Enabled = true;
            zamknijWszystkieToolStripMenuItem.Enabled = true;
            zapiszToolStripMenuItem.Enabled = true;
            zapiszJakoToolStripMenuItem.Enabled = true;
            zbadajToolStripMenuItem.Enabled = true;
            operacjeToolStripMenuItem.Enabled = true;
            histogramToolStripMenuItem.Enabled = true;
            rGBToolStripMenuItem.Enabled = true;
            monoToolStripMenuItem.Enabled = true;
            obrazToolStripMenuItem.Enabled = true;
            duplikujToolStripMenuItem.Enabled = true;
            infoToolStripMenuItem.Enabled = true;
            LUTToolStripMenuItem.Enabled = true;
            rGBToolStripMenuItem1.Enabled = true;
            greyscaleToolStripMenuItem.Enabled = true;
            histogramToolStripMenuItem1.Enabled = true;
            stretchToolStripMenuItem.Enabled = true;
            wyrównanieToolStripMenuItem.Enabled = true;
            jednopunktoweToolStripMenuItem.Enabled = true;
            negacjaToolStripMenuItem.Enabled = true;
            progrowanieBinarneToolStripMenuItem.Enabled = true;
            progToolStripMenuItem.Enabled = true;
            redukcjaPoziomówSzarościToolStripMenuItem.Enabled = true;
            rozciąganieHistogramuZZakresemToolStripMenuItem.Enabled = true;
            filtryToolStripMenuItem.Enabled = true;
            wygładzanieToolStripMenuItem.Enabled = true;
            wyostrzanieToolStripMenuItem.Enabled = true;
            detekcjaKrawędziToolStripMenuItem.Enabled = true;
            specjalnaDetekacjaKrawędziToolStripMenuItem.Enabled = true;
            specjalnaDetekacjaKrawędziCannyToolStripMenuItem.Enabled = true;
            medianowyToolStripMenuItem.Enabled = true;
        }

        public void DissableButtonsIfNeeded()
        {
            if (MdiChildren.Length == 1)
            {
                zamknijToolStripMenuItem.Enabled = false;
                zamknijWszystkieToolStripMenuItem.Enabled = false;
                zapiszToolStripMenuItem.Enabled = false;
                zapiszJakoToolStripMenuItem.Enabled = false;
                zbadajToolStripMenuItem.Enabled = false;
                operacjeToolStripMenuItem.Enabled = false;
                histogramToolStripMenuItem.Enabled = false;
                rGBToolStripMenuItem.Enabled = false;
                monoToolStripMenuItem.Enabled = false;
                obrazToolStripMenuItem.Enabled = false;
                duplikujToolStripMenuItem.Enabled = false;
                infoToolStripMenuItem.Enabled = false;
                LUTToolStripMenuItem.Enabled = false;
                rGBToolStripMenuItem1.Enabled = false;
                greyscaleToolStripMenuItem.Enabled = false;
                histogramToolStripMenuItem1.Enabled = false;
                stretchToolStripMenuItem.Enabled = false;
                wyrównanieToolStripMenuItem.Enabled = false;
                jednopunktoweToolStripMenuItem.Enabled = false;
                negacjaToolStripMenuItem.Enabled = false;
                progrowanieBinarneToolStripMenuItem.Enabled = false;
                progToolStripMenuItem.Enabled = false;
                redukcjaPoziomówSzarościToolStripMenuItem.Enabled = false;
                rozciąganieHistogramuZZakresemToolStripMenuItem.Enabled = false;
                filtryToolStripMenuItem.Enabled = false;
                wygładzanieToolStripMenuItem.Enabled = false;
                wyostrzanieToolStripMenuItem.Enabled = false;
                detekcjaKrawędziToolStripMenuItem.Enabled = false;
                specjalnaDetekacjaKrawędziToolStripMenuItem.Enabled = false;
                specjalnaDetekacjaKrawędziCannyToolStripMenuItem.Enabled = false;
                medianowyToolStripMenuItem.Enabled = false;
            }
        }

        private void otwórzToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == openFileDialog1.ShowDialog())
            {
                NewImage(openFileDialog1.FileName);
            }
        }

        private void nowyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewImage("Nowy obraz");
        }

        private void zapiszToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ((FormWithImage)ActiveMdiChild).Save();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error saving file", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void zapiszJakoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    ((FormWithImage)ActiveMdiChild).Save(saveFileDialog1.FileName);
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error saving file", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        public void zamknijToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ((FormWithImage)ActiveMdiChild).Close();
            DissableButtonsIfNeeded();
        }

        private void zamknijWszystkieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (FormWithImage form in this.MdiChildren) {
                form.Close();
            }
            DissableButtonsIfNeeded();
        }

        private void wyjścieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            zamknijWszystkieToolStripMenuItem_Click(sender,e);
            this.Close();
        }

        private void duplikujToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewImage(ActiveMdiChild.Text);
        }

        private void monoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormWithHistogramGreyscale histForm = new FormWithHistogramGreyscale(((FormWithImage)ActiveMdiChild).HistogramG, ((FormWithImage)ActiveMdiChild).Source);
            histForm.ShowDialog();
        }

        private void rGBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormWithHistogramRGB histForm = new FormWithHistogramRGB(((FormWithImage)ActiveMdiChild).HistogramRGB, ((FormWithImage)ActiveMdiChild).Source);
            histForm.ShowDialog();
        }

        private void rGBToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormWithLUTTableRGB LUTForm = new FormWithLUTTableRGB(((FormWithImage)ActiveMdiChild).HistogramRGB);
            LUTForm.ShowDialog();
        }

        private void greyscaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormWithLUTTableGreyscale LUTForm = new FormWithLUTTableGreyscale(((FormWithImage)ActiveMdiChild).HistogramG);
            LUTForm.ShowDialog();
        }

        private void rozciąganieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ImageProcessor.ProcessImage(((FormWithImage)ActiveMdiChild),ImageProcessor.Operations.Stretch);
             ((FormWithImage)ActiveMdiChild).Refresh();
        }

        private void wyrównanieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ImageProcessor.ProcessImage(((FormWithImage)ActiveMdiChild), ImageProcessor.Operations.Equalize);
            ((FormWithImage)ActiveMdiChild).Refresh();
        }

        private void ąganieHistogramuZZakresemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PreviewWithSlider previewWithSlider = new PreviewWithSlider((FormWithImage)ActiveMdiChild, PreviewWithSlider.Operations.StretchP1P2);
            if (previewWithSlider.ShowDialog() == DialogResult.OK)
            {
                ((FormWithImage)ActiveMdiChild).FastBitmap = previewWithSlider.NewImage;
                ((FormWithImage)ActiveMdiChild).Refresh();
            }
        }

        private void redukcjaPoziomówSzarościToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PreviewWithSlider previewWithSlider = new PreviewWithSlider((FormWithImage)ActiveMdiChild, PreviewWithSlider.Operations.Posterize);
            if (previewWithSlider.ShowDialog() == DialogResult.OK)
            {
                ((FormWithImage)ActiveMdiChild).FastBitmap = previewWithSlider.NewImage;
                ((FormWithImage)ActiveMdiChild).Refresh();
            }
        }

        private void progToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PreviewWithSlider previewWithSlider = new PreviewWithSlider((FormWithImage)ActiveMdiChild, PreviewWithSlider.Operations.Thresholding);
            if (previewWithSlider.ShowDialog() == DialogResult.OK)
            {
                ((FormWithImage)ActiveMdiChild).FastBitmap = previewWithSlider.NewImage;
                ((FormWithImage)ActiveMdiChild).Refresh();
            }
        }

        private void progrowanieBinarneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PreviewWithSlider previewWithSlider = new PreviewWithSlider((FormWithImage)ActiveMdiChild, PreviewWithSlider.Operations.Binarization);
            if (previewWithSlider.ShowDialog() == DialogResult.OK)
            {
                ((FormWithImage)ActiveMdiChild).FastBitmap = previewWithSlider.NewImage;
                ((FormWithImage)ActiveMdiChild).Refresh();
            }
        }

        private void negacjaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ImageProcessor.ProcessImage(((FormWithImage)ActiveMdiChild), ImageProcessor.Operations.Negation);
            ((FormWithImage)ActiveMdiChild).Refresh();
        }

        private void wygładzanieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ImageProcessor.ProcessImage(((FormWithImage)ActiveMdiChild), ImageProcessor.Operations.Smooth);
            ((FormWithImage)ActiveMdiChild).Refresh();
        }

        private void wyostrzanieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ImageProcessor.ProcessImage(((FormWithImage)ActiveMdiChild), ImageProcessor.Operations.Sharpen);
            ((FormWithImage)ActiveMdiChild).Refresh();
        }

        private void detekcjaKrawędziToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ImageProcessor.ProcessImage(((FormWithImage)ActiveMdiChild), ImageProcessor.Operations.DetectEdges);
            ((FormWithImage)ActiveMdiChild).Refresh();
        }

        private void specjalnaDetekacjaKrawędziToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ImageProcessor.ProcessImage(((FormWithImage)ActiveMdiChild), ImageProcessor.Operations.SpecDetectEdgesP);
            ((FormWithImage)ActiveMdiChild).Refresh();
        }

        private void specjalnaDetekacjaKrawędziCannyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ImageProcessor.ProcessImage(((FormWithImage)ActiveMdiChild), ImageProcessor.Operations.SpecDetectEdgesC);
            ((FormWithImage)ActiveMdiChild).Refresh();
        }

        private void medianowyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ImageProcessor.ProcessImage(((FormWithImage)ActiveMdiChild), ImageProcessor.Operations.Median);
            ((FormWithImage)ActiveMdiChild).Refresh();
        }
    }
}