using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ClientForm
{
    
    public partial class FormLogin : Form
    {
        string Conn = "SERVER = localhost;port = 3306;user = root; DATABASE = db_server; password = 12345; SSLMODE = none";
        private Form currentChildForm;

        public FormLogin()
        {
            InitializeComponent();

            //로그인 유지나 ID 유지 체크 여부 불러와서 처리
        }

        private void Login_Click(object sender, EventArgs e)
        {
       
           Verify();
        }

        private void UserID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.ActiveControl = PW;
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void PW_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Verify();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void Verify() {
            //로그인 성공 시
            string user_id = UserID.Text;
            string user_pwd = PW.Text;
            MessageBox.Show(user_id);
            MessageBox.Show(user_pwd);
            using (MySqlConnection conn = new MySqlConnection(Conn))
            {
                try
                {
                    conn.Open();
                    string sql = "SELECT * FROM user_tb where U_id =\'" + user_id + "\'";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    MySqlDataReader dbr = cmd.ExecuteReader();
                    bool login = false;
                    while (dbr.Read())
                    {
                        if (user_id == (string)dbr["U_id"] && user_pwd == (string)dbr["U_password"])
                        {
                            login = true;
                        }
                    }
                    conn.Close();
                    if (login)
                    {
                        FormMenuBar formMenuBar = new FormMenuBar();
                        OpenAndHide(formMenuBar);
                        PW.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("ID 혹은 비밀번호를 잘못 입력하셨거나 등록되지 않은 ID입니다.", "로그인 오류");
                    }
                }
                catch(Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
            
            //if (UserID.Text == "admin" && PW.Text == "1234")
            //{
            //    FormMenuBar formMenuBar = new FormMenuBar();
            //    OpenAndHide(formMenuBar);
            //    PW.Text = "";
            //}
            //else
        //    {
        //        MessageBox.Show("ID 혹은 비밀번호를 잘못 입력하셨거나 등록되지 않은 ID입니다.", "로그인 오류");
        //    }
        }

        public void OpenAndHide(Form form) {
            if (currentChildForm != null)
                currentChildForm.Close();

            this.Hide();

            currentChildForm = form;
            currentChildForm.BringToFront();
            currentChildForm.FormClosed += (s, args) => this.Show();
            currentChildForm.ShowDialog();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            ExFormSignUp exFormSignUp = new ExFormSignUp();
            OpenAndHide(exFormSignUp);
        }
    }
}
