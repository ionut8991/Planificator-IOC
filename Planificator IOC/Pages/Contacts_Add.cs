using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Planificator_IOC.Pages
{
    public partial class Contacts_Add : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        public Contacts_Add()
        {
            InitializeComponent();
            //nu afiseaza peste taskbar
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);


        private void minBtn_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void maxBtn_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                WindowState = FormWindowState.Maximized;
            else
                WindowState = FormWindowState.Normal;
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Ionut\Desktop\Proiect IOC\Planificator IOC\Planificator IOC\db_users.mdf"";Integrated Security=True");
            con.Open();

            int newId;

            cmd = new SqlCommand("SELECT MAX(Id) from Contacte", con); 
            
            object rezultat = cmd.ExecuteScalar();
            if(rezultat != DBNull.Value && Convert.ToInt32(rezultat) > 0)
            {
                int maxid = Convert.ToInt32(cmd.ExecuteScalar());
            newId = maxid + 1;
            }
            else
            {
                newId = 1;
            }


            string nume = NumeCont.Text;
            string nr = NrCont.Text;
            string adresa = AdresaCont.Text;

            if (NumeCont.Text == "" && NrCont.Text == "" && AdresaCont.Text == "") 
            {
                MessageBox.Show("Some fields are empty", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                
                cmd = new SqlCommand("insert into Contacte values (@id,@nume, @nr, @adresa)", con);
                cmd.Parameters.AddWithValue("@id", newId);
                cmd.Parameters.AddWithValue("@nume", nume);
                cmd.Parameters.AddWithValue("@nr", nr);
                cmd.Parameters.AddWithValue("@adresa", adresa);
                cmd.ExecuteNonQuery();
                NumeCont.Text = "";
                NrCont.Text = "";
                AdresaCont.Text = "";

                MessageBox.Show("Data saved succesfully!", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void NrCont_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                warning.Visible = true;
            }
            else
            {
                warning.Visible = false;
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
