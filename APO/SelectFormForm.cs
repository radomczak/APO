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
    public partial class SelectFormForm : Form
    {
        FormWithImage form;
        Form[] forms;
        public SelectFormForm(Form[] forms)
        {
            this.forms = forms;
            InitializeComponent();
            foreach(Form f in forms)
            {
                String s = ((FormWithImage)f).Source;
                int i = s.LastIndexOf('\\');
                String source = s.Substring(i+1);
                comboBox1.Items.Add(source);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            form = (FormWithImage)forms[comboBox1.SelectedIndex];
        }

        public FormWithImage Form
        {
            get { return form; }
        }
    }
}
