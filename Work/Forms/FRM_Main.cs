using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Work.Forms
{
    public partial class FRM_Main : Form
    {
        static Classes.Class_Devices clsDevices = new Classes.Class_Devices();
        Thread thread = new Thread(conn);
        static int count = 1;
        static string state = "";
        static int ThreadState = 1;
        public static void conn()
        {
            clsDevices.ADP_Devices();
        }
        public FRM_Main()
        {
            InitializeComponent();

        }

        private Point newpoint;
        private int xpos1, ypos1;
        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal) { this.WindowState = FormWindowState.Maximized; }
            else
                this.WindowState = FormWindowState.Normal;
        }

        private void bunifuImageButton3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void B_All_Click(object sender, EventArgs e)
        {
            if (ThreadState == 2) conn();
            L_Title.Text = "الجرد";
            state = "All";
            thread.Join();
            DGV_All.DataSource = clsDevices.Read();
            bunifuMaterialTextbox1.Text = "";
            P_Start.Visible = false;
            P_View.Visible = true;
            P_Filter.Visible = false;
            P_Mentainens.Visible = false;
            P_Ok.Visible = false;
            //Classes.Class_Devices clsDevices = new Classes.Class_Devices();
            //clsDevices.ADP_Devices();
            //DGV_All.DataSource = clsDevices.Read();
            DGV_All.Columns[0].HeaderText = "ID";
            DGV_All.Columns[1].HeaderText = "الموديل";
            DGV_All.Columns[2].HeaderText = "Imei";
            DGV_All.Columns[3].HeaderText = "اسم الزبون";
            DGV_All.Columns[4].HeaderText = "رقم الزبون";
            DGV_All.Columns[5].HeaderText = "مشكلة الجهاز";
            DGV_All.Columns[6].HeaderText = "اسم الفني";
            DGV_All.Columns[7].HeaderText = "حالة الجهاز";
            DGV_All.Columns[8].HeaderText = "تاريخ الاستلام";
            ThreadState = 2;
        }

        private void B_Ok_Click(object sender, EventArgs e)
        {
            P_Start.Visible = false;
            L_Title.Text = "تم التسليم";
            state = "Delivered";
            P_View.Visible = false;
            P_Filter.Visible = false;
            P_Ok.Visible = true;
            P_Mentainens.Visible = false;
            bunifuMaterialTextbox2.Text = "";
            Classes.Class_DelivredDevices clsDelivery = new Classes.Class_DelivredDevices();
            clsDelivery.ViewByDate(dateTimePicker1.Value.ToString(), dateTimePicker2.Value.ToString());
            DGV_Ok.DataSource = clsDelivery.Read();
            DGV_Ok.Columns[0].HeaderText = "ID";
            DGV_Ok.Columns[1].HeaderText = "الموديل";
            DGV_Ok.Columns[2].HeaderText = "Imei";
            DGV_Ok.Columns[3].HeaderText = "اسم الزبون";
            DGV_Ok.Columns[4].HeaderText = "رقم الزبون";
            DGV_Ok.Columns[5].HeaderText = "مشكلة الجهاز";
            DGV_Ok.Columns[6].HeaderText = "اسم الفني";
            DGV_Ok.Columns[7].HeaderText = "حالة التسليم";
            DGV_Ok.Columns[8].HeaderText = "تاريخ الاستلام";
            DGV_Ok.Columns[9].HeaderText = "تاريخ التسليم";
        }

        private void B_Filter_Click(object sender, EventArgs e)
        {
            P_Start.Visible = false;
            L_Title.Text = "الفلترة";
            P_View.Visible = false;
            P_Filter.Visible = true;
            P_Mentainens.Visible = false;
            P_Ok.Visible = false;
            Classes.ClassMentains clsmentain = new Classes.ClassMentains();
            clsmentain.ADP_Names();
            DataTable dt = clsmentain.Read();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (comboBox1.Items.Contains(dt.Rows[i]["Mentain_Name"]) == false)
                    comboBox1.Items.Add(dt.Rows[i]["Mentain_Name"]);
            }
        }

        private void bunifuImageButton4_Click(object sender, EventArgs e)
        {
            if (P_Right.Width == 167)
            {
                P_Right.Width = 70;
                B_All.RightToLeft = RightToLeft.No;
                B_Filter.RightToLeft = RightToLeft.No;
                B_Ok.RightToLeft = RightToLeft.No;
                B_Mentainens.RightToLeft = RightToLeft.No;
                pictureBox1.Width = 70;
                pictureBox1.Height = 60;
            }
            else
            {
                P_Right.Width = 167;
                B_All.RightToLeft = RightToLeft.Yes;
                B_Filter.RightToLeft = RightToLeft.Yes;
                B_Ok.RightToLeft = RightToLeft.Yes;
                B_Mentainens.RightToLeft = RightToLeft.Yes;
                pictureBox1.Width = 161;
                pictureBox1.Height = 120;
            }
        }

        private void P_Right_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FRM_Main_Activated(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Forms.FRM_AddDevice frmAddDevice = new FRM_AddDevice();
            frmAddDevice.ShowDialog();
        }

        private void bunifuMaterialTextbox1_OnValueChanged(object sender, EventArgs e)
        {
            if (bunifuMaterialTextbox1.Text != "")
            {
                Classes.Class_Devices clsDevices = new Classes.Class_Devices();
                clsDevices.Search(bunifuMaterialTextbox1.Text);
                DGV_All.DataSource = clsDevices.Read();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Forms.FRM_EditDevice frmEdit = new FRM_EditDevice();
            if (DGV_All.Rows.Count != 0)
                frmEdit.Id = int.Parse(DGV_All.CurrentRow.Cells[0].Value.ToString());
            frmEdit.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Forms.FRM_Info frmInfo = new FRM_Info();
            frmInfo.state = "All";
            if (DGV_All.Rows.Count != 0)
                frmInfo.Id = int.Parse(DGV_All.CurrentRow.Cells[0].Value.ToString());
            frmInfo.ShowDialog();
        }

        private void P_Top_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                newpoint = Control.MousePosition;
                newpoint.X -= xpos1;
                newpoint.Y -= ypos1;
                this.Location = newpoint;
            }
        }

        private void FRM_Main_Load(object sender, EventArgs e)
        {
            thread.Start();
            timer1.Enabled = true;
        }

        private void bunifuMaterialTextbox2_OnValueChanged(object sender, EventArgs e)
        {
            if (bunifuMaterialTextbox2.Text != "")
            {
                Classes.Class_DelivredDevices clsDelivred = new Classes.Class_DelivredDevices();
                clsDelivred.Search(bunifuMaterialTextbox2.Text);
                DGV_Ok.DataSource = clsDelivred.Read();
            }
        }

        private void bunifuMaterialTextbox3_OnValueChanged(object sender, EventArgs e)
        {
            Classes.Class_Devices clsDevices = new Classes.Class_Devices();
            DGV_Filter.DataSource = clsDevices.Read();
            DGV_Filter.Columns[0].HeaderText = "ID";
            DGV_Filter.Columns[1].HeaderText = "الموديل";
            DGV_Filter.Columns[2].HeaderText = "Imei";
            DGV_Filter.Columns[3].HeaderText = "اسم الزبون";
            DGV_Filter.Columns[4].HeaderText = "رقم الزبون";
            DGV_Filter.Columns[5].HeaderText = "مشكلة الجهاز";
            DGV_Filter.Columns[6].HeaderText = "اسم الفني";
            DGV_Filter.Columns[7].HeaderText = "حالة الجهاز";
            DGV_Filter.Columns[8].HeaderText = "تاريخ الاستلام";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (DGV_All.Rows.Count != 0)
            {
                Classes.Class_Devices clsDevices = new Classes.Class_Devices();
                Classes.Class_DelivredDevices clsDeliverd = new Classes.Class_DelivredDevices();
                clsDeliverd.Add_Device(int.Parse(DGV_All.CurrentRow.Cells[0].Value.ToString()));
                clsDevices.Del_Device(int.Parse(DGV_All.CurrentRow.Cells[0].Value.ToString()));
                MessageBox.Show("تم التسليم");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (DGV_All.Rows.Count != 0)
            {
                Classes.Class_Devices clsDevices = new Classes.Class_Devices();
                clsDevices.Device_Ok(int.Parse(DGV_All.CurrentRow.Cells[0].Value.ToString()));
                MessageBox.Show("الجهاز جاهز");
                DGV_All.CurrentRow.Cells[7].Value = "جاهز";
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Classes.Class_Devices clsDevices = new Classes.Class_Devices();
            clsDevices.ADP_Filter(comboBox1.SelectedItem.ToString());
            DGV_Filter.DataSource = clsDevices.Read();
            DGV_Filter.Columns[0].HeaderText = "ID";
            DGV_Filter.Columns[1].HeaderText = "الموديل";
            DGV_Filter.Columns[2].HeaderText = "Imei";
            DGV_Filter.Columns[3].HeaderText = "اسم الزبون";
            DGV_Filter.Columns[4].HeaderText = "رقم الزبون";
            DGV_Filter.Columns[5].HeaderText = "مشكلة الجهاز";
            DGV_Filter.Columns[6].HeaderText = "اسم الفني";
            DGV_Filter.Columns[7].HeaderText = "حالة الجهاز";
            DGV_Filter.Columns[8].HeaderText = "تاريخ الاستلام";
        }

        private void B_Mentainens_Click(object sender, EventArgs e)
        {
            P_Start.Visible = false;
            L_Title.Text = "طاقم العمال";
            P_Filter.Visible = false;
            P_Ok.Visible = false;
            P_View.Visible = false;
            P_Mentainens.Visible = true;
            state = "Men";
            Classes.ClassMentains clsMen = new Classes.ClassMentains();
            clsMen.ADP_All();
            DGV_Mentainens.DataSource = clsMen.Read();
            DGV_Mentainens.Columns[0].HeaderText = "ID";
            DGV_Mentainens.Columns[1].HeaderText = "اسم الفني";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Forms.FRM_AddMentain frmMen = new FRM_AddMentain();
            frmMen.ShowDialog();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (DGV_Mentainens.Rows.Count != 0)
            {
                Classes.ClassMentains clsMen = new Classes.ClassMentains();
                clsMen.DeleteMen(int.Parse(DGV_Mentainens.CurrentRow.Cells[0].Value.ToString()));
                MessageBox.Show("تم الحذف بنجاح");
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Forms.FRM_Info frmInfo = new FRM_Info();
            frmInfo.state = "Delivry";
            if (DGV_Ok.Rows.Count != 0)
                frmInfo.Id = int.Parse(DGV_Ok.CurrentRow.Cells[0].Value.ToString());
            frmInfo.ShowDialog();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void P_Top_DoubleClick(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal) { this.WindowState = FormWindowState.Maximized; }
            else
                this.WindowState = FormWindowState.Normal;
        }

        private void DGV_All_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            L_Count.Text = DGV_All.Rows.Count.ToString();
        }

        private void DGV_All_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            L_Count.Text = DGV_All.Rows.Count.ToString();
        }

        private void DGV_Ok_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            L_CountOk.Text = DGV_Ok.Rows.Count.ToString();
        }

        private void DGV_Ok_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            L_CountOk.Text = DGV_Ok.Rows.Count.ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Classes.Class_DelivredDevices clsDelivred = new Classes.Class_DelivredDevices();
            clsDelivred.EditStateToUnOk(Convert.ToInt32(DGV_Ok.CurrentRow.Cells[0].Value));
            MessageBox.Show("تم التعديل");
            DGV_Ok.CurrentRow.Cells[7].Value = "غير جاهز";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Classes.Class_DelivredDevices clsDelivred = new Classes.Class_DelivredDevices();
            clsDelivred.EditStateToOk(Convert.ToInt32(DGV_Ok.CurrentRow.Cells[0].Value));
            MessageBox.Show("تم التعديل");
            DGV_Ok.CurrentRow.Cells[7].Value = "جاهز";
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            Classes.Class_DelivredDevices clsDel = new Classes.Class_DelivredDevices();
            clsDel.ViewByDate(dateTimePicker1.Value.ToString(), dateTimePicker2.Value.ToString());
            DGV_Ok.DataSource = clsDel.Read();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            Classes.Class_DelivredDevices clsDel = new Classes.Class_DelivredDevices();
            clsDel.ViewByDate(dateTimePicker1.Value.ToString(), dateTimePicker2.Value.ToString());
            DGV_Ok.DataSource = clsDel.Read();
        }

        private void FRM_Main_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void DGV_All_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                if (state == "All")
                {
                    Classes.Class_Devices clsDevices = new Classes.Class_Devices();
                    clsDevices.ADP_Devices();
                    DGV_All.DataSource = clsDevices.Read();
                    DGV_All.Columns[0].HeaderText = "ID";
                    DGV_All.Columns[1].HeaderText = "الموديل";
                    DGV_All.Columns[2].HeaderText = "Imei";
                    DGV_All.Columns[3].HeaderText = "اسم الزبون";
                    DGV_All.Columns[4].HeaderText = "رقم الزبون";
                    DGV_All.Columns[5].HeaderText = "مشكلة الجهاز";
                    DGV_All.Columns[6].HeaderText = "اسم الفني";
                    DGV_All.Columns[7].HeaderText = "حالة الجهاز";
                    DGV_All.Columns[8].HeaderText = "تاريخ الاستلام";
                }
                if (state == "Men")
                {
                    Classes.ClassMentains clsMen = new Classes.ClassMentains();
                    clsMen.ADP_All();
                    DGV_Mentainens.DataSource = clsMen.Read();
                    DGV_Mentainens.Columns[0].HeaderText = "ID";
                    DGV_Mentainens.Columns[1].HeaderText = "اسم الفني";
                }
                if (state == "Delivered")
                {
                    P_View.Visible = false;
                    P_Filter.Visible = false;
                    P_Ok.Visible = true;
                    P_Mentainens.Visible = false;
                    Classes.Class_DelivredDevices clsDelivery = new Classes.Class_DelivredDevices();
                    clsDelivery.ViewByDate(dateTimePicker1.Value.ToString(), dateTimePicker2.Value.ToString());
                    DGV_Ok.DataSource = clsDelivery.Read();
                    DGV_Ok.Columns[0].HeaderText = "ID";
                    DGV_Ok.Columns[1].HeaderText = "الموديل";
                    DGV_Ok.Columns[2].HeaderText = "Imei";
                    DGV_Ok.Columns[3].HeaderText = "اسم الزبون";
                    DGV_Ok.Columns[4].HeaderText = "رقم الزبون";
                    DGV_Ok.Columns[5].HeaderText = "مشكلة الجهاز";
                    DGV_Ok.Columns[6].HeaderText = "اسم الفني";
                    DGV_Ok.Columns[7].HeaderText = "حالة التسليم";
                    DGV_Ok.Columns[8].HeaderText = "تاريخ الاستلام";
                    DGV_Ok.Columns[9].HeaderText = "تاريخ التسليم";
                }
            }
        }

        private void DGV_Ok_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                if (state == "All")
                {
                    Classes.Class_Devices clsDevices = new Classes.Class_Devices();
                    clsDevices.ADP_Devices();
                    DGV_All.DataSource = clsDevices.Read();
                    DGV_All.Columns[0].HeaderText = "ID";
                    DGV_All.Columns[1].HeaderText = "الموديل";
                    DGV_All.Columns[2].HeaderText = "Imei";
                    DGV_All.Columns[3].HeaderText = "اسم الزبون";
                    DGV_All.Columns[4].HeaderText = "رقم الزبون";
                    DGV_All.Columns[5].HeaderText = "مشكلة الجهاز";
                    DGV_All.Columns[6].HeaderText = "اسم الفني";
                    DGV_All.Columns[7].HeaderText = "حالة الجهاز";
                    DGV_All.Columns[8].HeaderText = "تاريخ الاستلام";
                }
                if (state == "Men")
                {
                    Classes.ClassMentains clsMen = new Classes.ClassMentains();
                    clsMen.ADP_All();
                    DGV_Mentainens.DataSource = clsMen.Read();
                    DGV_Mentainens.Columns[0].HeaderText = "ID";
                    DGV_Mentainens.Columns[1].HeaderText = "اسم الفني";
                }
                if (state == "Delivered")
                {
                    P_View.Visible = false;
                    P_Filter.Visible = false;
                    P_Ok.Visible = true;
                    P_Mentainens.Visible = false;
                    Classes.Class_DelivredDevices clsDelivery = new Classes.Class_DelivredDevices();
                    clsDelivery.ViewByDate(dateTimePicker1.Value.ToString(), dateTimePicker2.Value.ToString());
                    DGV_Ok.DataSource = clsDelivery.Read();
                    DGV_Ok.Columns[0].HeaderText = "ID";
                    DGV_Ok.Columns[1].HeaderText = "الموديل";
                    DGV_Ok.Columns[2].HeaderText = "Imei";
                    DGV_Ok.Columns[3].HeaderText = "اسم الزبون";
                    DGV_Ok.Columns[4].HeaderText = "رقم الزبون";
                    DGV_Ok.Columns[5].HeaderText = "مشكلة الجهاز";
                    DGV_Ok.Columns[6].HeaderText = "اسم الفني";
                    DGV_Ok.Columns[7].HeaderText = "حالة التسليم";
                    DGV_Ok.Columns[8].HeaderText = "تاريخ الاستلام";
                    DGV_Ok.Columns[9].HeaderText = "تاريخ التسليم";
                }
            }

        }

        private void bunifuImageButton5_Click(object sender, EventArgs e)
        {
            Forms.FRM_Query frmQuery = new FRM_Query();
            frmQuery.ShowDialog();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (count++ >= 2 && PB_Wait.Value == 100) { P_Wait.Visible = false; P_Container.Visible = true; timer1.Enabled = false; }
            if (PB_Wait.Value < 100)
                PB_Wait.Value += 50;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Classes.Class_Devices class_Devices = new Classes.Class_Devices();
            class_Devices.EditStateToCantBeFixed(int.Parse(DGV_All.CurrentRow.Cells[0].Value.ToString()));
            MessageBox.Show("تم وضع الجهاز لا يصلّح");
            DGV_All.CurrentRow.Cells[7].Value = "لا يصلّح";
            
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Classes.Class_Devices class_Devices = new Classes.Class_Devices();
            class_Devices.EditStateToUnOk(int.Parse(DGV_All.CurrentRow.Cells[0].Value.ToString()));
            MessageBox.Show("تم وضع الجهاز غير جاهز");
            DGV_All.CurrentRow.Cells[7].Value = "غير جاهز";
        }
        private void P_Top_MouseDown(object sender, MouseEventArgs e)
        {
            xpos1 = Control.MousePosition.X - this.Location.X;
            ypos1 = Control.MousePosition.Y - this.Location.Y;
        }
    }
}
