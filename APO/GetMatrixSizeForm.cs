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
    public partial class GetMatrixSizeForm : Form
    {
        int size;

        public GetMatrixSizeForm()
        {
            InitializeComponent();
        }

        private void decrease_Click(object sender, EventArgs e)
        {
            size--;
            textBox1.Text = size.ToString();
        }

        private void increase_Click(object sender, EventArgs e)
        {
            size++;
            textBox1.Text = size.ToString();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            size = Int32.Parse(textBox1.Text);
        }

        public int GetSize()
        {
            return size;
        }
    }
}
