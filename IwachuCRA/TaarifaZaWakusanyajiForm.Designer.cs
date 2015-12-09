namespace IwachuCRA
{
    partial class TaarifaZaWakusanyajiForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TaarifaZaWakusanyajiForm));
            this.toDatePick = new System.Windows.Forms.DateTimePicker();
            this.fromDatePick = new System.Windows.Forms.DateTimePicker();
            this.exportBtn = new System.Windows.Forms.Button();
            this.angaliaBtn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.jinaBox = new System.Windows.Forms.TextBox();
            this.makusanyoDataGridView = new System.Windows.Forms.DataGridView();
            this.totalPagesLabel = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.currentPageLabel = new System.Windows.Forms.Label();
            this.jumlaLabel = new System.Windows.Forms.Label();
            this.forwardBtn = new System.Windows.Forms.Button();
            this.backwardBtn = new System.Windows.Forms.Button();
            this.exportPDF = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.makusanyoDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // toDatePick
            // 
            this.toDatePick.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.toDatePick.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.toDatePick.Location = new System.Drawing.Point(360, 8);
            this.toDatePick.Name = "toDatePick";
            this.toDatePick.Size = new System.Drawing.Size(89, 20);
            this.toDatePick.TabIndex = 20;
            // 
            // fromDatePick
            // 
            this.fromDatePick.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.fromDatePick.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.fromDatePick.Location = new System.Drawing.Point(220, 8);
            this.fromDatePick.Name = "fromDatePick";
            this.fromDatePick.Size = new System.Drawing.Size(87, 20);
            this.fromDatePick.TabIndex = 19;
            // 
            // exportBtn
            // 
            this.exportBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.exportBtn.Image = global::IwachuCRA.Properties.Resources.excel;
            this.exportBtn.Location = new System.Drawing.Point(820, 7);
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
            this.angaliaBtn.Location = new System.Drawing.Point(595, 7);
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
            this.label4.Location = new System.Drawing.Point(315, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 23;
            this.label4.Text = "Mpaka:";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(171, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "Kuanzia:";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(455, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 24;
            this.label1.Text = "Jina:";
            // 
            // jinaBox
            // 
            this.jinaBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.jinaBox.Location = new System.Drawing.Point(482, 8);
            this.jinaBox.Name = "jinaBox";
            this.jinaBox.Size = new System.Drawing.Size(107, 20);
            this.jinaBox.TabIndex = 25;
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
            this.makusanyoDataGridView.Location = new System.Drawing.Point(1, 32);
            this.makusanyoDataGridView.Name = "makusanyoDataGridView";
            this.makusanyoDataGridView.ReadOnly = true;
            this.makusanyoDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.makusanyoDataGridView.Size = new System.Drawing.Size(863, 413);
            this.makusanyoDataGridView.TabIndex = 26;
            // 
            // totalPagesLabel
            // 
            this.totalPagesLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.totalPagesLabel.AutoSize = true;
            this.totalPagesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalPagesLabel.Location = new System.Drawing.Point(375, 455);
            this.totalPagesLabel.Name = "totalPagesLabel";
            this.totalPagesLabel.Size = new System.Drawing.Size(25, 13);
            this.totalPagesLabel.TabIndex = 32;
            this.totalPagesLabel.Text = "200";
            this.totalPagesLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(365, 455);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(9, 13);
            this.label5.TabIndex = 31;
            this.label5.Text = "|";
            // 
            // currentPageLabel
            // 
            this.currentPageLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.currentPageLabel.AutoSize = true;
            this.currentPageLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentPageLabel.Location = new System.Drawing.Point(343, 455);
            this.currentPageLabel.Name = "currentPageLabel";
            this.currentPageLabel.Padding = new System.Windows.Forms.Padding(0, 0, 6, 0);
            this.currentPageLabel.Size = new System.Drawing.Size(19, 13);
            this.currentPageLabel.TabIndex = 30;
            this.currentPageLabel.Text = "0";
            this.currentPageLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // jumlaLabel
            // 
            this.jumlaLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.jumlaLabel.AutoSize = true;
            this.jumlaLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.jumlaLabel.Location = new System.Drawing.Point(537, 454);
            this.jumlaLabel.Name = "jumlaLabel";
            this.jumlaLabel.Size = new System.Drawing.Size(101, 13);
            this.jumlaLabel.TabIndex = 29;
            this.jumlaLabel.Text = "JUMLA: 900,000";
            // 
            // forwardBtn
            // 
            this.forwardBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.forwardBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.forwardBtn.Location = new System.Drawing.Point(790, 449);
            this.forwardBtn.Name = "forwardBtn";
            this.forwardBtn.Size = new System.Drawing.Size(75, 23);
            this.forwardBtn.TabIndex = 28;
            this.forwardBtn.Text = ">>>";
            this.forwardBtn.UseVisualStyleBackColor = true;
            this.forwardBtn.Click += new System.EventHandler(this.forwardBtn_Click);
            // 
            // backwardBtn
            // 
            this.backwardBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.backwardBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backwardBtn.Location = new System.Drawing.Point(0, 449);
            this.backwardBtn.Name = "backwardBtn";
            this.backwardBtn.Size = new System.Drawing.Size(75, 23);
            this.backwardBtn.TabIndex = 27;
            this.backwardBtn.Text = "<<<";
            this.backwardBtn.UseVisualStyleBackColor = true;
            this.backwardBtn.Click += new System.EventHandler(this.backwardBtn_Click);
            // 
            // exportPDF
            // 
            this.exportPDF.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.exportPDF.Image = global::IwachuCRA.Properties.Resources.pdf;
            this.exportPDF.Location = new System.Drawing.Point(759, 7);
            this.exportPDF.Name = "exportPDF";
            this.exportPDF.Size = new System.Drawing.Size(55, 23);
            this.exportPDF.TabIndex = 33;
            this.exportPDF.UseVisualStyleBackColor = true;
            this.exportPDF.Click += new System.EventHandler(this.exportPDF_Click);
            // 
            // TaarifaZaWakusanyajiForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(867, 475);
            this.Controls.Add(this.exportPDF);
            this.Controls.Add(this.totalPagesLabel);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.currentPageLabel);
            this.Controls.Add(this.jumlaLabel);
            this.Controls.Add(this.forwardBtn);
            this.Controls.Add(this.backwardBtn);
            this.Controls.Add(this.makusanyoDataGridView);
            this.Controls.Add(this.jinaBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.exportBtn);
            this.Controls.Add(this.toDatePick);
            this.Controls.Add(this.fromDatePick);
            this.Controls.Add(this.angaliaBtn);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TaarifaZaWakusanyajiForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Taarifa Za Wakusanyaji";
            this.Load += new System.EventHandler(this.TaarifaZaWakusanyajiForm_Load);
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox jinaBox;
        private System.Windows.Forms.DataGridView makusanyoDataGridView;
        private System.Windows.Forms.Label totalPagesLabel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label currentPageLabel;
        private System.Windows.Forms.Label jumlaLabel;
        private System.Windows.Forms.Button forwardBtn;
        private System.Windows.Forms.Button backwardBtn;
        private System.Windows.Forms.Button exportPDF;
    }
}