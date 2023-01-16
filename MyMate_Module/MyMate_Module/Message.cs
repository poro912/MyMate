using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// 메시지에 대한 클래스
/// 메시지를 저장할 수 있는 방법을 제공한다.
/// 메시지의 생성을 담당하며 데이터 수정은 제한적으로 이루어져야 한다.
/// 메시지의 전송은 담당하지 않는다.
/// </summary>

namespace MyMate_Module
{
	/// <summary>
	/// 메시지 생성, 등록, 수정, 삭제
	/// 메시지의 형태를 정하고 메시지의 내용을 수정할 때만 쓰인다.
	/// 메시지 등록과 전송은 채널에서 한다.
	/// 
	/// 메시지 생성 : 메시지 전송 버튼 클릭, 메시지 송신완료 시 발생
	/// </summary>
	public abstract class Message
	{
		private long        userCode;
		private bool        isdelete;
		private long        to;
		private DateTime?	time;			// Nullable 타입 NULL 값이 들어갈 수 있음
		private String      context;		// 문자열 작업은 StringBilder를 통해서

		public long UserCode { get; }
		public long To { get; }
		public DateTime Time { get; }
		public string Context { get; }

		// 생성자

		/// <summary>
		/// 메시지의 내용이 없는 경우에 사용한다.
		/// 시간 객체를 초기화 하지 않는다.
		/// </summary>
		/// <param name="userCode"></param>
		/// <param name="to"></param>
		public Message(long userCode, long to)
		{
			Init(userCode, to);
		}

		/// <summary>
		/// 메시지 내용을 String으로 초기화 할 때 사용한다.
		/// 시간 객체를 초기화 한다.
		/// </summary>
		/// <param name="userCode"></param>
		/// <param name="to"></param>
		/// <param name="context"></param>
		/// 
		public Message(long userCode, long to, String context)
		{
			Init(userCode, to);
			SetContext(context);
			SetTime();
		}

		/// <summary>
		/// 메시지 내용을 StringBuilder로 초기화 할 때 사용한다.
		/// 시간 객체를 초기화 한다.
		/// </summary>
		/// <param name="userCode"></param>
		/// <param name="to"></param>
		/// <param name="context"></param>
		public Message(
			long			userCode,
			long			to,
			StringBuilder	context
			)
		{
			Init(userCode, to);
			SetContext(context);
			SetTime();
		}

		/// <summary>
		/// 생성자에서 호출 된다.
		/// 공통된 사항을 초기화 할 때 사용한다.
		/// 각 멤버 변수들을 기본값으로 만든다.
		/// </summary>
		/// <param name="userCode"></param>
		/// <param name="to"></param>
		private void Init(
			long		userCode,
			long		to)
		{
			this.userCode = userCode;
			this.to = to;
			isdelete = false;
			time = null;
			context = null;
		}

		/// <summary>
		/// 시간을 현재 시간으로 초기화 한다.
		/// 만약 시간이 이미 저장되어있으면 저장하지 않는다.
		/// 메시지 수정 가능성 때문에 해당 방식으로 작성함
		/// </summary>
		public void SetTime()
		{
			if (!this.time.HasValue)
				time = DateTime.Now;
		}

		/// <summary>
		/// 메시지의 내용을 저장한다.
		/// StringBuilder 형식
		/// String의 메모리 관리의 단점을 줄이기 위해 작성
		/// </summary>
		/// <param name="context"></param>
		public void SetContext(
			StringBuilder context
			)
		{
			this.context = context.ToString();
		}

		/// <summary>
		/// 메시지의 내용을 저장한다.
		/// String 형식
		/// 메모리 관리의 단점이 있다.
		/// </summary>
		/// <param name="context"></param>
		public void SetContext(
			String context
			)
		{
			this.context = context;
		}
	}
}
