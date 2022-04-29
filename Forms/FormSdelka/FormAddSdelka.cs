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
using Kyrsach.Klass;
using System.Threading;

namespace Kyrsach.Forms.FormSdelka
{
    public partial class FormAddSdelka : Form
    {
        BD db = new BD();
        public FormAddSdelka()
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
            cbNameFlower.Focus();
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

           

            db.CloseConnection();
        }
        string Product;
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
            Product = table.Rows[1].Field<int>("ProductID").ToString();
            command.CommandText = "";
            command = new SqlCommand($"select price from Product where ProductID = '{Product}'", db.GetConnection());
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
            SqlCommand command1 = new SqlCommand($"insert into Buyer(Familiya,B_name) values('{familiya}','{name}')", db.GetConnection());
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
        string koli;
        int kolich;
        public void prov()
        {
            
            getByu();
            checkPositionTvar();
            kolich = Convert.ToInt32(tbKolichestvo.Text);
            db.OpenConnection();
            SqlCommand command = new SqlCommand($"select Kolichestvo from Product where ProductID = '{Product}' ", db.GetConnection());
            DataTable table = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand= command;
            adapter.Fill(table);
            if (table.Rows.Count > 0)
                koli = table.Rows[0].Field<int>("Kolichestvo").ToString();
            
        }
        private void btnChenge_Click(object sender, EventArgs e)
        {
            prov();
            if (kolich > Convert.ToInt32(koli))
            {
                MessageBox.Show("Колличество выбранных цветов привешает количество на складе", "Ошибка");
            }
            else
            {

                int kk = Convert.ToInt32(koli) - kolich;
                db.OpenConnection();

                int kol = Convert.ToInt32(tbKolichestvo.Text);
                int summ = kol * Convert.ToInt32(Prise);

                checkPositionRabotnik();
                checkPositionTvar();
                vshet();
                rfret();
                db.OpenConnection();
                var time = tbTime.Text;
                SqlCommand command = new SqlCommand($"insert into sdelka(Rf_productID,Rf_buyerID,Rf_RabotnikID,Sdelka_data,Kolichestvo,summa_sdelki) values('{Product}','{pok}','{rab}','{time}','{kol}','{summ}')", db.GetConnection());
                command.ExecuteNonQuery();
                //$"update sdelka set Rf_productID ='{ff}', Rf_buyerID = '{pok}' , Rf_RabotnikID = '{rab}' , Sdelka_data = '{time}' , Kolichestvo = '{kol}' , summa_sdelki = '{summ}' where sdelkaID = '{index}'",db.GetConnection())
                SqlCommand command1 = new SqlCommand($"update product set Kolichestvo = '{kk}' where productID = '{Product}' ",db.GetConnection());
                command1.ExecuteNonQuery();
                MessageBox.Show("Запись успешно созданна");
                Bank.formSdelka.gef();
                Close();
            }
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cbNameFlower_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void cbNameFlower_KeyDown(object sender, KeyEventArgs e)
        {
            if(cbNameFlower.Focus() == true)
            {
            if(e.KeyCode == Keys.Enter)
                tbKolichestvo.Focus();
            }
            
        }

        private void tbKolichestvo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                tbP_Familaya.Focus();
        }

        private void tbP_Name_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
                tbP_Name.Focus();
        }

        private void cbProdovec_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                tbTime.Focus();
        }

        private void tbP_Familaya_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                tbP_Name.Focus();
        }

        private void tbKolichestvo_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if(!Char.IsDigit(number) && number != 8 && number != 45)
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
