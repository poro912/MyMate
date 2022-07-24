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
    public partial class ExFormSignUp : Form
    {
        string Conn = "SERVER = localhost;port = 3306;user = root; DATABASE = db_server; password = 12345; SSLMODE = none";

        public ExFormSignUp()
        {
            InitializeComponent();
        }

        private void SignUpForm_Load(object sender, EventArgs e)
        {

        }

        //제출 버튼 클릭 시
        private void button2_Click(object sender, EventArgs e)
        {
            int a = 12;
            string user_id = textBox1.Text;
            string user_pwd = textBox2.Text;
            string chpwd = textBox3.Text;
            string user_name = textBox4.Text;
            string user_phone = textBox5.Text;



            if (user_id.Length == 0)
            {
                MessageBox.Show((string)"유저 아이디가 비어있다");

            }
            else
            {
                if (user_pwd.Length == 0)
                {
                    MessageBox.Show((string)"유저 비밀번호가 비어있다");
                }
                else
                {
                    if (user_pwd != chpwd)
                    {
                        MessageBox.Show((string)"비밀번호가 일치하지 않음");
                    }
                    else
                    {
                        if (user_name.Length == 0)
                        {
                            MessageBox.Show((string)"이름이 비어있다");
                        }
                        else
                        {
                            if (user_phone.Length == 0)
                            {
                                MessageBox.Show((string)"전화번호가 비어있다");
                            }
                            else
                            {
                                using (MySqlConnection conn = new MySqlConnection(Conn))
                                {
                                    try
                                    {
                                        conn.Open();
                                        string sql ="insert into user_tb(U_code,U_id,U_password,U_name,U_phone) values(" + a + ",\'" + user_id + "\',\'" + user_pwd + "\',\'" + user_name + "\',\'" + user_phone + "\')";
                                        MySqlCommand cmd = new MySqlCommand(sql, conn);
                                        cmd.ExecuteNonQuery();
                                        //conn.Close();
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show(ex.Message);

                                    }


                                }

                            }
                        }


                    }

                }


            }



            this.Close();
        }

        //취소 버튼 클릭 시
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
