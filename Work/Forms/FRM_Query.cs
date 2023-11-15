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
    public partial class FRM_Query : Form
    {
        public FRM_Query()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Classes.Class_Query clsQuery = new Classes.Class_Query();
            try
            {
                DGV_Results.DataSource = clsQuery.Query(T_Query.Text);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
