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
    public partial class ExFormGroupChat : Form
    {
        public delegate void FormSwitchEventHandler(Form form);
        public event FormSwitchEventHandler FormSwitchEvent;
        
        public ExFormGroupChat()
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

        private void button4_Click(object sender, EventArgs e)
        {
            FormSwitchEvent(new ExFormCall());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormSwitchEvent(new ExFormProfile());
        }

        private void button11_Click(object sender, EventArgs e)
        {
            FormSwitchEvent(new ExFormProfile());
        }
    }
}