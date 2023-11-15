using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Work.Forms
{
    public partial class FRM_EditDevice : Form
    {
        public int Id = 0,index=0;
        public FRM_EditDevice()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Forms.FRM_AddMentain addmentain = new FRM_AddMentain();
            addmentain.ShowDialog();
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void T_Model_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                T_Imei1.Focus();
            }
        }

        private void T_Imei1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                T_CName.Focus();
            }
        }

        private void T_CName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                T_CNum.Focus();
            }
        }

        private void T_CNum_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                T_Problem.Focus();
            }
        }

        private void T_Problem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                C_MentainName.Focus();
            }
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            Classes.Class_Devices clsDevice = new Classes.Class_Devices();
            if (T_Model.Text != "" && T_Imei1.Text != "" && T_CName.Text != "" && T_Problem.Text != "" && C_MentainName.SelectedItem != null)
            {
                clsDevice.Edit_Device(T_Model.Text, T_Imei1.Text, T_CName.Text, T_CNum.Text, T_Problem.Text, C_MentainName.SelectedItem.ToString(), T_Notes.Text,Id);
                MessageBox.Show("تمت التعديل بنجاح");
                this.Close();
            }
            else
            {
                MessageBox.Show("الرجاء اكمال البيانات المطلوبة");
            }
        }

        private void T_Notes_KeyDown(object sender, KeyEventArgs e)
        {
         
        }

        private void T_Imei1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void T_CNum_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void FRM_EditDevice_Activated(object sender, EventArgs e)
        {
            Classes.ClassMentains clsMentain = new Classes.ClassMentains();
            Classes.Class_Devices clsDevice = new Classes.Class_Devices();
            clsMentain.ADP_Names();
            clsDevice.ADP_Id(Id);
            DataTable dt = new DataTable();
            dt = clsMentain.Read();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (C_MentainName.Items.Contains(dt.Rows[i]["Mentain_Name"]) == false)
                    C_MentainName.Items.Add(dt.Rows[i]["Mentain_Name"]);
            }
            dt = clsDevice.Read();
            if (dt.Rows.Count != 0)
            {
                T_Model.Text = dt.Rows[0]["Device_name"].ToString();
                T_Imei1.Text = dt.Rows[0]["Device_Imei"].ToString();
                T_CName.Text = dt.Rows[0]["Coustomer_Name"].ToString();
                T_CNum.Text = dt.Rows[0]["Coustomer_Phone"].ToString();
                T_Problem.Text = dt.Rows[0]["Device_Problem"].ToString();
                C_MentainName.SelectedItem = dt.Rows[0]["Men_Name"].ToString();
                T_Notes.Text = dt.Rows[0]["Device_Info"].ToString();
            }
        }
    }
}
