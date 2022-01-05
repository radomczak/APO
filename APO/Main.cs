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
            // Opcje zapisu dla przetwarzanych obrazów oraz kompatibylne rozszerzenia, możliwe do wczytania przez program
            saveFileDialog1.Filter = "Obraz BMP|*.bmp|Obraz TIFF|*.tiff|Obraz PNG|*.png|Obraz JPG|*.jpg";
            openFileDialog1.Filter = "Obrazy(*.BMP;*.TIFF;*.PNG;*.JPG)|*.BMP;*.TIFF;*.PNG;*.JPG;*.JPEG|Wszystkie pliki(*.*)|*.*";
            // Określa ten formularz jako rodzica co pozwala na wielowątkowe otwieranie innych formularzy (obrazów) wewnątrz tego.
            IsMdiContainer = true;
        }

        //FUNCKJE KONTROLEK Z MENU (PASKA NARZĘDZI)

        //Funckja pokazująca podstawowe informacje o programie
        private void infoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String appInfo = "Autor: Radosław Popielarski\nGrupa: IZ07IO1\nRok: 2021/2022\nPrzedmiot: Algorytmy przetwarzania obrazów (APO)\n";
            MessageBox.Show(appInfo, "Informacje", MessageBoxButtons.OK);
        }
        //Funckja pozwalająca tworząca nowy formularz zawierajacy obraz wczytany z podanej ścieżki
        private void NewImage(string filename)
        {
            FormWithImage form = new FormWithImage(filename);
            form.MdiParent = this;
            EnableButtons();
            form.Show();
        }

        //Po otwarciu obrazu wykorzystywana jest poniższa funkcja zezwalająca na użycie reszty przycisków i narzędzi z głównego menu
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
            punktoweDwuargumentoweToolStripMenuItem.Enabled = true;
            aNDToolStripMenuItem.Enabled = true;
            oRToolStripMenuItem.Enabled = true;
            xORToolStripMenuItem.Enabled = true;
            otsuToolStripMenuItem.Enabled = true;
            wododziałowaToolStripMenuItem.Enabled = true;
            erozjaToolStripMenuItem.Enabled = true;
            dylacjaToolStripMenuItem.Enabled = true;
        }

        // Gdy nie ma żadnego innego obrazu, ta funckja wyłącza kontrolki w menu
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
                punktoweDwuargumentoweToolStripMenuItem.Enabled = false;
                aNDToolStripMenuItem.Enabled = false;
                oRToolStripMenuItem.Enabled = false;
                xORToolStripMenuItem.Enabled = false;
                otsuToolStripMenuItem.Enabled = false;
                wododziałowaToolStripMenuItem.Enabled = false;
                erozjaToolStripMenuItem.Enabled = false;
                dylacjaToolStripMenuItem.Enabled = false;
            }
        }

        //Pokazuje okienko eksploratora windows gdzie po wskazaniu obrazku pobiera jego ścieżkę i używając funckji NewImage tworzy formularz z tym obrazem
        private void otwórzToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == openFileDialog1.ShowDialog())
            {
                NewImage(openFileDialog1.FileName);
            }
        }

        //Zapisanie / Nadpisanie obrazu, wykorzystujące funckje Save formulrza z obrazem. W przypadku blędu jest pokazywany komunikat
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

        //Zapisanie obrazu jako nowego obrazu z wybraniem rozszerzenia. Wykorzystuje funckje Save formulrza z obrazem. W przypadku blędu jest pokazywany komunikat
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

        //Zamyka wybrany obraz bez zapisu.
        public void zamknijToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ((FormWithImage)ActiveMdiChild).Close();
            DissableButtonsIfNeeded();
        }

        //Zamyka wszystkie obrazy bez zapisu
        private void zamknijWszystkieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (FormWithImage form in this.MdiChildren) {
                form.Close();
            }
            DissableButtonsIfNeeded();
        }

        //Zamyka wszystkie obrazy bez zapisu i zamyka aplikacje.
        private void wyjścieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            zamknijWszystkieToolStripMenuItem_Click(sender,e);
            this.Close();
        }

        //Tworzy duplikat obrazu z obecnie wybranego obrazu
        private void duplikujToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewImage(ActiveMdiChild.Text);
        }

        //Wyświetla formularz z histogramem monochromatyczny
        private void monoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormWithHistogramGreyscale histForm = new FormWithHistogramGreyscale(((FormWithImage)ActiveMdiChild).HistogramG, ((FormWithImage)ActiveMdiChild).Source);
            histForm.ShowDialog();
        }

        //Wyświetla formularz z histogramem rbg
        private void rGBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormWithHistogramRGB histForm = new FormWithHistogramRGB(((FormWithImage)ActiveMdiChild).HistogramRGB, ((FormWithImage)ActiveMdiChild).Source);
            histForm.ShowDialog();
        }

        //Tablica LUT rgb
        private void rGBToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormWithLUTTableRGB LUTForm = new FormWithLUTTableRGB(((FormWithImage)ActiveMdiChild).HistogramRGB);
            LUTForm.ShowDialog();
        }

        //Tablica LUT monochromatyczna
        private void greyscaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormWithLUTTableGreyscale LUTForm = new FormWithLUTTableGreyscale(((FormWithImage)ActiveMdiChild).HistogramG);
            LUTForm.ShowDialog();
        }

        //Przeprowadza operację rozciągnięcia histogramu. Używa klasy ImageProcessor do przetworzenia obrazu
        private void rozciąganieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ImageProcessor.ProcessImage(((FormWithImage)ActiveMdiChild),ImageProcessor.Operations.Stretch);
             ((FormWithImage)ActiveMdiChild).Refresh();
        }

        //Przeprowadza operację wyrównania histogramu.  Używa klasy ImageProcessor do przetworzenia obrazu
        private void wyrównanieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ImageProcessor.ProcessImage(((FormWithImage)ActiveMdiChild), ImageProcessor.Operations.Equalize);
            ((FormWithImage)ActiveMdiChild).Refresh();
        }

        //Rozciąganie histogramu z wyborem zakresu. Używa klasy PreviewWithSlider do przetworzenia obrazu oraz wyświetlenia go z podglądem
        private void ąganieHistogramuZZakresemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PreviewWithSlider previewWithSlider = new PreviewWithSlider((FormWithImage)ActiveMdiChild, PreviewWithSlider.Operations.StretchP1P2);
            if (previewWithSlider.ShowDialog() == DialogResult.OK)
            {
                ((FormWithImage)ActiveMdiChild).FastBitmap = previewWithSlider.NewImage;
                ((FormWithImage)ActiveMdiChild).Refresh();
            }
        }

        //Redukcja poziomów szarości histogramu z suwakiem. Używa klasy PreviewWithSlider do przetworzenia obrazu oraz wyświetlenia go z podglądem
        private void redukcjaPoziomówSzarościToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PreviewWithSlider previewWithSlider = new PreviewWithSlider((FormWithImage)ActiveMdiChild, PreviewWithSlider.Operations.Posterize);
            if (previewWithSlider.ShowDialog() == DialogResult.OK)
            {
                ((FormWithImage)ActiveMdiChild).FastBitmap = previewWithSlider.NewImage;
                ((FormWithImage)ActiveMdiChild).Refresh();
            }
        }

        //Progowanie obrazu. Używa klasy PreviewWithSlider do przetworzenia obrazu oraz wyświetlenia go z podglądem
        private void progToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PreviewWithSlider previewWithSlider = new PreviewWithSlider((FormWithImage)ActiveMdiChild, PreviewWithSlider.Operations.Thresholding);
            if (previewWithSlider.ShowDialog() == DialogResult.OK)
            {
                ((FormWithImage)ActiveMdiChild).FastBitmap = previewWithSlider.NewImage;
                ((FormWithImage)ActiveMdiChild).Refresh();
            }
        }

        //Progowanie binarne obrazu. Używa klasy PreviewWithSlider do przetworzenia obrazu oraz wyświetlenia go z podglądem
        private void progrowanieBinarneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PreviewWithSlider previewWithSlider = new PreviewWithSlider((FormWithImage)ActiveMdiChild, PreviewWithSlider.Operations.Binarization);
            if (previewWithSlider.ShowDialog() == DialogResult.OK)
            {
                ((FormWithImage)ActiveMdiChild).FastBitmap = previewWithSlider.NewImage;
                ((FormWithImage)ActiveMdiChild).Refresh();
            }
        }

        //Negacja obrazu. Używa klasy ImageProcessor do przetworzenia obrazu
        private void negacjaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ImageProcessor.ProcessImage(((FormWithImage)ActiveMdiChild), ImageProcessor.Operations.Negation);
            ((FormWithImage)ActiveMdiChild).Refresh();
        }

        //Wygładzanie  Używa klasy ImageProcessor do przetworzenia obrazu
        private void wygładzanieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ImageProcessor.ProcessImage(((FormWithImage)ActiveMdiChild), ImageProcessor.Operations.Smooth);
            ((FormWithImage)ActiveMdiChild).Refresh();
        }

        //Wyostrzanie. Używa klasy ImageProcessor do przetworzenia obrazu
        private void wyostrzanieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ImageProcessor.ProcessImage(((FormWithImage)ActiveMdiChild), ImageProcessor.Operations.Sharpen);
            ((FormWithImage)ActiveMdiChild).Refresh();
        }

        //Detekcja krawiędzi w obrazie. Używa klasy ImageProcessor do przetworzenia obrazu
        private void detekcjaKrawędziToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ImageProcessor.ProcessImage(((FormWithImage)ActiveMdiChild), ImageProcessor.Operations.DetectEdges);
            ((FormWithImage)ActiveMdiChild).Refresh();
        }

        //Detekcja krawiędzi typu Prewitt na obrazie. Używa klasy ImageProcessor do przetworzenia obrazu
        private void specjalnaDetekacjaKrawędziToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ImageProcessor.ProcessImage(((FormWithImage)ActiveMdiChild), ImageProcessor.Operations.SpecDetectEdgesP);
            ((FormWithImage)ActiveMdiChild).Refresh();
        }

        //Detekcja krawiędzi typu Canny na obrazie. Używa klasy ImageProcessor do przetworzenia obrazu
        private void specjalnaDetekacjaKrawędziCannyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ImageProcessor.ProcessImage(((FormWithImage)ActiveMdiChild), ImageProcessor.Operations.SpecDetectEdgesC);
            ((FormWithImage)ActiveMdiChild).Refresh();
        }

        //Filtr medianowy na obrazie. Używa klasy ImageProcessor do przetworzenia obrazu
        private void medianowyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ImageProcessor.ProcessImage(((FormWithImage)ActiveMdiChild), ImageProcessor.Operations.Median);
            ((FormWithImage)ActiveMdiChild).Refresh();
        }

        //Operacja dwuargumentowa typu AND na obrazie. Początkowo za pomocą formularza SelectFormForm wybiera drugi argument dla operacji AND. Używa klasy ImageProcessor do przetworzenia obrazu
        private void aNDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SelectFormForm selectForm = new SelectFormForm(MdiChildren);
            if(selectForm.ShowDialog() == DialogResult.OK)
            {
                ImageProcessor.ProcessImage((FormWithImage)ActiveMdiChild, selectForm.Form, ImageProcessor.Operations.AND);
                ((FormWithImage)ActiveMdiChild).Refresh();
            }
        }

        //Operacja dwuargumentowa typu OR na obrazie. Początkowo za pomocą formularza SelectFormForm wybiera drugi argument dla operacji OR. Używa klasy ImageProcessor do przetworzenia obrazu
        private void oRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SelectFormForm selectForm = new SelectFormForm(MdiChildren);
            if (selectForm.ShowDialog() == DialogResult.OK)
            {
                ImageProcessor.ProcessImage((FormWithImage)ActiveMdiChild, selectForm.Form, ImageProcessor.Operations.OR);
                ((FormWithImage)ActiveMdiChild).Refresh();
            }
        }

        //Operacja dwuargumentowa typu XOR na obrazie. Początkowo za pomocą formularza SelectFormForm wybiera drugi argument dla operacji XOR. Używa klasy ImageProcessor do przetworzenia obrazu
        private void xORToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SelectFormForm selectForm = new SelectFormForm(MdiChildren);
            if (selectForm.ShowDialog() == DialogResult.OK)
            {
                ImageProcessor.ProcessImage((FormWithImage)ActiveMdiChild, selectForm.Form, ImageProcessor.Operations.XOR);
                ((FormWithImage)ActiveMdiChild).Refresh();
            }
        }

        //Operacja progowania otsu na obrazie. Używa klasy ImageProcessor do przetworzenia obrazu
        private void otsuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ImageProcessor.ProcessImage(((FormWithImage)ActiveMdiChild), ImageProcessor.Operations.Otsu);
            ((FormWithImage)ActiveMdiChild).Refresh();
        }

        //Operacja segmentacji watershed na obrazie. Używa klasy ImageProcessor do przetworzenia obrazu
        private void wododziałowaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ImageProcessor.ProcessImage(((FormWithImage)ActiveMdiChild), ImageProcessor.Operations.Watershed);
            ((FormWithImage)ActiveMdiChild).Refresh();
        }

        //Operacja erozji na obrazie. Używa klasy ImageProcessor do przetworzenia obrazu
        private void erozjaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ImageProcessor.ProcessImage(((FormWithImage)ActiveMdiChild), ImageProcessor.Operations.Erode);
            ((FormWithImage)ActiveMdiChild).Refresh();
        }

        //Operacja dylacji na obrazie. Używa klasy ImageProcessor do przetworzenia obrazu
        private void dylacjaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ImageProcessor.ProcessImage(((FormWithImage)ActiveMdiChild), ImageProcessor.Operations.Dilate);
            ((FormWithImage)ActiveMdiChild).Refresh();
        }
    }
}