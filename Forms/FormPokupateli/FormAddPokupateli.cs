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

namespace Kyrsach.Forms.FormPokupateli
{
    public partial class FormAddPokupateli : Form
    {
        BD db = new BD();
        public FormAddPokupateli()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAddPokupateli_Click(object sender, EventArgs e)
        {
            db.OpenConnection();
            string Name = tbName.Text;
            string Familiya = tbFamiliya.Text;
            
            var addQuery = $"insert into Buyer (B_name,Familiya,Telephone) values('{Name}','{Familiya}')";
            var command = new SqlCommand(addQuery, db.GetConnection());
            command.ExecuteNonQuery();
            Bank.FormPokupateli.Gef();
            MessageBox.Show("Запись успешно создана!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            db.CloseConnection();
            Close();
        }

        private void tbFamiliya_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) == false) return;
            e.Handled = true;
        }

        private void tbName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) == false) return;
            e.Handled = true;
        }

        private void tbTelephon_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8 && number != 45)
            {
                e.Handled = true;
            }
        }
    }
}
