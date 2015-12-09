namespace IwachuCRA
{
    partial class MakusanyoKwaMwakaWaFedhaForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MakusanyoKwaMwakaWaFedhaForm));
            this.makusanyoDataGridView = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.toDatePick = new System.Windows.Forms.DateTimePicker();
            this.fromDatePick = new System.Windows.Forms.DateTimePicker();
            this.angaliaBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.endYearPick = new System.Windows.Forms.DateTimePicker();
            this.startYearPick = new System.Windows.Forms.DateTimePicker();
            this.exportbtn = new System.Windows.Forms.Button();
            this.exportPDF = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.makusanyoDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // makusanyoDataGridView
            // 
            this.makusanyoDataGridView.AllowUserToAddRows = false;
            this.makusanyoDataGridView.AllowUserToDeleteRows = false;
            this.makusanyoDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.makusanyoDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.makusanyoDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.makusanyoDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.makusanyoDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.makusanyoDataGridView.Location = new System.Drawing.Point(2, 64);
            this.makusanyoDataGridView.Name = "makusanyoDataGridView";
            this.makusanyoDataGridView.ReadOnly = true;
            this.makusanyoDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.makusanyoDataGridView.Size = new System.Drawing.Size(892, 514);
            this.makusanyoDataGridView.TabIndex = 30;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(439, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 29;
            this.label4.Text = "Mpaka:";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(296, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 28;
            this.label3.Text = "Kuanzia:";
            // 
            // toDatePick
            // 
            this.toDatePick.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.toDatePick.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.toDatePick.Location = new System.Drawing.Point(485, 8);
            this.toDatePick.Name = "toDatePick";
            this.toDatePick.Size = new System.Drawing.Size(89, 20);
            this.toDatePick.TabIndex = 27;
            // 
            // fromDatePick
            // 
            this.fromDatePick.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.fromDatePick.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.fromDatePick.Location = new System.Drawing.Point(349, 8);
            this.fromDatePick.Name = "fromDatePick";
            this.fromDatePick.Size = new System.Drawing.Size(87, 20);
            this.fromDatePick.TabIndex = 26;
            // 
            // angaliaBtn
            // 
            this.angaliaBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.angaliaBtn.Image = global::IwachuCRA.Properties.Resources.search;
            this.angaliaBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.angaliaBtn.Location = new System.Drawing.Point(580, 34);
            this.angaliaBtn.Name = "angaliaBtn";
            this.angaliaBtn.Size = new System.Drawing.Size(75, 23);
            this.angaliaBtn.TabIndex = 25;
            this.angaliaBtn.Text = "Angalia";
            this.angaliaBtn.UseVisualStyleBackColor = true;
            this.angaliaBtn.Click += new System.EventHandler(this.angaliaBtn_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(439, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 34;
            this.label1.Text = "Mpaka:";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(208, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 13);
            this.label2.TabIndex = 33;
            this.label2.Text = "Mwaka wa Fedha Kuanzia:";
            // 
            // endYearPick
            // 
            this.endYearPick.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.endYearPick.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.endYearPick.Location = new System.Drawing.Point(485, 36);
            this.endYearPick.Name = "endYearPick";
            this.endYearPick.Size = new System.Drawing.Size(89, 20);
            this.endYearPick.TabIndex = 32;
            // 
            // startYearPick
            // 
            this.startYearPick.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.startYearPick.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.startYearPick.Location = new System.Drawing.Point(349, 36);
            this.startYearPick.Name = "startYearPick";
            this.startYearPick.Size = new System.Drawing.Size(87, 20);
            this.startYearPick.TabIndex = 31;
            // 
            // exportbtn
            // 
            this.exportbtn.Image = global::IwachuCRA.Properties.Resources.excel;
            this.exportbtn.Location = new System.Drawing.Point(833, 2);
            this.exportbtn.Name = "exportbtn";
            this.exportbtn.Size = new System.Drawing.Size(59, 26);
            this.exportbtn.TabIndex = 35;
            this.exportbtn.UseVisualStyleBackColor = true;
            this.exportbtn.Click += new System.EventHandler(this.exportbtn_Click_1);
            // 
            // exportPDF
            // 
            this.exportPDF.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.exportPDF.Image = global::IwachuCRA.Properties.Resources.pdf;
            this.exportPDF.Location = new System.Drawing.Point(833, 33);
            this.exportPDF.Name = "exportPDF";
            this.exportPDF.Size = new System.Drawing.Size(59, 25);
            this.exportPDF.TabIndex = 36;
            this.exportPDF.UseVisualStyleBackColor = true;
            this.exportPDF.Click += new System.EventHandler(this.exportPDF_Click);
            // 
            // MakusanyoKwaMwakaWaFedhaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(896, 581);
            this.Controls.Add(this.exportPDF);
            this.Controls.Add(this.exportbtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.endYearPick);
            this.Controls.Add(this.startYearPick);
            this.Controls.Add(this.makusanyoDataGridView);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.toDatePick);
            this.Controls.Add(this.fromDatePick);
            this.Controls.Add(this.angaliaBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MakusanyoKwaMwakaWaFedhaForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Makusanyo Kwa Mwaka Wa Fedha";
            ((System.ComponentModel.ISupportInitialize)(this.makusanyoDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView makusanyoDataGridView;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker toDatePick;
        private System.Windows.Forms.DateTimePicker fromDatePick;
        private System.Windows.Forms.Button angaliaBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker endYearPick;
        private System.Windows.Forms.DateTimePicker startYearPick;
        private System.Windows.Forms.Button exportbtn;
        private System.Windows.Forms.Button exportPDF;
    }
}