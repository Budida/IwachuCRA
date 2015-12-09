namespace IwachuCRA
{
    partial class SajiliMtaaKijijiForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SajiliMtaaKijijiForm));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.jinaLaMtaaKijijiBox = new System.Windows.Forms.TextBox();
            this.kataSelectDropDown = new System.Windows.Forms.ComboBox();
            this.hifadhiMtaaKijijiBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(57, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Jina La Mtaa/Kijiji:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(118, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Kata:";
            // 
            // jinaLaMtaaKijijiBox
            // 
            this.jinaLaMtaaKijijiBox.Location = new System.Drawing.Point(156, 24);
            this.jinaLaMtaaKijijiBox.Name = "jinaLaMtaaKijijiBox";
            this.jinaLaMtaaKijijiBox.Size = new System.Drawing.Size(268, 20);
            this.jinaLaMtaaKijijiBox.TabIndex = 1;
            // 
            // kataSelectDropDown
            // 
            this.kataSelectDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.kataSelectDropDown.ItemHeight = 13;
            this.kataSelectDropDown.Location = new System.Drawing.Point(156, 55);
            this.kataSelectDropDown.MaxDropDownItems = 10;
            this.kataSelectDropDown.Name = "kataSelectDropDown";
            this.kataSelectDropDown.Size = new System.Drawing.Size(268, 21);
            this.kataSelectDropDown.TabIndex = 2;
            // 
            // hifadhiMtaaKijijiBtn
            // 
            this.hifadhiMtaaKijijiBtn.Location = new System.Drawing.Point(349, 83);
            this.hifadhiMtaaKijijiBtn.Name = "hifadhiMtaaKijijiBtn";
            this.hifadhiMtaaKijijiBtn.Size = new System.Drawing.Size(75, 23);
            this.hifadhiMtaaKijijiBtn.TabIndex = 3;
            this.hifadhiMtaaKijijiBtn.Text = "Hifadhi";
            this.hifadhiMtaaKijijiBtn.UseVisualStyleBackColor = true;
            this.hifadhiMtaaKijijiBtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // SajiliMtaaKijijiForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(477, 129);
            this.Controls.Add(this.hifadhiMtaaKijijiBtn);
            this.Controls.Add(this.kataSelectDropDown);
            this.Controls.Add(this.jinaLaMtaaKijijiBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SajiliMtaaKijijiForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sajili Mitaa na Vijiji";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox jinaLaMtaaKijijiBox;
        private System.Windows.Forms.ComboBox kataSelectDropDown;
        private System.Windows.Forms.Button hifadhiMtaaKijijiBtn;
    }
}