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
    public partial class FRM_Info : Form
    {
        public int Id = 0;
        public string state;
        private Point newpoint;
        private int xpos1, ypos1;
        public FRM_Info()
        {
            InitializeComponent();
        }

        private void FRM_Info_Load(object sender, EventArgs e)
        {
            if (state == "All")
            {
                Classes.Class_Devices clsDevice = new Classes.Class_Devices();
                clsDevice.ADP_Id(Id);
                DataTable dt = clsDevice.Read();
                if (dt.Rows.Count != 0)
                    textBox1.Text = dt.Rows[0]["Device_Info"].ToString();
            }
            if (state == "Delivry")
            {
                Classes.Class_DelivredDevices clsDelevery = new Classes.Class_DelivredDevices();
                clsDelevery.ADP_Id(Id);
                DataTable dt = clsDelevery.Read();
                if (dt.Rows.Count != 0)
                    textBox1.Text = dt.Rows[0]["Device_Info"].ToString();
            }
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                newpoint = Control.MousePosition;
                newpoint.X -= xpos1;
                newpoint.Y -= ypos1;
                this.Location = newpoint;
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            xpos1 = Control.MousePosition.X - this.Location.X;
            ypos1 = Control.MousePosition.Y - this.Location.Y;
        }
    }
}
