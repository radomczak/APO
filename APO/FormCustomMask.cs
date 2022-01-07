using Emgu.CV.CvEnum;
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
    public partial class FormCustomMask : Form
    {
        //Zmienne do przechowania maski, metody krawędziowej oraz wygenerowanych kontrolek
        private BorderType borderType;
        private int borderConstant;
        private int matrixSize = 0;
        //Tablica na wygenerowane kontrolki
        private TextBox[] boxes;
        private float[,] values;
        private bool generated = false;

        public BorderType BorderType
        {
            get { return borderType; }
        }

        public int BorderConstant
        {
            get { return borderConstant; }
        }

        public int MatrixSize
        {
            get { return matrixSize; }
        }

        public float[,] Values
        {
            get { return values; }
        }

        public FormCustomMask()
        {
            InitializeComponent();
        }

        //Metoda służąca do wygenerowania określonej liczby kontrolek w kształcie kwadratu (maska) 
        private void generateButton_Click(object sender, EventArgs e)
        {
            if (matrixSize != 0)
            {
                //W przypadku ponownej generacji, obecne kontrolki są usuwane i będą generowane nowe
                if (generated) {
                    foreach (TextBox b in boxes) {
                        this.Controls.Remove(b);
                        b.Dispose();
                    }
                }
                //Wstępma pozycha pierwszej kontrolki
                int heightToAdd = 70;
                int widthToAdd = 15;
                TextBox box;
                //Inicjacja miejsca w tablicy na kontrolki
                boxes = new TextBox[matrixSize * matrixSize];
                
                for (int i = 0; i < matrixSize; i++)
                {
                    for (int j = 0; j < matrixSize; j++)
                    {
                        //Indeks kontrolki
                        int x = i * matrixSize + j;

                        //Stworzenie nowej kontrolki z określonym rozmiarem i w określonym miejscu
                        box = new TextBox();
                        box.Size = new Size(20, 20);
                        box.Location = new Point(widthToAdd, heightToAdd);
                        //Dodanie kontrolki do Formularza i tablicy
                        Controls.Add(box);
                        boxes[x] = box;

                        //Zwiększenie odległości kolejnej kontrolki od krawędzi (Tak by wszystkei były ułozone w wiersz)
                        widthToAdd += 25;
                    }
                    //Przy nowym wierszu, pozycja pozioma jest resetowana a pozycja od góry jest zwiększana
                    widthToAdd = 15;
                    heightToAdd += 25;
                }
                generated = true;
            }
        }

        //Zapisanie pożadanej wielkości filtru
        private void matrixSizeBox_TextChanged(object sender, EventArgs e)
        {
            int i = ParseOrZero(matrixSizeBox.Text);
            if (i != 0)
                matrixSize = i;
        }

        //Wybór metody krawędziowej
        private void methodComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int x = methodComboBox.SelectedIndex;
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

        //Konwersja tekstu na zmienna liczbową typu int
        private int ParseOrZero(string s)
        {
            if (s.Length > 0)
                try
                {
                    return int.Parse(s, System.Globalization.CultureInfo.InvariantCulture);

                }
                catch
                {
                    return 0;
                }
            else return 0;
        }

        //Potwierdzenie, które wstawia dane maski do tablicy by za pomocą gettera mogła być później użyta w programie
        private void OK_Click(object sender, EventArgs e)
        {
            if (generated)
            {
                values = new float[matrixSize, matrixSize];
                for (int i = 0; i < matrixSize; i++)
                {
                    for (int j = 0; j < matrixSize; j++)
                    {
                        int x = i * matrixSize + j;
                        float value = ParseOrZero(boxes[x].Text);
                        values[i, j] = value;
                    }
                }
            }
        }
    }
}
