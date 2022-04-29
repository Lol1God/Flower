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

namespace Kyrsach.Forms.FormProducts
{
    public partial class FormAddProduct : Form
    {
        BD db = new BD();
        public FormAddProduct()
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
            checkPositionTvar(cbTovar);

        }
        string tovar = "";
        
        public void checkPositionTvar(ComboBox box)
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
                box.Items.Add(table.Rows[i].Field<string>("Nameflower"));
            }
            command.CommandText = "";
             command = new SqlCommand("Select [NameflowerID] From [Flowertype] Where [Nameflower] = @dol", db.GetConnection());
            command.Parameters.Add("dol", SqlDbType.NVarChar).Value = cbTovar.Text;
             table = new DataTable();
             adapter = new SqlDataAdapter();
            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
                tovar = table.Rows[0].Field<int>("NameflowerID").ToString();
            db.CloseConnection();
        }
        string provider = "";
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
                provider = table.Rows[0].Field<int>("ProviderID").ToString();
            db.CloseConnection();
        }
        
        private void FormAddProduct_Load(object sender, EventArgs e)
        {
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bntAdd_Click(object sender, EventArgs e)
        {
            checkPositionProvider();
            checkPositionTvar(cbTovar);
            var Pryse = tbPryse.Text;
            string Postavki = tbPostavki.Text;
            var nalichie = cbNalicie.Text;
            var kol = tbKolichestvo.Text;
            db.OpenConnection();
            var addQuery = $"insert into Product (Rf_nameflowerID,Kolichestvo,Price,Delivery_date,Rf_ProviderID,Nalichie) values('{tovar}','{kol}','{Pryse}','{Postavki}','{provider}','{nalichie}')";
                    var command = new SqlCommand(addQuery, db.GetConnection());
                    command.ExecuteNonQuery();
                    MessageBox.Show("Запись успешно создана!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            db.CloseConnection();
            Bank.FormProduct.gef();
            Close();
            

        }

        private void tbKolichestvo_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8 && number != 45)
            {
                e.Handled = true;
            }
        }

        private void tbPryse_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8 && number != 45)
            {
                e.Handled = true;
            }
        }

        private void tbPostavki_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8 && number != 46)
            {
                e.Handled = true;
            }
        }
    }
}
