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
    public partial class FormWithLUTTableRGB : Form
    {
        private int[] tableR;
        private int[] tableG;
        private int[] tableB;
        private int size;
        public FormWithLUTTableRGB(HistogramRGB histogram)
        {
            InitializeComponent();
            this.tableR = histogram.HistogramTableR;
            this.tableG = histogram.HistogramTableG;
            this.tableB = histogram.HistogramTableB;
            size = tableR.Length;

            
            for (int i = 0; i < size; ++i)
            {
                dataGridView1.Columns.Add(i.ToString(), i.ToString());
                dataGridView1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }

            dataGridView1.RowHeadersWidth = 90;
            dataGridView1.Rows.Add(1);
            dataGridView1.Rows[0].HeaderCell.Value = "Ilość pikseli";
            dataGridView1.AllowUserToAddRows = false;

            dataGridView1.ScrollBars = ScrollBars.Horizontal;
        }

        private void REDButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < size; ++i)
            {
                dataGridView1.Rows[0].Cells[i].Value = tableR[i];
            }
        }

        private void GREENButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < size; ++i)
            {
                dataGridView1.Rows[0].Cells[i].Value = tableG[i];
            }
        }

        private void BLUEButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < size; ++i)
            {
                dataGridView1.Rows[0].Cells[i].Value = tableB[i];
            }
        }
    }
}
