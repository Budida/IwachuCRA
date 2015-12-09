namespace IwachuCRA
{
    partial class AndaaMakisioForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AndaaMakisioForm));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.fromDatePick = new System.Windows.Forms.DateTimePicker();
            this.toDatePick = new System.Windows.Forms.DateTimePicker();
            this.serialNumberPanel = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.maeneoNamesPanel = new System.Windows.Forms.Panel();
            this.makisioBoxesPanel = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(175, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Kuanzia:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(374, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Mpaka:";
            // 
            // fromDatePick
            // 
            this.fromDatePick.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.fromDatePick.Location = new System.Drawing.Point(225, 7);
            this.fromDatePick.Name = "fromDatePick";
            this.fromDatePick.Size = new System.Drawing.Size(135, 20);
            this.fromDatePick.TabIndex = 2;
            // 
            // toDatePick
            // 
            this.toDatePick.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.toDatePick.Location = new System.Drawing.Point(419, 7);
            this.toDatePick.Name = "toDatePick";
            this.toDatePick.Size = new System.Drawing.Size(135, 20);
            this.toDatePick.TabIndex = 3;
            // 
            // serialNumberPanel
            // 
            this.serialNumberPanel.AutoScroll = true;
            this.serialNumberPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.serialNumberPanel.Location = new System.Drawing.Point(-9, 54);
            this.serialNumberPanel.Name = "serialNumberPanel";
            this.serialNumberPanel.Size = new System.Drawing.Size(55, 414);
            this.serialNumberPanel.TabIndex = 4;
            this.serialNumberPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.serialNumberPanel_Paint);
            // 
            // button2
            // 
            this.button2.Image = global::IwachuCRA.Properties.Resources.filesave;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button2.Location = new System.Drawing.Point(654, 477);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "Hifadhi";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // maeneoNamesPanel
            // 
            this.maeneoNamesPanel.AutoScroll = true;
            this.maeneoNamesPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.maeneoNamesPanel.Location = new System.Drawing.Point(44, 54);
            this.maeneoNamesPanel.Name = "maeneoNamesPanel";
            this.maeneoNamesPanel.Size = new System.Drawing.Size(499, 414);
            this.maeneoNamesPanel.TabIndex = 7;
            this.maeneoNamesPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.maeneoNamesPanel_Paint);
            // 
            // makisioBoxesPanel
            // 
            this.makisioBoxesPanel.AutoScroll = true;
            this.makisioBoxesPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.makisioBoxesPanel.Location = new System.Drawing.Point(539, 54);
            this.makisioBoxesPanel.Name = "makisioBoxesPanel";
            this.makisioBoxesPanel.Size = new System.Drawing.Size(273, 414);
            this.makisioBoxesPanel.TabIndex = 8;
            this.makisioBoxesPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.makisioBoxesPanel_Paint);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(262, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "CHANZO(ENEO)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(651, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "KIASI";
            // 
            // AndaaMakisioForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(824, 504);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.makisioBoxesPanel);
            this.Controls.Add(this.maeneoNamesPanel);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.serialNumberPanel);
            this.Controls.Add(this.toDatePick);
            this.Controls.Add(this.fromDatePick);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "AndaaMakisioForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Andaa Makisio";
            this.Load += new System.EventHandler(this.AndaaMakisioForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker fromDatePick;
        private System.Windows.Forms.DateTimePicker toDatePick;
        private System.Windows.Forms.Panel serialNumberPanel;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel maeneoNamesPanel;
        private System.Windows.Forms.Panel makisioBoxesPanel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}