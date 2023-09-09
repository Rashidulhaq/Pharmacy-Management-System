using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace medisoft
{

    public partial class Adminstrator : Form
    {


        String user = "";
        public Adminstrator()
        {
            InitializeComponent();

        }
        public string ID
        {
            get { return user.ToString(); }
        }
        public Adminstrator(String username)
        {
            InitializeComponent();
            userLabel.Text = username;
            user = username;
            uC_ViewUser1.ID = ID;
            uC_Profile1.ID = ID;

        }


        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

     

      

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            LogIn login = new LogIn();
            login.Show();
            this.Hide();
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            uC_Dashbord1.Visible = true;
            uC_Dashbord1.BringToFront();
        }

        private void Adminstrator_Load(object sender, EventArgs e)
        {
            
            uC_Dashbord1.Visible = false;
            btnDashboard.PerformClick();
            uC_AddUser1.Visible = false;
            uC_ViewUser1.Visible = false;
            uC_Profile1.Visible = false;
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            uC_AddUser1.Visible = true;
            uC_AddUser1.BringToFront();
        }

        private void btnViewUser_Click(object sender, EventArgs e)
        {
            uC_ViewUser1.Visible = true;
            uC_ViewUser1.BringToFront();
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            uC_Profile1.Visible = true;
            uC_Profile1.BringToFront();
        }

      

    }

    public class Class1
    {
    }
}
