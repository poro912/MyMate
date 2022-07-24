using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// 서버에 대한 클래스이다.
/// 서버코드, 서버명, 유저, 채널목록, 권한에 대해 저장 관리하는 클래스이다.
/// </summary>

namespace MyMate_Module
{
	public abstract class Server
	{
		private long            code;
		private string          name;
		private List<User>      owners;
		private Dictionary<long,User>      users;
		private Dictionary<long,Channel>   Channels;
		private Dictionary<int, Role>  roles; 

		public long Code { get; }
		public string Name { get; }

		// 생성자
		private void Init()
        {

        }

		public Server(
			User owner
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

		/// <summary>
		/// roles 의 값을 반환
		/// </summary>
		public Dictionary<int, Role> retRoles { get {

				/*
				// 해당 코드로 진행 시 garbage collector 가 제대로 작동하는지 지속 확인 바람
				List<KeyValuePair<int, Role>> temp;
				temp = new List<KeyValuePair<int, Role>>();
				foreach (KeyValuePair<int, Role> role in roles)
                {
					temp.Add(new KeyValuePair<int, Role>(role.Key, role.Value));
				}
				return temp; 
				*/
				return this.roles;
			} 
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
