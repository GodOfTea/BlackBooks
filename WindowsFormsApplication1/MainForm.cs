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
    public partial class MainForm : Form
    {

        public MainForm()
        {
            InitializeComponent();
            MinusB.Enabled = false;
        }

        BookRequestDto GetModelfromUI()
        {
            return new BookRequestDto()
            {
                Filled = DataFilled.Value,
                Price = PriceNum.Value,
                Delivery = DeliveryData.Value,
                FullName = FullNameBox.Text,
                Addres = AdressBox.Text,
                BookDetails = BookList.Items.OfType<BookDetail>().ToList(),
            };
        }

        private void SetModelToUI(BookRequestDto dto)
        {
            DataFilled.Value = dto.Filled;
            PriceNum.Value = dto.Price;
            DeliveryData.Value = dto.Delivery;
            FullNameBox.Text = dto.FullName;
            AdressBox.Text = dto.Addres;
            BookList.Items.Clear();
            foreach (var item in dto.BookDetails)
                BookList.Items.Add(item);
        }

        private void SaveB_Click(object sender, EventArgs e)
        {
            var sfd = new SaveFileDialog() { Filter = "Бланки заказов|*.blk" };
            var result = sfd.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                var dto = GetModelfromUI();
                BooksDtoHelper.WriteToFile(sfd.FileName, dto);
            }
        }

        private void OpenB_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog() { Filter = "Файл заказа|*.blk" };
            var result = ofd.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                var dto = BooksDtoHelper.LoadFromFile(ofd.FileName);
                SetModelToUI(dto);
            }
        }

        private void PlusB_Click(object sender, EventArgs e)
        {
            BookDeteilsForm bdf = new BookDeteilsForm(new BookDetail());
            var result = bdf.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                BookList.Items.Add(bdf.bd);
                RecalculatePrice();
            }
        }

        private void RecalculatePrice()
        {
            var dto = GetModelfromUI();
            decimal TotalPrice = 0;
            TotalPrice = 0;
                foreach (var genre in dto.BookDetails)
                {
                    switch (genre.Genre)
                    {
                        case Genre.Adventures:
                            TotalPrice += 299;
                            break;
                        case Genre.Biography:
                            TotalPrice += 199;
                            break;
                        case Genre.Comics:
                            TotalPrice += 99;
                            break;
                        case Genre.Detective:
                            TotalPrice += 149;
                            break;
                        case Genre.Fantasy:
                            TotalPrice += 299;
                            break;
                        case Genre.Fiction:
                            TotalPrice += 119;
                            break;
                        case Genre.Horror:
                            TotalPrice += 249;
                            break;
                        case Genre.RomanceNovel:
                            TotalPrice += 249;
                            break;
                        case Genre.Tale:
                            TotalPrice += 49;
                            break;
                    }
                }
            PriceNum.Value = TotalPrice;
        }

        private void BookList_SelectedIndexChanged(object sender, EventArgs e)
        {
            MinusB.Enabled = true;
            var bkl = BookList.SelectedItem as BookDetail;
            if (bkl == null)
                return;
            var form = new BookDeteilsForm(bkl);
            var result = form.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                var si = BookList.SelectedIndex;
                BookList.Items.RemoveAt(si);
                BookList.Items.Insert(si, form.bd);
            }            
        }

        private void PriceNum_ValueChanged(object sender, EventArgs e)
        {
            /////////////////////////////////////////////////////////
        }

        private void MinusB_Click_1(object sender, EventArgs e)
        {
            var si = BookList.SelectedIndex;
            BookList.Items.RemoveAt(si);
            RecalculatePrice();
        }

        private void выйтиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About form = new About();
            var opn = form.ShowDialog(this);
        }

        private void файлToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutFile form = new AboutFile();
            var opn = form.ShowDialog(this);
        }
    }

}
