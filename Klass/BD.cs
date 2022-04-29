using System.Data;
using System.Windows.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;



namespace Kyrsach.Klass
{

    class BD
    {

        private SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["Admin"].ConnectionString);
        public bool ValidConnection()
        {
            
            sqlConnection.Open();
            if (sqlConnection.State == ConnectionState.Open)
            {
                MessageBox.Show("");
                sqlConnection.Close();
                return true;
            }
            else
            {
                MessageBox.Show("подключения нет");
                return false;
            }
        }

        public void OpenConnection()
        {
            if (sqlConnection.State == ConnectionState.Closed)
                sqlConnection.Open();
        }

        public void CloseConnection()
        {
            if (sqlConnection.State == ConnectionState.Open)
                sqlConnection.Close();
        }

        public SqlConnection GetConnection()
        {
            return sqlConnection;
        }





    }
}


