using Kyrsach.Klass;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kyrsach.Forms.FormSdelka
{
    public partial class FormSdelka : Form
    {
        BD db = new BD();
        
        public FormSdelka()
        {
            InitializeComponent();
            Bank.formSdelka = this;
        }
        private void CreateColumns()
        {
            dataGridView1.Columns.Add("SdelkaID", "Id");
            dataGridView1.Columns.Add("Nameflower", "Название");
            dataGridView1.Columns.Add("Price", "Цена");
            dataGridView1.Columns.Add("Kolichestvo", "Количество");
            dataGridView1.Columns.Add("Familiya", "Фамилия покупателя");
            dataGridView1.Columns.Add("B_Name", "Имя покупателя");
            dataGridView1.Columns.Add("Familiya", "Фамилия Продавца");
            dataGridView1.Columns.Add("Sdelka_data", "Дата и время сделки");
            dataGridView1.Columns.Add("summa_sdelki", "Сумма сделки");
        }
        private void ReadSingleRow(DataGridView dgv, IDataRecord record)
        {
            dgv.Rows.Add(record.GetInt32(0), record.GetString(1), record.GetInt32(2), record.GetInt32(3),record.GetString(4),record.GetString(5), record.GetString(6), record.GetString(7), record.GetInt32(8));
        }
        public void RefreshDataGridView(DataGridView dvg)
        {
            dvg.Rows.Clear();
            SqlCommand Command = new SqlCommand("select s.SdelkaID,ft.Nameflower, p.Price,s.Kolichestvo, b.Familiya,b.B_name, r.Familiya,s.Sdelka_data,s.summa_sdelki from Sdelka s inner join Product p on s.Rf_productID = p.ProductID inner join Buyer b on s.Rf_buyerID = b.BuyerID inner join Rabotnik r on s.Rf_RabotnikID = r.RabotnikID inner join Flowertype ft on p.Rf_nameflowerID = ft.NameflowerID", db.GetConnection());
            db.OpenConnection();
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


        private void FormSdelka_Load(object sender, EventArgs e)
        {
            RefrehsPage();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FormAddSdelka formAddSdelka = new FormAddSdelka();
            formAddSdelka.Show();
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
                    Bank.nameFlaver = Convert.ToString(row.Cells[1].Value.ToString());
                    Bank.Pryse = Convert.ToString(row.Cells[2].Value.ToString());
                    Bank.Kolichestvo = Convert.ToString(row.Cells[3].Value.ToString());
                    Bank.Pfamiliya = Convert.ToString(row.Cells[4].Value.ToString());
                    Bank.Name = Convert.ToString(row.Cells[5].Value.ToString());
                    Bank.F_Familiya = Convert.ToString(row.Cells[6].Value.ToString());
                    Bank.time = Convert.ToString(row.Cells[7].Value.ToString());
                    Bank.Summa = Convert.ToString(row.Cells[8].Value.ToString());
                    FormChengeSdelka formChengeSdelka = new FormChengeSdelka();
                    formChengeSdelka.Show();
                }
                prov = false;
                btnChange.Text = "Изменение текста выключенно";
            }
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
