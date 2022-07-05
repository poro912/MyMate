using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module.MainModule
{
	public abstract class User
	{
		private long code;
		private String id;
		private String name;
		private String nick;
		private uint tag;

		public long Code { get; }
		public String Id { get; }
		public String Name { get; }
		
		/// <summary>
		/// User 클래스의 생성자
		/// </summary>
		/// <param name="code">		유저 코드(식별자) </param>
		/// <param name="id">		유저 id </param>
		/// <param name="name">		유저이름 </param>
		/// <param name="nick">		보조이름 </param>
		/// <param name="tag">		유저 태그코드 ex) 포로#1234 </param>
		public User(
			long		code,
			String		id,
			String		name,
			String		nick,
			uint		tag
			)
		{
			this.code = code;
			this.id = id;
			this.name = name;
			this.nick = nick;
			this.tag = tag;
		}

		/// <summary>
		/// 자신의 닉네임 변경에 대한 메소드이다.<para/>
		/// 서버에서는 DB에 변경 요청을 보내야함<para/>
		/// 클라이언트는 서버에 바꿀 닉네임을 보내야함
		/// </summary>
		/// <param name="nick"> 변경될 닉네임 </param>
		public abstract void ReplaceNick(
			String nick
		);

		//해당 메소드는 User클래스에 어울리지 않는다. 다른 클래스로의 이동을 고려하는 중이다.
		/// <summary>
		/// 비밀번호 확인에 대한 메소드이다.<para/>
		/// 서버에서는 복호화 후 DB에 대조 요청을 진행한다. <para/>
		/// 클라이언트는 암호화 후 서버에 전송한다.
		/// </summary>
		/// <param name="pw"> 비밀번호 </param>
		/// <returns> 
		/// true : 암호 일치 <para/>
		///	false : 암호 불일치
		/// </returns>
		public abstract bool CheckPW(
			String pw
		);



	}
}
