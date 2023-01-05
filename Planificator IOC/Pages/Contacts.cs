using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Planificator_IOC.Pages
{
    public partial class Contacts : Form
    {
        

        public Contacts()
        {
            InitializeComponent();
        }

        private void Contacts_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'db_usersDataSet.Contacte' table. You can move, or remove it, as needed.
            this.contacteTableAdapter.Fill(this.db_usersDataSet.Contacte);
            

        }

        public void update_grid()
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Ionut\Desktop\Proiect IOC\Planificator IOC\Planificator IOC\db_users.mdf"";Integrated Security=True");
            con.Open();

            SqlDataAdapter da = new SqlDataAdapter("select * from Contacte", con);
            DataSet ds = new DataSet();
            da.Fill(ds, "Contacte");
            dataGridContacte.DataSource= ds;
            dataGridContacte.DataMember = "Contacte";
            con.Close();

            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {          
            Contacts_Add contacts = new Contacts_Add();
            contacts.Show();
        }

        
        
        private void button1_Click(object sender, EventArgs e)
        {
            update_grid();
        }
    }
}
