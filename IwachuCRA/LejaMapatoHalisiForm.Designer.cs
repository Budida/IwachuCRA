namespace IwachuCRA
{
    partial class LejaMapatoHalisiForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LejaMapatoHalisiForm));
            this.label1 = new System.Windows.Forms.Label();
            this.chanzoDropDown = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.fromDatePcik = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.toDatePick = new System.Windows.Forms.DateTimePicker();
            this.angaliaBtn = new System.Windows.Forms.Button();
            this.lejaDataGridView = new System.Windows.Forms.DataGridView();
            this.exportBtn = new System.Windows.Forms.Button();
            this.exportPDF = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.lejaDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(89, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Chanzo:";
            // 
            // chanzoDropDown
            // 
            this.chanzoDropDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chanzoDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.chanzoDropDown.FormattingEnabled = true;
            this.chanzoDropDown.Location = new System.Drawing.Point(136, 5);
            this.chanzoDropDown.Name = "chanzoDropDown";
            this.chanzoDropDown.Size = new System.Drawing.Size(170, 21);
            this.chanzoDropDown.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(312, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Kuanzia:";
            // 
            // fromDatePcik
            // 
            this.fromDatePcik.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.fromDatePcik.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.fromDatePcik.Location = new System.Drawing.Point(366, 6);
            this.fromDatePcik.Name = "fromDatePcik";
            this.fromDatePcik.Size = new System.Drawing.Size(95, 20);
            this.fromDatePcik.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(467, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Mpaka:";
            // 
            // toDatePick
            // 
            this.toDatePick.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.toDatePick.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.toDatePick.Location = new System.Drawing.Point(512, 6);
            this.toDatePick.Name = "toDatePick";
            this.toDatePick.Size = new System.Drawing.Size(95, 20);
            this.toDatePick.TabIndex = 5;
            // 
            // angaliaBtn
            // 
            this.angaliaBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.angaliaBtn.Image = global::IwachuCRA.Properties.Resources.search;
            this.angaliaBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.angaliaBtn.Location = new System.Drawing.Point(613, 5);
            this.angaliaBtn.Name = "angaliaBtn";
            this.angaliaBtn.Size = new System.Drawing.Size(75, 23);
            this.angaliaBtn.TabIndex = 6;
            this.angaliaBtn.Text = "Angalia";
            this.angaliaBtn.UseVisualStyleBackColor = true;
            this.angaliaBtn.Click += new System.EventHandler(this.angaliaBtn_Click);
            // 
            // lejaDataGridView
            // 
            this.lejaDataGridView.AllowUserToAddRows = false;
            this.lejaDataGridView.AllowUserToDeleteRows = false;
            this.lejaDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lejaDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.lejaDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.lejaDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.lejaDataGridView.Location = new System.Drawing.Point(0, 33);
            this.lejaDataGridView.MultiSelect = false;
            this.lejaDataGridView.Name = "lejaDataGridView";
            this.lejaDataGridView.ReadOnly = true;
            this.lejaDataGridView.RowHeadersVisible = false;
            this.lejaDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.lejaDataGridView.Size = new System.Drawing.Size(830, 508);
            this.lejaDataGridView.TabIndex = 7;
            // 
            // exportBtn
            // 
            this.exportBtn.Image = global::IwachuCRA.Properties.Resources.excel;
            this.exportBtn.Location = new System.Drawing.Point(776, 1);
            this.exportBtn.Name = "exportBtn";
            this.exportBtn.Size = new System.Drawing.Size(54, 31);
            this.exportBtn.TabIndex = 8;
            this.exportBtn.UseVisualStyleBackColor = true;
            this.exportBtn.Click += new System.EventHandler(this.exportBtn_Click);
            // 
            // exportPDF
            // 
            this.exportPDF.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.exportPDF.Image = global::IwachuCRA.Properties.Resources.pdf;
            this.exportPDF.Location = new System.Drawing.Point(719, 1);
            this.exportPDF.Name = "exportPDF";
            this.exportPDF.Size = new System.Drawing.Size(54, 31);
            this.exportPDF.TabIndex = 27;
            this.exportPDF.UseVisualStyleBackColor = true;
            this.exportPDF.Click += new System.EventHandler(this.exportPDF_Click);
            // 
            // LejaMapatoHalisiForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(832, 545);
            this.Controls.Add(this.exportPDF);
            this.Controls.Add(this.exportBtn);
            this.Controls.Add(this.lejaDataGridView);
            this.Controls.Add(this.angaliaBtn);
            this.Controls.Add(this.toDatePick);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.fromDatePcik);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.chanzoDropDown);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "LejaMapatoHalisiForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Leja Ya Mapato Halisi";
            this.Load += new System.EventHandler(this.LejaMapatoHalisiForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.lejaDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox chanzoDropDown;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker fromDatePcik;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker toDatePick;
        private System.Windows.Forms.Button angaliaBtn;
        private System.Windows.Forms.DataGridView lejaDataGridView;
        private System.Windows.Forms.Button exportBtn;
        private System.Windows.Forms.Button exportPDF;
    }
}