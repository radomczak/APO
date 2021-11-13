
namespace APO
{
    partial class GetMatrixSizeForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.increase = new System.Windows.Forms.Button();
            this.ok = new System.Windows.Forms.Button();
            this.decrease = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Podaj wielkość filtru (MxM)";
            // 
            // textBox1
            // 
            this.textBox1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.textBox1.Location = new System.Drawing.Point(49, 34);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(35, 20);
            this.textBox1.TabIndex = 1;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // increase
            // 
            this.increase.Location = new System.Drawing.Point(90, 33);
            this.increase.Name = "increase";
            this.increase.Size = new System.Drawing.Size(23, 23);
            this.increase.TabIndex = 2;
            this.increase.Text = "+";
            this.increase.UseVisualStyleBackColor = true;
            this.increase.Click += new System.EventHandler(this.increase_Click);
            // 
            // ok
            // 
            this.ok.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.ok.Location = new System.Drawing.Point(32, 70);
            this.ok.Name = "ok";
            this.ok.Size = new System.Drawing.Size(75, 23);
            this.ok.TabIndex = 3;
            this.ok.Text = "OK";
            this.ok.UseVisualStyleBackColor = true;
            // 
            // decrease
            // 
            this.decrease.Location = new System.Drawing.Point(20, 33);
            this.decrease.Name = "decrease";
            this.decrease.Size = new System.Drawing.Size(23, 23);
            this.decrease.TabIndex = 4;
            this.decrease.Text = "-";
            this.decrease.UseVisualStyleBackColor = true;
            this.decrease.Click += new System.EventHandler(this.decrease_Click);
            // 
            // GetMatrixSizeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(141, 105);
            this.Controls.Add(this.decrease);
            this.Controls.Add(this.ok);
            this.Controls.Add(this.increase);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Name = "GetMatrixSizeForm";
            this.Text = "GetMatrixSizeForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button increase;
        private System.Windows.Forms.Button ok;
        private System.Windows.Forms.Button decrease;
    }
}