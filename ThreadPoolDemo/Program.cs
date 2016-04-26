using System;
using System.Threading;

namespace ThreadPoolDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            WaitCallback callback = new WaitCallback(ShowMyText);

            ThreadPool.QueueUserWorkItem(callback, "Alpha");
            ThreadPool.QueueUserWorkItem(callback, "Betha");
            ThreadPool.QueueUserWorkItem(callback, "Ghamma");
            ThreadPool.QueueUserWorkItem(callback, "Epsilon");
            ThreadPool.QueueUserWorkItem(callback, "Phi");
            ThreadPool.QueueUserWorkItem(callback, "Pi");
            ThreadPool.QueueUserWorkItem(callback, "Omegha");

            Thread.Sleep(10);
        }

        static void ShowMyText(object state)
        {
            string myText = (string)state;
            Console.WriteLine("Thread: {0} - {1}", Thread.CurrentThread.ManagedThreadId, myText);
        }
    }
}
