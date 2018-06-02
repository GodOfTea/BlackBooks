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
using Database;

namespace WindowsFormsApplication1
{
    public partial class MainForm : Form
    {
        List<DomainData> users = new List<DomainData>();
        string User;
        public MainForm(string User)
        {
            InitializeComponent();
            SerFile SerFile = new SerFile("Database.xml");
            users = SerFile.LoadData();
            UpdateDataGrid();
            MinusB.Enabled = false;
            this.User = User;
            UserName.Text = "Добро пожаловать " + User;
            FullNameBox.Text = User;
            if (User != "God")
            {
                файлToolStripMenuItem.Enabled = false;
                базаДанныхToolStripMenuItem.Enabled = false;
                OpenB.Enabled = false;
                passwordDataGridViewTextBoxColumn.Visible = false;
                ExcelB.Enabled = false;
            }
        }

        private void UpdateDataGrid()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = users;
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

        private void новыйToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddUser addUser = new AddUser();

            if (addUser.ShowDialog() == DialogResult.OK)
            {
                DomainData dmd = addUser.DomainData;
                dmd.Id = users.Count > 0 ? users.Max(i => i.Id) + 1 : 1;
                users.Add(addUser.DomainData);
                UpdateDataGrid();
            }
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                    DomainData dd = dataGridView1.SelectedRows[0].DataBoundItem as DomainData;
                    users.Remove(dd);
            }
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SerFile serFile = new SerFile("Database.xml");
            serFile.Save(users);
        }

        private void dataGridView1_SelectionChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DomainData dd = dataGridView1.SelectedRows[0].DataBoundItem as DomainData;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void FullNameBox_TextChanged(object sender, EventArgs e)
        {
        }

        private void ExcelB_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook ExcelWorkBook;
            Microsoft.Office.Interop.Excel.Worksheet ExcelWorkSheet;

            ExcelWorkBook = ExcelApp.Workbooks.Add(System.Reflection.Missing.Value);

            ExcelWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)ExcelWorkBook.Worksheets.get_Item(1);
            ExcelApp.get_Range("A1").Value = "Id";
            ExcelApp.get_Range("B1").Value = "Login";
            ExcelApp.get_Range("C1").Value = "Password";
            ExcelApp.get_Range("E1").Value = "Данные за: " + DateTime.Now.ToShortDateString();

            for (int i = 1; i < dataGridView1.Rows.Count; i++)
            {
                for (int j = 0; j < dataGridView1.ColumnCount; j++)
                {
                    if (dataGridView1.Rows[i].Cells[j].GetType().Name == "DataGridViewComboBoxCell")
                    {
                        DataGridViewComboBoxCell DataC = new DataGridViewComboBoxCell();
                        DataC = (DataGridViewComboBoxCell)dataGridView1.Rows[i].Cells[j];
                        ExcelApp.Cells[i + 1, j + 1] = DataC.EditedFormattedValue;
                    }
                    else
                    {
                        ExcelApp.Cells[i + 1, j + 1] = dataGridView1.Rows[i].Cells[j].Value; 
                    }
                }
            }
            ExcelApp.Visible = true;
            ExcelApp.UserControl = true;
        }
    }

}
