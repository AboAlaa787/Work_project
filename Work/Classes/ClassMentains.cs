using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Work.Classes
{
    class ClassMentains
    {
        SqlConnection con = new SqlConnection();
        SqlDataAdapter ADP;
        SqlCommandBuilder b1;
        DataTable table = new DataTable();
        public ClassMentains()
        {
            con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\DevicesDB.mdf;Integrated Security=True");
        }
        public void ADP_All()
        {
            ADP = new SqlDataAdapter("select * from Mentains", con);
            b1 = new SqlCommandBuilder(ADP);
            ADP.Fill(table);
        }
        public void ADP_Names()
        {
            ADP = new SqlDataAdapter("select Mentain_Name from Mentains", con);
            b1 = new SqlCommandBuilder(ADP);
            ADP.Fill(table);
        }
        public DataTable Read()
        {
            return table;
        }
        public void Add_Mentain(string name)
        {
            con.Open();
            ADP_All();
            SqlCommand add = new SqlCommand("insert into Mentains (Mentain_Name) values(N'"+name+"')", con);
            add.ExecuteNonQuery();
            ADP.Update(table);
            con.Close();
        }
        public void DeleteMen(int id)
        {
            con.Open();
            ADP_All();
            SqlCommand Del = new SqlCommand("delete from Mentains where Id="+id, con);
            Del.ExecuteNonQuery();
            ADP.Update(table);
            con.Close();
        }
    }
}
