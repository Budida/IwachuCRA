namespace IwachuCRA
{
    partial class RecoverPasswordForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RecoverPasswordForm));
            this.label1 = new System.Windows.Forms.Label();
            this.recoverPasswordBox = new System.Windows.Forms.TextBox();
            this.recoverPassBtn = new System.Windows.Forms.Button();
            this.futaEmailBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Modern No. 20", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Barua Pepe:";
            // 
            // recoverPasswordBox
            // 
            this.recoverPasswordBox.Location = new System.Drawing.Point(134, 26);
            this.recoverPasswordBox.Name = "recoverPasswordBox";
            this.recoverPasswordBox.Size = new System.Drawing.Size(238, 20);
            this.recoverPasswordBox.TabIndex = 1;
            // 
            // recoverPassBtn
            // 
            this.recoverPassBtn.Font = new System.Drawing.Font("Modern No. 20", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recoverPassBtn.Location = new System.Drawing.Point(297, 52);
            this.recoverPassBtn.Name = "recoverPassBtn";
            this.recoverPassBtn.Size = new System.Drawing.Size(75, 23);
            this.recoverPassBtn.TabIndex = 2;
            this.recoverPassBtn.Text = "Tuma";
            this.recoverPassBtn.UseVisualStyleBackColor = true;
            this.recoverPassBtn.Click += new System.EventHandler(this.recoverPassBtn_Click);
            // 
            // futaEmailBtn
            // 
            this.futaEmailBtn.Location = new System.Drawing.Point(216, 52);
            this.futaEmailBtn.Name = "futaEmailBtn";
            this.futaEmailBtn.Size = new System.Drawing.Size(75, 23);
            this.futaEmailBtn.TabIndex = 3;
            this.futaEmailBtn.Text = "Futa";
            this.futaEmailBtn.UseVisualStyleBackColor = true;
            this.futaEmailBtn.Click += new System.EventHandler(this.futaEmailBtn_Click);
            // 
            // RecoverPasswordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(395, 84);
            this.Controls.Add(this.futaEmailBtn);
            this.Controls.Add(this.recoverPassBtn);
            this.Controls.Add(this.recoverPasswordBox);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RecoverPasswordForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pata Nywila Mpya";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox recoverPasswordBox;
        private System.Windows.Forms.Button recoverPassBtn;
        private System.Windows.Forms.Button futaEmailBtn;
    }
}