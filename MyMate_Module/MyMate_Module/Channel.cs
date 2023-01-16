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
		public DateTime CreateTime;			// 채널 생성 시각을 저장

		// 프로퍼티
		public long Code { get; }
		public String Name { get; }

		// 생성자
		/// <summary>
		/// 코드값만 지정된 경우 호출될 생성자 
		/// 이름은 default로 지정되어 생성된다.
		/// </summary>
		/// <param name="code"> 채널 코드 값 </param>
		public Channel(long code) { Init(code, "default"); }
		/// <summary>
		/// 코드값과 이름이 지정된 경우의 생성자
		/// </summary>
		/// <param name="code"></param>
		/// <param name="name"></param>
		public Channel(long code, String name) { Init(code, name); }

		/// <summary>
		/// 초기화시 사용하는 메소드 
		/// code값, name값을 받아와 저장
		/// 메시지에 대한 리스트를 생성
		/// 채널 생성시간을 
		/// </summary>
		/// <param name="code"></param>
		/// <param name="name"></param>
		private void Init(
			long		code,
			String		name)
		{
			this.code = code;
			this.name = name;
			this.messages = new List<Message>();
			this.ChangeTime = DateTime.Now;
			this.CreateTime = DateTime.Now;
		}


		/// <summary>
		/// 메시지를 message vector에 저장하는 메소드
		/// </summary>
		/// <param name="message">등록할 메시지</param>	
		public void save_Message(Message message) { this.messages.Add(message); }


		// 메시지 전체를 반환
		public List<Message> retMessages() { return messages; }
		// 해당하는 날짜의 메시지를 반환
		public List<Message> retMessages(DateTime date)
		{
			return messages;
		}
		// 해당하는 날짜의 메시지를 반환
		public List<Message> retMessages(
			int			year,
			int			month,
			int			day)
		{
			return messages;
		}

		// 변경사항이 있는지 확인
		public bool checkChange(DateTime date)
        {
			if(this.ChangeTime == date) return true;
			else return false;
        }

		// 변경사항 발생 시각을 현재시간으로 또는 지정 시간으로 변경
		private void setChangeTime() { }

		// 채널이름을 변경
		public bool Rename(String name)
		{
			this.name = name;
			return true;
		}
	}
}
