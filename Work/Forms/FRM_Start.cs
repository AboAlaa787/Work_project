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
    public partial class FRM_Start : Form
    {
        int count = 1;
        Forms.FRM_Main frmMain;

        public FRM_Start()
        {
            InitializeComponent();
        }

        private void FRM_Start_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            count++;
            progressBar1.Value += 10;
            if (count==3)
            {
                frmMain = new FRM_Main();
                frmMain.Visible = false;
            }
            if (count==6)
            {
                frmMain.Show();
                frmMain.Visible = true;
                this.Visible = false;
                timer1.Enabled = false;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
