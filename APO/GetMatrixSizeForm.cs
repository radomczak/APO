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
    //Formularz do pobrania wielkosci filtru. Zawiera przycisku pozwalająca na regulację wpisanej wartości w polu tekstowym
    public partial class GetMatrixSizeForm : Form
    {
        //Zmienna przechowujaca rozmiar filtru
        int size;

        public GetMatrixSizeForm()
        {
            InitializeComponent();
        }

        public GetMatrixSizeForm(String s)
        {
            InitializeComponent();
            label1.Text = s;
        }

        //Zmniejszenie wartości maski
        private void decrease_Click(object sender, EventArgs e)
        {
            size--;
            textBox1.Text = size.ToString();
        }

        //Zwiększenie wartości maski
        private void increase_Click(object sender, EventArgs e)
        {
            size++;
            textBox1.Text = size.ToString();

        }

        //Po zmianie wartości w polu tekstowym jest ona zapisywana do zmiennej size
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            size = Int32.Parse(textBox1.Text);
        }

        //Getter
        public int GetSize()
        {
            return size;
        }
    }
}
