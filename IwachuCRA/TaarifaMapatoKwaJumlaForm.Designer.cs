namespace IwachuCRA
{
    partial class TaarifaMapatoKwaJumlaForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TaarifaMapatoKwaJumlaForm));
            this.toDatePick = new System.Windows.Forms.DateTimePicker();
            this.fromDatePick = new System.Windows.Forms.DateTimePicker();
            this.button2 = new System.Windows.Forms.Button();
            this.angaliaBtn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.incomeDataGridView = new System.Windows.Forms.DataGridView();
            this.jumlaLabel = new System.Windows.Forms.Label();
            this.exportPDF = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.incomeDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // toDatePick
            // 
            this.toDatePick.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.toDatePick.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.toDatePick.Location = new System.Drawing.Point(404, 9);
            this.toDatePick.Name = "toDatePick";
            this.toDatePick.Size = new System.Drawing.Size(94, 20);
            this.toDatePick.TabIndex = 11;
            // 
            // fromDatePick
            // 
            this.fromDatePick.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.fromDatePick.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.fromDatePick.Location = new System.Drawing.Point(265, 9);
            this.fromDatePick.Name = "fromDatePick";
            this.fromDatePick.Size = new System.Drawing.Size(94, 20);
            this.fromDatePick.TabIndex = 10;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Image = global::IwachuCRA.Properties.Resources.excel;
            this.button2.Location = new System.Drawing.Point(801, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(63, 28);
            this.button2.TabIndex = 13;
            this.button2.UseVisualStyleBackColor = true;
            // 
            // angaliaBtn
            // 
            this.angaliaBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.angaliaBtn.Image = global::IwachuCRA.Properties.Resources.filesave;
            this.angaliaBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.angaliaBtn.Location = new System.Drawing.Point(504, 8);
            this.angaliaBtn.Name = "angaliaBtn";
            this.angaliaBtn.Size = new System.Drawing.Size(75, 23);
            this.angaliaBtn.TabIndex = 12;
            this.angaliaBtn.Text = "Angalia";
            this.angaliaBtn.UseVisualStyleBackColor = true;
            this.angaliaBtn.Click += new System.EventHandler(this.angaliaBtn_Click);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(360, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Mpaka:";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(214, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Kuanzia:";
            // 
            // incomeDataGridView
            // 
            this.incomeDataGridView.AllowUserToAddRows = false;
            this.incomeDataGridView.AllowUserToDeleteRows = false;
            this.incomeDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.incomeDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.incomeDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.incomeDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.incomeDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.incomeDataGridView.Location = new System.Drawing.Point(2, 34);
            this.incomeDataGridView.Name = "incomeDataGridView";
            this.incomeDataGridView.ReadOnly = true;
            this.incomeDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.incomeDataGridView.Size = new System.Drawing.Size(863, 416);
            this.incomeDataGridView.TabIndex = 25;
            // 
            // jumlaLabel
            // 
            this.jumlaLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.jumlaLabel.AutoSize = true;
            this.jumlaLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.jumlaLabel.Location = new System.Drawing.Point(371, 457);
            this.jumlaLabel.Name = "jumlaLabel";
            this.jumlaLabel.Size = new System.Drawing.Size(83, 13);
            this.jumlaLabel.TabIndex = 26;
            this.jumlaLabel.Text = "JUMLA: 0000";
            // 
            // exportPDF
            // 
            this.exportPDF.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.exportPDF.Image = global::IwachuCRA.Properties.Resources.pdf;
            this.exportPDF.Location = new System.Drawing.Point(720, 4);
            this.exportPDF.Name = "exportPDF";
            this.exportPDF.Size = new System.Drawing.Size(75, 28);
            this.exportPDF.TabIndex = 27;
            this.exportPDF.UseVisualStyleBackColor = true;
            this.exportPDF.Click += new System.EventHandler(this.exportPDF_Click);
            // 
            // TaarifaMapatoKwaJumlaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(867, 475);
            this.Controls.Add(this.exportPDF);
            this.Controls.Add(this.jumlaLabel);
            this.Controls.Add(this.incomeDataGridView);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.angaliaBtn);
            this.Controls.Add(this.toDatePick);
            this.Controls.Add(this.fromDatePick);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TaarifaMapatoKwaJumlaForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Taarifa Ya Mapato Kwa Jumla";
            this.Load += new System.EventHandler(this.TaarifaMapatoKwaJumlaForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.incomeDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button angaliaBtn;
        private System.Windows.Forms.DateTimePicker toDatePick;
        private System.Windows.Forms.DateTimePicker fromDatePick;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView incomeDataGridView;
        private System.Windows.Forms.Label jumlaLabel;
        private System.Windows.Forms.Button exportPDF;
    }
}