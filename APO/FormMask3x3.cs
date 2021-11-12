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
    public partial class FormMask3x3 : Form
    {
        public enum Operations { Smooth, Sharpen, DetectEdges, SpecDetectEdges}
        private enum Options { Custom, Standard, Standard_K, Gauss, Undefined, Laplace1, Laplace2, Laplace3}

        private float[,] mask;
        float divisor;
        Operations operation;
        bool divide = false;

        public float[,] Mask
        {
            get { return mask; }
        }

        public float Divisor
        {
            get { return divisor; }
        }

        public FormMask3x3(Operations operation)
        {
            this.operation = operation;
            mask = new float[3, 3];
            InitializeComponent();
            AddOperationsToSelect();
        }

        private void Recalculate()
        {
            mask[0, 0] = ParseOrZero(textBox00.Text);
            mask[0, 1] = ParseOrZero(textBox01.Text);
            mask[0, 2] = ParseOrZero(textBox02.Text);
            mask[1, 0] = ParseOrZero(textBox10.Text);
            mask[1, 1] = ParseOrZero(textBox11.Text);
            mask[1, 2] = ParseOrZero(textBox12.Text);
            mask[2, 0] = ParseOrZero(textBox20.Text);
            mask[2, 1] = ParseOrZero(textBox21.Text);
            mask[2, 2] = ParseOrZero(textBox22.Text);

            if (!checkBox1.Checked)
                divisor = Math.Max(ParseOrZero(textBoxDiv.Text), 1);
            else
            {
                divisor = 0;
                foreach (float value in mask)
                {
                    divisor += value;
                }
                divisor = Math.Max(divisor, 1);
                textBoxDiv.Text = divisor.ToString();
            }

            if(divide)
            {
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        mask[i, j] /= divisor;
                    }
                }
            }
        }

        private float ParseOrZero(string s)
        {
            if(s.Length > 0 )
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

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == false)
                textBoxDiv.Enabled = true;
            else
                textBoxDiv.Enabled = false;
            Recalculate();
        }

        private void confirmButton_Click(object sender, EventArgs e)
        {
               Recalculate();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int optionInt = this.comboBox1.SelectedIndex;
            Options option = getOptionFromString(optionInt);

            switch (option)
            {
                case Options.Custom:
                    textBox00.Enabled = true;
                    textBox01.Enabled = true;
                    textBox02.Enabled = true;
                    textBox10.Enabled = true;
                    textBox11.Enabled = true;
                    textBox12.Enabled = true;
                    textBox20.Enabled = true;
                    textBox21.Enabled = true;
                    textBox22.Enabled = true;
                    checkBox1.Enabled = true;
                    break;
                case Options.Standard:
                    disableMatrix();
                    textBox00.Text = "1";
                    textBox01.Text = "1";
                    textBox02.Text = "1";
                    textBox10.Text = "1";
                    textBox11.Text = "1";
                    textBox12.Text = "1";
                    textBox20.Text = "1";
                    textBox21.Text = "1";
                    textBox22.Text = "1";
                    break;
                case Options.Standard_K:
                    disableMatrix();
                    textBox00.Text = "1";
                    textBox01.Text = "1";
                    textBox02.Text = "1";
                    textBox10.Text = "1";
                    textBox11.Enabled = true;
                    textBox12.Text = "1";
                    textBox20.Text = "1";
                    textBox21.Text = "1";
                    textBox22.Text = "1";
                    break;
                case Options.Gauss:
                    disableMatrix();
                    textBox00.Text = "1";
                    textBox01.Text = "2";
                    textBox02.Text = "1";
                    textBox10.Text = "2";
                    textBox11.Text = "4";
                    textBox12.Text = "2";
                    textBox20.Text = "1";
                    textBox21.Text = "2";
                    textBox22.Text = "1";
                    break;
            }
            Recalculate();
        }

        private Options getOptionFromString(int option)
        {
            switch (option)
            {
                case 0:
                    return Options.Custom;
                case 1:
                    return Options.Standard;
                case 2:
                    return Options.Standard_K;
                case 3:
                    return Options.Gauss;
                default:
                    return Options.Undefined;
            }
        }

        private void AddOperationsToSelect()
        {
            switch (operation)
            {
                case Operations.Smooth:
                    comboBox1.Items.Add("Własna");
                    comboBox1.Items.Add("Uśrednianie");
                    comboBox1.Items.Add("Uśrednianie K");
                    comboBox1.Items.Add("Gauss podst");
                    divide = true;
                    break;
                case Operations.Sharpen:
                    comboBox1.Items.Add("Własna");
                    comboBox1.Items.Add("Lapsjan1");
                    comboBox1.Items.Add("Lapsjan2");
                    comboBox1.Items.Add("Lapsjan3");
                    break;
            }
        }

        private void maskInputChanged(object sender, EventArgs e)
        {
            Recalculate();
        }

        private void disableMatrix()
        {
            textBox00.Enabled = false;
            textBox01.Enabled = false;
            textBox02.Enabled = false;
            textBox10.Enabled = false;
            textBox11.Enabled = false;
            textBox12.Enabled = false;
            textBox20.Enabled = false;
            textBox21.Enabled = false;
            textBox21.Enabled = false;
            textBox22.Enabled = false;
        }
    }
}
