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

namespace ClientForm
{
    public partial class FormScheduleList : Form
    {
        private DateTime date;

        public FormScheduleList()
        {
            InitializeComponent();
        }

        public void SetDate_Schedule(DateTime date)
        {
            this.date = date;
            lblDate.Text = date.ToString("yyyy-MM-dd");
            TimePickerFrom.Value = date;
            if (TimePickerFrom.Value >= TimePickerTo.Value)
            {
                //제출 버튼을 비활성화하고 경고 라벨 표시할 예정
                btnSubmit.Enabled = false;
            }
            else
                btnSubmit.Enabled = true;
        }

        private void SetDate_ScheduleEnd(DateTime date)
        {
            TimePickerTo.Value = date;
            if (TimePickerFrom.Value >= TimePickerTo.Value)
            {
                btnSubmit.Enabled = false;
            }
            else
                btnSubmit.Enabled = true;
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void TimePickerFrom_ValueChanged(object sender, EventArgs e)
        {
            SetDate_Schedule(TimePickerFrom.Value);
        }

        private void TimePickerTo_ValueChanged(object sender, EventArgs e)
        {
            SetDate_ScheduleEnd(TimePickerTo.Value);
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            MessageBox.Show("데이터 삭제 기능 구현 예정", "Caption");
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            MessageBox.Show("데이터 적용 기능 구현 예정", "Caption");
        }


    }
}
