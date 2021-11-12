
namespace APO
{
    partial class FormWithLUTTableRGB
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.REDButton = new System.Windows.Forms.Button();
            this.GREENButton = new System.Windows.Forms.Button();
            this.BLUEButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(2, 22);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(665, 150);
            this.dataGridView1.TabIndex = 0;
            // 
            // REDButton
            // 
            this.REDButton.Location = new System.Drawing.Point(2, 2);
            this.REDButton.Name = "REDButton";
            this.REDButton.Size = new System.Drawing.Size(75, 20);
            this.REDButton.TabIndex = 1;
            this.REDButton.Text = "RED";
            this.REDButton.UseVisualStyleBackColor = true;
            this.REDButton.Click += new System.EventHandler(this.REDButton_Click);
            // 
            // GREENButton
            // 
            this.GREENButton.Location = new System.Drawing.Point(83, 2);
            this.GREENButton.Name = "GREENButton";
            this.GREENButton.Size = new System.Drawing.Size(75, 20);
            this.GREENButton.TabIndex = 2;
            this.GREENButton.Text = "GREEN";
            this.GREENButton.UseVisualStyleBackColor = true;
            this.GREENButton.Click += new System.EventHandler(this.GREENButton_Click);
            // 
            // BLUEButton
            // 
            this.BLUEButton.Location = new System.Drawing.Point(164, 2);
            this.BLUEButton.Name = "BLUEButton";
            this.BLUEButton.Size = new System.Drawing.Size(75, 20);
            this.BLUEButton.TabIndex = 3;
            this.BLUEButton.Text = "BLUE";
            this.BLUEButton.UseVisualStyleBackColor = true;
            this.BLUEButton.Click += new System.EventHandler(this.BLUEButton_Click);
            // 
            // FormWithLUTTableRGB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(669, 174);
            this.Controls.Add(this.BLUEButton);
            this.Controls.Add(this.GREENButton);
            this.Controls.Add(this.REDButton);
            this.Controls.Add(this.dataGridView1);
            this.Name = "FormWithLUTTableRGB";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button REDButton;
        private System.Windows.Forms.Button GREENButton;
        private System.Windows.Forms.Button BLUEButton;
    }
}