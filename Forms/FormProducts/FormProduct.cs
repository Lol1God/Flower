using Kyrsach.Klass;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Kyrsach.Forms.FormProducts
{
    public partial class FormProduct : Form
    {
        BD bd = new BD();
        public FormProduct()
        {
            InitializeComponent();
            Bank.FormProduct = this;

        }
        private void CreateColumns()
        {
            dataGridView1.Columns.Add("ProductID", "Id");
            dataGridView1.Columns.Add("Nameflower", "Название");
            dataGridView1.Columns.Add("Kolichestvo", "Количество");
            dataGridView1.Columns.Add("Price", "Цена");
            dataGridView1.Columns.Add("Delivery_date", "Дата поставки");
            dataGridView1.Columns.Add("NameProvider", "Поставщик");
            dataGridView1.Columns.Add("Nalichiet", "Наличие");


        }
        private void ReadSingleRow(DataGridView dgv, IDataRecord record)
        {
            dgv.Rows.Add(record.GetInt32(0), record.GetString(1), record.GetInt32(2), record.GetInt32(3), record.GetString(4), record.GetString(5), record.GetString(6));
        }
        public void RefreshDataGridView(DataGridView dvg)
        {
            dvg.Rows.Clear();
            string zapros = $"select p.ProductID,f.Nameflower,p.Kolichestvo,p.Price,p.Delivery_date,pp.NameProvider,p.Nalichie from Product p inner join Flowertype f on p.Rf_nameflowerID = f.NameflowerID inner join P_provider pp on p.Rf_ProviderID = pp.ProviderID";
            SqlCommand Command = new SqlCommand(zapros, bd.GetConnection());
            bd.OpenConnection();
            SqlDataReader reader = Command.ExecuteReader();
            while (reader.Read())
            {
                ReadSingleRow(dvg, reader);
            }
            reader.Close();
        }
        public void gef()
        {
            RefreshDataGridView(dataGridView1);
        }

        public void RefrehsPage()
        {
            dataGridView1.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            CreateColumns();
            RefreshDataGridView(dataGridView1);
        }

        

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FormAddProduct formAddProduct = new FormAddProduct();
            formAddProduct.Show();
        }
        bool prov = false;
        int selectedRow;

        

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (prov == true)
            {
                selectedRow = e.RowIndex;
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = dataGridView1.Rows[selectedRow];

                    Bank.Index = Convert.ToInt32(row.Cells[0].Value.ToString());
                    Bank.F_Name = Convert.ToString(row.Cells[1].Value.ToString());
                    Bank.Kolichestvo = Convert.ToString(row.Cells[2].Value.ToString());
                    Bank.Pryse = Convert.ToString(row.Cells[3].Value.ToString());
                    Bank.Date = Convert.ToString(row.Cells[4].Value.ToString());
                    Bank.Provider = Convert.ToString(row.Cells[5].Value.ToString());
                    Bank.Key = Convert.ToString(row.Cells[6].Value.ToString());
                    FormChengeProduct formChengeProduct = new FormChengeProduct();
                    formChengeProduct.Show();
                }
                prov = false;
                btnChange.Text = "Изменение текста выключенно";
            }
        }

        private void FormProduct_Load(object sender, EventArgs e)
        {
            RefrehsPage();
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            if (prov == true)
            {
                prov = false;
                btnChange.Text = "Изменение текста выключенно";
            }
            else
            {
                btnChange.Text = "Изменение текста включено";
                prov = true;
            }
        }
    }
}

