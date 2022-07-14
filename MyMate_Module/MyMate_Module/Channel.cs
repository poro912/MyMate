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

namespace MyMate_Module
{
	public abstract class Channel
	{
		private long        code;	
		private String      name;
		public List<Message>    messages;

		public long Code { get; }
		public String Name { get; }

		/*
		public abstract bool SendMessage(Message message);
		
		 *		클라이언트에서 구현
		 * 		public abstract bool ModifyContext();
		 * 		public abstract bool ModifyContext(String context);
		 * 		public abstract bool ModifyContext(StringBuilder context);
		
		public abstract bool ReceiveMessage(
			Message			message
			);
		*/
		
		/// <summary>
		/// 수신한 메시지를 등록,하는 메소드
		/// </summary>
		/// <param name="message"></param>
		/// <returns></returns>
		public abstract bool regist_Message( Message message );

		// 저장된 메시지들을 읽어오는 메소드
		public abstract List<Message> GetMessages();

		/// <summary>
		/// 새로운 메시지가 있는지 확인하는 메소드
		/// 이 메소드는 각 모듈에서 작성해야 할것으로 보인다.
		/// </summary>
		/// <returns></returns>
		public abstract bool CheckNewMessage();

		public abstract bool Rename(
			String			name
			);


	}

}
