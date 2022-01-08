using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Emgu.CV;
using System.Windows.Forms;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using Emgu.CV.CvEnum;

namespace APO
{
    //Klasa która obsługuję większość jeżeli nie wszystkie żądania, przetworzenia obrazu dla przekazanej operacji.
    class ImageProcessor
    {
        //Operacje obsługiwane przez tę klase
        public enum Operations { Stretch, Equalize, Negation, Binarization, Thresholding, Posterize, StretchP1P2, 
            Smooth, Sharpen, DetectEdges, SpecDetectEdgesP, SpecDetectEdgesC, Median,
            AND, OR, XOR, Otsu, Watershed,
            Erode, Dilate
        };

        //Metoda przetwarzania pojedyńczego obrazu z użyciem wybranej operacji
        public static void ProcessImage(FormWithImage form, Operations operation)
        {
            switch(operation)
            {
                case Operations.Stretch:
                    Stretch(form);
                    break;
                case Operations.Equalize:
                    EqualizeHistogram(form);
                    break;
                case Operations.Negation:
                    Negation(form);
                    break;
                case Operations.Smooth:
                    Smooth(form);
                    break;
                case Operations.Sharpen:
                    Sharpen(form);
                    break;
                case Operations.DetectEdges:
                    DetectEdges(form);
                    break;
                case Operations.SpecDetectEdgesP:
                    SpecDetectEdgesP(form);
                    break;
                case Operations.SpecDetectEdgesC:
                    SpecDetectEdgesC(form);
                    break;
                case Operations.Median:
                    MedianFilter(form);
                    break;
                case Operations.Otsu:
                    Otsu(form);
                    break;
                case Operations.Watershed:
                    Watershed(form);
                    break;
                case Operations.Erode:
                case Operations.Dilate:
                    BinaryOperation(form, operation);
                    break;
            }
        }

        //Metoda przetwarzania obrazu z użyciem wybranej operacji i drugiego obrazu. Operacje dwuargumentowe
        public static void ProcessImage(FormWithImage form1, FormWithImage form2, Operations operation)
        {
            switch (operation)
            {
                case Operations.AND:
                    ANDOperator(form1,form2);
                    break;
                case Operations.OR:
                    OROperator(form1, form2);
                    break;
                case Operations.XOR:
                    XOROperator(form1, form2);
                    break;
            }
        }

        //Do przetwarzania obrazów za pomocą metod, które wymagają pewnych wartości progów. Metoda zwraca obraz wynikowy
        public static FastBitmap ProcessAndReturnImage(FormWithImage form, Operations operation, int value)
        {
            FastBitmap fastBitmap = null;
            switch (operation)
            {
                case Operations.Binarization:
                    fastBitmap = Binarize(form, value);
                    break;
                case Operations.Posterize:
                    fastBitmap = Posterize(form, value);
                    break;
            }
            return fastBitmap;
        }

        //Do przetwarzania obrazów za pomocą metod, które wymagają pewnych wartości progów od do. Metoda zwraca obraz wynikowy
        public static FastBitmap ProcessAndReturnImage(FormWithImage form, Operations operation, int from, int to)
        {
            FastBitmap fastBitmap = null;
            switch (operation)
            {
                case Operations.Thresholding:
                    fastBitmap = Threshold(form, from, to);
                    break;
                case Operations.StretchP1P2:
                    fastBitmap = StretchP1P2(form, from, to);
                    break;
            }
            return fastBitmap;
        }

        //Rozciąganie histogramu obrazu
        private static void Stretch(FormWithImage form)
        {
            FastBitmap bmp = form.FastBitmap;
            if (form.IsMono)  
            {
                //Dla obrazów monochromatycznych jest tworzona jest tworzona jedna tabela do przechowywania tabeli LUT tego obrazu.
                //Następnie używając tej tabeli program wywołuję metodę stretchCalculateLUT, która zwróci przetworzoną tablicę.
                int[] value = form.HistogramG.HistogramTable;
                int[] LUTvalue = stretchCalculateLUT(value);

                //Po przetworzeniu, wartości kolorów poszczególnych pixeli w obrazie są nadpisywane z użyciem nowej rozciągniętej tabeli LUT
                //Dwie pętle for do iracji po pixelach obrazu
                for (int i = 0; i < bmp.Size.Width; ++i)
                {
                    for (int j = 0; j < bmp.Size.Height; ++j)
                    {
                        int pixelR = bmp[i, j].R;
                        Color newPixel = Color.FromArgb(LUTvalue[pixelR], LUTvalue[pixelR], LUTvalue[pixelR]);
                        bmp[i, j] = newPixel;
                    }
                }
            }
            else
            {
                //Dla obrazów kolorowych jest tak podobnie tylko, operacje i zmienne są powtórzone dodatkowo dwa razy przez wzgląd na 3 kanały obrazów kolorowych (R,G,B)
                int[] red = form.HistogramRGB.HistogramTableR;
                int[] green = form.HistogramRGB.HistogramTableG;
                int[] blue = form.HistogramRGB.HistogramTableB;
                int[] LUTred = stretchCalculateLUT(red);
                int[] LUTgreen = stretchCalculateLUT(green);
                int[] LUTblue = stretchCalculateLUT(blue);

                //Dwie pętle for do iracji po pixelach obrazu
                for (int i = 0; i < bmp.Size.Width; ++i)
                {
                    for (int j = 0; j < bmp.Size.Height; ++j)
                    {
                        Color pixel = bmp[i, j];
                        Color newPixel = Color.FromArgb(LUTred[pixel.R], LUTgreen[pixel.G], LUTblue[pixel.B]);
                        bmp[i, j] = newPixel;
                    }
                }
            }
        }

        //Wyrównanie histogramu obrazu
        private static void EqualizeHistogram(FormWithImage form)
        {
            FastBitmap bmp = form.FastBitmap;
            int bmpSize = bmp.Size.Height * bmp.Size.Width;
            if (form.IsMono)
            {
                //Dla obrazów monochromatycznych jest tworzona jest tworzona jedna tabela do przechowywania tabeli LUT tego obrazu.
                //Następnie używając tej tabeli program wywołuję metodę equalizeCalculateLUT, która zwróci przetworzoną tablicę.
                int[] value = form.HistogramG.HistogramTable;
                int[] LUTvalue = equalizeCalculateLUT(value, bmpSize);

                //Po przetworzeniu, wartości kolorów poszczególnych pixeli w obrazie są nadpisywane z użyciem nowej wyrównanej tabeli LUT
                //Dwie pętle for do iracji po pixelach obrazu
                for (int i = 0; i < bmp.Size.Width; ++i)
                {
                    for (int j = 0; j < bmp.Size.Height; ++j)
                    {
                        int pixelR = bmp[i, j].R;
                        Color newPixel = Color.FromArgb(LUTvalue[pixelR], LUTvalue[pixelR], LUTvalue[pixelR]);
                        bmp[i, j] = newPixel;
                    }
                }
            }
            else
            {
                //Dla obrazów kolorowych jest tak podobnie tylko, operacje i zmienne są powtórzone dodatkowo dwa razy przez wzgląd na 3 kanały obrazów kolorowych (R,G,B)
                int[] red = form.HistogramRGB.HistogramTableR;
                int[] green = form.HistogramRGB.HistogramTableG;
                int[] blue = form.HistogramRGB.HistogramTableB;
                int[] LUTred = equalizeCalculateLUT(red,bmpSize);
                int[] LUTgreen = equalizeCalculateLUT(green, bmpSize);
                int[] LUTblue = equalizeCalculateLUT(blue, bmpSize);

                //Dwie pętle for do iracji po pixelach obrazu
                for (int i = 0; i < bmp.Size.Width; ++i)
                {
                    for (int j = 0; j < bmp.Size.Height; ++j)
                    {
                        Color pixel = bmp[i, j];
                        Color newPixel = Color.FromArgb(LUTred[pixel.R], LUTgreen[pixel.G], LUTblue[pixel.B]);
                        bmp[i, j] = newPixel;
                    }
                }
            }
        }

        //Negacja obrazu
        private static void Negation(FormWithImage form)
        {
            FastBitmap bmp = form.FastBitmap;
            
            //Dwie pętle for do iracji po pixelach obrazu
            for (int i = 0; i < bmp.Size.Width; ++i)
            {
                for (int j = 0; j < bmp.Size.Height; ++j)
                {
                    //Negacja odbywa się przez odwrócenie wartości kolorów poszczególnych pixeli.
                    Color pixel = bmp[i, j];
                    Color newPixel = Color.FromArgb(255 - pixel.R, 255 - pixel.G, 255 - pixel.B);
                    bmp[i, j] = newPixel;
                }
            }
        }

        //Binaryzacja obrazu, z zadanym progiem
        private static FastBitmap Binarize(FormWithImage form, int value)
        {
            //Obraz jest sklonowany, gdyż funkcja zwraca przetworzony obraz bez modyfikacji pierwotnego
            FastBitmap bmp = form.FastBitmap.Clone();

            if (form.IsMono)
            {
                //Dwie pętle for do iracji po pixelach obrazu
                for (int i = 0; i < bmp.Size.Width; ++i)
                {
                    for (int j = 0; j < bmp.Size.Height; ++j)
                    {
                        //Wartości pixeli poniżej danego progu są zerowane, a pozostałe są maksymalizowane
                        int pixelR = bmp[i, j].R;
                        if (pixelR <= value) pixelR = 0;
                        else pixelR = 255;
                        //Nowe wartości pixeli zostają przypisane do sklonowanego obrazu
                        Color newPixel = Color.FromArgb(pixelR, pixelR, pixelR);
                        bmp[i, j] = newPixel;
                    }
                }
            }
            else
            {
                //Dla obrazów kolorowych proces jest ten sam z różnicą, że obraz zostaje najpierw zamieniony na monochromatyczny.
                int R;
                int G;
                int B;
                int v;
                //Dwie pętle for do iracji po pixelach obrazu
                for (int i = 0; i < bmp.Size.Width; ++i)
                {
                    for (int j = 0; j < bmp.Size.Height; ++j)
                    {
                        R = bmp[i, j].R;
                        G = bmp[i, j].G;
                        B = bmp[i, j].B;
                        //Wylcizenie nowej wartości pixela, używając poniższych wag dla odpowiednich kanałów, tak by obraz finalnie stał się monochromatyczny
                        v = (int)((double)R * 0.3d + (double)G * 0.6d + (double)B * 0.1d);
                        if (v <= value) v = 0;
                        else v = 255;
                        Color newPixel = Color.FromArgb(v, v, v);
                        bmp[i, j] = newPixel;
                    }
                }
            }

            return bmp;
        }

        //Progowanie obrazu
        private static FastBitmap Threshold(FormWithImage form, int from, int to)
        {
            //Obraz jest sklonowany, gdyż funkcja zwraca przetworzony obraz bez modyfikacji pierwotnego
            FastBitmap bmp = form.FastBitmap.Clone();

            if (form.IsMono)
            {
                //Dwie pętle for do iracji po pixelach obrazu
                for (int i = 0; i < bmp.Size.Width; ++i)
                {
                    for (int j = 0; j < bmp.Size.Height; ++j)
                    {
                        //Wartość koloru czerwonego dla obecnego pixela
                        int pixelR = bmp[i, j].R;
                        //Wartości znajdująca się pomiędzy wybranym progiem min i max jest zachowywana a pozostałe są zerowane i nadpisywane
                        if (pixelR < from || pixelR > to)
                        {
                            pixelR = 0;
                            Color newPixel = Color.FromArgb(pixelR, pixelR, pixelR);
                            bmp[i, j] = newPixel;
                        }
                    }
                }
            }
            else
            {
                //Dla obrazów kolorowych proces jest ten sam z różnicą, że obraz zostaje najpierw zamieniony na monochromatyczny.
                int R;
                int G;
                int B;
                int v;

                //Dwie pętle for do iracji po pixelach obrazu
                for (int i = 0; i < bmp.Size.Width; ++i)
                {
                    for (int j = 0; j < bmp.Size.Height; ++j)
                    {
                        R = bmp[i, j].R;
                        G = bmp[i, j].G;
                        B = bmp[i, j].B;
                        //Wylcizenie nowej wartości pixela, używając poniższych wag dla odpowiednich kanałów, tak by obraz finalnie stał się monochromatyczny
                        v = (int)((double)R * 0.3d + (double)G * 0.6d + (double)B * 0.1d);
                        if (v < from || v > to)
                        {
                            v = 0;
                            Color newPixel = Color.FromArgb(v, v, v);
                            bmp[i, j] = newPixel;
                        }
                    }
                }
            }

            return bmp;
        }

        //Posteryzacja obrazu
        private static FastBitmap Posterize(FormWithImage form, int value)
        {
            //Obraz jest sklonowany, gdyż funkcja zwraca przetworzony obraz bez modyfikacji pierwotnego
            FastBitmap bmp = form.FastBitmap.Clone();
            //Zmienna na nową tablice LUT
            int[] tab = new int[256];
            //Parametry potrzebne do posteryzacji
            float param1 = 255.0f / (value - 1);
            float param2 = 256.0f / (value);

            //Fla każdegopoziomu szarości jest wyznaczana nowa wartość. Tworzenie nowej tablicy LUT
            for (int i = 0; i < 256; ++i)
            {
                tab[i] = (int)((int)(i / param2) * param1);
            }

            //Przypisanie tablicy LUT. W przypadku obrazu RGB jest on najpierw konwertowany na monochromatyczny
            if (form.IsMono)
            {
                for (int i = 0; i < bmp.Size.Width; ++i)
                {
                    for (int j = 0; j < bmp.Size.Height; ++j)
                    {
                        Color currentColor = bmp[i, j];
                        int newColor = tab[currentColor.R];
                        bmp[i, j] = Color.FromArgb(newColor, newColor, newColor);
                    }
                }
            } 
            else
            {
                int R;
                int G;
                int B;
                int v;
                for (int i = 0; i < bmp.Size.Width; ++i)
                {
                    for (int j = 0; j < bmp.Size.Height; ++j)
                    {
                        R = bmp[i, j].R;
                        G = bmp[i, j].G;
                        B = bmp[i, j].B;
                        v = (int)((double)R * 0.3d + (double)G * 0.6d + (double)B * 0.1d);
                        int newColor = tab[v];
                        bmp[i, j] = Color.FromArgb(newColor, newColor, newColor);
                    }
                }
            }

            return bmp;
        }

        //Rozciąganie z progami
        private static FastBitmap StretchP1P2(FormWithImage form, int from, int to)
        {
            //Obraz jest sklonowany, gdyż funkcja zwraca przetworzony obraz bez modyfikacji pierwotnego
            FastBitmap bmp = form.FastBitmap.Clone();
            if (form.IsMono)
            {
                //Wyznaczenie nowej tablicy LUT wedle progów
                int[] LUTvalue = stretchP1P2CalculateLUT( from, to);

                for (int i = 0; i < bmp.Size.Width; ++i)
                {
                    for (int j = 0; j < bmp.Size.Height; ++j)
                    {
                        //Nadpisanie wartości pixeli, wedle nowej tablicy LUT
                        int pixelR = bmp[i, j].R;
                        Color newPixel = Color.FromArgb(LUTvalue[pixelR], LUTvalue[pixelR], LUTvalue[pixelR]);
                        bmp[i, j] = newPixel;
                    }
                }
            }
            else
            {
                //Wyznaczenie nowych tablic LUT wedle progów
                int[] LUTred = stretchP1P2CalculateLUT(from, to);
                int[] LUTgreen = stretchP1P2CalculateLUT(from, to);
                int[] LUTblue = stretchP1P2CalculateLUT(from, to);

                for (int i = 0; i < bmp.Size.Width; ++i)
                {
                    for (int j = 0; j < bmp.Size.Height; ++j)
                    {
                        //Nadpisanie wartości pixeli, wedle nowych tablic LUT
                        Color pixel = bmp[i, j];
                        Color newPixel = Color.FromArgb(LUTred[pixel.R], LUTgreen[pixel.G], LUTblue[pixel.B]);
                        bmp[i, j] = newPixel;
                    }
                }
            }
            return bmp;
        }

        //Rozciąganie, poprzez wyznaczenie nowej tablicy LUT z wartości wyliczonymi wedle przekazych progów. Funckja zwraca wyliczoną tablicę
        private static int[] stretchP1P2CalculateLUT(int from, int to)
        {
            int k = 256;
            int[] result = new int[k];
            double a;
            //Współczynnik
            a = 255.0 / (to - from);
            for (int i = 0; i < k; i++)
            {
                //Wartości poniżej progu od są zerowane
                if (i < from)
                    result[i] = 0;
                //Wartości powyżej progu do są maksymalizowane
                else if (i > to)
                    result[i] = 255;
                //Reszta wartości jest wyliczona wedle wzoru
                else
                    result[i] = (int)(a * (i - from));
            }

            return result;
        }

        //Roziągnięcie przekazanej tablicy LUT
        private static int[] stretchCalculateLUT(int[] tabLUT)
        {
            //Zmienne określające całkowitą ilość kolorów, oraz najmniejszą i nawiększą wartość koloru 
            int k = 256;
            int min = 0;
            int max = 255;
            //Tablica na wynik operacji rozciągania
            int[] result = new int[k];
            //Współczynnik
            double a;

            //Szukanie najmniejszej niezerowej wartości od lewej
            for (int i = 0; i < k; i++)
            {
                if (tabLUT[i] != 0)
                {
                    min = i;
                    break;
                }
            }

            //Szukanie najwiekszej niezerowej wartości od prawej
            for (int i = 255; i >= 0; i--)
            {
                if (tabLUT[i] != 0)
                {
                    max = i;
                    break;
                }
            }
           //Wyliczenie wartości wspóczynnika
            a = 255.0 / (max - min);
            //Wylcizenie wartości nowej tablicy wynikowej z użyciem wzoru
            for (int i = 0; i < k; i++)
            {
                result[i] = (int)(a * (i - min));
            }

            return result;
        }

        //Metoda do wyrównania przekazanej tablicy. Zmienna size jest potrzebna do wzoru
        private static int[] equalizeCalculateLUT(int[] tabLUT, int size)
        {
            //Zmienne określające całkowitą ilość kolorów, oraz najmniejszą wartość koloru 
            int k = 256;
            double min = 0;
            //Tablica na wynikową tablicę LUT
            int[] result = new int[k];
            double sum = 0;

            //Szukanie najmniejszej niezerowej wartości od lewej
            for (int i = 0; i < k; i++)
            {
                if (tabLUT[i] != 0)
                {
                    min = tabLUT[i];
                    break;
                }
            }
            
            //Wyliczenie z nowej tablicy LUT z użyciem wzoru
            for (int i = 0; i < k; i++)
            {
                sum += tabLUT[i];
                result[i] = (int)(((sum - min) / (size - min)) * 255.0);
            }

            return result;
        }

        //Wygładzanie, używa formularza FormMask3x3 do pobrania odpowiedniej maski
        //Funckja korzysta z uniwersalnej metody aplikacji wybranego filtru do obrazu
        private static void Smooth(FormWithImage form)
        {
            FormMask3x3 formMask = new FormMask3x3(FormMask3x3.Operations.Smooth);

            //Gdy formularz został zamknięty z pozytywnym rezultatem 
            if (formMask.ShowDialog() == DialogResult.OK)
            {
                applyFilterToForm(formMask, form);
            }
        }

        //Wygostrzanie, używa formularza FormMask3x3 do pobrania odpowiedniej maski
        //Funckja korzysta z uniwersalnej metody aplikacji wybranego filtru do obrazu
        private static void Sharpen(FormWithImage form)
        {
            FormMask3x3 formMask = new FormMask3x3(FormMask3x3.Operations.Sharpen);

            //Gdy formularz został zamknięty z pozytywnym rezultatem 
            if (formMask.ShowDialog() == DialogResult.OK)
            {
                applyFilterToForm(formMask, form);
            }
        }

        //Detekcja krawędzi, używa formularza FormMask3x3 do pobrania odpowiedniej maski
        //Funckja korzysta z uniwersalnej metody aplikacji wybranego filtru do obrazu
        private static void DetectEdges(FormWithImage form)
        {
            FormMask3x3 formMask = new FormMask3x3(FormMask3x3.Operations.DetectEdges);

            //Gdy formularz został zamknięty z pozytywnym rezultatem 
            if (formMask.ShowDialog() == DialogResult.OK)
            {
                form.RGBtoGray();
                applyFilterToForm(formMask, form);
            }
        }

        //Detekcja krawędzi z maskami Prewitta, używa formularza PrewittForm do pobrania odpowiednich mask
        private static void SpecDetectEdgesP(FormWithImage form)
        {
            PrewittForm prewittForm = new PrewittForm();

            //Gdy formularz został zamknięty z pozytywnym rezultatem 
            if (prewittForm.ShowDialog() == DialogResult.OK)
            {
                //Obraz jest konwertowany na monochromatyczny, po czym jest klonowany i zamieniony na obraz z biblioteki OpenCV
                form.RGBtoGray();
                FastBitmap bmp = form.FastBitmap.Clone();
                bmp.Unlock();   //Odblokowuje obraz do edycji
                var img = bmp.Bitmap.ToImage<Gray, byte>();
                bmp.Lock();    //Blokuje edycje obrazu

                //Utworzenie obiektu dla maski, do użycia w funckji z biblioteki OpenCV
                ConvolutionKernelF kernelF1 = new ConvolutionKernelF(prewittForm.Mask1);
                ConvolutionKernelF kernelF2 = new ConvolutionKernelF(prewittForm.Mask2);
               
                //Zczytanie metody krawędziowej z formularza
                BorderType type = prewittForm.BorderType;

                //Punkt wyznaczający środek maski
                Point anchor = new Point(-1, -1);

                //Wygładzanie filtrem Gaussa
                CvInvoke.GaussianBlur(img, img, new Size(3, 3), 0);

                //Zmienne fo wykrycia krawędzi, z użcyiem pierwszzej i drugiej maski
                var img1 = new Image<Gray, byte>(img.Size);
                var img2 = new Image<Gray, byte>(img.Size);

                CvInvoke.Filter2D(img, img1, kernelF1, anchor, 0, type);
                CvInvoke.Filter2D(img, img2, kernelF2, anchor, 0, type);

                //Złaczenie wyników i podmiana obrazu
                img = img1 + img2;
                bmp = new FastBitmap(img.ToBitmap());
                form.FastBitmap = bmp;
            }
        }

        //Detekcja krawędzi typu Canny, używa formularza GetThresholdForm do pobrania odpowiednich progów
        private static void SpecDetectEdgesC(FormWithImage form)
        {

            GetThresholdForm thresholdForm = new GetThresholdForm();
            if (thresholdForm.ShowDialog() == DialogResult.OK)
            {
                //Pobranie progów od do
                int[] threshold = thresholdForm.GetThreshold();

                //Obraz jest konwertowany na monochromatyczny, po czym jest klonowany i zamieniony na obraz z biblioteki OpenCV
                form.RGBtoGray();
                FastBitmap bmp = form.FastBitmap.Clone();
                bmp.Unlock();
                var img = bmp.Bitmap.ToImage<Gray, byte>();
                bmp.Lock();

                //Metoda z biblioteki OpenCV przeprowadzająca pożądaną operacje z użyciem wcześniej pobranych progów
                CvInvoke.Canny(img, img, threshold[0], threshold[1]);
                bmp = new FastBitmap(img.ToBitmap());
                form.FastBitmap = bmp;
            }
        }

        //Metoda wykonujące filtrowanie medianowe na wybranych obrazie. Korzysta z formularza pozwalającego na wybranei czterech wielkości maski: 3x3, 5x5, 7x7 lub 9x9
        private static void MedianFilter(FormWithImage form)
        {
            //Formularz do wyboru rozmiaru maski i metody krawędzioej
            FourCustomMatrixForm customMatrix = new FourCustomMatrixForm();
            if (customMatrix.ShowDialog() == DialogResult.OK)
            {
                //Obraz klonowany by operacja w funkcji aplikującej filtr była wykonywana na kopii
                FastBitmap bmp = form.FastBitmap.Clone();

                //Zmienne pobrane z formularza
                int size = customMatrix.getSize();
                BorderType type = customMatrix.GetBorderType();
                bool color = !form.IsMono;
                int i = customMatrix.BorderConstant;

                //W przypadku metody krawędziowej stałej, jest wykorzystywana przeciążona funckja z argumentem na kolor ramki
                if (type.Equals(BorderType.Constant))
                    bmp = applyMedianBlurToFastBitmap(bmp, size, type, i, color);
                else
                    bmp = applyMedianBlurToFastBitmap(bmp, size, type, color);
                form.FastBitmap = bmp;
                form.Resize();
            }
        }

        //Metoda do określenia z jakimi argumentami wywołać metodę applyKernelToFastBitmap aplikująca filtr wielkości 3x3 dla danego obrazu
        private static void applyFilterToForm(FormMask3x3 mask, FormWithImage form)
        {
            FastBitmap bmp = form.FastBitmap.Clone();

            //Pobranie maski i metody krawędziowej
            float[,] kernel = mask.Mask;
            BorderType type = mask.BorderType;
            int i = mask.BorderConstant;

            //Rozdział na obrazy mono i rgb. W przypadku metody krawędziowej stałej, jest wykorzystywana przeciążona funckja z argumentem na kolor ramki
            if (form.IsMono)
            {
                if (mask.BorderType.Equals(BorderType.Constant))
                    bmp = applyKernelToFastBitmap(kernel, bmp, type, i, false);
                else
                    bmp = applyKernelToFastBitmap(kernel, bmp, type, false);
            }
            else
            {
                if (mask.BorderType.Equals(BorderType.Constant))
                    bmp = applyKernelToFastBitmap(kernel, bmp, type, i, true);
                else
                    bmp = applyKernelToFastBitmap(kernel, bmp, type, true);
            }
            form.FastBitmap = bmp;
            form.Resize();
        }

        //Metoda aplikująca filtr wielkości 3x3 dla danego obrazu, wersja dla metod krawędziowych innych niż stała
        private static FastBitmap applyKernelToFastBitmap(float[,] kernel, FastBitmap bitmap, BorderType type , bool color)
        {
            if (color)
            {
                //Odblokowanie obrazu do edycji, stworzenie obiektu do edycji z użyciem metod z biblioteki OpenCV i ponowne zablokowanie pierwotnego obrazu
                bitmap.Unlock();
                var img = bitmap.Bitmap.ToImage<Rgb, byte>();
                bitmap.Lock();

                //Rozdzielenie obrazu kolorowego na 3 kanały i utworzenie zmiennych dla maski i punktu wskazującego środek maski
                Image<Gray, byte>[] channels = img.Split();
                ConvolutionKernelF kernelF = new ConvolutionKernelF(kernel);
                Point anchor = new Point(-1, -1);

                //Aplikacja filtru i złączenie kanałów na powrót w całość
                CvInvoke.Filter2D(channels[0], channels[0], kernelF, anchor, 0, type);
                CvInvoke.Filter2D(channels[1], channels[1], kernelF, anchor, 0, type);
                CvInvoke.Filter2D(channels[2], channels[2], kernelF, anchor, 0, type);
                CvInvoke.Merge(new VectorOfMat(channels[0].Mat, channels[1].Mat, channels[2].Mat), img);
                return new FastBitmap(img.ToBitmap());
            }
            else
            {
                //Odblokowanie obrazu do edycji, stworzenie obiektu do edycji z użyciem metod z biblioteki OpenCV i ponowne zablokowanie pierwotnego obrazu
                bitmap.Unlock();
                var img = bitmap.Bitmap.ToImage<Gray, byte>();
                bitmap.Lock();

                //utworzenie zmiennych dla maski i punktu wskazującego środek maski
                ConvolutionKernelF kernelF = new ConvolutionKernelF(kernel);
                Point anchor = new Point(-1, -1);

                //Aplikacja filtru
                CvInvoke.Filter2D(img, img, kernelF, anchor, 0, type);
                return new FastBitmap(img.ToBitmap());
            }
        }

        //Metoda aplikująca filtr wielkości 3x3 dla danego obrazu, wersja dla metody krawędziowej stałej
        private static FastBitmap applyKernelToFastBitmap(float[,] kernel, FastBitmap bitmap, BorderType type, int i, bool color)
        {
            if (color)
            {
                //Odblokowanie obrazu do edycji, stworzenie obiektu do edycji z użyciem metod z biblioteki OpenCV i ponowne zablokowanie pierwotnego obrazu
                bitmap.Unlock();
                var img = bitmap.Bitmap.ToImage<Rgb, byte>();
                bitmap.Lock();

                //Rozdzielenie obrazu kolorowego na 3 kanały i utworzenie zmiennych dla maski i punktu wskazującego środek maski
                Image<Gray, byte>[] channels = img.Split();
                ConvolutionKernelF kernelF = new ConvolutionKernelF(kernel);
                Point anchor = new Point(-1, -1);

                //Aplikacja filtru i złączenie kanałów na powrót w całość
                CvInvoke.Filter2D(channels[0], channels[0], kernelF, anchor, 0, type);
                CvInvoke.Filter2D(channels[1], channels[1], kernelF, anchor, 0, type);
                CvInvoke.Filter2D(channels[2], channels[2], kernelF, anchor, 0, type);
                CvInvoke.Merge(new VectorOfMat(channels[0].Mat, channels[1].Mat, channels[2].Mat), img);

                //Stworzenie ramki o zadanym kolorze. Wielkość ramki to 1 px
                CvInvoke.CopyMakeBorder(img, img, 1, 1, 1, 1, type, new MCvScalar(i));
                return new FastBitmap(img.Mat.ToBitmap()); //Jest używany MAT ponieważ ramka wychodzi poza oryginalną wielkość obrazu
            }
            else
            {
                //Odblokowanie obrazu do edycji, stworzenie obiektu do edycji z użyciem metod z biblioteki OpenCV i ponowne zablokowanie pierwotnego obrazu
                bitmap.Unlock();
                var img = bitmap.Bitmap.ToImage<Gray, byte>();
                bitmap.Lock();

                //Utworzenie zmiennych dla maski i punktu wskazującego środek maski
                ConvolutionKernelF kernelF = new ConvolutionKernelF(kernel);
                Point anchor = new Point(-1, -1);

                //Aplikacja filtru
                CvInvoke.Filter2D(img, img, kernelF, anchor, 0, type);

                //Stworzenie ramki o zadanym kolorze. Wielkość ramki to 1 px
                CvInvoke.CopyMakeBorder(img, img, 1, 1, 1, 1, type, new MCvScalar(i));
                return new FastBitmap(img.Mat.ToBitmap()); //Jest używany MAT ponieważ ramka wychodzi poza oryginalną wielkość obrazu
            }
        }

        //Filtr medianowy dla metody krawędziowej innej niż stała
        private static FastBitmap applyMedianBlurToFastBitmap(FastBitmap bitmap, int size,BorderType type, bool color)
        {
            int borderSize = size / 2;
            if (color)
            {
                //Odblokowanie obrazu do edycji, stworzenie obiektu do edycji z użyciem metod z biblioteki OpenCV i ponowne zablokowanie pierwotnego obrazu
                bitmap.Unlock();
                var img = bitmap.Bitmap.ToImage<Rgb, byte>();
                bitmap.Lock();

                //Rozdzielenie obrazu kolorowego na 3 kanały i aplikacja filtru dla każdego z nich
                Image<Gray, byte>[] channels = img.Split();
                CvInvoke.MedianBlur(channels[0], channels[0], size);
                CvInvoke.MedianBlur(channels[1], channels[1], size);
                CvInvoke.MedianBlur(channels[2], channels[2], size);

                //Stworzenie ramki o zadanym kolorze. Wielkość ramki wyznacza zmienna borderSize
                CvInvoke.CopyMakeBorder(channels[0], channels[0], borderSize, borderSize, borderSize, borderSize, type);
                CvInvoke.CopyMakeBorder(channels[1], channels[1], borderSize, borderSize, borderSize, borderSize, type);
                CvInvoke.CopyMakeBorder(channels[2], channels[2], borderSize, borderSize, borderSize, borderSize, type);

                //Złączenie kanałów na powrót w całość
                CvInvoke.Merge(new VectorOfMat(channels[0].Mat, channels[1].Mat, channels[2].Mat), img);
                return new FastBitmap(img.Mat.ToBitmap()); //Jest używany MAT ponieważ ramka wychodzi poza oryginalną wielkość obrazu
            }
            else
            {
                //Odblokowanie obrazu do edycji, stworzenie obiektu do edycji z użyciem metod z biblioteki OpenCV i ponowne zablokowanie pierwotnego obrazu
                bitmap.Unlock();
                var img = bitmap.Bitmap.ToImage<Gray, byte>();
                bitmap.Lock();

                //Aplikacja filtru
                CvInvoke.MedianBlur(img, img, size);

                //Stworzenie ramki o zadanym kolorze. Wielkość ramki wyznacza zmienna borderSize
                CvInvoke.CopyMakeBorder(img, img, borderSize, borderSize, borderSize, borderSize, type);
                return new FastBitmap(img.Mat.ToBitmap()); //Jest używany MAT ponieważ ramka wychodzi poza oryginalną wielkość obrazu
            }
        }

        //Filtr medianowy, wersja dla metdoy krawędziowej stałej, z podanym kolorem
        private static FastBitmap applyMedianBlurToFastBitmap(FastBitmap bitmap, int size, BorderType type, int i, bool color)
        {
            int borderSize = size / 2;
            if (color)
            {
                //Odblokowanie obrazu do edycji, stworzenie obiektu do edycji z użyciem metod z biblioteki OpenCV i ponowne zablokowanie pierwotnego obrazu
                bitmap.Unlock();
                var img = bitmap.Bitmap.ToImage<Rgb, byte>();
                bitmap.Lock();

                //Rozdzielenie obrazu kolorowego na 3 kanały i aplikacja filtru dla każdego z nich
                Image<Gray, byte>[] channels = img.Split();
                CvInvoke.MedianBlur(channels[0], channels[0], size);
                CvInvoke.MedianBlur(channels[1], channels[1], size);
                CvInvoke.MedianBlur(channels[2], channels[2], size);

                //Stworzenie ramki o zadanym kolorze. Wielkość ramki wyznacza zmienna borderSize
                CvInvoke.CopyMakeBorder(channels[0], channels[0], borderSize, borderSize, borderSize, borderSize, type, new MCvScalar(i));
                CvInvoke.CopyMakeBorder(channels[1], channels[1], borderSize, borderSize, borderSize, borderSize, type, new MCvScalar(i));
                CvInvoke.CopyMakeBorder(channels[2], channels[2], borderSize, borderSize, borderSize, borderSize, type, new MCvScalar(i));

                //Złączenie kanałów na powrót w całość
                CvInvoke.Merge(new VectorOfMat(channels[0].Mat, channels[1].Mat, channels[2].Mat), img);
                return new FastBitmap(img.Mat.ToBitmap());
            }
            else
            {
                //Odblokowanie obrazu do edycji, stworzenie obiektu do edycji z użyciem metod z biblioteki OpenCV i ponowne zablokowanie pierwotnego obrazu
                bitmap.Unlock();
                var img = bitmap.Bitmap.ToImage<Gray, byte>();
                bitmap.Lock();

                //Aplikacja filtru
                CvInvoke.MedianBlur(img, img, size);

                //Stworzenie ramki o zadanym kolorze. Wielkość ramki wyznacza zmienna borderSize
                CvInvoke.CopyMakeBorder(img, img, borderSize, borderSize, borderSize, borderSize, type, new MCvScalar(i));
                return new FastBitmap(img.Mat.ToBitmap());
            }
        }

        //Metoda wykonująca operację AND na dwóch obrazach
        private static void ANDOperator(FormWithImage form1, FormWithImage form2)
        {
            //Zmienne do przechowywania dwóch obrazów
            FastBitmap bmp1 = form1.FastBitmap;
            FastBitmap bmp2 = form2.FastBitmap;

            //Weryfikacja rozmiarów i zgodności obrazów
            if(form1.IsMono && form2.IsMono && bmp1.Size.Equals(bmp2.Size))
            {
                //Odblokowanie obrazu do edycji, stworzenie obiektu do edycji z użyciem metod z biblioteki OpenCV i ponowne zablokowanie pierwotnego obrazu
                bmp1.Unlock();
                var img1 = bmp1.Bitmap.ToImage<Gray, byte>();
                bmp1.Lock();

                bmp2.Unlock();
                var img2 = bmp2.Bitmap.ToImage<Gray, byte>();
                bmp2.Lock();

                //Operacja AND, gdzie wynik operacji jest zapisywany w pierwszym argumencie operacji - obraz img1
                CvInvoke.BitwiseAnd(img1, img2, img1);
                form1.FastBitmap = new FastBitmap(img1.ToBitmap());
            }
        }

        //Metoda wykonująca operację OR na dwóch obrazach
        private static void OROperator(FormWithImage form1, FormWithImage form2)
        {
            //Zmienne do przechowywania dwóch obrazów
            FastBitmap bmp1 = form1.FastBitmap;
            FastBitmap bmp2 = form2.FastBitmap;

            //Weryfikacja rozmiarów i zgodności obrazów
            if (form1.IsMono && form2.IsMono && bmp1.Size.Equals(bmp2.Size))
            {
                //Odblokowanie obrazu do edycji, stworzenie obiektu do edycji z użyciem metod z biblioteki OpenCV i ponowne zablokowanie pierwotnego obrazu
                bmp1.Unlock();
                var img1 = bmp1.Bitmap.ToImage<Gray, byte>();
                bmp1.Lock();

                bmp2.Unlock();
                var img2 = bmp2.Bitmap.ToImage<Gray, byte>();
                bmp2.Lock();

                //Operacja OR, gdzie wynik operacji jest zapisywany w pierwszym argumencie operacji - obraz img1
                CvInvoke.BitwiseOr(img1, img2, img1);
                form1.FastBitmap = new FastBitmap(img1.ToBitmap());
            } 
        }

        //Metoda wykonująca operację XOR na dwóch obrazach
        private static void XOROperator(FormWithImage form1, FormWithImage form2)
        {
            //Zmienne do przechowywania dwóch obrazów
            FastBitmap bmp1 = form1.FastBitmap;
            FastBitmap bmp2 = form2.FastBitmap;

            //Weryfikacja rozmiarów i zgodności obrazów
            if (form1.IsMono && form2.IsMono && bmp1.Size.Equals(bmp2.Size))
            {
                //Odblokowanie obrazu do edycji, stworzenie obiektu do edycji z użyciem metod z biblioteki OpenCV i ponowne zablokowanie pierwotnego obrazu
                bmp1.Unlock();
                var img1 = bmp1.Bitmap.ToImage<Gray, byte>();
                bmp1.Lock();

                bmp2.Unlock();
                var img2 = bmp2.Bitmap.ToImage<Gray, byte>();
                bmp2.Lock();

                //Operacja XOR, gdzie wynik operacji jest zapisywany w pierwszym argumencie operacji - obraz img1
                CvInvoke.BitwiseXor(img1, img2, img1);
                form1.FastBitmap = new FastBitmap(img1.ToBitmap());
            }
        }

        //Progowanie metodą otsu
        private static void Otsu(FormWithImage form)
        {
            FastBitmap bmp = form.FastBitmap;

            //Odblokowanie obrazu do edycji, stworzenie obiektu do edycji z użyciem metod z biblioteki OpenCV i ponowne zablokowanie pierwotnego obrazu
            bmp.Unlock();
            var img = bmp.Bitmap.ToImage<Gray, byte>();
            bmp.Lock();

            //Wywołanie metody progowania, z podaniem typu progowania otsu
            CvInvoke.Threshold(img, img, 0, 255, ThresholdType.Otsu);

            form.FastBitmap = new FastBitmap(img.ToBitmap());
        }

        //Metoda wododziałowa
        private static void Watershed(FormWithImage form)
        {
            FastBitmap bmp = form.FastBitmap;
            
            //Obraz grey to monohromatyczna wersja podanego obrazu, użyta do wyznaczenia markerów dla metody watershed
            bmp.Unlock();
            var img = bmp.Bitmap.ToImage<Rgb, byte>();  
            var grey = bmp.Bitmap.ToImage<Gray, byte>();  
            bmp.Lock();

            //Zmienne do przechowywania wyników progowania i normalizacji
            Mat thresh = new Mat();
            Mat distance = new Mat();

            //Maska i punkt środkowy
            Point anchor = new Point(-1, -1);
            Mat kernel = CvInvoke.GetStructuringElement(ElementShape.Rectangle, new Size(3, 3), anchor);
            
            //Wyznaczenie markerów
            CvInvoke.Threshold(grey, thresh, 0, 255, ThresholdType.Otsu);
            CvInvoke.BitwiseNot(thresh, thresh);
            CvInvoke.DistanceTransform(thresh, distance, null, DistType.L2, 3);
            CvInvoke.Normalize(distance, distance, 0, 255, NormType.MinMax);
            Mat markers = new Mat();
            CvInvoke.Threshold(distance.ToImage<Gray, byte>(), markers, 178, 255, ThresholdType.Binary);
            CvInvoke.ConnectedComponents(markers, markers);
            var finalMarkers = markers.ToImage<Gray, byte>().Convert<Gray, Int32>();

            //Aplikacja wyznaczonych markerów do oryginalnego obrazu
            CvInvoke.Watershed(img, finalMarkers);

            //Zaznaczenie wykrytych krawędzi
            Image<Gray, byte> boundaries = finalMarkers.Convert<byte>(delegate (Int32 x)
            {
                return (byte)(x == -1 ? 255 : 0);
            });

            img.SetValue(new Rgb(255, 0, 0), boundaries);

            form.FastBitmap = new FastBitmap(img.Mat.ToBitmap());
            form.Resize();
        }

        //Metoda do pobrania odpowiednich danych dla operacji binarnej erode lub dilate
        private static void BinaryOperation(FormWithImage form, Operations op)
        {
            //Wywołanie formularza 
            FormCustomMask formCustomMask = new FormCustomMask();
            if (formCustomMask.ShowDialog() == DialogResult.OK) 
            {
                //pobranie odpowiednich danych i utworzenie zmiennej dla obrazu
                FastBitmap bmp = form.FastBitmap.Clone();
                float[,] kernel = formCustomMask.Values;
                BorderType type = formCustomMask.BorderType;
                int i = formCustomMask.BorderConstant;

                //Konwersja obrazu na monochromatyczny
                bmp.RGBtoGray();

                //Wywołanie odpowiedniej operacji
                if (op.Equals(Operations.Erode))
                    bmp = Erode(bmp, kernel, type, i);
                else
                    bmp = Dilate(bmp, kernel, type, i);

                //Podmiana obrazu i odświeżenie formularza
                form.FastBitmap = bmp;
                form.Resize();
            }
        }

        private static FastBitmap Erode(FastBitmap bmp, float[,] kernel, BorderType type, int color) 
        {
            //Odblokowanie obrazu do edycji, stworzenie obiektu do edycji z użyciem metod z biblioteki OpenCV i ponowne zablokowanie pierwotnego obrazu
            bmp.Unlock();
            var img = bmp.Bitmap.ToImage<Gray, byte>();
            bmp.Lock();

            //Maska i punkt środkowy
            ConvolutionKernelF kernelF = new ConvolutionKernelF(kernel);
            Point anchor = new Point(-1, -1);

            //Aplikacja maski z użyciem metody Erode
            CvInvoke.Erode(img, img, kernelF, anchor, 1, type, new MCvScalar(color));
            return new FastBitmap(img.ToBitmap());
        }

        private static FastBitmap Dilate(FastBitmap bmp, float[,] kernel, BorderType type, int color)
        {
            //Odblokowanie obrazu do edycji, stworzenie obiektu do edycji z użyciem metod z biblioteki OpenCV i ponowne zablokowanie pierwotnego obrazu
            bmp.Unlock();
            var img = bmp.Bitmap.ToImage<Gray, byte>();
            bmp.Lock();

            //Maska i punkt środkowy
            ConvolutionKernelF kernelF = new ConvolutionKernelF(kernel);
            Point anchor = new Point(-1, -1);

            //Aplikacja maski z użyciem metody Dilate
            CvInvoke.Dilate(img, img, kernelF, anchor, 1, type, new MCvScalar(color));
            return new FastBitmap(img.ToBitmap());
        }
    }
}
