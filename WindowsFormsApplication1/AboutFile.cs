using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class AboutFile : Form
    {
        public AboutFile()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var file = new OpenFileDialog();
            var result = file.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                GetFileInfo(file.FileName);
            }
        }

        private void GetFileInfo(string fileName)
        {
            listBox1.Items.Clear();
            FileInfo info = new FileInfo(fileName);

            label1.Text = "Время создания - " + info.CreationTime.ToString();
            label2.Text = "Расположение файла - " + info.DirectoryName;
            label3.Text = "Формат файла - " + info.Extension;
            label4.Text = "Полное имя - " + info.FullName;
            label5.Text = "Последний раз открывали - " + info.LastAccessTime;
            label6.Text = "Последнее время записи - " + info.LastWriteTime;
            label7.Text = "Размер - " + (info.Length / 1024).ToString() + "Кб";
            if (info.Extension.ToString().Equals(".txt") || info.Extension.ToString().Equals(".blk"))
            {
                string[] allLines = File.ReadAllLines(fileName, Encoding.GetEncoding(1251));
                listBox1.Items.AddRange(allLines);
            }
            if (info.Extension.ToString().Equals(".png") || info.Extension.ToString().Equals(".jpg"))
            {
                pictureBox1.Image = Image.FromFile(Path.GetFullPath(fileName));
            }


        }

        private void button3_Click(object sender, EventArgs e)
        {
            CreateNewFile form = new CreateNewFile();
            form.ShowDialog();
        }
    }
}
