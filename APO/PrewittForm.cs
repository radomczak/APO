using Emgu.CV.CvEnum;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APO
{
    /*
     * Formularz do wybrania metody krawędziowej i maski do operacji detekcji krawędzi. Zawiera:
     * Dwa zestawy pól tekstowych ułozonych w kwadrat do masek
     * Pole comboBox do wyboru metody krawędziowwej
     */
    public partial class PrewittForm : Form
    {
        //Opcje (Maski) możliwe do wybrania. Ostatnia opcja jest określona dla wszelkich innych przypadków poza wybranymi opcjami
        private enum Options
        {
            Custom, Prewitt1, Prewitt2, Prewitt3, Prewitt4, Prewitt5, Prewitt6, Prewitt7, Prewitt8, Undefined
        }
        //Tablice przechowujące maski
        private float[,] mask1;
        private float[,] mask2;
        //Zmienna przechowująca typ metody krawędziowej. Zmienna borderConstant zawiera kolor wybrany w przypadku, gdy metoda krawędziowa jest stała
        private BorderType borderType;
        private int borderConstant;

        //Gettery
        public BorderType BorderType
        {
            get { return borderType; }
        }

        public int BorderConstant
        {
            get { return borderConstant; }
        }
        public float[,] Mask1
        {
            get { return mask1; }
        }
        public float[,] Mask2
        {
            get { return mask2; }
        }

        //Konstruktor, inicjuje tablice dla masek
        public PrewittForm()
        {
            mask1 = new float[3, 3];
            mask2 = new float[3, 3];
            InitializeComponent();
        }

        //Funckje, która zlicza wartości i wprowadza je do tablica, uprzednio konwertując tekst z pól tekstowych na liczbę
        private void Recalculate()
        {
            mask1[0, 0] = ParseOrZero(textBox100.Text);
            mask1[0, 1] = ParseOrZero(textBox101.Text);
            mask1[0, 2] = ParseOrZero(textBox102.Text);
            mask1[1, 0] = ParseOrZero(textBox110.Text);
            mask1[1, 1] = ParseOrZero(textBox111.Text);
            mask1[1, 2] = ParseOrZero(textBox112.Text);
            mask1[2, 0] = ParseOrZero(textBox120.Text);
            mask1[2, 1] = ParseOrZero(textBox121.Text);
            mask1[2, 2] = ParseOrZero(textBox122.Text);

            mask2[0, 0] = ParseOrZero(textBox200.Text);
            mask2[0, 1] = ParseOrZero(textBox201.Text);
            mask2[0, 2] = ParseOrZero(textBox202.Text);
            mask2[1, 0] = ParseOrZero(textBox210.Text);
            mask2[1, 1] = ParseOrZero(textBox211.Text);
            mask2[1, 2] = ParseOrZero(textBox212.Text);
            mask2[2, 0] = ParseOrZero(textBox220.Text);
            mask2[2, 1] = ParseOrZero(textBox221.Text);
            mask2[2, 2] = ParseOrZero(textBox222.Text);
        }

        //Funckja do konwersji tekstu na wartość typu float. W przypadku błędu konwersjii, zwracana jest wartość 0
        private float ParseOrZero(string s)
        {
            if (s.Length > 0)
                try
                {
                    return float.Parse(s, CultureInfo.InvariantCulture);

                }
                catch
                {
                    return 0;
                }
            else return 0;
        }

        //Funckja ustawiająca odpowiednią konfigurację maski dla wybranej opcji.
        //Wybranie opcji powoduję włączenie / wyłączenie odpowiednich pól i wstawienie do nich wartości odpowiedniej dla tej opcji
        //Po ustawieniu maski, następuję przeliczenie ponownie wartości masek w tablicach
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int opt = this.comboBox1.SelectedIndex;
            Options option = getOptionFromIndex(opt);
            switch(option)
            {
                case Options.Custom:
                    textBox100.Enabled = true;
                    textBox101.Enabled = true;
                    textBox102.Enabled = true;
                    textBox110.Enabled = true;
                    textBox111.Enabled = true;
                    textBox112.Enabled = true;
                    textBox120.Enabled = true;
                    textBox121.Enabled = true;
                    textBox122.Enabled = true;
                    break;
                case Options.Prewitt1:
                    disableMatrix1();
                    textBox100.Text = "-1";
                    textBox101.Text = "0";
                    textBox102.Text = "1";
                    textBox110.Text = "-1";
                    textBox111.Text = "0";
                    textBox112.Text = "1";
                    textBox120.Text = "-1";
                    textBox121.Text = "0";
                    textBox122.Text = "1";
                    break;
                case Options.Prewitt2:
                    disableMatrix1();
                    textBox100.Text = "-1";
                    textBox101.Text = "-1";
                    textBox102.Text = "0";
                    textBox110.Text = "-1";
                    textBox111.Text = "0";
                    textBox112.Text = "1";
                    textBox120.Text = "0";
                    textBox121.Text = "1";
                    textBox122.Text = "1";
                    break;
                case Options.Prewitt3:
                    disableMatrix1();
                    textBox100.Text = "-1";
                    textBox101.Text = "-1";
                    textBox102.Text = "-1";
                    textBox110.Text = "0";
                    textBox111.Text = "0";
                    textBox112.Text = "0";
                    textBox120.Text = "1";
                    textBox121.Text = "1";
                    textBox122.Text = "1";
                    break;
                case Options.Prewitt4:
                    disableMatrix1();
                    textBox100.Text = "0";
                    textBox101.Text = "-1";
                    textBox102.Text = "-1";
                    textBox110.Text = "1";
                    textBox111.Text = "0";
                    textBox112.Text = "-1";
                    textBox120.Text = "1";
                    textBox121.Text = "1";
                    textBox122.Text = "0";
                    break;
                case Options.Prewitt5:
                    disableMatrix1();
                    textBox100.Text = "1";
                    textBox101.Text = "0";
                    textBox102.Text = "-1";
                    textBox110.Text = "1";
                    textBox111.Text = "0";
                    textBox112.Text = "-1";
                    textBox120.Text = "1";
                    textBox121.Text = "0";
                    textBox122.Text = "-1";
                    break;
                case Options.Prewitt6:
                    disableMatrix1();
                    textBox100.Text = "1";
                    textBox101.Text = "1";
                    textBox102.Text = "0";
                    textBox110.Text = "1";
                    textBox111.Text = "0";
                    textBox112.Text = "-1";
                    textBox120.Text = "0";
                    textBox121.Text = "-1";
                    textBox122.Text = "-1";
                    break;
                case Options.Prewitt7:
                    disableMatrix1();
                    textBox100.Text = "1";
                    textBox101.Text = "1";
                    textBox102.Text = "1";
                    textBox110.Text = "0";
                    textBox111.Text = "0";
                    textBox112.Text = "0";
                    textBox120.Text = "-1";
                    textBox121.Text = "-1";
                    textBox122.Text = "-1";
                    break;
                case Options.Prewitt8:
                    disableMatrix1();
                    textBox100.Text = "0";
                    textBox101.Text = "1";
                    textBox102.Text = "1";
                    textBox110.Text = "-1";
                    textBox111.Text = "0";
                    textBox112.Text = "1";
                    textBox120.Text = "-1";
                    textBox121.Text = "-1";
                    textBox122.Text = "0";
                    break;
            }
            Recalculate();
        }

        //Jak funkcja powyżej tylko dla drugiej maski.
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int opt = this.comboBox2.SelectedIndex;
            Options option = getOptionFromIndex(opt);
            switch (option)
            {
                case Options.Custom:
                    textBox200.Enabled = true;
                    textBox201.Enabled = true;
                    textBox202.Enabled = true;
                    textBox210.Enabled = true;
                    textBox211.Enabled = true;
                    textBox212.Enabled = true;
                    textBox220.Enabled = true;
                    textBox221.Enabled = true;
                    textBox222.Enabled = true;
                    break;
                case Options.Prewitt1:
                    disableMatrix2();
                    textBox200.Text = "-1";
                    textBox201.Text = "0";
                    textBox202.Text = "1";
                    textBox210.Text = "-1";
                    textBox211.Text = "0";
                    textBox212.Text = "1";
                    textBox220.Text = "-1";
                    textBox221.Text = "0";
                    textBox222.Text = "1";
                    break;
                case Options.Prewitt2:
                    disableMatrix2();
                    textBox200.Text = "-1";
                    textBox201.Text = "-1";
                    textBox202.Text = "0";
                    textBox210.Text = "-1";
                    textBox211.Text = "0";
                    textBox212.Text = "1";
                    textBox220.Text = "0";
                    textBox221.Text = "1";
                    textBox222.Text = "1";
                    break;
                case Options.Prewitt3:
                    disableMatrix2();
                    textBox200.Text = "-1";
                    textBox201.Text = "-1";
                    textBox202.Text = "-1";
                    textBox210.Text = "0";
                    textBox211.Text = "0";
                    textBox212.Text = "0";
                    textBox220.Text = "1";
                    textBox221.Text = "1";
                    textBox222.Text = "1";
                    break;
                case Options.Prewitt4:
                    disableMatrix2();
                    textBox200.Text = "0";
                    textBox201.Text = "-1";
                    textBox202.Text = "-1";
                    textBox210.Text = "1";
                    textBox211.Text = "0";
                    textBox212.Text = "-1";
                    textBox220.Text = "1";
                    textBox221.Text = "1";
                    textBox222.Text = "0";
                    break;
                case Options.Prewitt5:
                    disableMatrix2();
                    textBox200.Text = "1";
                    textBox201.Text = "0";
                    textBox202.Text = "-1";
                    textBox210.Text = "1";
                    textBox211.Text = "0";
                    textBox212.Text = "-1";
                    textBox220.Text = "1";
                    textBox221.Text = "0";
                    textBox222.Text = "-1";
                    break;
                case Options.Prewitt6:
                    disableMatrix2();
                    textBox200.Text = "1";
                    textBox201.Text = "1";
                    textBox202.Text = "0";
                    textBox210.Text = "1";
                    textBox211.Text = "0";
                    textBox212.Text = "-1";
                    textBox220.Text = "0";
                    textBox221.Text = "-1";
                    textBox222.Text = "-1";
                    break;
                case Options.Prewitt7:
                    disableMatrix2();
                    textBox200.Text = "1";
                    textBox201.Text = "1";
                    textBox202.Text = "1";
                    textBox210.Text = "0";
                    textBox211.Text = "0";
                    textBox212.Text = "0";
                    textBox220.Text = "-1";
                    textBox221.Text = "-1";
                    textBox222.Text = "-1";
                    break;
                case Options.Prewitt8:
                    disableMatrix1();
                    textBox100.Text = "0";
                    textBox101.Text = "1";
                    textBox102.Text = "1";
                    textBox110.Text = "-1";
                    textBox111.Text = "0";
                    textBox112.Text = "1";
                    textBox120.Text = "-1";
                    textBox121.Text = "-1";
                    textBox122.Text = "0";
                    break;
            }
            Recalculate();
        }

        //Zmienia wartość zmiennej borderType w zalezności od wybranej metody krawędziowej w formularzu
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            int x = comboBox3.SelectedIndex;
            switch (x)
            {
                case 0:
                    borderType = BorderType.Constant;
                    GetMatrixSizeForm form = new GetMatrixSizeForm("Wartość:");
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        borderConstant = form.GetSize();
                    }
                    break;
                case 1:
                    borderType = BorderType.Replicate;
                    break;
                case 2:
                    borderType = BorderType.Reflect;
                    break;
                case 3:
                    borderType = BorderType.Reflect101;
                    break;
                case 4:
                    borderType = BorderType.Transparent;
                    break;
                case 5:
                    borderType = BorderType.Isolated;
                    break;
                case 6:
                    borderType = BorderType.Default;
                    break;
            }
        }

        //Zwraca opcję z indeksu użytego w kontrolce comboBox w której znajdują się wszystkie dostepne maski do wyboru
        private Options getOptionFromIndex(int option)
        {
            switch (option)
            {
                case 0:
                    return Options.Custom;
                case 1:
                    return Options.Prewitt1;
                case 2:
                    return Options.Prewitt2;
                case 3:
                    return Options.Prewitt3;
                case 4:
                    return Options.Prewitt4;
                case 5:
                    return Options.Prewitt5;
                case 6:
                    return Options.Prewitt6;
                case 7:
                    return Options.Prewitt7;
                case 8:
                    return Options.Prewitt8;
                default:
                    return Options.Undefined;
            }
        }

        //Wyłączenie pól tekstowych(zablokowanie wstawiania danych) dla maski1
        private void disableMatrix1()
        {
            textBox100.Enabled = false;
            textBox101.Enabled = false;
            textBox102.Enabled = false;
            textBox110.Enabled = false;
            textBox111.Enabled = false;
            textBox112.Enabled = false;
            textBox120.Enabled = false;
            textBox121.Enabled = false;
            textBox121.Enabled = false;
            textBox122.Enabled = false;
        }

        //Wyłączenie pól tekstowych(zablokowanie wstawiania danych) dla maski2
        private void disableMatrix2()
        {
            textBox200.Enabled = false;
            textBox201.Enabled = false;
            textBox202.Enabled = false;
            textBox210.Enabled = false;
            textBox211.Enabled = false;
            textBox212.Enabled = false;
            textBox220.Enabled = false;
            textBox221.Enabled = false;
            textBox221.Enabled = false;
            textBox222.Enabled = false;
        }

        //Po zatwierdzeniu, po raz ostatni następuje ponowne przeliczenie wartości masek w tablicach
        private void confirmButton_Click(object sender, EventArgs e)
        {
            Recalculate();
        }
    }
}
