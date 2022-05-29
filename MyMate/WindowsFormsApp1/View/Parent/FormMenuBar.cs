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
using FontAwesome.Sharp;
using System.Windows.Threading;

namespace ClientForm
{
    public partial class FormMenuBar : Form
    {
        private IconButton currentBtn;
        private Form currentChildForm;
        private List<Form> previousChildForms;

        public FormMenuBar()
        {
            InitializeComponent();
            this.Text = string.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            lblTime.Text = DateTime.Now.ToString();
            //DispatcherTimer 지정 - 초마다 시계 동작
            DispatcherTimer dt1 = new DispatcherTimer();
            dt1.Interval = new TimeSpan(0, 0, 1);
            dt1.Tick += new EventHandler(Timer1_Tick);
            dt1.Start();
            previousChildForms = new List<Form>();

            OpenChildForm(new FormDefault());
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToString();
        }


        //상단 바 드래그를 위한 운영체제 dll import
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        public void OpenChildForm(Form childForm)
        {
            if (currentChildForm != null)
                currentChildForm.Close();

            previousChildForms.Clear();
            currentChildForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            childForm.BackColor = Color.White;
            panelDesktop.Controls.Add(childForm);
            panelDesktop.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            lblTitle.Text = childForm.Text;
        }

        private void ActivateButton(object btnSender)
        {
            if (btnSender != null)
            {
                if (currentBtn != (IconButton)btnSender)
                {
                    DisableButton();
                    currentBtn = (IconButton)btnSender;
                    currentBtn.BackColor = Color.Thistle;
                    currentBtn.Font = new Font("Bahnschrift",11,FontStyle.Bold,GraphicsUnit.Point,((byte)(0)));
                }
            }
        }

        private void DisableButton()
        {
            foreach (Control prevBtn in panelMenubar.Controls)
            {
                if (prevBtn.GetType() == typeof(IconButton))
                {
                    if (prevBtn.Name == "btnLogout")
                        return;
                    prevBtn.BackColor = Color.AliceBlue;
                    prevBtn.Font = new Font("Bahnschrift", 12, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                }
            }
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void btnMaximize_Click(object sender, EventArgs e)
        {
            WindowState = (WindowState == FormWindowState.Normal) ? FormWindowState.Maximized : FormWindowState.Normal;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnCalendar_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            OpenChildForm(new FormCalendar());
        }

        private void btnChkList_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            OpenChildForm(new ExFormCheckList()); //fix
        }

        private void btnChat_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            ExFormGroupChat exFormGroupChat = new ExFormGroupChat();
            exFormGroupChat.FormSwitchEvent += new ExFormGroupChat.FormSwitchEventHandler(SwitchChildForm);
            OpenChildForm(exFormGroupChat);
        }

        private void SwitchChildForm(Form childForm) {
            if (currentChildForm != null)
            {
                currentChildForm.Hide();
                previousChildForms.Add(currentChildForm);
            }

            currentChildForm = childForm;
            childForm.FormClosed += (s, arg) =>
            {
                previousChildForms[previousChildForms.Count - 1].Show();
                previousChildForms.RemoveAt(previousChildForms.Count - 1);
            };

            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            childForm.BackColor = Color.White;
            panelDesktop.Controls.Add(childForm);
            panelDesktop.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            lblTitle.Text = childForm.Text;
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            OpenChildForm(new FormSettings());
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pBoxLogo_Click(object sender, EventArgs e)
        {
            DisableButton();
            OpenChildForm(new FormDefault());
        }
    }
}
