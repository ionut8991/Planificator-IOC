using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.SqlClient;

namespace Planificator_IOC
{
    public partial class Login : Form
    {

        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;

        public Login()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Register f2 = new Register();
            this.Hide();
            f2.Show();           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Ionut\Desktop\Proiect IOC\Planificator IOC\Planificator IOC\db_users.mdf"";Integrated Security=True");
            con.Open();
            string username = logUser.Text;
            string password = logPass.Text;
            string login = "SELECT * FROM userdata WHERE username= '" + username + "' and password= '" + password + "'";
            cmd = new SqlCommand(login, con);
            dr = cmd.ExecuteReader();

            if(dr.Read() == true) 
            {
                dr.Close();
                dashboard f3 = new dashboard();
                f3.Show();
                this.Hide(); 
                
            }
            else
            {
                dr.Close();
                MessageBox.Show("Invalid username or password, Please Try Again", "Login invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                logUser.Text = "";
                logPass.Text = "";
                logUser.Focus();
            }

            con.Close();
        }
    }
}
