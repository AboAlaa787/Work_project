
namespace Work.Forms
{
    partial class FRM_Query
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.T_Query = new System.Windows.Forms.TextBox();
            this.DGV_Results = new System.Windows.Forms.DataGridView();
            this.listBox1 = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Results)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.button1.Location = new System.Drawing.Point(0, 427);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(592, 40);
            this.button1.TabIndex = 0;
            this.button1.Text = "Query";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // T_Query
            // 
            this.T_Query.Dock = System.Windows.Forms.DockStyle.Top;
            this.T_Query.Location = new System.Drawing.Point(0, 0);
            this.T_Query.Name = "T_Query";
            this.T_Query.Size = new System.Drawing.Size(592, 20);
            this.T_Query.TabIndex = 1;
            // 
            // DGV_Results
            // 
            this.DGV_Results.AllowUserToAddRows = false;
            this.DGV_Results.AllowUserToDeleteRows = false;
            this.DGV_Results.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_Results.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGV_Results.Location = new System.Drawing.Point(92, 20);
            this.DGV_Results.Name = "DGV_Results";
            this.DGV_Results.ReadOnly = true;
            this.DGV_Results.Size = new System.Drawing.Size(500, 407);
            this.DGV_Results.TabIndex = 2;
            // 
            // listBox1
            // 
            this.listBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Items.AddRange(new object[] {
            "Devices",
            "Devices_Delivered",
            "Mentains"});
            this.listBox1.Location = new System.Drawing.Point(0, 20);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(92, 407);
            this.listBox1.TabIndex = 3;
            // 
            // FRM_Query
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 467);
            this.Controls.Add(this.DGV_Results);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.T_Query);
            this.Controls.Add(this.button1);
            this.Name = "FRM_Query";
            this.Text = "FRM_Query";
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Results)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox T_Query;
        private System.Windows.Forms.DataGridView DGV_Results;
        private System.Windows.Forms.ListBox listBox1;
    }
}