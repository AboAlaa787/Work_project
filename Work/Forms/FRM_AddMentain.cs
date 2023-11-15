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
    public partial class FRM_AddMentain : Form
    {
        public FRM_AddMentain()
        {
            InitializeComponent();
        }

        private void bunifuMaterialTextbox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Classes.ClassMentains clsMentain = new Classes.ClassMentains();
                if (bunifuMaterialTextbox1.Text != " ")
                {
                    clsMentain.Add_Mentain(bunifuMaterialTextbox1.Text);
                    MessageBox.Show("تمت الاضافة بنجاح");
                    this.Close();
                }
                else
                    MessageBox.Show("الرجاء اكمال البيانات المطلوبة");
            }
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            Classes.ClassMentains clsMentain = new Classes.ClassMentains();
            if (bunifuMaterialTextbox1.Text != " ")
            {
                clsMentain.Add_Mentain(bunifuMaterialTextbox1.Text);
                MessageBox.Show("تمت الاضافة بنجاح");
                this.Close();
            }
            else
                MessageBox.Show("الرجاء اكمال البيانات المطلوبة");
        }
    }
}
