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
    public partial class FormProduct : Form
    {
        BD bd = new BD();
        public FormProduct()
        {
            InitializeComponent();
        }
        private void CreateColumns()
        {
            dataGridView1.Columns.Add("ProductID", "Id");
            dataGridView1.Columns.Add("Nameflower", "Название");
            dataGridView1.Columns.Add("Price", "Цена");
            dataGridView1.Columns.Add("Delivery_date", "Дата поставки");
            dataGridView1.Columns.Add("NameProvider", "Поставщик");
            dataGridView1.Columns.Add("Nalichiet", "Наличие");
            
            
        }
        private void ReadSingleRow(DataGridView dgv, IDataRecord record)
        {
            dgv.Rows.Add(record.GetInt32(0), record.GetString(1), record.GetInt32(2), record.GetData(3), record.GetString(4), record.GetString(5));
        }
        private void RefreshDataGridView(DataGridView dvg)
        {
            dvg.Rows.Clear();
            string zapros = $"select p.ProductID,f.Nameflower, p.Price, p.Delivery_date,pp.NameProvider,p.Nalichie from Product p inner join Flowertype f on p.Rf_nameflowerID = f.NameflowerID inner join P_provider pp on f.Rf_p_provider = pp.ProviderID";
            SqlCommand Command = new SqlCommand(zapros, bd.GetConnection());
            bd.OpenConnection();
            SqlDataReader reader = Command.ExecuteReader();
            while (reader.Read())
            {
                ReadSingleRow(dvg, reader);
            }
            reader.Close();
        }
        public void RefrehsPage()
        {
            dataGridView1.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            CreateColumns();
            RefreshDataGridView(dataGridView1);
        }
        private void FormProduct_Load(object sender, EventArgs e)
        {
       
        }

        private void FormProduct_Load(object sender, EventArgs e, SqlCommand sqlCommand)
        {
            RefrehsPage();
        }
    }
}
