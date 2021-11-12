
namespace APO
{
    partial class FormWithHistogramGreyscale
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
            this.label1 = new System.Windows.Forms.Label();
            this.ColorValueLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.NOPixelsLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // histogramPanel
            // 
            this.histogramPanel.Location = new System.Drawing.Point(10, 10);
            this.histogramPanel.Name = "histogramPanel";
            this.histogramPanel.Size = new System.Drawing.Size(768, 256);
            this.histogramPanel.TabIndex = 0;
            this.histogramPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.histogramPanel_Paint);
            this.histogramPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.histogramPanel_MouseMove);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 276);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Kolor:";
            // 
            // ColorValueLabel
            // 
            this.ColorValueLabel.BackColor = System.Drawing.SystemColors.Info;
            this.ColorValueLabel.Location = new System.Drawing.Point(51, 276);
            this.ColorValueLabel.Name = "ColorValueLabel";
            this.ColorValueLabel.Size = new System.Drawing.Size(80, 13);
            this.ColorValueLabel.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(143, 276);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Liczba pikseli:";
            // 
            // NOPixelsLabel
            // 
            this.NOPixelsLabel.BackColor = System.Drawing.SystemColors.Info;
            this.NOPixelsLabel.Location = new System.Drawing.Point(222, 276);
            this.NOPixelsLabel.Name = "NOPixelsLabel";
            this.NOPixelsLabel.Size = new System.Drawing.Size(100, 13);
            this.NOPixelsLabel.TabIndex = 4;
            // 
            // FormWithHistogram
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(768, 301);
            this.Controls.Add(this.NOPixelsLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ColorValueLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.histogramPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormWithHistogram";
            this.Text = "FormWithHistogram";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel histogramPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label ColorValueLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label NOPixelsLabel;
    }
}