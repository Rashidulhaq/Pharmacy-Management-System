﻿using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace medisoft.PharmacistUC
{
    public partial class UC_P_Dashboard : UserControl
    {
        function fn = new function();
        String query;
        DataSet ds;
        Int64 count;
        public UC_P_Dashboard()
        {
            InitializeComponent();
        }

        private void UC_P_Dashboard_Load(object sender, EventArgs e)
        {
            loadChart();
        }

        public void loadChart()
        {
            query = "select count(mname) from medic where eDate >= getdate()";
            ds = fn.getData(query);
            setLabel(ds, validLabel);
            count = Int64.Parse(ds.Tables[0].Rows[0][0].ToString());
            this.chart1.Series["Valid Medicines"].Points.AddXY("Medicines Validity Chart", count);

            query = "select count(mname) from medic where eDate <= getdate()";
            ds = fn.getData(query);
            setLabel(ds, expiredLabel);
            count = Int64.Parse(ds.Tables[0].Rows[0][0].ToString());
            this.chart1.Series["Expired Medicines"].Points.AddXY("Medicines Validity Chart", count);

        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            chart1.Series["Valid Medicines"].Points.Clear();
            chart1.Series["Expired Medicines"].Points.Clear();
            loadChart();
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
            chart1.Series["Valid Medicines"].Points.Clear();
            chart1.Series["Expired Medicines"].Points.Clear();
            loadChart();
        }
    }
}
