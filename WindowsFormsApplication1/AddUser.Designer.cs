namespace WindowsFormsApplication1
{
    partial class AddUser
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
            this.txtPasswordBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtLoginBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SaveB = new System.Windows.Forms.Button();
            this.CancelB = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtPasswordBox
            // 
            this.txtPasswordBox.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtPasswordBox.Location = new System.Drawing.Point(103, 88);
            this.txtPasswordBox.Name = "txtPasswordBox";
            this.txtPasswordBox.Size = new System.Drawing.Size(112, 26);
            this.txtPasswordBox.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 19);
            this.label1.TabIndex = 15;
            this.label1.Text = "Пароль";
            // 
            // txtLoginBox
            // 
            this.txtLoginBox.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtLoginBox.Location = new System.Drawing.Point(103, 56);
            this.txtLoginBox.Name = "txtLoginBox";
            this.txtLoginBox.Size = new System.Drawing.Size(112, 26);
            this.txtLoginBox.TabIndex = 18;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(12, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 19);
            this.label2.TabIndex = 17;
            this.label2.Text = "Логин";
            // 
            // SaveB
            // 
            this.SaveB.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.SaveB.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SaveB.Location = new System.Drawing.Point(12, 168);
            this.SaveB.Name = "SaveB";
            this.SaveB.Size = new System.Drawing.Size(91, 27);
            this.SaveB.TabIndex = 19;
            this.SaveB.Text = "Сохранить";
            this.SaveB.UseVisualStyleBackColor = true;
            this.SaveB.Click += new System.EventHandler(this.SaveB_Click);
            // 
            // CancelB
            // 
            this.CancelB.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelB.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CancelB.Location = new System.Drawing.Point(124, 168);
            this.CancelB.Name = "CancelB";
            this.CancelB.Size = new System.Drawing.Size(91, 27);
            this.CancelB.TabIndex = 20;
            this.CancelB.Text = "Отмена";
            this.CancelB.UseVisualStyleBackColor = true;
            // 
            // AddUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(227, 207);
            this.Controls.Add(this.CancelB);
            this.Controls.Add(this.SaveB);
            this.Controls.Add(this.txtLoginBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPasswordBox);
            this.Controls.Add(this.label1);
            this.Name = "AddUser";
            this.Text = "AddUser";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtPasswordBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtLoginBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button SaveB;
        private System.Windows.Forms.Button CancelB;
    }
}