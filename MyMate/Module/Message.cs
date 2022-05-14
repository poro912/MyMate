using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServerModule;
using ClientModule;

namespace Module
{
	internal class Message
	{
		private long userCode;
		private bool isdelete;
		private long to;
		private DateTime time;
		private string context;

		public long UserCode { get; }
		public long To { get; }
		public DateTime Time { get { return Time; } }
		public string Context { get; }

		public void set_Time()
        {
			time = DateTime.Now;
		}
			

	}
}
