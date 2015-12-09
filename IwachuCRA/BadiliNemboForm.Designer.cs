namespace IwachuCRA
{
    partial class BadiliNemboForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BadiliNemboForm));
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.chaguaPichaBtn = new System.Windows.Forms.Button();
            this.previewPictureBox = new System.Windows.Forms.PictureBox();
            this.hifadhiNemboBtn = new System.Windows.Forms.Button();
            this.sahihiPreviewPictureBox = new System.Windows.Forms.PictureBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.chaguaSahihiBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.previewPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sahihiPreviewPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(23, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(310, 20);
            this.textBox1.TabIndex = 0;
            // 
            // chaguaPichaBtn
            // 
            this.chaguaPichaBtn.Location = new System.Drawing.Point(349, 10);
            this.chaguaPichaBtn.Name = "chaguaPichaBtn";
            this.chaguaPichaBtn.Size = new System.Drawing.Size(133, 23);
            this.chaguaPichaBtn.TabIndex = 1;
            this.chaguaPichaBtn.Text = "Chagua Nembo";
            this.chaguaPichaBtn.UseVisualStyleBackColor = true;
            this.chaguaPichaBtn.Click += new System.EventHandler(this.chaguaPichaBtn_Click);
            // 
            // previewPictureBox
            // 
            this.previewPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.previewPictureBox.Location = new System.Drawing.Point(23, 121);
            this.previewPictureBox.Name = "previewPictureBox";
            this.previewPictureBox.Size = new System.Drawing.Size(153, 171);
            this.previewPictureBox.TabIndex = 2;
            this.previewPictureBox.TabStop = false;
            // 
            // hifadhiNemboBtn
            // 
            this.hifadhiNemboBtn.Location = new System.Drawing.Point(349, 303);
            this.hifadhiNemboBtn.Name = "hifadhiNemboBtn";
            this.hifadhiNemboBtn.Size = new System.Drawing.Size(133, 23);
            this.hifadhiNemboBtn.TabIndex = 3;
            this.hifadhiNemboBtn.Text = "Hifadhi";
            this.hifadhiNemboBtn.UseVisualStyleBackColor = true;
            this.hifadhiNemboBtn.Click += new System.EventHandler(this.hifadhiNemboBtn_Click);
            // 
            // sahihiPreviewPictureBox
            // 
            this.sahihiPreviewPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sahihiPreviewPictureBox.Location = new System.Drawing.Point(182, 121);
            this.sahihiPreviewPictureBox.Name = "sahihiPreviewPictureBox";
            this.sahihiPreviewPictureBox.Size = new System.Drawing.Size(153, 171);
            this.sahihiPreviewPictureBox.TabIndex = 4;
            this.sahihiPreviewPictureBox.TabStop = false;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(23, 59);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(310, 20);
            this.textBox2.TabIndex = 5;
            // 
            // chaguaSahihiBtn
            // 
            this.chaguaSahihiBtn.Location = new System.Drawing.Point(349, 59);
            this.chaguaSahihiBtn.Name = "chaguaSahihiBtn";
            this.chaguaSahihiBtn.Size = new System.Drawing.Size(133, 23);
            this.chaguaSahihiBtn.TabIndex = 6;
            this.chaguaSahihiBtn.Text = "Chagua Sahihi";
            this.chaguaSahihiBtn.UseVisualStyleBackColor = true;
            this.chaguaSahihiBtn.Click += new System.EventHandler(this.chaguaSahihiBtn_Click);
            // 
            // BadiliNemboForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(509, 359);
            this.Controls.Add(this.chaguaSahihiBtn);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.sahihiPreviewPictureBox);
            this.Controls.Add(this.hifadhiNemboBtn);
            this.Controls.Add(this.previewPictureBox);
            this.Controls.Add(this.chaguaPichaBtn);
            this.Controls.Add(this.textBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "BadiliNemboForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Badili Nembo Na Sahihi";
            ((System.ComponentModel.ISupportInitialize)(this.previewPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sahihiPreviewPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button chaguaPichaBtn;
        private System.Windows.Forms.PictureBox previewPictureBox;
        private System.Windows.Forms.Button hifadhiNemboBtn;
        private System.Windows.Forms.PictureBox sahihiPreviewPictureBox;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button chaguaSahihiBtn;
    }
}