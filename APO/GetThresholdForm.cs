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
    public partial class GetThresholdForm : Form
    {
        private int[] threshold = new int[2];

        public GetThresholdForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            threshold[0] = Int32.Parse(from.Text);
            threshold[1] = Int32.Parse(to.Text);
        }

        public int[] GetThreshold()
        {
            return threshold;
        }
    }
}
