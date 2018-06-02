using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Database;
using System.IO;
using BookClass;

namespace WindowsFormsApplication1
{
    public partial class LoginForm : Form
    {
        List<DomainData> domainData = new List<DomainData>();
        public LoginForm()
        { 
            InitializeComponent();
            SerFile serFile = new SerFile("Database.xml");
            domainData = serFile.LoadData();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            CheckLicense();
        }

        private void SignInB_Click(object sender, EventArgs e)
        {
            int f = 0;
            foreach (var user in domainData)
            {
                if (user.Login == LoginBox.Text && user.Password == PasswordBox.Text.GetHashCode())
                {
                    f = 1;
                    MainForm form = new MainForm(this.LoginBox.Text);
                    form.ShowDialog();
                    this.Hide();
                }
            }
            if (f == 0)
                MessageBox.Show("Неверный логин или пароль");
            else
                Application.Exit();
        }

        private void CheckLicense()
        {
            var lv = new LicenseValidator(Directory.GetCurrentDirectory());
            if (!lv.HasLicense)
            {
                MessageBox.Show("Лицензия не найдена. Укажите путь к папке с лицензией.");
                FolderBrowserDialog dr = new FolderBrowserDialog();
                var result = dr.ShowDialog();
                if (result == DialogResult.OK)
                {
                    CheckLicense(dr.SelectedPath);
                }
                if (result == DialogResult.Cancel)
                {
                    Application.Exit();
                }
            }
            else if (!lv.IsValid)
            {
                MessageBox.Show("Лицензия просрочена.Укажите путь к папке с лицензией.");
                FolderBrowserDialog dr = new FolderBrowserDialog();
                var result = dr.ShowDialog();
                if (result == DialogResult.OK)
                {
                    CheckLicense(dr.SelectedPath);
                }
                if (result == DialogResult.Cancel)
                {
                    Application.Exit();
                }
            }
        }

        private void CheckLicense(string newPath)
        {
            var lv = new LicenseValidator(newPath);
            if (!lv.HasLicense)
            {
                MessageBox.Show("Лицензия не найдена. Укажите путь к папке с лицензией.");
                FolderBrowserDialog dr = new FolderBrowserDialog();
                var result = dr.ShowDialog();
                if (result == DialogResult.OK)
                {
                    CheckLicense(dr.SelectedPath);
                }
                if (result == DialogResult.Cancel)
                {
                    Application.Exit();
                }
            }
            if (!lv.IsValid)
            {
                MessageBox.Show("Лицензия просрочена.Укажите путь к папке с лицензией.");
                FolderBrowserDialog dr = new FolderBrowserDialog();
                var result = dr.ShowDialog();
                if (result == DialogResult.OK)
                {
                    CheckLicense(dr.SelectedPath);
                }
                if (result == DialogResult.Cancel)
                {
                    Application.Exit();
                }
            }
        }

      
    }
}
