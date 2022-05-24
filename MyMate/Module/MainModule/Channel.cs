using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module.MainModule
{
	public abstract class Channel
	{
		private long        cdoe;
		private String      name;
		public List<Message>    messages;

		public long Code { get; }
		public String Name { get; }

		public abstract bool SendMessage(Message message);
		/*
		 *		클라이언트에서 구현
		 * 		public abstract bool ModifyContext();
		 * 		public abstract bool ModifyContext(String context);
		 * 		public abstract bool ModifyContext(StringBuilder context);
		*/
		public abstract bool ReceiveMessage(
			Message			message
			);

		public abstract bool CheckNewMessage();

		public abstract bool Rename(
			String			name
			);


	}

}
