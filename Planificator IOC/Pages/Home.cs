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
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
            
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ceas.Text = DateTime.Now.ToString("hh:mm:ss");
        }

        private void Home_Load(object sender, EventArgs e)
        {
            timer1.Start();
            data.Text = DateTime.Today.ToString("dd/MM/yyy");
            
        }
    }
}
