using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace medisoft.AdministratorUC
{
    public partial class Dashbord : UserControl
    {
        function fn = new function();
        String query;
        DataSet ds;
        Int64 count;
        public Dashbord()
        {
            InitializeComponent();
        }

        

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void UC_Dashbord_Load(object sender, EventArgs e)
        {
            query = "select count(userRole) from users where userRole='Admin'";
            ds = fn.getData(query);
            setLabel(ds, AdminLabel);
            count = Int64.Parse(ds.Tables[0].Rows[0][0].ToString());
            this.chart1.Series["Total Admin"].Points.AddXY("Total User", count);
            query = "select count(userRole) from users where userRole='Pharmacist'";
            ds = fn.getData(query);
            setLabel(ds, PharmaLabel);
            count = Int64.Parse(ds.Tables[0].Rows[0][0].ToString());
            this.chart1.Series["Total Pharmacist"].Points.AddXY("Total User", count);
        }

       

        private void setLabel(DataSet ds, Guna2HtmlLabel lbl)
        {
            if (ds.Tables[0].Rows.Count != 0)
            {

                lbl.Text = ds.Tables[0].Rows[0][0].ToString();

            }

            else
            {
                lbl.Text = "0";
            }
        }

        private void btnSync_Click(object sender, EventArgs e)
        {
            chart1.Series["Total Admin"].Points.Clear();
            chart1.Series["Total Pharmacist"].Points.Clear();
            UC_Dashbord_Load(this, null);
        }

        
    }
}
