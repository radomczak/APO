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
    /* Formularz do wybrania obrazu z pośród dzieci formularza głównego. 
     * Otrzymuje w konstruktorze wszystkie formularze (obrazy) od głównego widoku, po czym wstawia ich nazwy do kontrolki typu comboBox (select).
     * Uzytkownik następnie wybiera obraz (formularz), który zostaje przypisany do zmiennej form.
     * W późnieszych etapach obraz jest zwracany używając gettera dla pola form.
     */


    public partial class SelectFormForm : Form
    {
        FormWithImage form; //Zmienna do zapisania obrazu wybranego przez użytkownika
        Form[] forms; //Tablica obrazów przyjęta w konstruktorze
        public SelectFormForm(Form[] forms)
        {
            this.forms = forms;
            InitializeComponent();
            foreach(Form f in forms)    //Pętla, która pobiera nazwy od wszystkich przekazanych obrazów, po czym wstawia je do pola comboBox1
            {
                String s = ((FormWithImage)f).Source;
                int i = s.LastIndexOf('\\');
                String source = s.Substring(i+1);
                comboBox1.Items.Add(source);
            }
        }
        //Po kliknięciu przycisku potwierdzającego, wybrany obraz jest przypisywany do zmiennej
        private void button1_Click(object sender, EventArgs e)
        {
            form = (FormWithImage)forms[comboBox1.SelectedIndex];
        }

        //Getter dla wybranego obrazu
        public FormWithImage Form
        {
            get { return form; }
        }
    }
}
