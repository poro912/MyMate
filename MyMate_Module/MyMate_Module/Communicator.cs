using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// 커뮤니케이터
/// 각 스레드, 모듈간 데이터교환을 위해 사용하는 클래스(자료형)
/// MyMate에서 사용하는 모든 정보를 임시 저장할 수 있게 해주는 클래스이다.
/// 데이터의 종류를 파악 할 수 있어야하며, 각 정보를 반환해줄 수 있어야 한다.
/// </summary>

// 0001 User    0010 Message

namespace MyMate_Module
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
