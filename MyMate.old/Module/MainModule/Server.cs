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
		private List<KeyValuePair<int, Role>>  roles; 

		public long Code { get; }
		public string Name { get; }
		/// <summary>
		/// roles 의 값을 필요로 할 때 새로운 객체로 만들어서 반환
		/// 자주 사용되면 메모리 과부하 걸릴 가능성이 있음
		/// </summary>
		public List<KeyValuePair<int, Role>> Roles { get {
				// garbage collector 가 제대로 작동하는지 지속 확인 바람
				List<KeyValuePair<int, Role>> temp;
				temp = new List<KeyValuePair<int, Role>>();
				foreach (KeyValuePair<int, Role> role in roles)
                {
					temp.Add(new KeyValuePair<int, Role>(role.Key, role.Value));
				}
				return temp; 
			} 
		}

		public Server(
			User            owner
			)
		{
			owners.Add(owner);
			createRole("master");
			// master의 권한을 전부 허용으로 변환 하는 코드 필요

		}
		public Server(
			List<User> owners
			)
		{
			foreach (var user in owners)
            {
				this.owners.Add(user);
            }
			createRole("master");
			// master의 권한을 전부 허용으로 변환 하는 코드 필요

		}

		public abstract bool addChannel(
			string          name
			);
		public abstract void deleteChannel(
			String name
			);
		public abstract void renameChannel(
			String oldname,
			String newname
			);
		public abstract void renameChannel(
			int code,
			String newname
			);

		public abstract bool UserEnter(
			User            user
			);
		public abstract bool UserExit(
			User user
			);

		public abstract bool removeServer();



		// Role 에 관한 메소드
		private void createRole(
			String			name
			)
		{
			KeyValuePair<int, Role> temp = new KeyValuePair<int, Role>(roles.Count, new Role());
			roles.Add(temp);
			return;
		}
		public abstract bool addRole(
			String          name
			);

		public abstract bool changeRole(
		   String           permission_name,
		   Permission       permission
		   );
		public abstract bool deleteRole(
			String          permission_name
			);

	}
}
