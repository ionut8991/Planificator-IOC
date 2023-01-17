using Planificator_IOC.Pages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Planificator_IOC
{
    

    public partial class dashboard : Form
    {
        private Button currentButton;
        private Form currentChildForm;

        public dashboard()
        {
            InitializeComponent();
            this.Text = string.Empty;
            //nu afiseaza peste taskbar
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            this.ControlBox = false;

        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void dashboard_Load(object sender, EventArgs e)
        {
            OpenChildForm(new Home());
        }

        private void ActivateButton(object senderBtn)
        {
            if (senderBtn != null)
            {
                DisableButton();
                currentButton = (Button)senderBtn;
                currentButton.BackColor = Color.FromArgb(129, 103, 103);
            }
        }
        private void DisableButton()
        {
            if(currentButton != null)
            {
                currentButton.BackColor = Color.FromArgb(40, 27, 27);
            }
        }

        private void OpenChildForm(Form childForm)
        {
            
            if (currentChildForm != null)
            {
                currentChildForm.Close();
            }
            currentChildForm = childForm;
            
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelDesktop.Controls.Add(childForm);
            panelDesktop.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            
        }



        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //modifica pozitia
        private void dashboard_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            OpenChildForm(new Home());
            lableTitle.Text = "Home";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            OpenChildForm(new Contacts());
            lableTitle.Text = "Contacts";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            OpenChildForm(new Books());
            lableTitle.Text = "Books";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            OpenChildForm(new Todo());
            lableTitle.Text = "To-do";

        }

        private void button5_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            OpenChildForm(new Settings());
            lableTitle.Text = "Settings";

        }

        private void button6_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            OpenChildForm(new Contact());
            lableTitle.Text = "Contact Us";

        }

       
        //modifica pozitia
        private void panel3_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void maxBtn_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                WindowState = FormWindowState.Maximized;
            else
                WindowState = FormWindowState.Normal;
        }

        private void minBtn_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void panelDesktop_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnBooks_MouseHover(object sender, EventArgs e)
        {
            booksTip.SetToolTip(btnBooks, "Coming soon! Not available yet");
        }

        private void btnTodo_MouseHover(object sender, EventArgs e)
        {
            TodoTip.SetToolTip(btnTodo, "Coming soon! Not available yet");
        }

        private void btnSettings_MouseHover(object sender, EventArgs e)
        {
            settingTip.SetToolTip(btnSettings, "Coming soon! Not available yet");
        }
    }
}
