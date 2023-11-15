using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Work.Classes
{
    class Class_Query
    {
        SqlConnection con = new SqlConnection();
        SqlDataAdapter ADP;
        SqlCommandBuilder b1;
        DataTable table = new DataTable();
        public Class_Query()
        {
            con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\DevicesDB.mdf;Integrated Security=True");
            ADP = new SqlDataAdapter();
        }
        public DataTable Query(string query)
        {
            SqlCommand queryE = new SqlCommand();
            con.Open();
            queryE.CommandText = query;
            queryE.Connection = con;
            ADP.SelectCommand = queryE;
            try
            {
                table.Clear();
                ADP.Fill(table);
                return table;
            }
            catch
            {
                return table;
            }
            con.Close();
        }
    }
}
