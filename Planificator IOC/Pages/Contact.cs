using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Planificator_IOC.Pages
{
    public partial class Contact : Form
    {
        public Contact()
        {
            InitializeComponent();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if(NumeSupp.Text == "" && MailSupp.Text == "" && MsgSupp.Text == "") 
            {
                MessageBox.Show("Some fields are empty", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else 
            {
                NumeSupp.Text = "";
                MailSupp.Text = "";
                MsgSupp.Text = "";
                NumeSupp.Focus();
                MessageBox.Show("Mesaj trimis cu succes", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
        }
    }
}
