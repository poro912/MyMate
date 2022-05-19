using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Module.MainModule;

namespace Module.ClientModule
{
	class ClientUser : User
    {

        public ClientUser
			(
			long code,
			String id,
			String name,
			String nick,
			uint tag
			)
			: base
			(code, id, name, nick, tag)
		{

		}

		public override bool CheckPW(string pw)
		{
			throw new NotImplementedException();
		}

		public override void ReplaceNick(string nick)
		{
			throw new NotImplementedException();
		}
	}
}