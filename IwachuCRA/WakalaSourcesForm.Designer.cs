namespace IwachuCRA
{
    partial class WakalaSourcesForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WakalaSourcesForm));
            this.maeneoYaWakalaDataGridView = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.maeneoYaWakalaDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // maeneoYaWakalaDataGridView
            // 
            this.maeneoYaWakalaDataGridView.AllowUserToAddRows = false;
            this.maeneoYaWakalaDataGridView.AllowUserToDeleteRows = false;
            this.maeneoYaWakalaDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.maeneoYaWakalaDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.maeneoYaWakalaDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.maeneoYaWakalaDataGridView.Location = new System.Drawing.Point(1, 28);
            this.maeneoYaWakalaDataGridView.MultiSelect = false;
            this.maeneoYaWakalaDataGridView.Name = "maeneoYaWakalaDataGridView";
            this.maeneoYaWakalaDataGridView.ReadOnly = true;
            this.maeneoYaWakalaDataGridView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.maeneoYaWakalaDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.maeneoYaWakalaDataGridView.Size = new System.Drawing.Size(400, 268);
            this.maeneoYaWakalaDataGridView.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(325, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Ondoa Eneo";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // WakalaSourcesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(402, 296);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.maeneoYaWakalaDataGridView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WakalaSourcesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Maeneo Ya Wakala";
            this.Load += new System.EventHandler(this.WakalaSourcesForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.maeneoYaWakalaDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView maeneoYaWakalaDataGridView;
        private System.Windows.Forms.Button button1;
    }
}