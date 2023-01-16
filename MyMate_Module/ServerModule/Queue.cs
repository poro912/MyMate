using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyMate_Module;

namespace ServerModule
{
    public class Queue
    {
        Queue<Communicator> process;
        Queue<Communicator> send;
        Queue<Communicator> receive;
        Queue<Thread> subscribers;
    }
}
