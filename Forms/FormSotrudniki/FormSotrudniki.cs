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
using System.Data.Common;
using System.Runtime.InteropServices;
using System.Configuration;

namespace Kyrsach.Forms
{
    enum RowState
    {
        Existed,
        Exit,
        Modified,
        ModifiedNew,
        Deleted
    }
    public partial class FormSotrudniki : Form
    {
        int selectedRow;
        BD bd = new BD();
        private void CreateColumns()
        {
            dataGridView1.Columns.Add("RabotnikID", "Id");
            dataGridView1.Columns.Add("Familiya", "Фамилия");
            dataGridView1.Columns.Add("R_name", "Имя");
            dataGridView1.Columns.Add("Otchestvo", "Отчество");
            dataGridView1.Columns.Add("NameDolzhnost", "Должность");
            dataGridView1.Columns.Add("Salary", "Зарплата");
        }
        private void ReadSingleRow(DataGridView dgv, IDataRecord record)
        {
            dgv.Rows.Add(record.GetInt32(0), record.GetString(1), record.GetString(2), record.GetString(3), record.GetString(4), record.GetInt32(5), RowState.ModifiedNew);
        }

        private void RefreshDataGridView(DataGridView dvg)
        {
            dvg.Rows.Clear();
            string zapros = $"select r.RabotnikID, r.Familiya, r.R_name, r.Otchestvo, d.NameDolzhnost,d.Salary from Rabotnik r inner join Dolzhnost d on r.rf_Dolzhnost = d.DolzhnostID";
            SqlCommand Command = new SqlCommand(zapros, bd.GetConnection());
            bd.OpenConnection();
            SqlDataReader reader = Command.ExecuteReader();

            while (reader.Read())
            {
                ReadSingleRow(dvg, reader);
            }
            reader.Close();
        }
        public FormSotrudniki()
        {
            InitializeComponent();
        }
        public void Gef()
        {
            RefreshDataGridView(dataGridView1);
        }
        public void RefrehsPage()
        {
            dataGridView1.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            CreateColumns();
            RefreshDataGridView(dataGridView1);
        }
        private void FormSotrudniki_Load(object sender, EventArgs e)
        {
            RefrehsPage();
            
        }

        private void btnAddsotr_Click(object sender, EventArgs e)
        {
            FormAddSotrud formAddSotrud = new FormAddSotrud(this);
            formAddSotrud.Show();
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
                    Bank.F_Othcestvo = row.Cells[3].Value.ToString();
                    Bank.F_Dolxnost = row.Cells[4].Value.ToString();
                    Bank.F_salary = row.Cells[5].Value.ToString();
                    FormChengeRabotnik formChengeRabotnik = new FormChengeRabotnik(this);
                    formChengeRabotnik.Show();
                }
                prov = false;
                btnChange.Text = "Изменение текста выключенно";
            }
        }
        bool prov = false;
        private void btnChange_Click(object sender, EventArgs e)
        {
            if(prov == true)
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
