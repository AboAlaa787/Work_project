using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace Work.Classes
{
    class Class_DelivredDevices
    {
        SqlConnection con = new SqlConnection();
        SqlDataAdapter ADP;
        SqlCommandBuilder b1;
        DataTable table = new DataTable();
        public Class_DelivredDevices()
        {
            con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\DevicesDB.mdf;Integrated Security=True");
        }
        public void ADP_All()
        {
            ADP = new SqlDataAdapter("select * from Devices_Delivered", con);
            b1 = new SqlCommandBuilder(ADP);
            ADP.Fill(table);
        }
        public void ADP_Devices()
        {
            ADP = new SqlDataAdapter("select Id,Device_name,Device_Imei,Coustomer_Name,Coustomer_Phone,Device_Problem,Men_Name,DeviceState,Recived_Date,Delivery_Date from Devices_Delivered", con);
            b1 = new SqlCommandBuilder(ADP);
            ADP.Fill(table);
        }
        public DataTable Read()
        {
            return table;
        }
        public void Add_Device(int id)
        {
            con.Open();
            ADP_All();
            Classes.Class_Devices clsDevice = new Class_Devices();
            clsDevice.ADP_Id(id);
            DataTable dt = clsDevice.Read();
            SqlCommand AddDevice = new SqlCommand("insert into Devices_Delivered (Device_name,Device_Imei,Coustomer_Name,Coustomer_Phone,Device_Problem,Men_Name,DeviceState,Recived_Date,Device_Info,Delivery_Date) values('" + dt.Rows[0]["Device_name"] + "','" + dt.Rows[0]["Device_Imei"] + "',N'" + dt.Rows[0]["Coustomer_Name"] + "','" + dt.Rows[0]["Coustomer_Phone"] + "',N'" + dt.Rows[0]["Device_Problem"] + "',N'" + dt.Rows[0]["Men_Name"] + "',N'"+dt.Rows[0]["Ok_State"] +"','"+ dt.Rows[0]["Date"] + "',N'" + dt.Rows[0]["Device_Info"] + "',GETDATE())", con);
            AddDevice.ExecuteNonQuery();
            ADP.Update(table);
            con.Close();
        }
        public void Search(string SreachBox)
        {
            ADP = new SqlDataAdapter("select Id,Device_name,Device_Imei,Coustomer_Name,Coustomer_Phone,Device_Problem,Men_Name,DeviceState,Recived_Date,Delivery_Date from Devices_Delivered where concat(Device_name,Device_Imei,Coustomer_Name) like N'%" + SreachBox + "%'", con);
            b1 = new SqlCommandBuilder(ADP);
            ADP.Fill(table);
        }
        public void ADP_Id(int id)
        {
            ADP = new SqlDataAdapter("select * from Devices_Delivered where Id=" + id, con);
            b1 = new SqlCommandBuilder(ADP);
            ADP.Fill(table);
        }
        public void EditStateToUnOk(int id)
        {
            con.Open();
            ADP_All();
            SqlCommand edit = new SqlCommand("update Devices_Delivered set DeviceState=N'غير جاهز' where Id="+id, con);
            edit.ExecuteNonQuery();
            ADP.Update(table);
            con.Close();
        }
        public void EditStateToOk(int id)
        {
            con.Open();
            ADP_All();
            SqlCommand edit = new SqlCommand("update Devices_Delivered set DeviceState=N'جاهز' where Id=" + id, con);
            edit.ExecuteNonQuery();
            ADP.Update(table);
            con.Close();
        }
        public void ViewByDate(string dateBegin,string dateEnd)
        {
            ADP = new SqlDataAdapter("select Id,Device_name,Device_Imei,Coustomer_Name,Coustomer_Phone,Device_Problem,Men_Name,DeviceState,Recived_Date,Delivery_Date from Devices_Delivered where Delivery_Date between '" + dateBegin+"' and '"+dateEnd+"' ", con);
            b1 = new SqlCommandBuilder(ADP);
            ADP.Fill(table);
        }
    }
}
