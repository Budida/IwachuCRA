namespace IwachuCRA
{
    partial class OrodhaWaliothaminiwaForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrodhaWaliothaminiwaForm));
            this.waliothaminiwaDataGridView1 = new System.Windows.Forms.DataGridView();
            this.exportWaliothaminiwaBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.kataDropDown = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.mitaaDropDown = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.matumiziDropDown = new System.Windows.Forms.ComboBox();
            this.searchWalithaminiwaBtn = new System.Windows.Forms.Button();
            this.backwardBtn = new System.Windows.Forms.Button();
            this.forwardBtn = new System.Windows.Forms.Button();
            this.currentPageLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.totalPagesLabel = new System.Windows.Forms.Label();
            this.idadiKodiLabel = new System.Windows.Forms.Label();
            this.jumlaKodiLabel = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tathminiDropDown = new System.Windows.Forms.ComboBox();
            this.exportPDF = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.waliothaminiwaDataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // waliothaminiwaDataGridView1
            // 
            this.waliothaminiwaDataGridView1.AllowUserToAddRows = false;
            this.waliothaminiwaDataGridView1.AllowUserToDeleteRows = false;
            this.waliothaminiwaDataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.waliothaminiwaDataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.waliothaminiwaDataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.waliothaminiwaDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.waliothaminiwaDataGridView1.Location = new System.Drawing.Point(1, 37);
            this.waliothaminiwaDataGridView1.Name = "waliothaminiwaDataGridView1";
            this.waliothaminiwaDataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.waliothaminiwaDataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.waliothaminiwaDataGridView1.Size = new System.Drawing.Size(894, 418);
            this.waliothaminiwaDataGridView1.TabIndex = 0;
            // 
            // exportWaliothaminiwaBtn
            // 
            this.exportWaliothaminiwaBtn.Image = global::IwachuCRA.Properties.Resources.excel;
            this.exportWaliothaminiwaBtn.Location = new System.Drawing.Point(1, 8);
            this.exportWaliothaminiwaBtn.Name = "exportWaliothaminiwaBtn";
            this.exportWaliothaminiwaBtn.Size = new System.Drawing.Size(75, 23);
            this.exportWaliothaminiwaBtn.TabIndex = 1;
            this.exportWaliothaminiwaBtn.UseVisualStyleBackColor = true;
            this.exportWaliothaminiwaBtn.Click += new System.EventHandler(this.exportWaliothaminiwaBtn_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(369, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Kata:";
            // 
            // kataDropDown
            // 
            this.kataDropDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.kataDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.kataDropDown.FormattingEnabled = true;
            this.kataDropDown.Location = new System.Drawing.Point(405, 10);
            this.kataDropDown.Name = "kataDropDown";
            this.kataDropDown.Size = new System.Drawing.Size(102, 21);
            this.kataDropDown.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(511, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Mtaa:";
            // 
            // mitaaDropDown
            // 
            this.mitaaDropDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.mitaaDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.mitaaDropDown.FormattingEnabled = true;
            this.mitaaDropDown.Location = new System.Drawing.Point(549, 10);
            this.mitaaDropDown.Name = "mitaaDropDown";
            this.mitaaDropDown.Size = new System.Drawing.Size(102, 21);
            this.mitaaDropDown.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(655, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Matumizi:";
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
            this.matumiziDropDown.Location = new System.Drawing.Point(710, 8);
            this.matumiziDropDown.Name = "matumiziDropDown";
            this.matumiziDropDown.Size = new System.Drawing.Size(102, 21);
            this.matumiziDropDown.TabIndex = 7;
            // 
            // searchWalithaminiwaBtn
            // 
            this.searchWalithaminiwaBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.searchWalithaminiwaBtn.Image = global::IwachuCRA.Properties.Resources.search;
            this.searchWalithaminiwaBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.searchWalithaminiwaBtn.Location = new System.Drawing.Point(816, 7);
            this.searchWalithaminiwaBtn.Name = "searchWalithaminiwaBtn";
            this.searchWalithaminiwaBtn.Size = new System.Drawing.Size(75, 23);
            this.searchWalithaminiwaBtn.TabIndex = 8;
            this.searchWalithaminiwaBtn.Text = "Tafuta";
            this.searchWalithaminiwaBtn.UseVisualStyleBackColor = true;
            this.searchWalithaminiwaBtn.Click += new System.EventHandler(this.searchWalithaminiwaBtn_Click);
            // 
            // backwardBtn
            // 
            this.backwardBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.backwardBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backwardBtn.Location = new System.Drawing.Point(1, 461);
            this.backwardBtn.Name = "backwardBtn";
            this.backwardBtn.Size = new System.Drawing.Size(75, 23);
            this.backwardBtn.TabIndex = 9;
            this.backwardBtn.Text = "<<<";
            this.backwardBtn.UseVisualStyleBackColor = true;
            this.backwardBtn.Click += new System.EventHandler(this.backwardBtn_Click);
            // 
            // forwardBtn
            // 
            this.forwardBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.forwardBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.forwardBtn.Location = new System.Drawing.Point(816, 461);
            this.forwardBtn.Name = "forwardBtn";
            this.forwardBtn.Size = new System.Drawing.Size(75, 23);
            this.forwardBtn.TabIndex = 10;
            this.forwardBtn.Text = ">>>";
            this.forwardBtn.UseVisualStyleBackColor = true;
            this.forwardBtn.Click += new System.EventHandler(this.forwardBtn_Click);
            // 
            // currentPageLabel
            // 
            this.currentPageLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.currentPageLabel.AutoSize = true;
            this.currentPageLabel.Location = new System.Drawing.Point(366, 466);
            this.currentPageLabel.Name = "currentPageLabel";
            this.currentPageLabel.Padding = new System.Windows.Forms.Padding(0, 0, 6, 0);
            this.currentPageLabel.Size = new System.Drawing.Size(19, 13);
            this.currentPageLabel.TabIndex = 11;
            this.currentPageLabel.Text = "1";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(385, 466);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(10, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "|";
            // 
            // totalPagesLabel
            // 
            this.totalPagesLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.totalPagesLabel.AutoSize = true;
            this.totalPagesLabel.Location = new System.Drawing.Point(396, 466);
            this.totalPagesLabel.Name = "totalPagesLabel";
            this.totalPagesLabel.Size = new System.Drawing.Size(25, 13);
            this.totalPagesLabel.TabIndex = 13;
            this.totalPagesLabel.Text = "200";
            // 
            // idadiKodiLabel
            // 
            this.idadiKodiLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.idadiKodiLabel.AutoSize = true;
            this.idadiKodiLabel.Location = new System.Drawing.Point(546, 466);
            this.idadiKodiLabel.Name = "idadiKodiLabel";
            this.idadiKodiLabel.Size = new System.Drawing.Size(60, 13);
            this.idadiKodiLabel.TabIndex = 14;
            this.idadiKodiLabel.Text = "IDADI: 200";
            // 
            // jumlaKodiLabel
            // 
            this.jumlaKodiLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.jumlaKodiLabel.AutoSize = true;
            this.jumlaKodiLabel.Location = new System.Drawing.Point(636, 466);
            this.jumlaKodiLabel.Name = "jumlaKodiLabel";
            this.jumlaKodiLabel.Size = new System.Drawing.Size(125, 13);
            this.jumlaKodiLabel.TabIndex = 15;
            this.jumlaKodiLabel.Text = "JUMLA KODI: 2,000,000";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(244, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Tathmini:";
            // 
            // tathminiDropDown
            // 
            this.tathminiDropDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tathminiDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tathminiDropDown.FormattingEnabled = true;
            this.tathminiDropDown.Items.AddRange(new object[] {
            "Ndiyo",
            "Hapana"});
            this.tathminiDropDown.Location = new System.Drawing.Point(296, 10);
            this.tathminiDropDown.Name = "tathminiDropDown";
            this.tathminiDropDown.Size = new System.Drawing.Size(67, 21);
            this.tathminiDropDown.TabIndex = 17;
            // 
            // exportPDF
            // 
            this.exportPDF.Image = global::IwachuCRA.Properties.Resources.pdf;
            this.exportPDF.Location = new System.Drawing.Point(82, 8);
            this.exportPDF.Name = "exportPDF";
            this.exportPDF.Size = new System.Drawing.Size(54, 23);
            this.exportPDF.TabIndex = 18;
            this.exportPDF.UseVisualStyleBackColor = true;
            this.exportPDF.Click += new System.EventHandler(this.exportPDF_Click);
            // 
            // OrodhaWaliothaminiwaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(896, 486);
            this.Controls.Add(this.exportPDF);
            this.Controls.Add(this.tathminiDropDown);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.jumlaKodiLabel);
            this.Controls.Add(this.idadiKodiLabel);
            this.Controls.Add(this.totalPagesLabel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.currentPageLabel);
            this.Controls.Add(this.forwardBtn);
            this.Controls.Add(this.backwardBtn);
            this.Controls.Add(this.searchWalithaminiwaBtn);
            this.Controls.Add(this.matumiziDropDown);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.mitaaDropDown);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.kataDropDown);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.exportWaliothaminiwaBtn);
            this.Controls.Add(this.waliothaminiwaDataGridView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "OrodhaWaliothaminiwaForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Walipa Kodi Waliofanyiwa Na Wasiofanyiwa Tathmini";
            this.Load += new System.EventHandler(this.OrodhaWaliothaminiwaForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.waliothaminiwaDataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView waliothaminiwaDataGridView1;
        private System.Windows.Forms.Button exportWaliothaminiwaBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox kataDropDown;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox mitaaDropDown;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox matumiziDropDown;
        private System.Windows.Forms.Button searchWalithaminiwaBtn;
        private System.Windows.Forms.Button backwardBtn;
        private System.Windows.Forms.Button forwardBtn;
        private System.Windows.Forms.Label currentPageLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label totalPagesLabel;
        private System.Windows.Forms.Label idadiKodiLabel;
        private System.Windows.Forms.Label jumlaKodiLabel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox tathminiDropDown;
        private System.Windows.Forms.Button exportPDF;
    }
}