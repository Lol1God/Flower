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

namespace Kyrsach.Forms.FormProducts
{
    public partial class FormChengeProduct : Form
    {
        BD db = new BD();
        public FormChengeProduct()
        {
            
            InitializeComponent();
            Init();
            cbNalicie.KeyPress += (sender, e) => e.Handled = true;
            cbProvider.KeyPress += (sender, e) => e.Handled = true;
            cbTovar.KeyPress += (sender, e) => e.Handled = true;
        }
        public void Init()
        {
            checkPositionProvider();
            checkPositionTvar();
        }
        string Provider = "";
        string Tovar = "";
        public void checkPositionProvider()
        {
            db.OpenConnection();
            cbProvider.Items.Clear();
            SqlCommand command = new SqlCommand("Select * From [P_Provider];", db.GetConnection());
            DataTable table = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = command;
            adapter.Fill(table);

            for (int i = 0; i < table.Rows.Count; i++)
            {
                cbProvider.Items.Add(table.Rows[i].Field<string>("NameProvider"));
            }
            command.CommandText = "";
            command = new SqlCommand("Select [ProviderID] From [P_provider] Where [NameProvider] = @dol", db.GetConnection());
            command.Parameters.Add("dol", SqlDbType.NVarChar).Value = cbProvider.Text;
            table = new DataTable();
            adapter = new SqlDataAdapter();
            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
                Provider = table.Rows[0].Field<int>("ProviderID").ToString();
            db.CloseConnection();
        }
        public void checkPositionTvar()
        {
            db.OpenConnection();
            cbTovar.Items.Clear();
            SqlCommand command = new SqlCommand("Select * From [Flowertype];", db.GetConnection());
            DataTable table = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = command;
            adapter.Fill(table);

            for (int i = 0; i < table.Rows.Count; i++)
            {
                cbTovar.Items.Add(table.Rows[i].Field<string>("Nameflower"));
            }
            command.CommandText = "";
            command = new SqlCommand("Select [NameflowerID] From [Flowertype] Where [Nameflower] = @dol", db.GetConnection());
            command.Parameters.Add("dol", SqlDbType.NVarChar).Value = cbTovar.Text;
            table = new DataTable();
            adapter = new SqlDataAdapter();
            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
                Tovar = table.Rows[0].Field<int>("NameflowerID").ToString();
            db.CloseConnection();
        }
        

        private void btnDell_Click(object sender, EventArgs e)
        {
            db.OpenConnection();
            var index = Bank.Index;
            var deleteQuery = $"delete from Product where ProductID = {index}";
            var command = new SqlCommand(deleteQuery, db.GetConnection());
            command.ExecuteNonQuery();
            Bank.FormProduct.gef();
            db.CloseConnection();
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FormChengeProduct_Load(object sender, EventArgs e)
        {
            cbTovar.Text = Bank.F_Name;
            tbKolichestvo.Text = Bank.Kolichestvo;
            tbPryse.Text = Bank.Pryse;
            tbPostavki.Text = Bank.Date;
            cbProvider.Text = Bank.Provider;
            cbNalicie.Text = Bank.Key;
        }
        
        private void btnCheng_Click(object sender, EventArgs e)
        {
            checkPositionProvider();
            checkPositionTvar();
            var index = Bank.Index;
            var Name = Bank.F_Name;
            var Kolichestvo = Bank.Kolichestvo;
            var Pryse = Bank.Pryse;
            var Date = Bank.Date;
            var tovar = Tovar;
            var provider = Provider;
            var key = cbNalicie.Text;
            db.OpenConnection();
            var changeQuery = $"update Product set Rf_nameflowerID = '{tovar}',Kolichestvo = '{Kolichestvo}',Price = '{Pryse}',Delivery_date = '{Date}',Rf_ProviderID = '{provider}',nalichie = '{key}'  where ProductID = '{index}'";
            var command = new SqlCommand(changeQuery, db.GetConnection());
            command.ExecuteNonQuery();
            MessageBox.Show("Запись успешно изменена!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Bank.FormProduct.gef();
            db.CloseConnection();
            this.Close();
        }


        private void tbKolichestvo_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8 && number != 45)
            {
                e.Handled = true;
            }
        }

        private void tbPryse_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8 && number != 45)
            {
                e.Handled = true;
            }
        }

        private void tbPostavki_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8 && number != 46)
            {
                e.Handled = true;
            }
        }
    }
}
