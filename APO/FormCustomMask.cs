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
        private BorderType borderType;
        private int borderConstant;
        private int matrixSize = 0;
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

        private void generateButton_Click(object sender, EventArgs e)
        {
            if (matrixSize != 0)
            {
                if (generated) {
                    foreach (TextBox b in boxes) {
                        this.Controls.Remove(b);
                        b.Dispose();
                    }
                }
                int heightToAdd = 70;
                int widthToAdd = 15;
                TextBox box;
                boxes = new TextBox[matrixSize * matrixSize];
                
                for (int i = 0; i < matrixSize; i++)
                {
                    for (int j = 0; j < matrixSize; j++)
                    {
                        int x = i * matrixSize + j;
                        box = new TextBox();
                        box.Size = new Size(20, 20);
                        box.Location = new Point(widthToAdd, heightToAdd);

                        Controls.Add(box);
                        boxes[x] = box;

                        widthToAdd += 25;
                    }
                    widthToAdd = 15;
                    heightToAdd += 25;
                }
                generated = true;
            }
        }

        private void matrixSizeBox_TextChanged(object sender, EventArgs e)
        {
            int i = ParseOrZero(matrixSizeBox.Text);
            if (i != 0)
                matrixSize = i;
        }

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
