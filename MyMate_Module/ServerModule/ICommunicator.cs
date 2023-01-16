using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyMate_Module;

namespace ServerModule
{
    internal interface ICommunicator
    {
        public void Subscribe(Thread thread);
        public void Unsubscribe(Thread thread);
        public int setMessage(int target, Communicator message);
        public Communicator GetMessage(int target);

    }
}
