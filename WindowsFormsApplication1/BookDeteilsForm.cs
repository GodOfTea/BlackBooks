using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BlackBooks;

namespace WindowsFormsApplication1
{
    public partial class BookDeteilsForm : Form
    {
        public BookDetail bd { get; set; }

        public BookDeteilsForm(BookDetail bd)
        {
            this.bd = bd;
            InitializeComponent();
            GenreBox.DataSource = Enum.GetValues(typeof(Genre));
        }

        private void GenereBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            /////////////////////////////////////////////////////////////////           
        }

        private void AuthorBox_TextChanged(object sender, EventArgs e)
        {
            if (String.Equals(AuthorBox.Text, ""))
                button1.Enabled = false;
            else
            {
                foreach (var c in AuthorBox.Text)
                {
                    if (!Char.IsLetter(c))
                    {
                        button1.Enabled = false;
                    }
                    else button1.Enabled = true;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bd.Title = TitleBox.Text;
            bd.Author = AuthorBox.Text;            
            bd.Genre = (Genre)GenreBox.SelectedItem;
            bd.Price = ChangePrice();
        }

        private double ChangePrice()
        {
            double price = 0;
            switch (bd.Genre)
            {
                case Genre.Adventures:
                    price = 299;
                    break;
                case Genre.Biography:
                    price = 199;
                    break;
                case Genre.Comics:
                    price = 99;
                    break;
                case Genre.Detective:
                    price = 149;
                    break;
                case Genre.Fantasy:
                    price = 299;
                    break;
                case Genre.Fiction:
                    price = 119;
                    break;
                case Genre.Horror:
                    price = 249;
                    break;
                case Genre.RomanceNovel:
                    price = 249;
                    break;
                case Genre.Tale:
                    price = 49;
                    break;
            }
            return price;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ////////////////////////////////////////////////////
        }

        private void TitleBox_TextChanged(object sender, EventArgs e)
        {
            if (String.Equals(TitleBox.Text, ""))
                button1.Enabled = false;
            else
            {
                foreach (var c in TitleBox.Text)
                {
                    if (!Char.IsLetter(c))
                    {
                        button1.Enabled = false;
                    }
                    else button1.Enabled = true;
                }
            }
        }

        private void PriceNum1_ValueChanged(object sender, EventArgs e)
        {
            //////////////////////////////////////////////////////////
        }

        private void GenreBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ///////////////////////////////////////////////////////////
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Price pr = new Price();
            var open = pr.ShowDialog(this);
        }
    }
}
