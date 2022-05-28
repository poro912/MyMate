using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class UcCalendarDate2 : UserControl
    {
        private Form currentDialogForm;
        private DateTime date;

        public UcCalendarDate2()
        {
            InitializeComponent();
        }

        public void SetDate_uc2(DateTime date)
        {
            lblDate.Text = date.Day.ToString();
            this.date = date;
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            FormScheduleList formScheduleList = new FormScheduleList();
            formScheduleList.SetDate_Schedule(date);
            OpenDialogForm(formScheduleList);
            
        }

        private void OpenDialogForm(Form dialogForm)
        {
            if (currentDialogForm != null)
                currentDialogForm.Close();

            currentDialogForm = dialogForm;
            dialogForm.FormBorderStyle = FormBorderStyle.None;
            dialogForm.BringToFront();
            dialogForm.ShowDialog();
            dialogForm.BackColor = Color.White;
        }
    }
}
