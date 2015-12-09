namespace IwachuCRA
{
    partial class OrodhaMitaaForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrodhaMitaaForm));
            this.badilimtaaBtn = new System.Windows.Forms.Button();
            this.pakuaMitaaUpya = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.mitaaDataGridView = new System.Windows.Forms.DataGridView();
            this.streetnameBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.wardDropDownSelect = new System.Windows.Forms.ComboBox();
            this.hifadhiMtaaBtn = new System.Windows.Forms.Button();
            this.exportPDF = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.mitaaDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // badilimtaaBtn
            // 
            this.badilimtaaBtn.Image = global::IwachuCRA.Properties.Resources.mini_edit;
            this.badilimtaaBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.badilimtaaBtn.Location = new System.Drawing.Point(487, 3);
            this.badilimtaaBtn.Name = "badilimtaaBtn";
            this.badilimtaaBtn.Size = new System.Drawing.Size(75, 23);
            this.badilimtaaBtn.TabIndex = 0;
            this.badilimtaaBtn.Text = "Badili";
            this.badilimtaaBtn.UseVisualStyleBackColor = true;
            this.badilimtaaBtn.Click += new System.EventHandler(this.badilimtaaBtn_Click);
            // 
            // pakuaMitaaUpya
            // 
            this.pakuaMitaaUpya.Image = global::IwachuCRA.Properties.Resources.reload;
            this.pakuaMitaaUpya.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.pakuaMitaaUpya.Location = new System.Drawing.Point(563, 3);
            this.pakuaMitaaUpya.Name = "pakuaMitaaUpya";
            this.pakuaMitaaUpya.Size = new System.Drawing.Size(89, 23);
            this.pakuaMitaaUpya.TabIndex = 1;
            this.pakuaMitaaUpya.Text = "Pakua Upya";
            this.pakuaMitaaUpya.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.pakuaMitaaUpya.UseVisualStyleBackColor = true;
            this.pakuaMitaaUpya.Click += new System.EventHandler(this.pakuaMitaaUpya_Click);
            // 
            // button1
            // 
            this.button1.Image = global::IwachuCRA.Properties.Resources.excel;
            this.button1.Location = new System.Drawing.Point(653, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // mitaaDataGridView
            // 
            this.mitaaDataGridView.AllowUserToAddRows = false;
            this.mitaaDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.mitaaDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.mitaaDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.mitaaDataGridView.Location = new System.Drawing.Point(1, 3);
            this.mitaaDataGridView.Name = "mitaaDataGridView";
            this.mitaaDataGridView.ReadOnly = true;
            this.mitaaDataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.mitaaDataGridView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.mitaaDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.mitaaDataGridView.Size = new System.Drawing.Size(484, 401);
            this.mitaaDataGridView.TabIndex = 3;
            // 
            // streetnameBox
            // 
            this.streetnameBox.Location = new System.Drawing.Point(572, 98);
            this.streetnameBox.Name = "streetnameBox";
            this.streetnameBox.Size = new System.Drawing.Size(150, 20);
            this.streetnameBox.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(531, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Mtaa:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(531, 134);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Kata:";
            // 
            // wardDropDownSelect
            // 
            this.wardDropDownSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.wardDropDownSelect.FormattingEnabled = true;
            this.wardDropDownSelect.Location = new System.Drawing.Point(572, 131);
            this.wardDropDownSelect.Name = "wardDropDownSelect";
            this.wardDropDownSelect.Size = new System.Drawing.Size(150, 21);
            this.wardDropDownSelect.TabIndex = 7;
            // 
            // hifadhiMtaaBtn
            // 
            this.hifadhiMtaaBtn.Image = global::IwachuCRA.Properties.Resources.filesave;
            this.hifadhiMtaaBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.hifadhiMtaaBtn.Location = new System.Drawing.Point(647, 175);
            this.hifadhiMtaaBtn.Name = "hifadhiMtaaBtn";
            this.hifadhiMtaaBtn.Size = new System.Drawing.Size(75, 23);
            this.hifadhiMtaaBtn.TabIndex = 8;
            this.hifadhiMtaaBtn.Text = "Hifadhi";
            this.hifadhiMtaaBtn.UseVisualStyleBackColor = true;
            this.hifadhiMtaaBtn.Click += new System.EventHandler(this.hifadhiMtaaBtn_Click);
            // 
            // exportPDF
            // 
            this.exportPDF.Image = global::IwachuCRA.Properties.Resources.pdf;
            this.exportPDF.Location = new System.Drawing.Point(583, 32);
            this.exportPDF.Name = "exportPDF";
            this.exportPDF.Size = new System.Drawing.Size(54, 26);
            this.exportPDF.TabIndex = 9;
            this.exportPDF.UseVisualStyleBackColor = true;
            this.exportPDF.Click += new System.EventHandler(this.exportPDF_Click);
            // 
            // OrodhaMitaaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 405);
            this.Controls.Add(this.exportPDF);
            this.Controls.Add(this.hifadhiMtaaBtn);
            this.Controls.Add(this.wardDropDownSelect);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.streetnameBox);
            this.Controls.Add(this.mitaaDataGridView);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pakuaMitaaUpya);
            this.Controls.Add(this.badilimtaaBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "OrodhaMitaaForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Orodha Ya Mitaa";
            this.Load += new System.EventHandler(this.OrodhaMitaaForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.mitaaDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button badilimtaaBtn;
        private System.Windows.Forms.Button pakuaMitaaUpya;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView mitaaDataGridView;
        private System.Windows.Forms.TextBox streetnameBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox wardDropDownSelect;
        private System.Windows.Forms.Button hifadhiMtaaBtn;
        private System.Windows.Forms.Button exportPDF;
    }
}