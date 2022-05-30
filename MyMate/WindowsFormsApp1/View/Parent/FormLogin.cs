﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientForm
{
    
    public partial class FormLogin : Form
    {
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
            if (UserID.Text == "admin" && PW.Text == "1234")
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
