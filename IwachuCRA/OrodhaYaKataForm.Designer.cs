namespace IwachuCRA
{
    partial class OrodhaYaKataForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrodhaYaKataForm));
            this.kataDataGridView = new System.Windows.Forms.DataGridView();
            this.printKataBtn = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.wardNameBox = new System.Windows.Forms.TextBox();
            this.makaziValueBox = new System.Windows.Forms.TextBox();
            this.biasharaValueBox = new System.Windows.Forms.TextBox();
            this.bmakaziValueBox = new System.Windows.Forms.TextBox();
            this.taasisiValueBox = new System.Windows.Forms.TextBox();
            this.kiwandaValueBox = new System.Windows.Forms.TextBox();
            this.hifadhiEditWardBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.kataDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // kataDataGridView
            // 
            this.kataDataGridView.AllowUserToAddRows = false;
            this.kataDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.kataDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.Info;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.kataDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.kataDataGridView.Location = new System.Drawing.Point(2, 31);
            this.kataDataGridView.MultiSelect = false;
            this.kataDataGridView.Name = "kataDataGridView";
            this.kataDataGridView.ReadOnly = true;
            this.kataDataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.kataDataGridView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.kataDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.kataDataGridView.ShowEditingIcon = false;
            this.kataDataGridView.Size = new System.Drawing.Size(691, 434);
            this.kataDataGridView.StandardTab = true;
            this.kataDataGridView.TabIndex = 0;
            this.kataDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.kataDataGridView_CellContentClick);
            // 
            // printKataBtn
            // 
            this.printKataBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.printKataBtn.Image = global::IwachuCRA.Properties.Resources.excel;
            this.printKataBtn.Location = new System.Drawing.Point(539, 2);
            this.printKataBtn.Name = "printKataBtn";
            this.printKataBtn.Size = new System.Drawing.Size(75, 23);
            this.printKataBtn.TabIndex = 3;
            this.printKataBtn.UseVisualStyleBackColor = true;
            this.printKataBtn.Click += new System.EventHandler(this.printKataBtn_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Image = global::IwachuCRA.Properties.Resources.reload;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.Location = new System.Drawing.Point(440, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(98, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Pakua Upya";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Image = global::IwachuCRA.Properties.Resources.mini_edit;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button2.Location = new System.Drawing.Point(364, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "Badili";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // wardNameBox
            // 
            this.wardNameBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.wardNameBox.Location = new System.Drawing.Point(768, 28);
            this.wardNameBox.Name = "wardNameBox";
            this.wardNameBox.Size = new System.Drawing.Size(134, 20);
            this.wardNameBox.TabIndex = 6;
            // 
            // makaziValueBox
            // 
            this.makaziValueBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.makaziValueBox.Location = new System.Drawing.Point(820, 63);
            this.makaziValueBox.Name = "makaziValueBox";
            this.makaziValueBox.Size = new System.Drawing.Size(82, 20);
            this.makaziValueBox.TabIndex = 7;
            // 
            // biasharaValueBox
            // 
            this.biasharaValueBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.biasharaValueBox.Location = new System.Drawing.Point(820, 100);
            this.biasharaValueBox.Name = "biasharaValueBox";
            this.biasharaValueBox.Size = new System.Drawing.Size(82, 20);
            this.biasharaValueBox.TabIndex = 8;
            // 
            // bmakaziValueBox
            // 
            this.bmakaziValueBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bmakaziValueBox.Location = new System.Drawing.Point(820, 137);
            this.bmakaziValueBox.Name = "bmakaziValueBox";
            this.bmakaziValueBox.Size = new System.Drawing.Size(82, 20);
            this.bmakaziValueBox.TabIndex = 9;
            // 
            // taasisiValueBox
            // 
            this.taasisiValueBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.taasisiValueBox.Location = new System.Drawing.Point(820, 179);
            this.taasisiValueBox.Name = "taasisiValueBox";
            this.taasisiValueBox.Size = new System.Drawing.Size(82, 20);
            this.taasisiValueBox.TabIndex = 10;
            this.taasisiValueBox.TextChanged += new System.EventHandler(this.textBox5_TextChanged);
            // 
            // kiwandaValueBox
            // 
            this.kiwandaValueBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.kiwandaValueBox.Location = new System.Drawing.Point(820, 222);
            this.kiwandaValueBox.Name = "kiwandaValueBox";
            this.kiwandaValueBox.Size = new System.Drawing.Size(82, 20);
            this.kiwandaValueBox.TabIndex = 11;
            // 
            // hifadhiEditWardBtn
            // 
            this.hifadhiEditWardBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.hifadhiEditWardBtn.Image = global::IwachuCRA.Properties.Resources.filesave;
            this.hifadhiEditWardBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.hifadhiEditWardBtn.Location = new System.Drawing.Point(820, 261);
            this.hifadhiEditWardBtn.Name = "hifadhiEditWardBtn";
            this.hifadhiEditWardBtn.Size = new System.Drawing.Size(82, 23);
            this.hifadhiEditWardBtn.TabIndex = 12;
            this.hifadhiEditWardBtn.Text = "Hifadhi";
            this.hifadhiEditWardBtn.UseVisualStyleBackColor = true;
            this.hifadhiEditWardBtn.Click += new System.EventHandler(this.hifadhiEditWardBtn_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(713, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Jina Kata:";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(748, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Kodi Makazi:";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(741, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Kodi Biashara:";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(706, 140);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(114, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Kodi Biashara/Makazi:";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(750, 182);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "Kodi Taasisi:";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(744, 225);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "Kodi Kiwanda:";
            // 
            // button3
            // 
            this.button3.Image = global::IwachuCRA.Properties.Resources.pdf;
            this.button3.Location = new System.Drawing.Point(617, 2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 19;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // OrodhaYaKataForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(958, 465);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.hifadhiEditWardBtn);
            this.Controls.Add(this.kiwandaValueBox);
            this.Controls.Add(this.taasisiValueBox);
            this.Controls.Add(this.bmakaziValueBox);
            this.Controls.Add(this.biasharaValueBox);
            this.Controls.Add(this.makaziValueBox);
            this.Controls.Add(this.wardNameBox);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.printKataBtn);
            this.Controls.Add(this.kataDataGridView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "OrodhaYaKataForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Orodha Ya Kata";
            this.Load += new System.EventHandler(this.OrodhaYaKataForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kataDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView kataDataGridView;
        private System.Windows.Forms.Button printKataBtn;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox wardNameBox;
        private System.Windows.Forms.TextBox makaziValueBox;
        private System.Windows.Forms.TextBox biasharaValueBox;
        private System.Windows.Forms.TextBox bmakaziValueBox;
        private System.Windows.Forms.TextBox taasisiValueBox;
        private System.Windows.Forms.TextBox kiwandaValueBox;
        private System.Windows.Forms.Button hifadhiEditWardBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button3;
    }
}