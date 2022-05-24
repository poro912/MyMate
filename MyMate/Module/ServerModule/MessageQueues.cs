using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Module.MainModule;

namespace Module.ServerModule
{
	enum Target_list
    {
		send	= 0,
		receive	= 1,
		process	= 2,
    }
	class MessageQueues : ICommunicator
	{
		List<Communicator> send;
		List<Communicator> receive;
		List<Communicator> process;
		List<Thread> subscribers;

		public void Subscribe(Thread thread)
		{

		}
		public void Unsubscribe(Thread thread)
		{

		}
		public int setMessage(int target, Communicator message)
		{
			switch (target)
            {
				case (int)Target_list.send:
					send.Add(message);
					break;
				case (int)Target_list.receive:
					receive.Add(message);
					break;
				case ((int)Target_list.process):
					process.Add(message);
					break;
				default:
					break;

            }
			return 0;
		}
        
		/// <summary>
		/// 동기화 문제 발생 가능성 있음
		/// </summary>
		/// <param name="target"></param>
		/// <returns></returns>
		public Communicator GetMessage(int target)
		{
			Communicator message = null;
			switch (target)
			{
				case (int)Target_list.send:
					if (send.Count > 0)
                    {
						message = send[0];
						send.RemoveAt(0);
					}
					break;
				case (int)Target_list.receive:
					if(receive.Count > 0)
                    {
						message = receive[0];
						receive.RemoveAt(0);
					}
					break;

				case ((int)Target_list.process):
					if (process.Count > 0)
                    {
						message = process[0];
						process.RemoveAt(0);
					}						
					break;
				default :
					break;
			}
			return message;
		}

	}
}
