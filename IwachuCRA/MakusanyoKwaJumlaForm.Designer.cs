namespace IwachuCRA
{
    partial class MakusanyoKwaJumlaForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MakusanyoKwaJumlaForm));
            this.toDatePick = new System.Windows.Forms.DateTimePicker();
            this.fromDatePick = new System.Windows.Forms.DateTimePicker();
            this.exportBtn = new System.Windows.Forms.Button();
            this.angaliaBtn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.makusanyoDataGridView = new System.Windows.Forms.DataGridView();
            this.jumlaLabel = new System.Windows.Forms.Label();
            this.exportPDF = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.makusanyoDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // toDatePick
            // 
            this.toDatePick.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.toDatePick.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.toDatePick.Location = new System.Drawing.Point(385, 8);
            this.toDatePick.Name = "toDatePick";
            this.toDatePick.Size = new System.Drawing.Size(89, 20);
            this.toDatePick.TabIndex = 20;
            // 
            // fromDatePick
            // 
            this.fromDatePick.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.fromDatePick.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.fromDatePick.Location = new System.Drawing.Point(249, 8);
            this.fromDatePick.Name = "fromDatePick";
            this.fromDatePick.Size = new System.Drawing.Size(87, 20);
            this.fromDatePick.TabIndex = 19;
            // 
            // exportBtn
            // 
            this.exportBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.exportBtn.Image = global::IwachuCRA.Properties.Resources.excel;
            this.exportBtn.Location = new System.Drawing.Point(812, 5);
            this.exportBtn.Name = "exportBtn";
            this.exportBtn.Size = new System.Drawing.Size(44, 23);
            this.exportBtn.TabIndex = 21;
            this.exportBtn.UseVisualStyleBackColor = true;
            this.exportBtn.Click += new System.EventHandler(this.exportBtn_Click);
            // 
            // angaliaBtn
            // 
            this.angaliaBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.angaliaBtn.Image = global::IwachuCRA.Properties.Resources.search;
            this.angaliaBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.angaliaBtn.Location = new System.Drawing.Point(480, 7);
            this.angaliaBtn.Name = "angaliaBtn";
            this.angaliaBtn.Size = new System.Drawing.Size(75, 23);
            this.angaliaBtn.TabIndex = 18;
            this.angaliaBtn.Text = "Angalia";
            this.angaliaBtn.UseVisualStyleBackColor = true;
            this.angaliaBtn.Click += new System.EventHandler(this.angaliaBtn_Click);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(339, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 23;
            this.label4.Text = "Mpaka:";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(196, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "Kuanzia:";
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
            this.makusanyoDataGridView.Location = new System.Drawing.Point(1, 31);
            this.makusanyoDataGridView.Name = "makusanyoDataGridView";
            this.makusanyoDataGridView.ReadOnly = true;
            this.makusanyoDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.makusanyoDataGridView.Size = new System.Drawing.Size(863, 419);
            this.makusanyoDataGridView.TabIndex = 24;
            // 
            // jumlaLabel
            // 
            this.jumlaLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.jumlaLabel.AutoSize = true;
            this.jumlaLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.jumlaLabel.Location = new System.Drawing.Point(365, 456);
            this.jumlaLabel.Name = "jumlaLabel";
            this.jumlaLabel.Size = new System.Drawing.Size(83, 13);
            this.jumlaLabel.TabIndex = 25;
            this.jumlaLabel.Text = "JUMLA: 0000";
            // 
            // exportPDF
            // 
            this.exportPDF.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.exportPDF.Image = global::IwachuCRA.Properties.Resources.pdf;
            this.exportPDF.Location = new System.Drawing.Point(756, 5);
            this.exportPDF.Name = "exportPDF";
            this.exportPDF.Size = new System.Drawing.Size(54, 23);
            this.exportPDF.TabIndex = 26;
            this.exportPDF.UseVisualStyleBackColor = true;
            this.exportPDF.Click += new System.EventHandler(this.exportPDF_Click);
            // 
            // MakusanyoKwaJumlaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(867, 475);
            this.Controls.Add(this.exportPDF);
            this.Controls.Add(this.jumlaLabel);
            this.Controls.Add(this.makusanyoDataGridView);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.exportBtn);
            this.Controls.Add(this.toDatePick);
            this.Controls.Add(this.fromDatePick);
            this.Controls.Add(this.angaliaBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MakusanyoKwaJumlaForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Jumla Ya Makusanyo Kwa Maeneo";
            ((System.ComponentModel.ISupportInitialize)(this.makusanyoDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button exportBtn;
        private System.Windows.Forms.DateTimePicker toDatePick;
        private System.Windows.Forms.DateTimePicker fromDatePick;
        private System.Windows.Forms.Button angaliaBtn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView makusanyoDataGridView;
        private System.Windows.Forms.Label jumlaLabel;
        private System.Windows.Forms.Button exportPDF;
    }
}