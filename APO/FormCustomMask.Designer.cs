
namespace APO
{
    partial class FormCustomMask
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.methodComboBox = new System.Windows.Forms.ComboBox();
            this.OK = new System.Windows.Forms.Button();
            this.matrixSizeBox = new System.Windows.Forms.TextBox();
            this.generateButton = new System.Windows.Forms.Button();
            this.point = new System.Windows.Forms.Label();
            this.pointXBox = new System.Windows.Forms.TextBox();
            this.pointYBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(85, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 90;
            this.label2.Text = "Metoda krawędzi";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 89;
            this.label1.Text = "Rozmiar filtru";
            // 
            // methodComboBox
            // 
            this.methodComboBox.FormattingEnabled = true;
            this.methodComboBox.Items.AddRange(new object[] {
            "Stała",
            "Replikacja",
            "Odbicie",
            "Odbicie 101",
            "Przezroczystość",
            "Izolacja",
            "Standardowa"});
            this.methodComboBox.Location = new System.Drawing.Point(88, 30);
            this.methodComboBox.Name = "methodComboBox";
            this.methodComboBox.Size = new System.Drawing.Size(121, 21);
            this.methodComboBox.TabIndex = 88;
            this.methodComboBox.SelectedIndexChanged += new System.EventHandler(this.methodComboBox_SelectedIndexChanged);
            // 
            // OK
            // 
            this.OK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OK.Location = new System.Drawing.Point(300, 29);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(75, 23);
            this.OK.TabIndex = 87;
            this.OK.Text = "OK";
            this.OK.UseVisualStyleBackColor = true;
            this.OK.Click += new System.EventHandler(this.OK_Click);
            // 
            // matrixSizeBox
            // 
            this.matrixSizeBox.Location = new System.Drawing.Point(15, 31);
            this.matrixSizeBox.Name = "matrixSizeBox";
            this.matrixSizeBox.Size = new System.Drawing.Size(64, 20);
            this.matrixSizeBox.TabIndex = 91;
            this.matrixSizeBox.TextChanged += new System.EventHandler(this.matrixSizeBox_TextChanged);
            // 
            // generateButton
            // 
            this.generateButton.Location = new System.Drawing.Point(216, 29);
            this.generateButton.Name = "generateButton";
            this.generateButton.Size = new System.Drawing.Size(75, 23);
            this.generateButton.TabIndex = 92;
            this.generateButton.Text = "Generuj";
            this.generateButton.UseVisualStyleBackColor = true;
            this.generateButton.Click += new System.EventHandler(this.generateButton_Click);
            // 
            // point
            // 
            this.point.AutoSize = true;
            this.point.Location = new System.Drawing.Point(361, 9);
            this.point.Name = "point";
            this.point.Size = new System.Drawing.Size(103, 13);
            this.point.TabIndex = 93;
            this.point.Text = "Punkt centralny (x,y)";
            // 
            // pointXBox
            // 
            this.pointXBox.Location = new System.Drawing.Point(392, 31);
            this.pointXBox.Name = "pointXBox";
            this.pointXBox.Size = new System.Drawing.Size(20, 20);
            this.pointXBox.TabIndex = 94;
            // 
            // pointYBox
            // 
            this.pointYBox.Location = new System.Drawing.Point(418, 31);
            this.pointYBox.Name = "pointYBox";
            this.pointYBox.Size = new System.Drawing.Size(20, 20);
            this.pointYBox.TabIndex = 95;
            // 
            // FormCustomMask
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(480, 112);
            this.Controls.Add(this.pointYBox);
            this.Controls.Add(this.pointXBox);
            this.Controls.Add(this.point);
            this.Controls.Add(this.generateButton);
            this.Controls.Add(this.matrixSizeBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.methodComboBox);
            this.Controls.Add(this.OK);
            this.Name = "FormCustomMask";
            this.Text = "FormCustomMask";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox methodComboBox;
        private System.Windows.Forms.Button OK;
        private System.Windows.Forms.TextBox matrixSizeBox;
        private System.Windows.Forms.Button generateButton;
        private System.Windows.Forms.Label point;
        private System.Windows.Forms.TextBox pointXBox;
        private System.Windows.Forms.TextBox pointYBox;
    }
}