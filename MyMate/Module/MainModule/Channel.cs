using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module.MainModule
{
	public abstract class Channel
	{
		private long cdoe;
		private String name;
		public List<Message> messages;
	}
}
