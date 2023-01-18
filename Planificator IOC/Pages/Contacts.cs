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
            // TODO: This line of code loads data into the 'db_usersDataSet2.Contacte' table. You can move, or remove it, as needed.
            this.contacteTableAdapter1.Fill(this.db_usersDataSet2.Contacte);
            update_grid();
            
            

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
            
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Ionut\Desktop\Proiect IOC\Planificator IOC\Planificator IOC\db_users.mdf"";Integrated Security=True");
            con.Open();

            

            if (dataGridContacte.SelectedCells.Count > 0)
            {
                int i = int.Parse(dataGridContacte.SelectedCells[0].ToString());
                if(dataGridContacte.Rows.Count > 1 && i != dataGridContacte.Rows.Count -1)
                { 
                SqlCommand deletecmd = new SqlCommand("delete from Contacte where Id = " + int.Parse(dataGridContacte.SelectedRows[i].Cells[0].Value.ToString()) + "");
                deletecmd.ExecuteNonQuery();
                dataGridContacte.Rows.RemoveAt(this.dataGridContacte.SelectedRows[i].Index);
                    MessageBox.Show("Deleted");
                }

            }
            else
            {
               MessageBox.Show("Please select a row to delete");
               
                
            }

            con.Close();

           
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

        private void btnEdit_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Ionut\Desktop\Proiect IOC\Planificator IOC\Planificator IOC\db_users.mdf"";Integrated Security=True");
            con.Open();

            for (int item = 0; item < dataGridContacte.Rows.Count; item++) 
            {
                SqlCommand cmd2 = new SqlCommand("Update Contacte set Nume=@nume, Numardetelefon=@nr, Adresa=@adresa where Id=@id", con);
                cmd2.Parameters.AddWithValue("@nume", dataGridContacte.Rows[item].Cells[1].Value);
                cmd2.Parameters.AddWithValue("@nr", dataGridContacte.Rows[item].Cells[2].Value);
                cmd2.Parameters.AddWithValue("@adresa", dataGridContacte.Rows[item].Cells[3].Value);
                cmd2.Parameters.AddWithValue("id", dataGridContacte.Rows[item].Cells[0].Value);

                cmd2.ExecuteNonQuery();
            }


            /* db_usersDataSet dataSet = (db_usersDataSet)dataGridContacte.DataSource;
            DataTable dataTable = dataSet.Tables["Contacte"];

            
            */
            /*
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("Select * from Contacte", con);

            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            dataGridContacte.DataSource= dataTable;
            foreach (DataGridViewRow row in dataGridContacte.Rows)
            {
                if (row.IsNewRow)
                {
                    int id = (int)row.Cells["Id"].Value;
                    string nume = (string)row.Cells["Nume"].Value;
                    string nr = (string)row.Cells["Numar de telefon"].Value;
                    string adresa = (string)row.Cells["Adresa"].Value;

                    DataRow dataRow = dataTable.Rows.Find(id);

                    dataRow["Nume"] = nume;
                    dataRow["Numar de telefon"] = nr;
                    dataRow["Adresa"] = adresa;
                }
            }
            SqlCommandBuilder builder= new SqlCommandBuilder(sqlDataAdapter);
            sqlDataAdapter.Update(dataTable);
            */
            con.Close();

            MessageBox.Show("Update succesful!","Succes",MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }

        private void btnEdit_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(btnEdit, "Pentru editare apasati dublu click in casuta dorita, \nfaceti modificarile necesare si apasati pe butonul 'Edit' ");
        }
    }
}
