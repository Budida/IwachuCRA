namespace IwachuCRA
{
    partial class OrodhaVipimoForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrodhaVipimoForm));
            this.badiliBtn = new System.Windows.Forms.Button();
            this.pakuaUpyaBtn = new System.Windows.Forms.Button();
            this.exportBtn = new System.Windows.Forms.Button();
            this.orodhaVipimoDataGridView = new System.Windows.Forms.DataGridView();
            this.forwardBtn = new System.Windows.Forms.Button();
            this.backwardBtn = new System.Windows.Forms.Button();
            this.jinaKipimoBox = new System.Windows.Forms.TextBox();
            this.tozoBox = new System.Windows.Forms.TextBox();
            this.hifadhiKipimoBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.idadiLabel = new System.Windows.Forms.Label();
            this.totalPagesLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.currentPageLabel = new System.Windows.Forms.Label();
            this.exportPDF = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.orodhaVipimoDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // badiliBtn
            // 
            this.badiliBtn.Image = global::IwachuCRA.Properties.Resources.mini_edit;
            this.badiliBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.badiliBtn.Location = new System.Drawing.Point(559, 3);
            this.badiliBtn.Name = "badiliBtn";
            this.badiliBtn.Size = new System.Drawing.Size(75, 23);
            this.badiliBtn.TabIndex = 0;
            this.badiliBtn.Text = "Badili";
            this.badiliBtn.UseVisualStyleBackColor = true;
            this.badiliBtn.Click += new System.EventHandler(this.badiliBtn_Click);
            // 
            // pakuaUpyaBtn
            // 
            this.pakuaUpyaBtn.Image = global::IwachuCRA.Properties.Resources.reload;
            this.pakuaUpyaBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.pakuaUpyaBtn.Location = new System.Drawing.Point(636, 3);
            this.pakuaUpyaBtn.Name = "pakuaUpyaBtn";
            this.pakuaUpyaBtn.Size = new System.Drawing.Size(89, 23);
            this.pakuaUpyaBtn.TabIndex = 1;
            this.pakuaUpyaBtn.Text = "Pakua Upya";
            this.pakuaUpyaBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.pakuaUpyaBtn.UseVisualStyleBackColor = true;
            this.pakuaUpyaBtn.Click += new System.EventHandler(this.pakuaUpyaBtn_Click);
            // 
            // exportBtn
            // 
            this.exportBtn.Image = global::IwachuCRA.Properties.Resources.excel;
            this.exportBtn.Location = new System.Drawing.Point(725, 3);
            this.exportBtn.Name = "exportBtn";
            this.exportBtn.Size = new System.Drawing.Size(75, 23);
            this.exportBtn.TabIndex = 2;
            this.exportBtn.UseVisualStyleBackColor = true;
            this.exportBtn.Click += new System.EventHandler(this.exportBtn_Click);
            // 
            // orodhaVipimoDataGridView
            // 
            this.orodhaVipimoDataGridView.AllowUserToAddRows = false;
            this.orodhaVipimoDataGridView.AllowUserToDeleteRows = false;
            this.orodhaVipimoDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.orodhaVipimoDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.orodhaVipimoDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.orodhaVipimoDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.orodhaVipimoDataGridView.Location = new System.Drawing.Point(2, 3);
            this.orodhaVipimoDataGridView.Name = "orodhaVipimoDataGridView";
            this.orodhaVipimoDataGridView.ReadOnly = true;
            this.orodhaVipimoDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.orodhaVipimoDataGridView.Size = new System.Drawing.Size(555, 403);
            this.orodhaVipimoDataGridView.TabIndex = 3;
            // 
            // forwardBtn
            // 
            this.forwardBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.forwardBtn.Location = new System.Drawing.Point(483, 412);
            this.forwardBtn.Name = "forwardBtn";
            this.forwardBtn.Size = new System.Drawing.Size(75, 23);
            this.forwardBtn.TabIndex = 4;
            this.forwardBtn.Text = ">>>";
            this.forwardBtn.UseVisualStyleBackColor = true;
            this.forwardBtn.Click += new System.EventHandler(this.forwardBtn_Click);
            // 
            // backwardBtn
            // 
            this.backwardBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backwardBtn.Location = new System.Drawing.Point(2, 412);
            this.backwardBtn.Name = "backwardBtn";
            this.backwardBtn.Size = new System.Drawing.Size(75, 23);
            this.backwardBtn.TabIndex = 5;
            this.backwardBtn.Text = "<<<";
            this.backwardBtn.UseVisualStyleBackColor = true;
            this.backwardBtn.Click += new System.EventHandler(this.backwardBtn_Click);
            // 
            // jinaKipimoBox
            // 
            this.jinaKipimoBox.Location = new System.Drawing.Point(681, 78);
            this.jinaKipimoBox.Name = "jinaKipimoBox";
            this.jinaKipimoBox.Size = new System.Drawing.Size(119, 20);
            this.jinaKipimoBox.TabIndex = 6;
            // 
            // tozoBox
            // 
            this.tozoBox.Location = new System.Drawing.Point(681, 113);
            this.tozoBox.Name = "tozoBox";
            this.tozoBox.Size = new System.Drawing.Size(119, 20);
            this.tozoBox.TabIndex = 7;
            // 
            // hifadhiKipimoBtn
            // 
            this.hifadhiKipimoBtn.Image = global::IwachuCRA.Properties.Resources.filesave;
            this.hifadhiKipimoBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.hifadhiKipimoBtn.Location = new System.Drawing.Point(725, 151);
            this.hifadhiKipimoBtn.Name = "hifadhiKipimoBtn";
            this.hifadhiKipimoBtn.Size = new System.Drawing.Size(75, 23);
            this.hifadhiKipimoBtn.TabIndex = 8;
            this.hifadhiKipimoBtn.Text = "Hifadhi";
            this.hifadhiKipimoBtn.UseVisualStyleBackColor = true;
            this.hifadhiKipimoBtn.Click += new System.EventHandler(this.hifadhiKipimoBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(597, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Jina La Kipimo:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(638, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Tozo:";
            // 
            // idadiLabel
            // 
            this.idadiLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.idadiLabel.AutoSize = true;
            this.idadiLabel.Location = new System.Drawing.Point(275, 417);
            this.idadiLabel.Name = "idadiLabel";
            this.idadiLabel.Size = new System.Drawing.Size(69, 13);
            this.idadiLabel.TabIndex = 14;
            this.idadiLabel.Text = "IDADI: 2,000";
            // 
            // totalPagesLabel
            // 
            this.totalPagesLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.totalPagesLabel.AutoSize = true;
            this.totalPagesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalPagesLabel.Location = new System.Drawing.Point(222, 418);
            this.totalPagesLabel.Name = "totalPagesLabel";
            this.totalPagesLabel.Size = new System.Drawing.Size(25, 13);
            this.totalPagesLabel.TabIndex = 13;
            this.totalPagesLabel.Text = "200";
            this.totalPagesLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(212, 418);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(9, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "|";
            // 
            // currentPageLabel
            // 
            this.currentPageLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.currentPageLabel.AutoSize = true;
            this.currentPageLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentPageLabel.Location = new System.Drawing.Point(190, 418);
            this.currentPageLabel.Name = "currentPageLabel";
            this.currentPageLabel.Padding = new System.Windows.Forms.Padding(0, 0, 6, 0);
            this.currentPageLabel.Size = new System.Drawing.Size(19, 13);
            this.currentPageLabel.TabIndex = 11;
            this.currentPageLabel.Text = "0";
            this.currentPageLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // exportPDF
            // 
            this.exportPDF.Image = global::IwachuCRA.Properties.Resources.pdf;
            this.exportPDF.Location = new System.Drawing.Point(659, 32);
            this.exportPDF.Name = "exportPDF";
            this.exportPDF.Size = new System.Drawing.Size(54, 26);
            this.exportPDF.TabIndex = 15;
            this.exportPDF.UseVisualStyleBackColor = true;
            this.exportPDF.Click += new System.EventHandler(this.exportPDF_Click);
            // 
            // OrodhaVipimoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 439);
            this.Controls.Add(this.exportPDF);
            this.Controls.Add(this.idadiLabel);
            this.Controls.Add(this.totalPagesLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.currentPageLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.hifadhiKipimoBtn);
            this.Controls.Add(this.tozoBox);
            this.Controls.Add(this.jinaKipimoBox);
            this.Controls.Add(this.backwardBtn);
            this.Controls.Add(this.forwardBtn);
            this.Controls.Add(this.orodhaVipimoDataGridView);
            this.Controls.Add(this.exportBtn);
            this.Controls.Add(this.pakuaUpyaBtn);
            this.Controls.Add(this.badiliBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "OrodhaVipimoForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Orodha Ya Vipimo";
            this.Load += new System.EventHandler(this.OrodhaVipimoForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.orodhaVipimoDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button badiliBtn;
        private System.Windows.Forms.Button pakuaUpyaBtn;
        private System.Windows.Forms.Button exportBtn;
        private System.Windows.Forms.DataGridView orodhaVipimoDataGridView;
        private System.Windows.Forms.Button forwardBtn;
        private System.Windows.Forms.Button backwardBtn;
        private System.Windows.Forms.TextBox jinaKipimoBox;
        private System.Windows.Forms.TextBox tozoBox;
        private System.Windows.Forms.Button hifadhiKipimoBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label idadiLabel;
        private System.Windows.Forms.Label totalPagesLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label currentPageLabel;
        private System.Windows.Forms.Button exportPDF;
    }
}