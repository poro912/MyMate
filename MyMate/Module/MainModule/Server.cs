using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module.MainModule
{
	public class Server
	{
		private long code;
		private string name;
		private List<User> owners;
		private List<User> users;
		private List<Channel> Channels;
		private List<KeyValuePair<String, Permission>> roles; 


		public Server(User owner)
        {
			owners.Add(owner);
			roles.Add(new KeyValuePair<string, Permission>("master",new Permission()));
        }
		
		public bool addRole(String name)
        {
			roles.Add(new KeyValuePair<string, Permission>(name, new Permission()));
			return true;
		}

		public bool regist()
        {
			return true;

        }

	}
}
