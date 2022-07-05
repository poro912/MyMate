using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// 메시지 교환을 위한 정보 집합체
/// 프로그램에서 사용하는 모든 정보를 저장할 수 있는 클래스이다.
/// </summary>
namespace Module.MainModule
{
	enum action_list
	{
		LOGIN = 0
	}

	public class Communicator
	{
		public User         user;
		public Message      message;
		public long ?       serverCode;
		public long ?       channelCode;
		public int ?        action;
	}
}
