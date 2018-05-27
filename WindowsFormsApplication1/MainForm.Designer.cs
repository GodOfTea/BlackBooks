namespace WindowsFormsApplication1
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.SaveB = new System.Windows.Forms.Button();
            this.OpenB = new System.Windows.Forms.Button();
            this.BookList = new System.Windows.Forms.ListBox();
            this.PlusB = new System.Windows.Forms.Button();
            this.DataFilled = new System.Windows.Forms.DateTimePicker();
            this.DeliveryData = new System.Windows.Forms.DateTimePicker();
            this.AdressBox = new System.Windows.Forms.TextBox();
            this.FullNameBox = new System.Windows.Forms.TextBox();
            this.PriceNum = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.MinusB = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.оПрограммеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выйтиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.PriceNum)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // SaveB
            // 
            this.SaveB.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.SaveB.Location = new System.Drawing.Point(301, 532);
            this.SaveB.Name = "SaveB";
            this.SaveB.Size = new System.Drawing.Size(95, 34);
            this.SaveB.TabIndex = 0;
            this.SaveB.Text = "Сохранить";
            this.SaveB.UseVisualStyleBackColor = true;
            this.SaveB.Click += new System.EventHandler(this.SaveB_Click);
            // 
            // OpenB
            // 
            this.OpenB.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.OpenB.Location = new System.Drawing.Point(402, 532);
            this.OpenB.Name = "OpenB";
            this.OpenB.Size = new System.Drawing.Size(95, 34);
            this.OpenB.TabIndex = 1;
            this.OpenB.Text = "Открыть";
            this.OpenB.UseVisualStyleBackColor = true;
            this.OpenB.Click += new System.EventHandler(this.OpenB_Click);
            // 
            // BookList
            // 
            this.BookList.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BookList.FormattingEnabled = true;
            this.BookList.HorizontalScrollbar = true;
            this.BookList.ItemHeight = 19;
            this.BookList.Location = new System.Drawing.Point(15, 151);
            this.BookList.Name = "BookList";
            this.BookList.Size = new System.Drawing.Size(482, 213);
            this.BookList.TabIndex = 1;
            this.BookList.SelectedIndexChanged += new System.EventHandler(this.BookList_SelectedIndexChanged);
            // 
            // PlusB
            // 
            this.PlusB.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.PlusB.Location = new System.Drawing.Point(341, 382);
            this.PlusB.Name = "PlusB";
            this.PlusB.Size = new System.Drawing.Size(75, 23);
            this.PlusB.TabIndex = 4;
            this.PlusB.Text = "+";
            this.PlusB.UseVisualStyleBackColor = true;
            this.PlusB.Click += new System.EventHandler(this.PlusB_Click);
            // 
            // DataFilled
            // 
            this.DataFilled.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.DataFilled.Location = new System.Drawing.Point(297, 44);
            this.DataFilled.Name = "DataFilled";
            this.DataFilled.Size = new System.Drawing.Size(200, 21);
            this.DataFilled.TabIndex = 5;
            // 
            // DeliveryData
            // 
            this.DeliveryData.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.DeliveryData.Location = new System.Drawing.Point(144, 411);
            this.DeliveryData.Name = "DeliveryData";
            this.DeliveryData.Size = new System.Drawing.Size(167, 21);
            this.DeliveryData.TabIndex = 6;
            // 
            // AdressBox
            // 
            this.AdressBox.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.AdressBox.Location = new System.Drawing.Point(164, 116);
            this.AdressBox.Name = "AdressBox";
            this.AdressBox.Size = new System.Drawing.Size(333, 21);
            this.AdressBox.TabIndex = 7;
            this.AdressBox.Text = "Заполните адрес";
            // 
            // FullNameBox
            // 
            this.FullNameBox.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FullNameBox.Location = new System.Drawing.Point(164, 90);
            this.FullNameBox.Name = "FullNameBox";
            this.FullNameBox.Size = new System.Drawing.Size(333, 21);
            this.FullNameBox.TabIndex = 8;
            this.FullNameBox.Text = "Заполните ФИО";
            // 
            // PriceNum
            // 
            this.PriceNum.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.PriceNum.Location = new System.Drawing.Point(144, 385);
            this.PriceNum.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.PriceNum.Name = "PriceNum";
            this.PriceNum.ReadOnly = true;
            this.PriceNum.Size = new System.Drawing.Size(120, 21);
            this.PriceNum.TabIndex = 9;
            this.PriceNum.ValueChanged += new System.EventHandler(this.PriceNum_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.label1.Location = new System.Drawing.Point(11, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 19);
            this.label1.TabIndex = 10;
            this.label1.Text = "ФИО заказчика";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.label2.Location = new System.Drawing.Point(11, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 19);
            this.label2.TabIndex = 11;
            this.label2.Text = "Адрес доставки";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.label3.Location = new System.Drawing.Point(11, 412);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 19);
            this.label3.TabIndex = 12;
            this.label3.Text = "Дата доставки";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(167, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(124, 19);
            this.label4.TabIndex = 13;
            this.label4.Text = "Дата заполнения";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.label6.Location = new System.Drawing.Point(11, 386);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(128, 19);
            this.label6.TabIndex = 15;
            this.label6.Text = "Общая стоимость";
            // 
            // MinusB
            // 
            this.MinusB.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.MinusB.Location = new System.Drawing.Point(422, 382);
            this.MinusB.Name = "MinusB";
            this.MinusB.Size = new System.Drawing.Size(75, 23);
            this.MinusB.TabIndex = 16;
            this.MinusB.Text = "-";
            this.MinusB.UseVisualStyleBackColor = true;
            this.MinusB.Click += new System.EventHandler(this.MinusB_Click_1);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.оПрограммеToolStripMenuItem,
            this.выйтиToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(509, 24);
            this.menuStrip1.TabIndex = 17;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            this.файлToolStripMenuItem.Click += new System.EventHandler(this.файлToolStripMenuItem_Click);
            // 
            // оПрограммеToolStripMenuItem
            // 
            this.оПрограммеToolStripMenuItem.Name = "оПрограммеToolStripMenuItem";
            this.оПрограммеToolStripMenuItem.Size = new System.Drawing.Size(102, 20);
            this.оПрограммеToolStripMenuItem.Text = "О приложении";
            this.оПрограммеToolStripMenuItem.Click += new System.EventHandler(this.оПрограммеToolStripMenuItem_Click);
            // 
            // выйтиToolStripMenuItem
            // 
            this.выйтиToolStripMenuItem.Name = "выйтиToolStripMenuItem";
            this.выйтиToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.выйтиToolStripMenuItem.Text = "Выйти";
            this.выйтиToolStripMenuItem.Click += new System.EventHandler(this.выйтиToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(509, 578);
            this.Controls.Add(this.MinusB);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PriceNum);
            this.Controls.Add(this.FullNameBox);
            this.Controls.Add(this.AdressBox);
            this.Controls.Add(this.DeliveryData);
            this.Controls.Add(this.DataFilled);
            this.Controls.Add(this.PlusB);
            this.Controls.Add(this.BookList);
            this.Controls.Add(this.OpenB);
            this.Controls.Add(this.SaveB);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "MainForm";
            ((System.ComponentModel.ISupportInitialize)(this.PriceNum)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SaveB;
        private System.Windows.Forms.Button OpenB;
        private System.Windows.Forms.ListBox BookList;
        private System.Windows.Forms.Button PlusB;
        private System.Windows.Forms.DateTimePicker DataFilled;
        private System.Windows.Forms.DateTimePicker DeliveryData;
        private System.Windows.Forms.TextBox AdressBox;
        private System.Windows.Forms.TextBox FullNameBox;
        private System.Windows.Forms.NumericUpDown PriceNum;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button MinusB;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem оПрограммеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выйтиToolStripMenuItem;
    }
}

