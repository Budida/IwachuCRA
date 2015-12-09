namespace IwachuCRA
{
    partial class OrodhaWalipaKodiForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrodhaWalipaKodiForm));
            this.walipaKodiDataGridView = new System.Windows.Forms.DataGridView();
            this.backwardBtn = new System.Windows.Forms.Button();
            this.forwardBtn = new System.Windows.Forms.Button();
            this.currentPageLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.totalPagesLabel = new System.Windows.Forms.Label();
            this.searchBox = new System.Windows.Forms.TextBox();
            this.idadiLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.kataDropDown = new System.Windows.Forms.ComboBox();
            this.mitaaDropDown = new System.Windows.Forms.ComboBox();
            this.matumiziDropDown = new System.Windows.Forms.ComboBox();
            this.jumlaKodiLabel = new System.Windows.Forms.Label();
            this.exportBtn = new System.Windows.Forms.Button();
            this.searchBtn = new System.Windows.Forms.Button();
            this.badiliBtn = new System.Windows.Forms.Button();
            this.exportPDF = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.walipaKodiDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // walipaKodiDataGridView
            // 
            this.walipaKodiDataGridView.AllowUserToAddRows = false;
            this.walipaKodiDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.walipaKodiDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.walipaKodiDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.walipaKodiDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.walipaKodiDataGridView.Location = new System.Drawing.Point(2, 34);
            this.walipaKodiDataGridView.Name = "walipaKodiDataGridView";
            this.walipaKodiDataGridView.ReadOnly = true;
            this.walipaKodiDataGridView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.walipaKodiDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.walipaKodiDataGridView.Size = new System.Drawing.Size(899, 418);
            this.walipaKodiDataGridView.TabIndex = 0;
            // 
            // backwardBtn
            // 
            this.backwardBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.backwardBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backwardBtn.Location = new System.Drawing.Point(10, 458);
            this.backwardBtn.Name = "backwardBtn";
            this.backwardBtn.Size = new System.Drawing.Size(75, 23);
            this.backwardBtn.TabIndex = 1;
            this.backwardBtn.Text = "<<<";
            this.backwardBtn.UseVisualStyleBackColor = true;
            this.backwardBtn.Click += new System.EventHandler(this.backwardBtn_Click);
            // 
            // forwardBtn
            // 
            this.forwardBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.forwardBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.forwardBtn.Location = new System.Drawing.Point(816, 458);
            this.forwardBtn.Name = "forwardBtn";
            this.forwardBtn.Size = new System.Drawing.Size(75, 23);
            this.forwardBtn.TabIndex = 2;
            this.forwardBtn.Text = ">>>";
            this.forwardBtn.UseVisualStyleBackColor = true;
            this.forwardBtn.Click += new System.EventHandler(this.forwardBtn_Click);
            // 
            // currentPageLabel
            // 
            this.currentPageLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.currentPageLabel.AutoSize = true;
            this.currentPageLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentPageLabel.Location = new System.Drawing.Point(385, 468);
            this.currentPageLabel.Name = "currentPageLabel";
            this.currentPageLabel.Padding = new System.Windows.Forms.Padding(0, 0, 6, 0);
            this.currentPageLabel.Size = new System.Drawing.Size(19, 13);
            this.currentPageLabel.TabIndex = 3;
            this.currentPageLabel.Text = "0";
            this.currentPageLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(407, 468);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(9, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "|";
            // 
            // totalPagesLabel
            // 
            this.totalPagesLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.totalPagesLabel.AutoSize = true;
            this.totalPagesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalPagesLabel.Location = new System.Drawing.Point(417, 468);
            this.totalPagesLabel.Name = "totalPagesLabel";
            this.totalPagesLabel.Size = new System.Drawing.Size(25, 13);
            this.totalPagesLabel.TabIndex = 5;
            this.totalPagesLabel.Text = "200";
            this.totalPagesLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // searchBox
            // 
            this.searchBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.searchBox.Location = new System.Drawing.Point(713, 6);
            this.searchBox.Name = "searchBox";
            this.searchBox.Size = new System.Drawing.Size(104, 20);
            this.searchBox.TabIndex = 6;
            // 
            // idadiLabel
            // 
            this.idadiLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.idadiLabel.AutoSize = true;
            this.idadiLabel.Location = new System.Drawing.Point(559, 467);
            this.idadiLabel.Name = "idadiLabel";
            this.idadiLabel.Size = new System.Drawing.Size(69, 13);
            this.idadiLabel.TabIndex = 8;
            this.idadiLabel.Text = "IDADI: 2,000";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(258, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Kata:";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(405, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Mtaa:";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(551, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Matumizi:";
            // 
            // kataDropDown
            // 
            this.kataDropDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.kataDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.kataDropDown.FormattingEnabled = true;
            this.kataDropDown.Location = new System.Drawing.Point(296, 7);
            this.kataDropDown.Name = "kataDropDown";
            this.kataDropDown.Size = new System.Drawing.Size(104, 21);
            this.kataDropDown.TabIndex = 13;
            // 
            // mitaaDropDown
            // 
            this.mitaaDropDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.mitaaDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.mitaaDropDown.FormattingEnabled = true;
            this.mitaaDropDown.Location = new System.Drawing.Point(444, 6);
            this.mitaaDropDown.Name = "mitaaDropDown";
            this.mitaaDropDown.Size = new System.Drawing.Size(104, 21);
            this.mitaaDropDown.TabIndex = 14;
            // 
            // matumiziDropDown
            // 
            this.matumiziDropDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.matumiziDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.matumiziDropDown.FormattingEnabled = true;
            this.matumiziDropDown.Items.AddRange(new object[] {
            "",
            "Makazi",
            "Biashara",
            "Taasisi",
            "Kiwanda",
            "Biashara/Makazi"});
            this.matumiziDropDown.Location = new System.Drawing.Point(602, 6);
            this.matumiziDropDown.Name = "matumiziDropDown";
            this.matumiziDropDown.Size = new System.Drawing.Size(104, 21);
            this.matumiziDropDown.TabIndex = 15;
            // 
            // jumlaKodiLabel
            // 
            this.jumlaKodiLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.jumlaKodiLabel.AutoSize = true;
            this.jumlaKodiLabel.Location = new System.Drawing.Point(634, 467);
            this.jumlaKodiLabel.Name = "jumlaKodiLabel";
            this.jumlaKodiLabel.Size = new System.Drawing.Size(104, 13);
            this.jumlaKodiLabel.TabIndex = 16;
            this.jumlaKodiLabel.Text = "JUMLA KODI: 9,000";
            // 
            // exportBtn
            // 
            this.exportBtn.Image = global::IwachuCRA.Properties.Resources.excel;
            this.exportBtn.Location = new System.Drawing.Point(2, 6);
            this.exportBtn.Name = "exportBtn";
            this.exportBtn.Size = new System.Drawing.Size(75, 21);
            this.exportBtn.TabIndex = 9;
            this.exportBtn.UseVisualStyleBackColor = true;
            this.exportBtn.Click += new System.EventHandler(this.exportBtn_Click);
            // 
            // searchBtn
            // 
            this.searchBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.searchBtn.Image = global::IwachuCRA.Properties.Resources.search;
            this.searchBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.searchBtn.Location = new System.Drawing.Point(824, 5);
            this.searchBtn.Name = "searchBtn";
            this.searchBtn.Size = new System.Drawing.Size(75, 21);
            this.searchBtn.TabIndex = 7;
            this.searchBtn.Text = "Tafuta";
            this.searchBtn.UseVisualStyleBackColor = true;
            this.searchBtn.Click += new System.EventHandler(this.searchBtn_Click);
            // 
            // badiliBtn
            // 
            this.badiliBtn.Image = global::IwachuCRA.Properties.Resources.mini_edit;
            this.badiliBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.badiliBtn.Location = new System.Drawing.Point(138, 5);
            this.badiliBtn.Name = "badiliBtn";
            this.badiliBtn.Size = new System.Drawing.Size(75, 23);
            this.badiliBtn.TabIndex = 17;
            this.badiliBtn.Text = "Badili";
            this.badiliBtn.UseVisualStyleBackColor = true;
            this.badiliBtn.Click += new System.EventHandler(this.badiliBtn_Click);
            // 
            // exportPDF
            // 
            this.exportPDF.Image = global::IwachuCRA.Properties.Resources.pdf;
            this.exportPDF.Location = new System.Drawing.Point(80, 6);
            this.exportPDF.Name = "exportPDF";
            this.exportPDF.Size = new System.Drawing.Size(54, 21);
            this.exportPDF.TabIndex = 19;
            this.exportPDF.UseVisualStyleBackColor = true;
            this.exportPDF.Click += new System.EventHandler(this.exportPDF_Click);
            // 
            // OrodhaWalipaKodiForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(901, 486);
            this.Controls.Add(this.exportPDF);
            this.Controls.Add(this.badiliBtn);
            this.Controls.Add(this.jumlaKodiLabel);
            this.Controls.Add(this.matumiziDropDown);
            this.Controls.Add(this.mitaaDropDown);
            this.Controls.Add(this.kataDropDown);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.exportBtn);
            this.Controls.Add(this.idadiLabel);
            this.Controls.Add(this.searchBtn);
            this.Controls.Add(this.searchBox);
            this.Controls.Add(this.totalPagesLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.currentPageLabel);
            this.Controls.Add(this.forwardBtn);
            this.Controls.Add(this.backwardBtn);
            this.Controls.Add(this.walipaKodiDataGridView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "OrodhaWalipaKodiForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Orodha Ya Walipa Kodi";
            this.Load += new System.EventHandler(this.OrodhaWalipaKodiForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.walipaKodiDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView walipaKodiDataGridView;
        private System.Windows.Forms.Button backwardBtn;
        private System.Windows.Forms.Button forwardBtn;
        private System.Windows.Forms.Label currentPageLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label totalPagesLabel;
        private System.Windows.Forms.TextBox searchBox;
        private System.Windows.Forms.Button searchBtn;
        private System.Windows.Forms.Label idadiLabel;
        private System.Windows.Forms.Button exportBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox kataDropDown;
        private System.Windows.Forms.ComboBox mitaaDropDown;
        private System.Windows.Forms.ComboBox matumiziDropDown;
        private System.Windows.Forms.Label jumlaKodiLabel;
        private System.Windows.Forms.Button badiliBtn;
        private System.Windows.Forms.Button exportPDF;
    }
}