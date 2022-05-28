using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientForm
{
    public partial class FormGroupChat : Form
    {
        public FormGroupChat()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label2.Text = textBox1.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            string filename = openFileDialog1.FileName;
            string readfile = File.ReadAllText(filename);
        }
    }
}
