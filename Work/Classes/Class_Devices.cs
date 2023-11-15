using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Work.Classes
{
    internal class Class_Devices
    {
        SqlConnection con;
        SqlDataAdapter ADP;
        SqlCommandBuilder b1;
        DataTable table=new DataTable();
        public Class_Devices()
        {
            con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\DevicesDB.mdf;Integrated Security=True");
        }
        public void ADP_All()
        {
            ADP = new SqlDataAdapter("select * from Devices", con);
            b1 = new SqlCommandBuilder(ADP);
            ADP.Fill(table);
        }
        public void ADP_Devices()
        {
            ADP = new SqlDataAdapter("select Id,Device_name,Device_Imei,Coustomer_Name,Coustomer_Phone,Device_Problem,Men_Name,Ok_State,Date from Devices", con);
            b1 = new SqlCommandBuilder(ADP);
            if (table.Rows.Count != 0) table.Clear();
            ADP.Fill(table);
        }
        public DataTable Read()
        {
            return table;
        }
        public void Add_Device(string DeviceName, string imei, string CName, string CNum, string DeviceProblem , string MName,string Notes)
        {
            con.Open();
            ADP_All();
            SqlCommand AddDevice = new SqlCommand("insert into Devices (Device_name,Device_Imei,Coustomer_Name,Coustomer_Phone,Device_Problem,Men_Name,Ok_State,Date,Device_Info) values('" + DeviceName + "','" + imei + "',N'" + CName + "','" + CNum + "',N'" + DeviceProblem + "',N'" + MName + "',N'غير جاهز',GETDATE(),N'"+Notes+"')", con);
            AddDevice.ExecuteNonQuery();
            ADP.Update(table);
            con.Close();
        }
        public void Search(string SreachBox)
        {
            ADP = new SqlDataAdapter("select Id,Device_name,Device_Imei,Coustomer_Name,Coustomer_Phone,Device_Problem,Men_Name,Ok_State,Date from Devices where concat(Device_name,Device_Imei,Coustomer_Name) like N'%" + SreachBox + "%'", con);
            b1 = new SqlCommandBuilder(ADP);
            ADP.Fill(table);
        }
        public void Edit_Device(string DeviceName, string imei, string CName, string CNum, string DeviceProblem, string MName, string Notes,int id)
        {
            con.Open();
            ADP_All();
            SqlCommand AddDevice = new SqlCommand("update Devices  set Device_name='" + DeviceName + "',Device_Imei='" + imei + "',Coustomer_Name=N'" + CName + "',Coustomer_Phone='" + CNum + "',Device_Problem=N'" + DeviceProblem + "',Men_Name=N'" + MName + "',Device_Info=N'" + Notes + "' where Id="+id, con);
            AddDevice.ExecuteNonQuery();
            ADP.Update(table);
            con.Close();
        }
        public void ADP_Id(int id)
        {
            ADP = new SqlDataAdapter("select * from Devices where Id="+id, con);
            b1 = new SqlCommandBuilder(ADP);
            ADP.Fill(table);
        }
        public void ADP_Filter(string name)
        {
            ADP = new SqlDataAdapter("select Id,Device_name,Device_Imei,Coustomer_Name,Coustomer_Phone,Device_Problem,Men_Name,Ok_State,Date from Devices where Men_Name=N'"+name+"'", con);
            b1 = new SqlCommandBuilder(ADP);
            ADP.Fill(table);
        }
        public void Device_Ok(int id)
        {
            con.Open();
            ADP_All();
            SqlCommand AddDevice = new SqlCommand("update Devices set Ok_State=N'جاهز' where Id=" + id, con);
            AddDevice.ExecuteNonQuery();
            ADP.Update(table);
            con.Close();
        }
        public void EditStateToUnOk(int id)
        {
            con.Open();
            ADP_All();
            SqlCommand edit = new SqlCommand("update Devices set Ok_State=N'غير جاهز' where Id=" + id, con);
            edit.ExecuteNonQuery();
            ADP.Update(table);
            con.Close();
        }
        public void EditStateToCantBeFixed(int id)
        {
            con.Open();
            ADP_All();
            SqlCommand edit = new SqlCommand("update Devices set Ok_State=N'لا يصلّح' where Id=" + id, con);
            edit.ExecuteNonQuery();
            ADP.Update(table);
            con.Close();
        }
        public void Del_Device(int id)
        {
            con.Open();
            ADP_All();
            SqlCommand AddDevice = new SqlCommand("delete from Devices where Id=" + id, con);
            AddDevice.ExecuteNonQuery();
            ADP.Update(table);
            con.Close();
        }
      
    }
}
