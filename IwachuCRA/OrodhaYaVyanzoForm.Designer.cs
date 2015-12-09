namespace IwachuCRA
{
    partial class OrodhaYaVyanzoForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrodhaYaVyanzoForm));
            this.vyanzoDataGridView = new System.Windows.Forms.DataGridView();
            this.badiliChanzoBtn = new System.Windows.Forms.Button();
            this.pakuaUpyaVyanzoBtn = new System.Windows.Forms.Button();
            this.exportVyanzoToExcelBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.jinaChanzoBox = new System.Windows.Forms.TextBox();
            this.nambaChanzoBox = new System.Windows.Forms.TextBox();
            this.hifadhiBadiliChanzo = new System.Windows.Forms.Button();
            this.exportPDF = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.vyanzoDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // vyanzoDataGridView
            // 
            this.vyanzoDataGridView.AllowUserToAddRows = false;
            this.vyanzoDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.vyanzoDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.vyanzoDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.vyanzoDataGridView.Location = new System.Drawing.Point(1, 1);
            this.vyanzoDataGridView.Name = "vyanzoDataGridView";
            this.vyanzoDataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.vyanzoDataGridView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.vyanzoDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.vyanzoDataGridView.Size = new System.Drawing.Size(426, 412);
            this.vyanzoDataGridView.TabIndex = 0;
            // 
            // badiliChanzoBtn
            // 
            this.badiliChanzoBtn.Image = global::IwachuCRA.Properties.Resources.mini_edit;
            this.badiliChanzoBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.badiliChanzoBtn.Location = new System.Drawing.Point(429, 1);
            this.badiliChanzoBtn.Name = "badiliChanzoBtn";
            this.badiliChanzoBtn.Size = new System.Drawing.Size(75, 23);
            this.badiliChanzoBtn.TabIndex = 1;
            this.badiliChanzoBtn.Text = "Badili";
            this.badiliChanzoBtn.UseVisualStyleBackColor = true;
            this.badiliChanzoBtn.Click += new System.EventHandler(this.badiliChanzoBtn_Click);
            // 
            // pakuaUpyaVyanzoBtn
            // 
            this.pakuaUpyaVyanzoBtn.Image = global::IwachuCRA.Properties.Resources.reload;
            this.pakuaUpyaVyanzoBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.pakuaUpyaVyanzoBtn.Location = new System.Drawing.Point(505, 1);
            this.pakuaUpyaVyanzoBtn.Name = "pakuaUpyaVyanzoBtn";
            this.pakuaUpyaVyanzoBtn.Size = new System.Drawing.Size(89, 23);
            this.pakuaUpyaVyanzoBtn.TabIndex = 2;
            this.pakuaUpyaVyanzoBtn.Text = "Pakua Upya";
            this.pakuaUpyaVyanzoBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.pakuaUpyaVyanzoBtn.UseVisualStyleBackColor = true;
            this.pakuaUpyaVyanzoBtn.Click += new System.EventHandler(this.pakuaUpyaVyanzoBtn_Click);
            // 
            // exportVyanzoToExcelBtn
            // 
            this.exportVyanzoToExcelBtn.Image = global::IwachuCRA.Properties.Resources.excel;
            this.exportVyanzoToExcelBtn.Location = new System.Drawing.Point(595, 1);
            this.exportVyanzoToExcelBtn.Name = "exportVyanzoToExcelBtn";
            this.exportVyanzoToExcelBtn.Size = new System.Drawing.Size(75, 23);
            this.exportVyanzoToExcelBtn.TabIndex = 3;
            this.exportVyanzoToExcelBtn.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(433, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Jina La Chanzo:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(473, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Namba:";
            // 
            // jinaChanzoBox
            // 
            this.jinaChanzoBox.Location = new System.Drawing.Point(514, 71);
            this.jinaChanzoBox.Name = "jinaChanzoBox";
            this.jinaChanzoBox.Size = new System.Drawing.Size(156, 20);
            this.jinaChanzoBox.TabIndex = 6;
            // 
            // nambaChanzoBox
            // 
            this.nambaChanzoBox.Location = new System.Drawing.Point(514, 103);
            this.nambaChanzoBox.Name = "nambaChanzoBox";
            this.nambaChanzoBox.Size = new System.Drawing.Size(156, 20);
            this.nambaChanzoBox.TabIndex = 7;
            // 
            // hifadhiBadiliChanzo
            // 
            this.hifadhiBadiliChanzo.Image = global::IwachuCRA.Properties.Resources.filesave;
            this.hifadhiBadiliChanzo.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.hifadhiBadiliChanzo.Location = new System.Drawing.Point(595, 129);
            this.hifadhiBadiliChanzo.Name = "hifadhiBadiliChanzo";
            this.hifadhiBadiliChanzo.Size = new System.Drawing.Size(75, 23);
            this.hifadhiBadiliChanzo.TabIndex = 8;
            this.hifadhiBadiliChanzo.Text = "Hifadhi";
            this.hifadhiBadiliChanzo.UseVisualStyleBackColor = true;
            this.hifadhiBadiliChanzo.Click += new System.EventHandler(this.hifadhiBadiliChanzo_Click);
            // 
            // exportPDF
            // 
            this.exportPDF.Image = global::IwachuCRA.Properties.Resources.pdf;
            this.exportPDF.Location = new System.Drawing.Point(522, 30);
            this.exportPDF.Name = "exportPDF";
            this.exportPDF.Size = new System.Drawing.Size(59, 23);
            this.exportPDF.TabIndex = 9;
            this.exportPDF.UseVisualStyleBackColor = true;
            this.exportPDF.Click += new System.EventHandler(this.exportPDF_Click);
            // 
            // OrodhaYaVyanzoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(675, 413);
            this.Controls.Add(this.exportPDF);
            this.Controls.Add(this.hifadhiBadiliChanzo);
            this.Controls.Add(this.nambaChanzoBox);
            this.Controls.Add(this.jinaChanzoBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.exportVyanzoToExcelBtn);
            this.Controls.Add(this.pakuaUpyaVyanzoBtn);
            this.Controls.Add(this.badiliChanzoBtn);
            this.Controls.Add(this.vyanzoDataGridView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "OrodhaYaVyanzoForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Orodha Ya Vyanzo Vya Mapato";
            this.Load += new System.EventHandler(this.OrodhaYaVyanzoForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.vyanzoDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView vyanzoDataGridView;
        private System.Windows.Forms.Button badiliChanzoBtn;
        private System.Windows.Forms.Button pakuaUpyaVyanzoBtn;
        private System.Windows.Forms.Button exportVyanzoToExcelBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox jinaChanzoBox;
        private System.Windows.Forms.TextBox nambaChanzoBox;
        private System.Windows.Forms.Button hifadhiBadiliChanzo;
        private System.Windows.Forms.Button exportPDF;
    }
}