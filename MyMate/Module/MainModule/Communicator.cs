using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// 메시지 교환을 위한 클래스
/// </summary>
namespace Module.MainModule
{
    enum action_list
    {
        LOGIN = 0
    }

    public class Communicator
    {
        public User user;
        public Message message;
        public long serverCode;
        public long channelCode;
        public int action;

    }
}
