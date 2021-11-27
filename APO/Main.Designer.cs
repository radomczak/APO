
namespace APO
{
    partial class Main
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.plikToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.otwórzToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zamknijToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zamknijWszystkieToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zapiszToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zapiszJakoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wyjścieToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zbadajToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.histogramToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rGBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.monoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LUTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rGBToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.greyscaleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.operacjeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.histogramToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.stretchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wyrównanieToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.jednopunktoweToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.negacjaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.progrowanieBinarneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.progToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redukcjaPoziomówSzarościToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rozciąganieHistogramuZZakresemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.filtryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wygładzanieToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wyostrzanieToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.detekcjaKrawędziToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.specjalnaDetekacjaKrawędziToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.specjalnaDetekacjaKrawędziCannyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.medianowyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.punktoweDwuargumentoweToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aNDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.oRToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xORToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.obrazToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.duplikujToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.infoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.otsuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.plikToolStripMenuItem,
            this.zbadajToolStripMenuItem,
            this.operacjeToolStripMenuItem,
            this.obrazToolStripMenuItem,
            this.infoToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // plikToolStripMenuItem
            // 
            this.plikToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.otwórzToolStripMenuItem,
            this.zamknijToolStripMenuItem,
            this.zamknijWszystkieToolStripMenuItem,
            this.zapiszToolStripMenuItem,
            this.zapiszJakoToolStripMenuItem,
            this.wyjścieToolStripMenuItem});
            this.plikToolStripMenuItem.Name = "plikToolStripMenuItem";
            this.plikToolStripMenuItem.Size = new System.Drawing.Size(38, 20);
            this.plikToolStripMenuItem.Text = "Plik";
            // 
            // otwórzToolStripMenuItem
            // 
            this.otwórzToolStripMenuItem.Name = "otwórzToolStripMenuItem";
            this.otwórzToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.otwórzToolStripMenuItem.Text = "Otwórz";
            this.otwórzToolStripMenuItem.Click += new System.EventHandler(this.otwórzToolStripMenuItem_Click);
            // 
            // zamknijToolStripMenuItem
            // 
            this.zamknijToolStripMenuItem.Enabled = false;
            this.zamknijToolStripMenuItem.Name = "zamknijToolStripMenuItem";
            this.zamknijToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.zamknijToolStripMenuItem.Text = "Zamknij";
            this.zamknijToolStripMenuItem.Click += new System.EventHandler(this.zamknijToolStripMenuItem_Click);
            // 
            // zamknijWszystkieToolStripMenuItem
            // 
            this.zamknijWszystkieToolStripMenuItem.Enabled = false;
            this.zamknijWszystkieToolStripMenuItem.Name = "zamknijWszystkieToolStripMenuItem";
            this.zamknijWszystkieToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.zamknijWszystkieToolStripMenuItem.Text = "Zamknij wszystkie";
            this.zamknijWszystkieToolStripMenuItem.Click += new System.EventHandler(this.zamknijWszystkieToolStripMenuItem_Click);
            // 
            // zapiszToolStripMenuItem
            // 
            this.zapiszToolStripMenuItem.Enabled = false;
            this.zapiszToolStripMenuItem.Name = "zapiszToolStripMenuItem";
            this.zapiszToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.zapiszToolStripMenuItem.Text = "Zapisz";
            this.zapiszToolStripMenuItem.Click += new System.EventHandler(this.zapiszToolStripMenuItem_Click);
            // 
            // zapiszJakoToolStripMenuItem
            // 
            this.zapiszJakoToolStripMenuItem.Enabled = false;
            this.zapiszJakoToolStripMenuItem.Name = "zapiszJakoToolStripMenuItem";
            this.zapiszJakoToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.zapiszJakoToolStripMenuItem.Text = "Zapisz jako";
            this.zapiszJakoToolStripMenuItem.Click += new System.EventHandler(this.zapiszJakoToolStripMenuItem_Click);
            // 
            // wyjścieToolStripMenuItem
            // 
            this.wyjścieToolStripMenuItem.Name = "wyjścieToolStripMenuItem";
            this.wyjścieToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.wyjścieToolStripMenuItem.Text = "Wyjście";
            this.wyjścieToolStripMenuItem.Click += new System.EventHandler(this.wyjścieToolStripMenuItem_Click);
            // 
            // zbadajToolStripMenuItem
            // 
            this.zbadajToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.histogramToolStripMenuItem,
            this.LUTToolStripMenuItem});
            this.zbadajToolStripMenuItem.Enabled = false;
            this.zbadajToolStripMenuItem.Name = "zbadajToolStripMenuItem";
            this.zbadajToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.zbadajToolStripMenuItem.Text = "Zbadaj";
            // 
            // histogramToolStripMenuItem
            // 
            this.histogramToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rGBToolStripMenuItem,
            this.monoToolStripMenuItem});
            this.histogramToolStripMenuItem.Enabled = false;
            this.histogramToolStripMenuItem.Name = "histogramToolStripMenuItem";
            this.histogramToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.histogramToolStripMenuItem.Text = "Histogram";
            // 
            // rGBToolStripMenuItem
            // 
            this.rGBToolStripMenuItem.Enabled = false;
            this.rGBToolStripMenuItem.Name = "rGBToolStripMenuItem";
            this.rGBToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.rGBToolStripMenuItem.Text = "RGB";
            this.rGBToolStripMenuItem.Click += new System.EventHandler(this.rGBToolStripMenuItem_Click);
            // 
            // monoToolStripMenuItem
            // 
            this.monoToolStripMenuItem.Enabled = false;
            this.monoToolStripMenuItem.Name = "monoToolStripMenuItem";
            this.monoToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.monoToolStripMenuItem.Text = "MONO";
            this.monoToolStripMenuItem.Click += new System.EventHandler(this.monoToolStripMenuItem_Click);
            // 
            // LUTToolStripMenuItem
            // 
            this.LUTToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rGBToolStripMenuItem1,
            this.greyscaleToolStripMenuItem});
            this.LUTToolStripMenuItem.Enabled = false;
            this.LUTToolStripMenuItem.Name = "LUTToolStripMenuItem";
            this.LUTToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.LUTToolStripMenuItem.Text = "LUT";
            // 
            // rGBToolStripMenuItem1
            // 
            this.rGBToolStripMenuItem1.Enabled = false;
            this.rGBToolStripMenuItem1.Name = "rGBToolStripMenuItem1";
            this.rGBToolStripMenuItem1.Size = new System.Drawing.Size(124, 22);
            this.rGBToolStripMenuItem1.Text = "RGB";
            this.rGBToolStripMenuItem1.Click += new System.EventHandler(this.rGBToolStripMenuItem1_Click);
            // 
            // greyscaleToolStripMenuItem
            // 
            this.greyscaleToolStripMenuItem.Enabled = false;
            this.greyscaleToolStripMenuItem.Name = "greyscaleToolStripMenuItem";
            this.greyscaleToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.greyscaleToolStripMenuItem.Text = "Greyscale";
            this.greyscaleToolStripMenuItem.Click += new System.EventHandler(this.greyscaleToolStripMenuItem_Click);
            // 
            // operacjeToolStripMenuItem
            // 
            this.operacjeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.histogramToolStripMenuItem1,
            this.jednopunktoweToolStripMenuItem,
            this.filtryToolStripMenuItem,
            this.punktoweDwuargumentoweToolStripMenuItem,
            this.otsuToolStripMenuItem});
            this.operacjeToolStripMenuItem.Enabled = false;
            this.operacjeToolStripMenuItem.Name = "operacjeToolStripMenuItem";
            this.operacjeToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.operacjeToolStripMenuItem.Text = "Operacje";
            // 
            // histogramToolStripMenuItem1
            // 
            this.histogramToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stretchToolStripMenuItem,
            this.wyrównanieToolStripMenuItem});
            this.histogramToolStripMenuItem1.Enabled = false;
            this.histogramToolStripMenuItem1.Name = "histogramToolStripMenuItem1";
            this.histogramToolStripMenuItem1.Size = new System.Drawing.Size(235, 22);
            this.histogramToolStripMenuItem1.Text = "Histogram";
            // 
            // stretchToolStripMenuItem
            // 
            this.stretchToolStripMenuItem.Enabled = false;
            this.stretchToolStripMenuItem.Name = "stretchToolStripMenuItem";
            this.stretchToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.stretchToolStripMenuItem.Text = "Rozciąganie";
            this.stretchToolStripMenuItem.Click += new System.EventHandler(this.rozciąganieToolStripMenuItem_Click);
            // 
            // wyrównanieToolStripMenuItem
            // 
            this.wyrównanieToolStripMenuItem.Enabled = false;
            this.wyrównanieToolStripMenuItem.Name = "wyrównanieToolStripMenuItem";
            this.wyrównanieToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.wyrównanieToolStripMenuItem.Text = "Wyrównanie";
            this.wyrównanieToolStripMenuItem.Click += new System.EventHandler(this.wyrównanieToolStripMenuItem_Click);
            // 
            // jednopunktoweToolStripMenuItem
            // 
            this.jednopunktoweToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.negacjaToolStripMenuItem,
            this.progrowanieBinarneToolStripMenuItem,
            this.progToolStripMenuItem,
            this.redukcjaPoziomówSzarościToolStripMenuItem,
            this.rozciąganieHistogramuZZakresemToolStripMenuItem});
            this.jednopunktoweToolStripMenuItem.Enabled = false;
            this.jednopunktoweToolStripMenuItem.Name = "jednopunktoweToolStripMenuItem";
            this.jednopunktoweToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            this.jednopunktoweToolStripMenuItem.Text = "Punktowe Jednoargumentowe";
            // 
            // negacjaToolStripMenuItem
            // 
            this.negacjaToolStripMenuItem.Name = "negacjaToolStripMenuItem";
            this.negacjaToolStripMenuItem.Size = new System.Drawing.Size(265, 22);
            this.negacjaToolStripMenuItem.Text = "Negacja";
            this.negacjaToolStripMenuItem.Click += new System.EventHandler(this.negacjaToolStripMenuItem_Click);
            // 
            // progrowanieBinarneToolStripMenuItem
            // 
            this.progrowanieBinarneToolStripMenuItem.Name = "progrowanieBinarneToolStripMenuItem";
            this.progrowanieBinarneToolStripMenuItem.Size = new System.Drawing.Size(265, 22);
            this.progrowanieBinarneToolStripMenuItem.Text = "Progowanie binarne";
            this.progrowanieBinarneToolStripMenuItem.Click += new System.EventHandler(this.progrowanieBinarneToolStripMenuItem_Click);
            // 
            // progToolStripMenuItem
            // 
            this.progToolStripMenuItem.Name = "progToolStripMenuItem";
            this.progToolStripMenuItem.Size = new System.Drawing.Size(265, 22);
            this.progToolStripMenuItem.Text = "Progowanie z zachowaniem szarości";
            this.progToolStripMenuItem.Click += new System.EventHandler(this.progToolStripMenuItem_Click);
            // 
            // redukcjaPoziomówSzarościToolStripMenuItem
            // 
            this.redukcjaPoziomówSzarościToolStripMenuItem.Name = "redukcjaPoziomówSzarościToolStripMenuItem";
            this.redukcjaPoziomówSzarościToolStripMenuItem.Size = new System.Drawing.Size(265, 22);
            this.redukcjaPoziomówSzarościToolStripMenuItem.Text = "Redukcja poziomów szarości";
            this.redukcjaPoziomówSzarościToolStripMenuItem.Click += new System.EventHandler(this.redukcjaPoziomówSzarościToolStripMenuItem_Click);
            // 
            // rozciąganieHistogramuZZakresemToolStripMenuItem
            // 
            this.rozciąganieHistogramuZZakresemToolStripMenuItem.Name = "rozciąganieHistogramuZZakresemToolStripMenuItem";
            this.rozciąganieHistogramuZZakresemToolStripMenuItem.Size = new System.Drawing.Size(265, 22);
            this.rozciąganieHistogramuZZakresemToolStripMenuItem.Text = "Rozciąganie histogramu z zakresem";
            this.rozciąganieHistogramuZZakresemToolStripMenuItem.Click += new System.EventHandler(this.ąganieHistogramuZZakresemToolStripMenuItem_Click);
            // 
            // filtryToolStripMenuItem
            // 
            this.filtryToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.wygładzanieToolStripMenuItem,
            this.wyostrzanieToolStripMenuItem,
            this.detekcjaKrawędziToolStripMenuItem,
            this.specjalnaDetekacjaKrawędziToolStripMenuItem,
            this.specjalnaDetekacjaKrawędziCannyToolStripMenuItem,
            this.medianowyToolStripMenuItem});
            this.filtryToolStripMenuItem.Enabled = false;
            this.filtryToolStripMenuItem.Name = "filtryToolStripMenuItem";
            this.filtryToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            this.filtryToolStripMenuItem.Text = "Filtry";
            // 
            // wygładzanieToolStripMenuItem
            // 
            this.wygładzanieToolStripMenuItem.Enabled = false;
            this.wygładzanieToolStripMenuItem.Name = "wygładzanieToolStripMenuItem";
            this.wygładzanieToolStripMenuItem.Size = new System.Drawing.Size(274, 22);
            this.wygładzanieToolStripMenuItem.Text = "Wygładzanie";
            this.wygładzanieToolStripMenuItem.Click += new System.EventHandler(this.wygładzanieToolStripMenuItem_Click);
            // 
            // wyostrzanieToolStripMenuItem
            // 
            this.wyostrzanieToolStripMenuItem.Enabled = false;
            this.wyostrzanieToolStripMenuItem.Name = "wyostrzanieToolStripMenuItem";
            this.wyostrzanieToolStripMenuItem.Size = new System.Drawing.Size(274, 22);
            this.wyostrzanieToolStripMenuItem.Text = "Wyostrzanie";
            this.wyostrzanieToolStripMenuItem.Click += new System.EventHandler(this.wyostrzanieToolStripMenuItem_Click);
            // 
            // detekcjaKrawędziToolStripMenuItem
            // 
            this.detekcjaKrawędziToolStripMenuItem.Enabled = false;
            this.detekcjaKrawędziToolStripMenuItem.Name = "detekcjaKrawędziToolStripMenuItem";
            this.detekcjaKrawędziToolStripMenuItem.Size = new System.Drawing.Size(274, 22);
            this.detekcjaKrawędziToolStripMenuItem.Text = "Kierunkowa detekcja krawędzi";
            this.detekcjaKrawędziToolStripMenuItem.Click += new System.EventHandler(this.detekcjaKrawędziToolStripMenuItem_Click);
            // 
            // specjalnaDetekacjaKrawędziToolStripMenuItem
            // 
            this.specjalnaDetekacjaKrawędziToolStripMenuItem.Enabled = false;
            this.specjalnaDetekacjaKrawędziToolStripMenuItem.Name = "specjalnaDetekacjaKrawędziToolStripMenuItem";
            this.specjalnaDetekacjaKrawędziToolStripMenuItem.Size = new System.Drawing.Size(274, 22);
            this.specjalnaDetekacjaKrawędziToolStripMenuItem.Text = "Specjalna detekacja krawędzi (Prewitt)";
            this.specjalnaDetekacjaKrawędziToolStripMenuItem.Click += new System.EventHandler(this.specjalnaDetekacjaKrawędziToolStripMenuItem_Click);
            // 
            // specjalnaDetekacjaKrawędziCannyToolStripMenuItem
            // 
            this.specjalnaDetekacjaKrawędziCannyToolStripMenuItem.Enabled = false;
            this.specjalnaDetekacjaKrawędziCannyToolStripMenuItem.Name = "specjalnaDetekacjaKrawędziCannyToolStripMenuItem";
            this.specjalnaDetekacjaKrawędziCannyToolStripMenuItem.Size = new System.Drawing.Size(274, 22);
            this.specjalnaDetekacjaKrawędziCannyToolStripMenuItem.Text = "Specjalna detekacja krawędzi (Canny)";
            this.specjalnaDetekacjaKrawędziCannyToolStripMenuItem.Click += new System.EventHandler(this.specjalnaDetekacjaKrawędziCannyToolStripMenuItem_Click);
            // 
            // medianowyToolStripMenuItem
            // 
            this.medianowyToolStripMenuItem.Enabled = false;
            this.medianowyToolStripMenuItem.Name = "medianowyToolStripMenuItem";
            this.medianowyToolStripMenuItem.Size = new System.Drawing.Size(274, 22);
            this.medianowyToolStripMenuItem.Text = "Medianowy";
            this.medianowyToolStripMenuItem.Click += new System.EventHandler(this.medianowyToolStripMenuItem_Click);
            // 
            // punktoweDwuargumentoweToolStripMenuItem
            // 
            this.punktoweDwuargumentoweToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aNDToolStripMenuItem,
            this.oRToolStripMenuItem,
            this.xORToolStripMenuItem});
            this.punktoweDwuargumentoweToolStripMenuItem.Enabled = false;
            this.punktoweDwuargumentoweToolStripMenuItem.Name = "punktoweDwuargumentoweToolStripMenuItem";
            this.punktoweDwuargumentoweToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            this.punktoweDwuargumentoweToolStripMenuItem.Text = "Punktowe Dwuargumentowe";
            // 
            // aNDToolStripMenuItem
            // 
            this.aNDToolStripMenuItem.Enabled = false;
            this.aNDToolStripMenuItem.Name = "aNDToolStripMenuItem";
            this.aNDToolStripMenuItem.Size = new System.Drawing.Size(99, 22);
            this.aNDToolStripMenuItem.Text = "AND";
            this.aNDToolStripMenuItem.Click += new System.EventHandler(this.aNDToolStripMenuItem_Click);
            // 
            // oRToolStripMenuItem
            // 
            this.oRToolStripMenuItem.Enabled = false;
            this.oRToolStripMenuItem.Name = "oRToolStripMenuItem";
            this.oRToolStripMenuItem.Size = new System.Drawing.Size(99, 22);
            this.oRToolStripMenuItem.Text = "OR";
            this.oRToolStripMenuItem.Click += new System.EventHandler(this.oRToolStripMenuItem_Click);
            // 
            // xORToolStripMenuItem
            // 
            this.xORToolStripMenuItem.Enabled = false;
            this.xORToolStripMenuItem.Name = "xORToolStripMenuItem";
            this.xORToolStripMenuItem.Size = new System.Drawing.Size(99, 22);
            this.xORToolStripMenuItem.Text = "XOR";
            this.xORToolStripMenuItem.Click += new System.EventHandler(this.xORToolStripMenuItem_Click);
            // 
            // obrazToolStripMenuItem
            // 
            this.obrazToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.duplikujToolStripMenuItem});
            this.obrazToolStripMenuItem.Enabled = false;
            this.obrazToolStripMenuItem.Name = "obrazToolStripMenuItem";
            this.obrazToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.obrazToolStripMenuItem.Text = "Obraz";
            // 
            // duplikujToolStripMenuItem
            // 
            this.duplikujToolStripMenuItem.Enabled = false;
            this.duplikujToolStripMenuItem.Name = "duplikujToolStripMenuItem";
            this.duplikujToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.duplikujToolStripMenuItem.Text = "Duplikuj";
            this.duplikujToolStripMenuItem.Click += new System.EventHandler(this.duplikujToolStripMenuItem_Click);
            // 
            // infoToolStripMenuItem
            // 
            this.infoToolStripMenuItem.Name = "infoToolStripMenuItem";
            this.infoToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.infoToolStripMenuItem.Text = "Info";
            this.infoToolStripMenuItem.Click += new System.EventHandler(this.infoToolStripMenuItem_Click);
            // 
            // otsuToolStripMenuItem
            // 
            this.otsuToolStripMenuItem.Enabled = false;
            this.otsuToolStripMenuItem.Name = "otsuToolStripMenuItem";
            this.otsuToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            this.otsuToolStripMenuItem.Text = "Otsu";
            this.otsuToolStripMenuItem.Click += new System.EventHandler(this.otsuToolStripMenuItem_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 508);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Main";
            this.Text = "Aplikacja APO";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem plikToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem otwórzToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zamknijToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zamknijWszystkieToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zapiszToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zapiszJakoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem wyjścieToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zbadajToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem operacjeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem obrazToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem histogramToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rGBToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem monoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem duplikujToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem infoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem LUTToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rGBToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem greyscaleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem histogramToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem stretchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem wyrównanieToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem jednopunktoweToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem negacjaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem progrowanieBinarneToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem progToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redukcjaPoziomówSzarościToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rozciąganieHistogramuZZakresemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem filtryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem wygładzanieToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem wyostrzanieToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem detekcjaKrawędziToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem specjalnaDetekacjaKrawędziToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem specjalnaDetekacjaKrawędziCannyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem medianowyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem punktoweDwuargumentoweToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aNDToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem oRToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xORToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem otsuToolStripMenuItem;
    }
}

