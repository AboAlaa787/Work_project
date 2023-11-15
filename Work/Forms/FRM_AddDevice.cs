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
    public partial class FRM_AddDevice : Form
    {
        public FRM_AddDevice()
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
                clsDevice.Add_Device(T_Model.Text, T_Imei1.Text, T_CName.Text, T_CNum.Text, T_Problem.Text, C_MentainName.SelectedItem.ToString(), T_Notes.Text);
                MessageBox.Show("تمت الاضافة بنجاح");
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

        private void FRM_AddDevice_Activated(object sender, EventArgs e)
        {
            Classes.ClassMentains clsMentain = new Classes.ClassMentains();
            DataTable dt = new DataTable();
            clsMentain.ADP_Names();
            dt = clsMentain.Read();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if(C_MentainName.Items.Contains(dt.Rows[i]["Mentain_Name"])==false)
                C_MentainName.Items.Add(dt.Rows[i]["Mentain_Name"]);
            }
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
    }
}
