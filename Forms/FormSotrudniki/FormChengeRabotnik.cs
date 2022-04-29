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
    
    public partial class FormChengeRabotnik : Form
    {
        BD bd = new BD();
        private FormSotrudniki main;
        public FormChengeRabotnik(FormSotrudniki _sender)
        {
            InitializeComponent();
            
            main = _sender;
            cbDolznost.KeyPress += (sender, e) => e.Handled = true;
        }
      

        private void FormChengeRabotnik_Load(object sender, EventArgs e)
        {
            tbFamiliya.Text = Bank.F_Familiya;
            tbName.Text = Bank.F_Name;
            tbOtchestvo.Text = Bank.F_Othcestvo;
            cbDolznost.Text = Bank.F_Dolxnost;
            tbSalary.Text = Bank.F_salary;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        int index = Bank.Index;
        private void btnDell_Click(object sender, EventArgs e)
        {
            bd.OpenConnection();
            var deleteQuery = $"delete from rabotnik where RabotnikID = {index}";

            var command = new SqlCommand(deleteQuery,bd.GetConnection());
            command.ExecuteNonQuery();
            main.RefrehsPage();
            this.Close();
            
        }

        private void btnCheng_Click(object sender, EventArgs e)
        {
            var familiya = tbFamiliya.Text;
            var neme = tbName.Text;
            var othcestvo = tbOtchestvo.Text;
            var salary = tbSalary.Text;
            var dolznost = cbDolznost.Text;
            bd.OpenConnection();
            var changeQuery = $"update rabotnik set Familiya = '{familiya}',R_name = '{neme}',Otchestvo = '{othcestvo}' where RabotnikID = '{index}'";
            var command = new SqlCommand(changeQuery,bd.GetConnection());
            var result = command.ExecuteNonQuery();
            bd.CloseConnection();
            main.Gef();
            this.Close();

        }

        private void tbSalary_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8 && number != 45)
            {
                e.Handled = true;
            }
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

        private void tbOtchestvo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) == false) return;
            e.Handled = true;
        }
    }
}
