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
    public partial class Register : Form
    {

        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;

        public Register()
        {
            InitializeComponent();


        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
        }

        private void ExitButton2_Click(object sender, EventArgs e)
        {
            
            Login f1 = new Login();
            f1.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Ionut\Desktop\Proiect IOC\Planificator IOC\Planificator IOC\db_users.mdf"";Integrated Security=True");
            con.Open();

            string username = regUser.Text;
            string password = regPass.Text;

            cmd = new SqlCommand("SELECT MAX(Id) from userdata", con);
            int maxid = Convert.ToInt32(cmd.ExecuteScalar());
            int newId = maxid + 1;



            if(regUser.Text == "" && regPass.Text == "" && regConPass.Text == "")
            {
                MessageBox.Show("Username and Password fields are empty", "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if(regPass.Text == regConPass.Text)
            {
                cmd = new SqlCommand("select * from userdata where username = '" + regUser.Text + "'", con);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    dr.Close();
                    MessageBox.Show("Username taken, please try another", "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    regUser.Text = "";
                    regUser.Focus();
                }
                else 
                {
                    dr.Close();
                    cmd = new SqlCommand("insert into userdata values (@id,@username, @password)", con);
                    cmd.Parameters.AddWithValue("@id", newId);
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);                                            
                    cmd.ExecuteNonQuery();                
                    regUser.Text = "";
                    regPass.Text = "";
                    regConPass.Text = "";

                    MessageBox.Show("Your account has been created succesfully!", "Registration Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
                }
            }
            else
            {
                MessageBox.Show("Passwords do not match, Please Re-enter", "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                regPass.Text = "";
                regConPass.Text = "";
                regPass.Focus();
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Login f1 = new Login();
            f1.Show();
            this.Close();
        }
    }
}
