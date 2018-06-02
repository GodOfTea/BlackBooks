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

namespace WindowsFormsApplication1
{
    public partial class AddUser : Form
    {
        private DomainData dd;

        public DomainData DomainData
        {
            get { return dd; }
        }

        public AddUser(DomainData dmd = null)
        {
            InitializeComponent();

            if (dmd != null)
            {
                dd = dmd;
                txtLoginBox.Text = dd.Login;
            }
        }

        private void SaveB_Click(object sender, EventArgs e)
        {
            if (dd == null)
            {
                dd = new DomainData();
            }

            dd.Login = txtLoginBox.Text;
            dd.Password = txtPasswordBox.Text.GetHashCode();
        }
    }
}
