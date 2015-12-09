namespace IwachuCRA
{
    partial class SajiliChanzoForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SajiliChanzoForm));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.jinaChanzoBox = new System.Windows.Forms.TextBox();
            this.nambaChanzoBox = new System.Windows.Forms.TextBox();
            this.hifadhiChanzoBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(69, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Jina la Chanzo:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(49, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Namba Ya Chanzo:";
            // 
            // jinaChanzoBox
            // 
            this.jinaChanzoBox.Location = new System.Drawing.Point(154, 26);
            this.jinaChanzoBox.Name = "jinaChanzoBox";
            this.jinaChanzoBox.Size = new System.Drawing.Size(290, 20);
            this.jinaChanzoBox.TabIndex = 2;
            // 
            // nambaChanzoBox
            // 
            this.nambaChanzoBox.Location = new System.Drawing.Point(154, 61);
            this.nambaChanzoBox.Name = "nambaChanzoBox";
            this.nambaChanzoBox.Size = new System.Drawing.Size(290, 20);
            this.nambaChanzoBox.TabIndex = 3;
            // 
            // hifadhiChanzoBtn
            // 
            this.hifadhiChanzoBtn.Location = new System.Drawing.Point(369, 87);
            this.hifadhiChanzoBtn.Name = "hifadhiChanzoBtn";
            this.hifadhiChanzoBtn.Size = new System.Drawing.Size(75, 23);
            this.hifadhiChanzoBtn.TabIndex = 4;
            this.hifadhiChanzoBtn.Text = "Hifadhi";
            this.hifadhiChanzoBtn.UseVisualStyleBackColor = true;
            this.hifadhiChanzoBtn.Click += new System.EventHandler(this.hifadhiChanzoBtn_Click);
            // 
            // SajiliChanzoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(478, 133);
            this.Controls.Add(this.hifadhiChanzoBtn);
            this.Controls.Add(this.nambaChanzoBox);
            this.Controls.Add(this.jinaChanzoBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SajiliChanzoForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sajili Vyanzo Vya Mapato";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox jinaChanzoBox;
        private System.Windows.Forms.TextBox nambaChanzoBox;
        private System.Windows.Forms.Button hifadhiChanzoBtn;
    }
}