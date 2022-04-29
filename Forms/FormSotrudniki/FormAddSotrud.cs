using Kyrsach.Klass;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Kyrsach.Forms
{
    public partial class FormAddSotrud : Form
    {
        BD db = new BD();

        private FormSotrudniki main;
        public FormAddSotrud(FormSotrudniki _sender)
        {
            InitializeComponent();
            main = _sender;
            Init();
            cbDolznost.KeyPress += (sender, e) => e.Handled = true;
        }

        private void Init()
        {
            checkPosition();
        }

        private void checkPosition()
        {
            cbDolznost.Items.Clear();
            SqlCommand command = new SqlCommand("Select * From [Dolzhnost];", db.GetConnection());
            DataTable table = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = command;
            adapter.Fill(table);

            for(int i = 0; i < table.Rows.Count; i++)
            {
                cbDolznost.Items.Add(table.Rows[i].Field<string>("NameDolzhnost"));
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void bntAdd_Click(object sender, EventArgs e)
        {
            db.OpenConnection();
            var Familiya = tbFamiliya.Text;
            var Name = tbName.Text;
            var Otchestvo = tbOthcestvo.Text;
            string dolzhnost = "";
            SqlCommand command = new SqlCommand("Select [DolzhnostID] From [Dolzhnost] Where [NameDolzhnost] = @dol", db.GetConnection());
            command.Parameters.Add("dol", SqlDbType.NVarChar).Value = cbDolznost.Text;
            DataTable table = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
               dolzhnost = table.Rows[0].Field<int>("DolzhnostID").ToString();


                   var addQuery = $"insert into Rabotnik(Familiya,R_name,Otchestvo,rf_Dolzhnost) values('{Familiya}','{Name}','{Otchestvo}','{dolzhnost}')";
                   var co = new SqlCommand(addQuery, db.GetConnection());
                   co.ExecuteNonQuery();
                   MessageBox.Show("Запись успешно создана!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                   
            db.CloseConnection();
            main.RefrehsPage();
            Close();
        }

        private void FormAddSotrud_Load(object sender, EventArgs e)
        {

        }

        private void tbFamiliya_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) == false) return;
            e.Handled = true;
        }

        private void tbOthcestvo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) == false) return;
            e.Handled = true;
        }

        private void tbName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) == false) return;
            e.Handled = true;
        }
    }
}
