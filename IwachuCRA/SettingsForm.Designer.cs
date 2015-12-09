namespace IwachuCRA
{
    partial class SettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ipbox = new System.Windows.Forms.TextBox();
            this.dbbox = new System.Windows.Forms.TextBox();
            this.userbox = new System.Windows.Forms.TextBox();
            this.pasbox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "System IP:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "System DB:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(45, 146);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "DB User:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(44, 187);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "DB Pass:";
            // 
            // ipbox
            // 
            this.ipbox.Location = new System.Drawing.Point(98, 61);
            this.ipbox.Name = "ipbox";
            this.ipbox.Size = new System.Drawing.Size(230, 20);
            this.ipbox.TabIndex = 4;
            // 
            // dbbox
            // 
            this.dbbox.Location = new System.Drawing.Point(97, 102);
            this.dbbox.Name = "dbbox";
            this.dbbox.Size = new System.Drawing.Size(230, 20);
            this.dbbox.TabIndex = 5;
            this.dbbox.UseSystemPasswordChar = true;
            // 
            // userbox
            // 
            this.userbox.Location = new System.Drawing.Point(96, 143);
            this.userbox.Name = "userbox";
            this.userbox.Size = new System.Drawing.Size(230, 20);
            this.userbox.TabIndex = 6;
            this.userbox.UseSystemPasswordChar = true;
            // 
            // pasbox
            // 
            this.pasbox.Location = new System.Drawing.Point(96, 184);
            this.pasbox.Name = "pasbox";
            this.pasbox.Size = new System.Drawing.Size(230, 20);
            this.pasbox.TabIndex = 7;
            this.pasbox.UseSystemPasswordChar = true;
            // 
            // button1
            // 
            this.button1.Image = global::IwachuCRA.Properties.Resources.filesave;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.Location = new System.Drawing.Point(251, 235);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(391, 301);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pasbox);
            this.Controls.Add(this.userbox);
            this.Controls.Add(this.dbbox);
            this.Controls.Add(this.ipbox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "System Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox ipbox;
        private System.Windows.Forms.TextBox dbbox;
        private System.Windows.Forms.TextBox userbox;
        private System.Windows.Forms.TextBox pasbox;
        private System.Windows.Forms.Button button1;
    }
}