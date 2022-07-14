using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
///  채널 클래스
///  채널에 관한 정보를 저장한다.
///  정보 변경에 대한 방법을 제공해야 한다.
///  해당 클래스에서는 데이터 저장만을 진행하며 전송에 대해서는 고려하지 않는다.
/// </summary>

/*
	메모
		채널은 메시지를 저장하는 역할을 한다.
	메소드
		메시지 등록
		메시지 정보 반환
		채널명 변경
		채널코드 획득
*/


namespace MyMate_Module
{
	public abstract class Channel
	{
		private long code;
		private String name;
		public List<Message> messages;
		public DateTime ChangeTime;         // 최근 변경사항이 발생한 시각을 저장

		// 프로퍼티
		public long Code { get; }
		public String Name { get; }

		// 생성자
		/// <summary>
		/// 코드값만 지정된 경우 호출될 생성자 
		/// default라는 이름으로 생성된다.
		/// </summary>
		/// <param name="code"> 채널 코드 값 </param>
		public Channel(long code) { init(code, "default"); }
		/// <summary>
		/// 코드값과 이름이 지정된 경우의 생성자
		/// </summary>
		/// <param name="code"></param>
		/// <param name="name"></param>
		public Channel(long code, String name) { init(code, name); }

		private void init(
			long		code,
			String		name)
		{
			this.code = code;
			this.name = name;
			this.messages = new List<Message>();
			this.ChangeTime = DateTime.Now;
		}


		/// <summary>
		/// 메시지를 저장하는 메소드
		/// </summary>
		/// <param name="message">등록할 메시지</param>	
		public void save_Message(Message message) { this.messages.Add(message); }


		public List<Message> retMessages() { return messages; }
		public List<Message> retMessages(DateTime date)
		{
			return messages;
		}
		public List<Message> retMessages(
			int			year,
			int			month,
			int			day)
		{
			return messages;
		}

		public bool checkChange(DateTime date)
        {
			if(this.ChangeTime == date) return true;
			else return false;
        }
		private void setChangeTime() { }


		public bool Rename(String name)
		{
			this.name = name;
			return true;
		}
	}
}
