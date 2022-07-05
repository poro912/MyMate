using System;
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
    public partial class ExFormSignUp : Form
    {
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
            this.Close();
        }

        //취소 버튼 클릭 시
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
