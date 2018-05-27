using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApplication1
{
    public partial class CreateNewFile : Form
    {
        public CreateNewFile()
        {
            InitializeComponent();
            IsNull();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.ShowDialog();
            richTextBox1.Text = dialog.SelectedPath;
            IsNull();
        }

        private void IsNull()
        {
            if (richTextBox1.Text == null)
            {
                button2.Enabled = false;
            }
            else
                button2.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
                File.WriteAllText(Path.Combine(richTextBox1.Text, richTextBox2.Text + ".txt"), richTextBox3.Text);
                Close();
        }
    }
}