namespace IwachuCRA
{
    partial class MapatoHalisiKwaMiamalaForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MapatoHalisiKwaMiamalaForm));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.chanzoDropDown = new System.Windows.Forms.ComboBox();
            this.mtumiajiDropDown = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.fromDatePick = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.toDatePick = new System.Windows.Forms.DateTimePicker();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.incomeResultsDataGridView = new System.Windows.Forms.DataGridView();
            this.totalPagesLabel = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.currentPageLabel = new System.Windows.Forms.Label();
            this.jumlaLabel = new System.Windows.Forms.Label();
            this.forwardBtn = new System.Windows.Forms.Button();
            this.backwardBtn = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.mwamalaBox = new System.Windows.Forms.TextBox();
            this.exportPDF = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.incomeResultsDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(174, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Chanzo:";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(330, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Mtumiaji:";
            // 
            // chanzoDropDown
            // 
            this.chanzoDropDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chanzoDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.chanzoDropDown.FormattingEnabled = true;
            this.chanzoDropDown.Location = new System.Drawing.Point(220, 4);
            this.chanzoDropDown.Name = "chanzoDropDown";
            this.chanzoDropDown.Size = new System.Drawing.Size(105, 21);
            this.chanzoDropDown.TabIndex = 2;
            // 
            // mtumiajiDropDown
            // 
            this.mtumiajiDropDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.mtumiajiDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.mtumiajiDropDown.FormattingEnabled = true;
            this.mtumiajiDropDown.Location = new System.Drawing.Point(379, 3);
            this.mtumiajiDropDown.Name = "mtumiajiDropDown";
            this.mtumiajiDropDown.Size = new System.Drawing.Size(105, 21);
            this.mtumiajiDropDown.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(489, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Kuanzia:";
            // 
            // fromDatePick
            // 
            this.fromDatePick.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.fromDatePick.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.fromDatePick.Location = new System.Drawing.Point(543, 5);
            this.fromDatePick.Name = "fromDatePick";
            this.fromDatePick.Size = new System.Drawing.Size(94, 20);
            this.fromDatePick.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(641, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Mpaka:";
            // 
            // toDatePick
            // 
            this.toDatePick.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.toDatePick.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.toDatePick.Location = new System.Drawing.Point(682, 5);
            this.toDatePick.Name = "toDatePick";
            this.toDatePick.Size = new System.Drawing.Size(94, 20);
            this.toDatePick.TabIndex = 7;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Image = global::IwachuCRA.Properties.Resources.filesave;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.Location = new System.Drawing.Point(782, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "Angalia";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Image = global::IwachuCRA.Properties.Resources.excel;
            this.button2.Location = new System.Drawing.Point(920, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(44, 25);
            this.button2.TabIndex = 9;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // incomeResultsDataGridView
            // 
            this.incomeResultsDataGridView.AllowUserToAddRows = false;
            this.incomeResultsDataGridView.AllowUserToDeleteRows = false;
            this.incomeResultsDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.incomeResultsDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.incomeResultsDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.incomeResultsDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.incomeResultsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.incomeResultsDataGridView.Location = new System.Drawing.Point(2, 31);
            this.incomeResultsDataGridView.Name = "incomeResultsDataGridView";
            this.incomeResultsDataGridView.ReadOnly = true;
            this.incomeResultsDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.incomeResultsDataGridView.Size = new System.Drawing.Size(961, 427);
            this.incomeResultsDataGridView.TabIndex = 27;
            // 
            // totalPagesLabel
            // 
            this.totalPagesLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.totalPagesLabel.AutoSize = true;
            this.totalPagesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalPagesLabel.Location = new System.Drawing.Point(373, 470);
            this.totalPagesLabel.Name = "totalPagesLabel";
            this.totalPagesLabel.Size = new System.Drawing.Size(25, 13);
            this.totalPagesLabel.TabIndex = 38;
            this.totalPagesLabel.Text = "200";
            this.totalPagesLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(363, 470);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(9, 13);
            this.label5.TabIndex = 37;
            this.label5.Text = "|";
            // 
            // currentPageLabel
            // 
            this.currentPageLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.currentPageLabel.AutoSize = true;
            this.currentPageLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentPageLabel.Location = new System.Drawing.Point(341, 470);
            this.currentPageLabel.Name = "currentPageLabel";
            this.currentPageLabel.Padding = new System.Windows.Forms.Padding(0, 0, 6, 0);
            this.currentPageLabel.Size = new System.Drawing.Size(19, 13);
            this.currentPageLabel.TabIndex = 36;
            this.currentPageLabel.Text = "0";
            this.currentPageLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // jumlaLabel
            // 
            this.jumlaLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.jumlaLabel.AutoSize = true;
            this.jumlaLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.jumlaLabel.Location = new System.Drawing.Point(535, 469);
            this.jumlaLabel.Name = "jumlaLabel";
            this.jumlaLabel.Size = new System.Drawing.Size(101, 13);
            this.jumlaLabel.TabIndex = 35;
            this.jumlaLabel.Text = "JUMLA: 900,000";
            // 
            // forwardBtn
            // 
            this.forwardBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.forwardBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.forwardBtn.Location = new System.Drawing.Point(887, 464);
            this.forwardBtn.Name = "forwardBtn";
            this.forwardBtn.Size = new System.Drawing.Size(75, 23);
            this.forwardBtn.TabIndex = 34;
            this.forwardBtn.Text = ">>>";
            this.forwardBtn.UseVisualStyleBackColor = true;
            this.forwardBtn.Click += new System.EventHandler(this.forwardBtn_Click);
            // 
            // backwardBtn
            // 
            this.backwardBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.backwardBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backwardBtn.Location = new System.Drawing.Point(2, 464);
            this.backwardBtn.Name = "backwardBtn";
            this.backwardBtn.Size = new System.Drawing.Size(75, 23);
            this.backwardBtn.TabIndex = 33;
            this.backwardBtn.Text = "<<<";
            this.backwardBtn.UseVisualStyleBackColor = true;
            this.backwardBtn.Click += new System.EventHandler(this.backwardBtn_Click);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(-1, 8);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 13);
            this.label6.TabIndex = 39;
            this.label6.Text = "Mwamala:";
            // 
            // mwamalaBox
            // 
            this.mwamalaBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.mwamalaBox.Location = new System.Drawing.Point(60, 5);
            this.mwamalaBox.Name = "mwamalaBox";
            this.mwamalaBox.Size = new System.Drawing.Size(108, 20);
            this.mwamalaBox.TabIndex = 40;
            // 
            // exportPDF
            // 
            this.exportPDF.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.exportPDF.Image = global::IwachuCRA.Properties.Resources.pdf;
            this.exportPDF.Location = new System.Drawing.Point(875, 2);
            this.exportPDF.Name = "exportPDF";
            this.exportPDF.Size = new System.Drawing.Size(42, 25);
            this.exportPDF.TabIndex = 41;
            this.exportPDF.UseVisualStyleBackColor = true;
            this.exportPDF.Click += new System.EventHandler(this.exportPDF_Click);
            // 
            // MapatoHalisiKwaMiamalaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(965, 489);
            this.Controls.Add(this.exportPDF);
            this.Controls.Add(this.mwamalaBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.totalPagesLabel);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.currentPageLabel);
            this.Controls.Add(this.jumlaLabel);
            this.Controls.Add(this.forwardBtn);
            this.Controls.Add(this.backwardBtn);
            this.Controls.Add(this.incomeResultsDataGridView);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.toDatePick);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.fromDatePick);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.mtumiajiDropDown);
            this.Controls.Add(this.chanzoDropDown);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MapatoHalisiKwaMiamalaForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Taarifa Ya Mapato Halisi";
            this.Load += new System.EventHandler(this.MapatoHalisiKwaMiamalaForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.incomeResultsDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox chanzoDropDown;
        private System.Windows.Forms.ComboBox mtumiajiDropDown;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker fromDatePick;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker toDatePick;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView incomeResultsDataGridView;
        private System.Windows.Forms.Label totalPagesLabel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label currentPageLabel;
        private System.Windows.Forms.Label jumlaLabel;
        private System.Windows.Forms.Button forwardBtn;
        private System.Windows.Forms.Button backwardBtn;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox mwamalaBox;
        private System.Windows.Forms.Button exportPDF;
    }
}