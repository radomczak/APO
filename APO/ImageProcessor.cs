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

namespace APO
{
    class ImageProcessor
    {
        public enum Operations { Stretch, Equalize, Negation, Binarization, Thresholding, Posterize, StretchP1P2, Smooth, Sharpen, DetectEdges, SpecDetectEdges };

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
                case Operations.SpecDetectEdges:
                    SpecDetectEdges(form);
                    break;
            }
        }
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
        private static void Stretch(FormWithImage form)
        {
            FastBitmap bmp = form.FastBitmap;
            if (form.IsMono)
            {
                int[] value = form.HistogramG.HistogramTable;
                int[] LUTvalue = stretchCalculateLUT(value);

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
                int[] red = form.HistogramRGB.HistogramTableR;
                int[] green = form.HistogramRGB.HistogramTableG;
                int[] blue = form.HistogramRGB.HistogramTableB;
                int[] LUTred = stretchCalculateLUT(red);
                int[] LUTgreen = stretchCalculateLUT(green);
                int[] LUTblue = stretchCalculateLUT(blue);

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

        private static void EqualizeHistogram(FormWithImage form)
        {
            FastBitmap bmp = form.FastBitmap;
            int bmpSize = bmp.Size.Height * bmp.Size.Width;
            if (form.IsMono)
            {
                int[] value = form.HistogramG.HistogramTable;
                int[] LUTvalue = equalizeCalculateLUT(value, bmpSize);

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
                int[] red = form.HistogramRGB.HistogramTableR;
                int[] green = form.HistogramRGB.HistogramTableG;
                int[] blue = form.HistogramRGB.HistogramTableB;
                int[] LUTred = equalizeCalculateLUT(red,bmpSize);
                int[] LUTgreen = equalizeCalculateLUT(green, bmpSize);
                int[] LUTblue = equalizeCalculateLUT(blue, bmpSize);

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

        private static void Negation(FormWithImage form)
        {
            FastBitmap bmp = form.FastBitmap;
            for (int i = 0; i < bmp.Size.Width; ++i)
            {
                for (int j = 0; j < bmp.Size.Height; ++j)
                {
                    Color pixel = bmp[i, j];
                    Color newPixel = Color.FromArgb(255 - pixel.R, 255 - pixel.G, 255 - pixel.B);
                    bmp[i, j] = newPixel;
                }
            }
        }

        private static FastBitmap Binarize(FormWithImage form, int value)
        {
            FastBitmap bmp = (FastBitmap)form.FastBitmap.Clone();

            if (form.IsMono)
            {
                for (int i = 0; i < bmp.Size.Width; ++i)
                {
                    for (int j = 0; j < bmp.Size.Height; ++j)
                    {
                        int pixelR = bmp[i, j].R;
                        if (pixelR <= value) pixelR = 0;
                        else pixelR = 255;
                        Color newPixel = Color.FromArgb(pixelR, pixelR, pixelR);
                        bmp[i, j] = newPixel;
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
                        if (v <= value) v = 0;
                        else v = 255;
                        Color newPixel = Color.FromArgb(v, v, v);
                        bmp[i, j] = newPixel;
                    }
                }
            }

            return bmp;
        }

        private static FastBitmap Threshold(FormWithImage form, int from, int to)
        {
            FastBitmap bmp = (FastBitmap)form.FastBitmap.Clone();

            if (form.IsMono)
            {
                for (int i = 0; i < bmp.Size.Width; ++i)
                {
                    for (int j = 0; j < bmp.Size.Height; ++j)
                    {
                        int pixelR = bmp[i, j].R;
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

        private static FastBitmap Posterize(FormWithImage form, int value)
        {
            FastBitmap bmp = (FastBitmap)form.FastBitmap.Clone();

            int[] tab = new int[256];
            float param1 = 255.0f / (value - 1);
            float param2 = 256.0f / (value);
            for (int i = 0; i < 256; ++i)
            {
                tab[i] = (int)((int)(i / param2) * param1);
            }

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

        private static FastBitmap StretchP1P2(FormWithImage form, int from, int to)
        {
            FastBitmap bmp = (FastBitmap)form.FastBitmap.Clone();
            if (form.IsMono)
            {
                int[] value = form.HistogramG.HistogramTable;
                int[] LUTvalue = stretchP1P2CalculateLUT(value, from, to);

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
                int[] red = form.HistogramRGB.HistogramTableR;
                int[] green = form.HistogramRGB.HistogramTableG;
                int[] blue = form.HistogramRGB.HistogramTableB;
                int[] LUTred = stretchP1P2CalculateLUT(red, from, to);
                int[] LUTgreen = stretchP1P2CalculateLUT(green, from, to);
                int[] LUTblue = stretchP1P2CalculateLUT(blue, from, to);

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
            return bmp;
        }


        private static int[] stretchP1P2CalculateLUT(int[] tabLUT, int from, int to)
        {
            int k = 256;
            int[] result = new int[k];
            double a;

            a = 255.0 / (to - from);
            for (int i = 0; i < k; i++)
            {
                if (i < from)
                    result[i] = 0;
                else if(i > to)
                    result[i] = 255;
                else
                    result[i] = (int)(a * (i - from));
            }

            return result;
        }

        private static int[] stretchCalculateLUT(int[] tabLUT)
        {
            int k = 256;
            int min = 0;
            int max = 255;
            int[] result = new int[k];
            double a;

            for (int i = 0; i < k; i++)
            {
                if (tabLUT[i] != 0)
                {
                    min = i;
                    break;
                }
            }
            for (int i = 255; i >= 0; i--)
            {
                if (tabLUT[i] != 0)
                {
                    max = i;
                    break;
                }
            }
           
            a = 255.0 / (max - min);
            for (int i = 0; i < k; i++)
            {
                result[i] = (int)(a * (i - min));
            }

            return result;
        }

        private static int[] equalizeCalculateLUT(int[] tabLUT, int size)
        {
            int k = 256;
            double min = 0;
            int[] result = new int[k];
            double sum = 0;
            for (int i = 0; i < k; i++)
            {
                if (tabLUT[i] != 0)
                {
                    min = tabLUT[i];
                    break;
                }
            }
            
            for (int i = 0; i < k; i++)
            {
                sum += tabLUT[i];
                result[i] = (int)(((sum - min) / (size - min)) * 255.0);
            }

            return result;
        }

        private static void Smooth(FormWithImage form)
        {
            FormMask3x3 formMask = new FormMask3x3(FormMask3x3.Operations.Smooth);
            if (formMask.ShowDialog() == DialogResult.OK)
            {
                applyFilterToForm(formMask, form);
            }
        }

        private static void Sharpen(FormWithImage form)
        {
            FormMask3x3 formMask = new FormMask3x3(FormMask3x3.Operations.Sharpen);
            if (formMask.ShowDialog() == DialogResult.OK)
            {
                applyFilterToForm(formMask, form);
            }
        }

        private static void DetectEdges(FormWithImage form)
        {
            FormMask3x3 formMask = new FormMask3x3(FormMask3x3.Operations.DetectEdges);
            if (formMask.ShowDialog() == DialogResult.OK)
            {
                applyFilterToForm(formMask, form);
            }
        }

        private static void SpecDetectEdges(FormWithImage form)
        {
            FormMask3x3 formMask = new FormMask3x3(FormMask3x3.Operations.SpecDetectEdges);
            if (formMask.ShowDialog() == DialogResult.OK)
            {
                applyFilterToForm(formMask, form);
            }
        }

        private static void applyFilterToForm(FormMask3x3 mask, FormWithImage form)
        {
            FastBitmap bmp = (FastBitmap)form.FastBitmap.Clone();
            float[,] kernel = mask.Mask;
            if (form.IsMono)
                bmp = applyKernelToFastBitmap(kernel, bmp, false);
            else
                bmp = applyKernelToFastBitmap(kernel, bmp, true);
            form.FastBitmap = bmp;
        }

        private static FastBitmap applyKernelToFastBitmap(float[,] kernel, FastBitmap bitmap, Boolean color)
        {
            if(color)
            {
                bitmap.Unlock();
                var img = bitmap.Bitmap.ToImage<Rgb, byte>();
                bitmap.Lock();
                Image<Gray, byte>[] channels = img.Split();
                ConvolutionKernelF kernelF = new ConvolutionKernelF(kernel);
                Point anchor = new Point(-1, -1);
                CvInvoke.Filter2D(channels[0], channels[0], kernelF, anchor);
                CvInvoke.Filter2D(channels[1], channels[1], kernelF, anchor);
                CvInvoke.Filter2D(channels[2], channels[2], kernelF, anchor);
                CvInvoke.Merge(new VectorOfMat(channels[0].Mat, channels[1].Mat, channels[2].Mat), img);
                return new FastBitmap(img.ToBitmap());
            } 
            else
            {
                bitmap.Unlock();
                var img = bitmap.Bitmap.ToImage<Gray, byte>();
                bitmap.Lock();
                ConvolutionKernelF kernelF = new ConvolutionKernelF(kernel);
                Point anchor = new Point(-1, -1);
                CvInvoke.Filter2D(img, img, kernelF, anchor);
                return new FastBitmap(img.ToBitmap());
            }
        }
    }
}
