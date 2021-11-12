
namespace APO
{
    partial class PreviewWithSlider
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.fromTrackBar = new System.Windows.Forms.TrackBar();
            this.fromLabel = new System.Windows.Forms.Label();
            this.toLabel = new System.Windows.Forms.Label();
            this.toTrackBar = new System.Windows.Forms.TrackBar();
            this.trackBar2 = new System.Windows.Forms.TrackBar();
            this.label2 = new System.Windows.Forms.Label();
            this.decreaseButton = new System.Windows.Forms.Button();
            this.increaseButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fromTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.toTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Location = new System.Drawing.Point(12, 12);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panel2);
            this.splitContainer1.Size = new System.Drawing.Size(760, 350);
            this.splitContainer1.SplitterDistance = 380;
            this.splitContainer1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(15, 15);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(347, 319);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(15, 15);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(344, 319);
            this.panel2.TabIndex = 0;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(96, 369);
            this.trackBar1.Maximum = 255;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(543, 45);
            this.trackBar1.TabIndex = 1;
            this.trackBar1.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar1.Visible = false;
            this.trackBar1.ValueChanged += new System.EventHandler(this.trackBar1_ValueChanged);
            this.trackBar1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.trackBar1_MouseUp);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(645, 372);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 14);
            this.label1.TabIndex = 2;
            this.label1.Text = "0";
            this.label1.Visible = false;
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Location = new System.Drawing.Point(245, 419);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Location = new System.Drawing.Point(461, 419);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "Anuluj";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // fromTrackBar
            // 
            this.fromTrackBar.Location = new System.Drawing.Point(27, 368);
            this.fromTrackBar.Maximum = 255;
            this.fromTrackBar.Name = "fromTrackBar";
            this.fromTrackBar.Size = new System.Drawing.Size(305, 45);
            this.fromTrackBar.TabIndex = 5;
            this.fromTrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.fromTrackBar.Visible = false;
            this.fromTrackBar.ValueChanged += new System.EventHandler(this.fromTrackBar_ValueChanged);
            this.fromTrackBar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.fromTrackBar_MouseUp);
            // 
            // fromLabel
            // 
            this.fromLabel.Location = new System.Drawing.Point(338, 372);
            this.fromLabel.Name = "fromLabel";
            this.fromLabel.Size = new System.Drawing.Size(25, 14);
            this.fromLabel.TabIndex = 6;
            this.fromLabel.Text = "0";
            this.fromLabel.Visible = false;
            // 
            // toLabel
            // 
            this.toLabel.Location = new System.Drawing.Point(720, 372);
            this.toLabel.Name = "toLabel";
            this.toLabel.Size = new System.Drawing.Size(25, 14);
            this.toLabel.TabIndex = 8;
            this.toLabel.Text = "0";
            this.toLabel.Visible = false;
            // 
            // toTrackBar
            // 
            this.toTrackBar.Location = new System.Drawing.Point(409, 368);
            this.toTrackBar.Maximum = 255;
            this.toTrackBar.Name = "toTrackBar";
            this.toTrackBar.Size = new System.Drawing.Size(305, 45);
            this.toTrackBar.TabIndex = 7;
            this.toTrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.toTrackBar.Visible = false;
            this.toTrackBar.ValueChanged += new System.EventHandler(this.toTrackBar_ValueChanged);
            this.toTrackBar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.toTrackBar_MouseUp);
            // 
            // trackBar2
            // 
            this.trackBar2.Location = new System.Drawing.Point(245, 368);
            this.trackBar2.Maximum = 255;
            this.trackBar2.Minimum = 2;
            this.trackBar2.Name = "trackBar2";
            this.trackBar2.Size = new System.Drawing.Size(291, 45);
            this.trackBar2.TabIndex = 9;
            this.trackBar2.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar2.Value = 2;
            this.trackBar2.Visible = false;
            this.trackBar2.ValueChanged += new System.EventHandler(this.trackBar2_ValueChanged);
            this.trackBar2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.trackBar2_MouseUp);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(551, 372);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 14);
            this.label2.TabIndex = 10;
            this.label2.Text = "2";
            this.label2.Visible = false;
            // 
            // decreaseButton
            // 
            this.decreaseButton.Location = new System.Drawing.Point(164, 369);
            this.decreaseButton.Name = "decreaseButton";
            this.decreaseButton.Size = new System.Drawing.Size(29, 23);
            this.decreaseButton.TabIndex = 11;
            this.decreaseButton.Text = "-";
            this.decreaseButton.UseVisualStyleBackColor = true;
            this.decreaseButton.Visible = false;
            this.decreaseButton.Click += new System.EventHandler(this.decreaseButton_Click);
            // 
            // increaseButton
            // 
            this.increaseButton.Location = new System.Drawing.Point(210, 369);
            this.increaseButton.Name = "increaseButton";
            this.increaseButton.Size = new System.Drawing.Size(29, 23);
            this.increaseButton.TabIndex = 12;
            this.increaseButton.Text = "+";
            this.increaseButton.UseVisualStyleBackColor = true;
            this.increaseButton.Visible = false;
            this.increaseButton.Click += new System.EventHandler(this.increaseButton_Click);
            // 
            // PreviewWithSlider
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 446);
            this.Controls.Add(this.increaseButton);
            this.Controls.Add(this.decreaseButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.trackBar2);
            this.Controls.Add(this.toLabel);
            this.Controls.Add(this.toTrackBar);
            this.Controls.Add(this.fromLabel);
            this.Controls.Add(this.fromTrackBar);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.splitContainer1);
            this.Name = "PreviewWithSlider";
            this.Text = "PreviewWithSlider";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fromTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.toTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TrackBar fromTrackBar;
        private System.Windows.Forms.Label fromLabel;
        private System.Windows.Forms.Label toLabel;
        private System.Windows.Forms.TrackBar toTrackBar;
        private System.Windows.Forms.TrackBar trackBar2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button decreaseButton;
        private System.Windows.Forms.Button increaseButton;
    }
}