using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module.MainModule
{
	public abstract class Server
	{
		private long            code;
		private string          name;
		private List<User>      owners;
		private List<User>      users;
		private List<Channel>   Channels;
		private List<KeyValuePair<String, Permission>>  roles; 


		public Server(
            User owner
            )
        {
			owners.Add(owner);
			roles.Add(new KeyValuePair<string, Permission>("master", new Permission() ) );
        }

        public abstract bool addRole(
            String name
            );
        /*
        {
			roles.Add(new KeyValuePair<string, Permission>(name, new Permission()));
			return true;
		}
        */

        public abstract bool changeRole(
           String permission_name,
           Permission permission
           );
        public abstract deleteRole(
            String permission_name
            );

        public abstract bool addChannel(
            string          name
            );

        public abstract bool UserEnter(
            User            user
            );
       
	}
}
