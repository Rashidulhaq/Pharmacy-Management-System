﻿using System;
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
    public partial class UC_P_UpdateMedicines : UserControl
    {
        function fn = new function();
        string query;
        public UC_P_UpdateMedicines()
        {
            InitializeComponent();
        }

        private void UC_P_UpdateMedicines_Load(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if(txtMediID.Text!="")
            {
                query = "select * from medic where mid='" + txtMediID.Text + "'";
                DataSet ds = fn.getData(query);
                if (ds.Tables[0].Rows.Count != 0)
                {
                    txtMediName.Text = ds.Tables[0].Rows[0][2].ToString();
                    txtMediNumber.Text= ds.Tables[0].Rows[0][3].ToString();
                    txtMDate.Text= ds.Tables[0].Rows[0][4].ToString();
                    txtEDate.Text= ds.Tables[0].Rows[0][5].ToString();
                    txtAvaiableQuantity.Text= ds.Tables[0].Rows[0][6].ToString();
                    txtPricePerUnite.Text= ds.Tables[0].Rows[0][7].ToString();
                }
                else
                {
                    MessageBox.Show("No Medicine with ID : " + txtMediID + "exitst.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                clearAll();
            }
            
        }
        private void clearAll()
        {
            txtMediID.Clear();
            txtMediName.Clear();
            txtMediNumber.Clear();
            txtMDate.ResetText();
            txtEDate.ResetText();
            txtAvaiableQuantity.Clear();
            txtPricePerUnite.Clear();
            if(txtAddQuan.Text !="0")
            {
                txtAddQuan.Text = "0";
            }
            else
            {
                txtAddQuan.Text = "0";
            }
            
        }

        Int64 totalQuantity;
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            String mname = txtMediName.Text;
            String mnumber = txtMediNumber.Text;
            String mdate = txtMDate.Text;
            String edate = txtEDate.Text;
            Int64 quantity = Int64.Parse(txtAvaiableQuantity.Text);
            Int64 addQuantity = Int64.Parse(txtAddQuan.Text);
            Int64 unitprice = Int64.Parse(txtPricePerUnite.Text);

            totalQuantity = quantity + addQuantity;

            query = "update medic set mname ='" + mname + "',mnumber='" + mnumber + "',mDate='" + mdate + "',eDate='" + edate + "',quantity=" + totalQuantity + ",perUnit=" + unitprice + " where mid='"+txtMediID.Text+"' ";
            fn.setData(query, "Medicine Details Updated.");
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            clearAll();
        }
    }
}
