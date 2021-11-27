
namespace APO
{
    partial class PrewittForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.cancelButton = new System.Windows.Forms.Button();
            this.confirmButton = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox122 = new System.Windows.Forms.TextBox();
            this.textBox121 = new System.Windows.Forms.TextBox();
            this.textBox120 = new System.Windows.Forms.TextBox();
            this.textBox112 = new System.Windows.Forms.TextBox();
            this.textBox111 = new System.Windows.Forms.TextBox();
            this.textBox110 = new System.Windows.Forms.TextBox();
            this.textBox102 = new System.Windows.Forms.TextBox();
            this.textBox101 = new System.Windows.Forms.TextBox();
            this.textBox100 = new System.Windows.Forms.TextBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox222 = new System.Windows.Forms.TextBox();
            this.textBox221 = new System.Windows.Forms.TextBox();
            this.textBox220 = new System.Windows.Forms.TextBox();
            this.textBox212 = new System.Windows.Forms.TextBox();
            this.textBox211 = new System.Windows.Forms.TextBox();
            this.textBox210 = new System.Windows.Forms.TextBox();
            this.textBox202 = new System.Windows.Forms.TextBox();
            this.textBox201 = new System.Windows.Forms.TextBox();
            this.textBox200 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(72, 156);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(138, 23);
            this.label3.TabIndex = 35;
            this.label3.Text = "Wybierz Metode krawędzi:";
            // 
            // comboBox3
            // 
            this.comboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Items.AddRange(new object[] {
            "Stała",
            "Replikacja",
            "Odbicie",
            "Odbicie 101",
            "Przezroczystość",
            "Izolacja",
            "Standardowa"});
            this.comboBox3.Location = new System.Drawing.Point(75, 182);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(121, 21);
            this.comboBox3.TabIndex = 34;
            this.comboBox3.SelectedIndexChanged += new System.EventHandler(this.comboBox3_SelectedIndexChanged);
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(140, 222);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 33;
            this.cancelButton.Text = "Anuluj";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // confirmButton
            // 
            this.confirmButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.confirmButton.Location = new System.Drawing.Point(59, 222);
            this.confirmButton.Name = "confirmButton";
            this.confirmButton.Size = new System.Drawing.Size(75, 23);
            this.confirmButton.TabIndex = 32;
            this.confirmButton.Text = "Potwierdź";
            this.confirmButton.UseVisualStyleBackColor = true;
            this.confirmButton.Click += new System.EventHandler(this.confirmButton_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Własna",
            "PrewittE",
            "PrewittSE",
            "PrewittS",
            "PrewittSW",
            "PrewittW",
            "PrewittNW",
            "PrewittN",
            "PrewittNE"});
            this.comboBox1.Location = new System.Drawing.Point(12, 31);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 28;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(25, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 27;
            this.label1.Text = "Wybierz Maskę:";
            // 
            // textBox122
            // 
            this.textBox122.Enabled = false;
            this.textBox122.Location = new System.Drawing.Point(90, 115);
            this.textBox122.Name = "textBox122";
            this.textBox122.Size = new System.Drawing.Size(25, 20);
            this.textBox122.TabIndex = 26;
            // 
            // textBox121
            // 
            this.textBox121.Enabled = false;
            this.textBox121.Location = new System.Drawing.Point(59, 115);
            this.textBox121.Name = "textBox121";
            this.textBox121.Size = new System.Drawing.Size(25, 20);
            this.textBox121.TabIndex = 25;
            // 
            // textBox120
            // 
            this.textBox120.Enabled = false;
            this.textBox120.Location = new System.Drawing.Point(28, 115);
            this.textBox120.Name = "textBox120";
            this.textBox120.Size = new System.Drawing.Size(25, 20);
            this.textBox120.TabIndex = 24;
            // 
            // textBox112
            // 
            this.textBox112.Enabled = false;
            this.textBox112.Location = new System.Drawing.Point(90, 89);
            this.textBox112.Name = "textBox112";
            this.textBox112.Size = new System.Drawing.Size(25, 20);
            this.textBox112.TabIndex = 23;
            // 
            // textBox111
            // 
            this.textBox111.Enabled = false;
            this.textBox111.Location = new System.Drawing.Point(59, 89);
            this.textBox111.Name = "textBox111";
            this.textBox111.Size = new System.Drawing.Size(25, 20);
            this.textBox111.TabIndex = 22;
            // 
            // textBox110
            // 
            this.textBox110.Enabled = false;
            this.textBox110.Location = new System.Drawing.Point(28, 89);
            this.textBox110.Name = "textBox110";
            this.textBox110.Size = new System.Drawing.Size(25, 20);
            this.textBox110.TabIndex = 21;
            // 
            // textBox102
            // 
            this.textBox102.Enabled = false;
            this.textBox102.Location = new System.Drawing.Point(90, 63);
            this.textBox102.Name = "textBox102";
            this.textBox102.Size = new System.Drawing.Size(25, 20);
            this.textBox102.TabIndex = 20;
            // 
            // textBox101
            // 
            this.textBox101.Enabled = false;
            this.textBox101.Location = new System.Drawing.Point(59, 63);
            this.textBox101.Name = "textBox101";
            this.textBox101.Size = new System.Drawing.Size(25, 20);
            this.textBox101.TabIndex = 19;
            // 
            // textBox100
            // 
            this.textBox100.Enabled = false;
            this.textBox100.Location = new System.Drawing.Point(28, 63);
            this.textBox100.Name = "textBox100";
            this.textBox100.Size = new System.Drawing.Size(25, 20);
            this.textBox100.TabIndex = 18;
            // 
            // comboBox2
            // 
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "Własna",
            "PrewittE",
            "PrewittSE",
            "PrewittS",
            "PrewittSW",
            "PrewittW",
            "PrewittNW",
            "PrewittN",
            "PrewittNE"});
            this.comboBox2.Location = new System.Drawing.Point(159, 31);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 21);
            this.comboBox2.TabIndex = 37;
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(169, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.label2.TabIndex = 36;
            this.label2.Text = "Wybierz Maskę:";
            // 
            // textBox222
            // 
            this.textBox222.Enabled = false;
            this.textBox222.Location = new System.Drawing.Point(239, 115);
            this.textBox222.Name = "textBox222";
            this.textBox222.Size = new System.Drawing.Size(25, 20);
            this.textBox222.TabIndex = 46;
            // 
            // textBox221
            // 
            this.textBox221.Enabled = false;
            this.textBox221.Location = new System.Drawing.Point(208, 115);
            this.textBox221.Name = "textBox221";
            this.textBox221.Size = new System.Drawing.Size(25, 20);
            this.textBox221.TabIndex = 45;
            // 
            // textBox220
            // 
            this.textBox220.Enabled = false;
            this.textBox220.Location = new System.Drawing.Point(177, 115);
            this.textBox220.Name = "textBox220";
            this.textBox220.Size = new System.Drawing.Size(25, 20);
            this.textBox220.TabIndex = 44;
            // 
            // textBox212
            // 
            this.textBox212.Enabled = false;
            this.textBox212.Location = new System.Drawing.Point(239, 89);
            this.textBox212.Name = "textBox212";
            this.textBox212.Size = new System.Drawing.Size(25, 20);
            this.textBox212.TabIndex = 43;
            // 
            // textBox211
            // 
            this.textBox211.Enabled = false;
            this.textBox211.Location = new System.Drawing.Point(208, 89);
            this.textBox211.Name = "textBox211";
            this.textBox211.Size = new System.Drawing.Size(25, 20);
            this.textBox211.TabIndex = 42;
            // 
            // textBox210
            // 
            this.textBox210.Enabled = false;
            this.textBox210.Location = new System.Drawing.Point(177, 89);
            this.textBox210.Name = "textBox210";
            this.textBox210.Size = new System.Drawing.Size(25, 20);
            this.textBox210.TabIndex = 41;
            // 
            // textBox202
            // 
            this.textBox202.Enabled = false;
            this.textBox202.Location = new System.Drawing.Point(239, 63);
            this.textBox202.Name = "textBox202";
            this.textBox202.Size = new System.Drawing.Size(25, 20);
            this.textBox202.TabIndex = 40;
            // 
            // textBox201
            // 
            this.textBox201.Enabled = false;
            this.textBox201.Location = new System.Drawing.Point(208, 63);
            this.textBox201.Name = "textBox201";
            this.textBox201.Size = new System.Drawing.Size(25, 20);
            this.textBox201.TabIndex = 39;
            // 
            // textBox200
            // 
            this.textBox200.Enabled = false;
            this.textBox200.Location = new System.Drawing.Point(177, 63);
            this.textBox200.Name = "textBox200";
            this.textBox200.Size = new System.Drawing.Size(25, 20);
            this.textBox200.TabIndex = 38;
            // 
            // PrewittForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(291, 255);
            this.Controls.Add(this.textBox222);
            this.Controls.Add(this.textBox221);
            this.Controls.Add(this.textBox220);
            this.Controls.Add(this.textBox212);
            this.Controls.Add(this.textBox211);
            this.Controls.Add(this.textBox210);
            this.Controls.Add(this.textBox202);
            this.Controls.Add(this.textBox201);
            this.Controls.Add(this.textBox200);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBox3);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.confirmButton);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox122);
            this.Controls.Add(this.textBox121);
            this.Controls.Add(this.textBox120);
            this.Controls.Add(this.textBox112);
            this.Controls.Add(this.textBox111);
            this.Controls.Add(this.textBox110);
            this.Controls.Add(this.textBox102);
            this.Controls.Add(this.textBox101);
            this.Controls.Add(this.textBox100);
            this.Name = "PrewittForm";
            this.Text = "PrewittForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button confirmButton;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox122;
        private System.Windows.Forms.TextBox textBox121;
        private System.Windows.Forms.TextBox textBox120;
        private System.Windows.Forms.TextBox textBox112;
        private System.Windows.Forms.TextBox textBox111;
        private System.Windows.Forms.TextBox textBox110;
        private System.Windows.Forms.TextBox textBox102;
        private System.Windows.Forms.TextBox textBox101;
        private System.Windows.Forms.TextBox textBox100;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox222;
        private System.Windows.Forms.TextBox textBox221;
        private System.Windows.Forms.TextBox textBox220;
        private System.Windows.Forms.TextBox textBox212;
        private System.Windows.Forms.TextBox textBox211;
        private System.Windows.Forms.TextBox textBox210;
        private System.Windows.Forms.TextBox textBox202;
        private System.Windows.Forms.TextBox textBox201;
        private System.Windows.Forms.TextBox textBox200;
    }
}