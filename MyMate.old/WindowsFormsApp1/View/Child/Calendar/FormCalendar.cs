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
	public partial class FormCalendar : Form
	{
		int year, month;
		public FormCalendar()
		{
			InitializeComponent();
			
			DateTime now = DateTime.Now;
			year = now.Year;
			month = now.Month;

			displayDays();
		}

		public void displayDays()
		{
			SuspendLayout();
			panDayContainer.Controls.Clear();
			//금월 시작일
			DateTime startOfTheMonth = new DateTime(year, month, 1);
			lblYM.Text = year.ToString() + "년   " + month.ToString("d2") + "월";
			//금월 시작 주의 전월 일수
			int daysOfStartWeek = Convert.ToInt32(startOfTheMonth.DayOfWeek.ToString("d")) + 1;
			//금월 일수
			int daysOfTheMonth = DateTime.DaysInMonth(year, month);
			//월말
			DateTime endOfTheMonth = new DateTime(year, month, daysOfTheMonth);
			//월말 주 남은 일수
			int daysOfEndWeek = Convert.ToInt32(endOfTheMonth.DayOfWeek.ToString("d")) + 1;

			//금월 시작 주의 전월 일만큼 UC 생성
			for (int i = 1; i < daysOfStartWeek; i++)
			{
				UcCalendarDate1 ucDate1 = new UcCalendarDate1();
				panDayContainer.Controls.Add(ucDate1);
			}

			//금월 일수만큼 UC 생성
			for (int i = 1; i <= daysOfTheMonth; i++)
			{
				UcCalendarDate2 ucDate2 = new UcCalendarDate2();
				ucDate2.SetDate_uc2(new DateTime(year,month,i));
				panDayContainer.Controls.Add(ucDate2);
			}

			//월말 주 남은 일수만큼 UC 생성
			for (int i = 1; i < daysOfEndWeek; i++)
			{
				UcCalendarDate1 ucDate1 = new UcCalendarDate1();
				panDayContainer.Controls.Add(ucDate1);
			}
			ResumeLayout(true);
		}

		public void increaseMonth()
		{
			month++;
			if (month == 13)
			{
				month = 1;
				year++;
			}
			displayDays();
		}

		public void increaseYear()
		{
			year++;
			displayDays();
		}

		public void decreaseYear()
		{
			year--;
			displayDays();
		}

		private void iconButton4_Click(object sender, EventArgs e)
		{
			increaseYear();
		}

		private void iconButton5_Click(object sender, EventArgs e)
		{
			increaseMonth();
		}

		private void iconButton6_Click(object sender, EventArgs e)
		{
			decreaseMonth();
		}

		private void iconButton7_Click(object sender, EventArgs e)
		{
			decreaseYear();
		}

		public void decreaseMonth()
		{
			month--;
			if (month == 0)
			{
				month = 12;
				year--;
			}
			displayDays();
		}
	}
}
