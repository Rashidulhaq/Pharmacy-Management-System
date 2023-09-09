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
    public partial class AddUser : UserControl
    {
        function fn = new function();
        String query;
        public AddUser()
        {
            InitializeComponent();
        }
   
        private void btnSignUp_Click(object sender, EventArgs e)
        {
            String role = txtUserRole.Text;
            String name = txtName.Text;
            String dob = txtDob.Text;
            Int64 mobile = Int64.Parse(txtMobile.Text);
            String email = txtEmail.Text;
            String username = txtUsername.Text;
            String pass = txtPass.Text;

            try
            {
                query = "insert into users (userRole,name,dob,mobile,email,username,pass) values ('" + role + "','" + name + "','" + dob + "'," + mobile + ",'" + email + "','" + username + "','" + pass + "')";
                fn.setData(query, "Sign Up Successful.");

            }

            catch (Exception)
            {
                MessageBox.Show("Username Allready exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtUserRole.SelectedIndex = -1;
            txtName.Clear();
            txtMobile.Clear();
            txtEmail.Clear();
            txtUsername.Clear();
            txtPass.Clear();
            txtDob.ResetText();
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            query = "select * from users where username='" + txtUsername.Text + "'";
            DataSet ds = fn.getData(query);
            if (ds.Tables[0].Rows.Count == 0)
            {
                picCheck.ImageLocation = @"F:\sdp2\C# Pharmacy Management System\Pharmacy Management System in C#\yes.png";
                const string V = "Available";
                labelAvailability.Text = V;
            }
            else
            {
                const string Y = "User name not available";
                picCheck.ImageLocation = @"F:\sdp2\C# Pharmacy Management System\Pharmacy Management System in C#\no.png";
                labelAvailability.Text = Y;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void picCheck_Click(object sender, EventArgs e)
        {

        }
    }
}
