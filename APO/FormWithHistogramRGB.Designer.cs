
namespace APO
{
    partial class FormWithHistogramRGB
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
            this.histogramPanel = new System.Windows.Forms.Panel();
            this.NOPixelsLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ColorValueLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ButtonR = new System.Windows.Forms.Button();
            this.ButtonG = new System.Windows.Forms.Button();
            this.ButtonB = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // histogramPanel
            // 
            this.histogramPanel.Location = new System.Drawing.Point(10, 40);
            this.histogramPanel.Name = "histogramPanel";
            this.histogramPanel.Size = new System.Drawing.Size(768, 256);
            this.histogramPanel.TabIndex = 0;
            this.histogramPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.histogramPanel_Paint);
            this.histogramPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.histogramPanel_MouseMove);
            // 
            // NOPixelsLabel
            // 
            this.NOPixelsLabel.BackColor = System.Drawing.SystemColors.Info;
            this.NOPixelsLabel.Location = new System.Drawing.Point(230, 306);
            this.NOPixelsLabel.Name = "NOPixelsLabel";
            this.NOPixelsLabel.Size = new System.Drawing.Size(100, 13);
            this.NOPixelsLabel.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(151, 306);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Liczba pikseli:";
            // 
            // ColorValueLabel
            // 
            this.ColorValueLabel.BackColor = System.Drawing.SystemColors.Info;
            this.ColorValueLabel.Location = new System.Drawing.Point(59, 306);
            this.ColorValueLabel.Name = "ColorValueLabel";
            this.ColorValueLabel.Size = new System.Drawing.Size(80, 13);
            this.ColorValueLabel.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 306);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Kolor:";
            // 
            // ButtonR
            // 
            this.ButtonR.Location = new System.Drawing.Point(10, 10);
            this.ButtonR.Name = "ButtonR";
            this.ButtonR.Size = new System.Drawing.Size(75, 20);
            this.ButtonR.TabIndex = 9;
            this.ButtonR.Text = "Red";
            this.ButtonR.UseVisualStyleBackColor = true;
            this.ButtonR.Click += new System.EventHandler(this.ButtonR_Click);
            // 
            // ButtonG
            // 
            this.ButtonG.Location = new System.Drawing.Point(91, 10);
            this.ButtonG.Name = "ButtonG";
            this.ButtonG.Size = new System.Drawing.Size(75, 20);
            this.ButtonG.TabIndex = 10;
            this.ButtonG.Text = "Green";
            this.ButtonG.UseVisualStyleBackColor = true;
            this.ButtonG.Click += new System.EventHandler(this.ButtonG_Click);
            // 
            // ButtonB
            // 
            this.ButtonB.Location = new System.Drawing.Point(172, 10);
            this.ButtonB.Name = "ButtonB";
            this.ButtonB.Size = new System.Drawing.Size(75, 20);
            this.ButtonB.TabIndex = 11;
            this.ButtonB.Text = "Blue";
            this.ButtonB.UseVisualStyleBackColor = true;
            this.ButtonB.Click += new System.EventHandler(this.ButtonB_Click);
            // 
            // FormWithHistogramRGB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(772, 335);
            this.Controls.Add(this.ButtonB);
            this.Controls.Add(this.ButtonG);
            this.Controls.Add(this.ButtonR);
            this.Controls.Add(this.NOPixelsLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ColorValueLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.histogramPanel);
            this.Name = "FormWithHistogramRGB";
            this.Text = "FormWithHistogramRGB";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel histogramPanel;
        private System.Windows.Forms.Label NOPixelsLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label ColorValueLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ButtonR;
        private System.Windows.Forms.Button ButtonG;
        private System.Windows.Forms.Button ButtonB;
    }
}