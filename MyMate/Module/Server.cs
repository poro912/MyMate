using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module
{
	class Server
	{
		private long code;
		private string name;
		private List<User> owners;
		private List<Channel> Channels;
		private List<KeyValuePair<long, int>> roles; 
	}
}
