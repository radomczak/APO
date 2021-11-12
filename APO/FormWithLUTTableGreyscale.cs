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
    public partial class FormWithLUTTableGreyscale : Form
    {
        private int[] table;
        private int size;
        public FormWithLUTTableGreyscale(HistogramGreyscale histogram)
        {
            InitializeComponent();
            this.table = histogram.HistogramTable;
            size = table.Length;

            for (int i = 0; i < size; ++i)
            {
                dataGridView.Columns.Add(i.ToString(), i.ToString());
                dataGridView.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }

            dataGridView.RowHeadersWidth = 90;
            dataGridView.Rows.Add(1);
            dataGridView.Rows[0].HeaderCell.Value = "Ilość pikseli";
            dataGridView.AllowUserToAddRows = false;

            for (int i = 0; i < size; ++i)
            {
                dataGridView.Rows[0].Cells[i].Value = table[i];
            }

            dataGridView.ScrollBars = ScrollBars.Horizontal;
        }
    }
}
