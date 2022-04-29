using Kyrsach.Klass;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Kyrsach.Forms.FormPokupateli
{
    public partial class FormPokupateli : Form
    {
        public FormPokupateli()
        {
            InitializeComponent();
            Bank.FormPokupateli = this;
        }
        int selectedRow;
        BD bd = new BD();
        private void CreateColumns()
        {
            dataGridView1.Columns.Add("BuyerID", "Id Покупателя");
            dataGridView1.Columns.Add("Familiya", "Фамилия");
            dataGridView1.Columns.Add("B_name", "Имя");
        }
        private void ReadSingleRow(DataGridView dgv, IDataRecord record)
        {
            dgv.Rows.Add(record.GetInt32(0), record.GetString(1), record.GetString(2));
        }

        private void RefreshDataGridView(DataGridView dvg)
        {
            dvg.Rows.Clear();
            string zapros = "select * from Buyer";
            SqlCommand Command = new SqlCommand(zapros, bd.GetConnection());
            bd.OpenConnection();
            SqlDataReader reader = Command.ExecuteReader();

            while (reader.Read())
            {
                ReadSingleRow(dvg, reader);
            }
            reader.Close();
        }

        
        public void Gef()
            => RefreshDataGridView(dataGridView1);
        public void RefrehsPage()
        {
            dataGridView1.DefaultCellStyle.ForeColor = Color.Black;
            CreateColumns();
            RefreshDataGridView(dataGridView1);
        }

        private void FormPokupateli_Load(object sender, EventArgs e)
        {
            RefrehsPage();
        }

        private void btnAddsotr_Click(object sender, EventArgs e)
        {
            FormAddPokupateli formAddPokupateli = new FormAddPokupateli();
            formAddPokupateli.Show();

        }
        bool prov = false;
        private void btnChange_Click(object sender, EventArgs e)
        {
            if (prov == true) btnChange.Text = "Изменение текста выключенно";
            else btnChange.Text = "Изменение текста включено";
            prov = !prov;
        }


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (prov == true)
            {
                selectedRow = e.RowIndex;

                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = dataGridView1.Rows[selectedRow];

                    Bank.Index = Convert.ToInt32(row.Cells[0].Value.ToString());
                    Bank.F_Familiya = row.Cells[1].Value.ToString();
                    Bank.F_Name = row.Cells[2].Value.ToString();
                    FormChengePokupateli formChengePokupateli = new FormChengePokupateli();
                    formChengePokupateli.ShowDialog();
                }
                prov = false;
                btnChange.Text = "Изменение текста выключенно";
            }
        }
    }
}
