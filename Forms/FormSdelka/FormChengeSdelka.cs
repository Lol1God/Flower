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

namespace Kyrsach.Forms.FormSdelka
{
    public partial class FormChengeSdelka : Form
    {
        BD db = new BD();
        public FormChengeSdelka()
        {
            InitializeComponent();
            Init();
            tbSumm.KeyPress += (sender, e) => e.Handled = true;
            tbPryse.KeyPress += (sender, e) => e.Handled = true;
            cbNameFlower.KeyPress += (sender, e) => e.Handled = true;
            cbProdovec.KeyPress += (sender, e) => e.Handled = true;
        }
        private void Init()
        {
            checkPositionTvar();
            checkPositionRabotnik();
        }
        string Tovar = "";
        string idd = "";
        public void checkPositionTvar()
        {
            db.OpenConnection();
            cbNameFlower.Items.Clear();
            SqlCommand command = new SqlCommand("Select * From [Flowertype];", db.GetConnection());
            DataTable table = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = command;
            adapter.Fill(table);

            for (int i = 0; i < table.Rows.Count; i++)
            {
                cbNameFlower.Items.Add(table.Rows[i].Field<string>("Nameflower"));
            }
            command.CommandText = "";
            command = new SqlCommand("Select [NameflowerID] From [Flowertype] Where [Nameflower] = @dol", db.GetConnection());
            command.Parameters.Add("dol", SqlDbType.NVarChar).Value = cbNameFlower.Text;
            table = new DataTable();
            adapter = new SqlDataAdapter();
            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
                Tovar = table.Rows[0].Field<int>("NameflowerID").ToString();
        }
        string ff;
        string Prise;
        private void getByu()
        {

            db.OpenConnection();
            SqlCommand command = new SqlCommand($"select NameflowerID from Flowertype where Nameflower = '{cbNameFlower.Text}'", db.GetConnection());
            DataTable table = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = command;
            adapter.Fill(table);
            if (table.Rows.Count > 0)
                idd = table.Rows[0].Field<int>("NameflowerID").ToString();

            command.CommandText = "";
            command = new SqlCommand($"select ProductID from Product where Rf_nameflowerID = '{idd}'", db.GetConnection());
            adapter.SelectCommand = command;
            adapter.Fill(table);
            ff = table.Rows[1].Field<int>("ProductID").ToString();
            command.CommandText = "";
            command = new SqlCommand($"select price from Product where ProductID = '{ff}'", db.GetConnection());
            adapter.SelectCommand = command;
            adapter.Fill(table);
            Prise = table.Rows[2].Field<int>("Price").ToString();
        }
        string rab;
        public void checkPositionRabotnik()
        {
            db.OpenConnection();
            cbProdovec.Items.Clear();
            SqlCommand command = new SqlCommand("Select * From [Rabotnik] where rf_Dolzhnost = 1 ;", db.GetConnection());
            DataTable table = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = command;
            adapter.Fill(table);

            for (int i = 0; i < table.Rows.Count; i++)
            {
                cbProdovec.Items.Add(table.Rows[i].Field<string>("Familiya"));
            }
            command.CommandText = "";
            command = new SqlCommand("Select [RabotnikID] From [Rabotnik] Where [Familiya] = @dol", db.GetConnection());
            command.Parameters.Add("dol", SqlDbType.NVarChar).Value = cbProdovec.Text;
            table = new DataTable();
            adapter = new SqlDataAdapter();
            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
                rab = table.Rows[0].Field<int>("RabotnikID").ToString();
        }
        int index = Bank.Index;
        string pok;
        public void rfret()
        {
            
            db.OpenConnection();
            string familiya = tbP_Familaya.Text;
            string name = tbP_Name.Text;
            SqlCommand command = new SqlCommand($"select * from Buyer where Familiya = @fam and B_name = @name", db.GetConnection());
            command.Parameters.Add("fam", SqlDbType.NVarChar).Value = tbP_Familaya.Text;
            command.Parameters.Add("name", SqlDbType.NVarChar).Value = tbP_Name.Text;
            DataTable table = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = command;
            adapter.Fill(table);
            SqlCommand command1 = new SqlCommand($"update Buyer set Familiya = '{familiya}',B_name = '{name}' where BuyerID = '{index}'", db.GetConnection());
            adapter.SelectCommand = command1;
            adapter.Fill(table);
            command = new SqlCommand($"select * from Buyer where Familiya = @fam and B_name = @name", db.GetConnection());
            command.Parameters.Add("fam", SqlDbType.NVarChar).Value = tbP_Familaya.Text;
            command.Parameters.Add("name", SqlDbType.NVarChar).Value = tbP_Name.Text;
            table = new DataTable();
            adapter = new SqlDataAdapter();
            adapter.SelectCommand = command;
            adapter.Fill(table);
            if (table.Rows.Count > 0)
                pok = table.Rows[0].Field<int>("BuyerID").ToString();
            else
                MessageBox.Show("Ошибка");
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FormChengeSdelka_Load(object sender, EventArgs e)
        {
            cbNameFlower.Text = Bank.nameFlaver;
            tbPryse.Text = Bank.Pryse;
            tbKolichestvo.Text = Bank.Kolichestvo;
            tbP_Familaya.Text = Bank.Pfamiliya;
            tbP_Name.Text = Bank.Name;
            cbProdovec.Text = Bank.F_Familiya;
            tbSumm.Text = Bank.Summa;
            tbTime.Text = Bank.time;

        }

        private void cbNameFlower_SelectedIndexChanged(object sender, EventArgs e)
        {
            db.OpenConnection();
            getByu();
            tbPryse.Text = Prise;
        }
        public void vshet()
        {
            checkPositionTvar();
            int kol = Convert.ToInt32(tbKolichestvo.Text);
            int summ = kol * Convert.ToInt32(Prise);
            tbSumm.Text = summ.ToString();
        }
        private void tbKolichestvo_TextChanged(object sender, EventArgs e)
        {
            if (tbKolichestvo.Text == "")
            {
                tbSumm.Text = "";
            }
            else
            {
                vshet();
            }
        }

        private void btnCheng_Click(object sender, EventArgs e)
        {
            db.OpenConnection();
            rfret();
            checkPositionRabotnik();
            checkPositionTvar();
            int kol = Convert.ToInt32(tbKolichestvo.Text);
            int summ = kol * Convert.ToInt32(Prise);
            string time = tbTime.Text;
            SqlCommand command = new SqlCommand($"update sdelka set Rf_productID ='{ff}', Rf_buyerID = '{pok}' , Rf_RabotnikID = '{rab}' , Sdelka_data = '{time}' , Kolichestvo = '{kol}' , summa_sdelki = '{summ}' where sdelkaID = '{index}'",db.GetConnection());
            command.ExecuteNonQuery();
            Bank.formSdelka.gef();
        }

        private void btnDell_Click(object sender, EventArgs e)
        {
                db.OpenConnection();
                var index = Bank.Index;
                SqlCommand command = new SqlCommand($"delete from sdelka where sdelkaID = { index }", db.GetConnection());
                command.ExecuteNonQuery();
                Bank.formSdelka.gef();
            SqlCommand command2 = new SqlCommand($"dalete from Buyer where BuyerID = '{index}'", db.GetConnection());
            command2.ExecuteNonQuery();
                db.CloseConnection();
                this.Close();
            
        }

        private void tbKolichestvo_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8 && number != 45)
            {
                e.Handled = true;
            }
        }

        private void tbP_Familaya_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) == false) return;
            e.Handled = true;
        }

        private void tbP_Name_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) == false) return;
            e.Handled = true;
        }

        private void tbTime_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8 && number != 46 && number != 32 && number != 58)
            {
                e.Handled = true;
            }
        }
    }
}
