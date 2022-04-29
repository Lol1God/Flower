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

namespace Kyrsach.Forms.FormPokupateli
{
    public partial class FormChengePokupateli : Form
    {
        public FormChengePokupateli()
        {
            InitializeComponent();
        }
        BD db = new BD();

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
        int index = Bank.Index;
        private void FormChengePokupateli_Load(object sender, EventArgs e)
        {
            
            tbName.Text = Bank.F_Name;
            tbFamiliya.Text = Bank.F_Familiya;
        }

        private void btnDell_Click(object sender, EventArgs e)
        {
            db.OpenConnection();
            var deleteQuery = $"delete from Buyer where BuyerID = {index}";
            var command = new SqlCommand(deleteQuery, db.GetConnection());
            command.ExecuteNonQuery();
            Bank.FormPokupateli.Gef();
            db.CloseConnection();
            this.Close();
        }

        private void btnChenge_Click(object sender, EventArgs e)
        {
            var familiya = tbFamiliya.Text;
            var neme = tbName.Text;
            db.OpenConnection();

            
            SqlCommand command = new SqlCommand($"update Buyer set Familiya = '{familiya}',B_name = '{neme}' where BuyerID = '{index}'", db.GetConnection());
            command.ExecuteNonQuery();
            db.CloseConnection();
            Bank.FormPokupateli.Gef();
            this.Close();
        }

        private void tbFamiliya_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) == false) return;
            e.Handled = true;
        }

        private void tbName_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) == false) return;
            e.Handled = true;
        }

        private void tbTelephon_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8 && number != 45)
            {
                e.Handled = true;
            }
        }
    }
}
