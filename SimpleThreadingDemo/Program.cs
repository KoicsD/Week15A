using System;
using System.Threading;

namespace SimpleThreadingDemo
{
    class Program
    {
        static void Count()
        {
            for (int i = 1; i <= 15; ++i)
            {
                Console.WriteLine("Count: {0}, at: {1} - Thread: {2}", i, DateTime.Now.Millisecond, Thread.CurrentThread.ManagedThreadId);
                Thread.Sleep(10);
            }
        }

        static void Main(string[] args)
        {
            Thread aChildThread, anotherChildThread;
            aChildThread = new Thread(Count);
            anotherChildThread = new Thread(Count);
            for (int i = 1; i <= 10; ++i)
            {
                if (i == 3)
                {
                    aChildThread.Start();
                    anotherChildThread.Start();
                }
                if (i == 8) // comment this block out to see what if children are not joint
                {
                    aChildThread.Join();
                    anotherChildThread.Join();
                }
                Console.WriteLine("Count: {0}, at: {1} - Thread: {2}", i, DateTime.Now.Millisecond, Thread.CurrentThread.ManagedThreadId);
                Thread.Sleep(10);
            }
        }
    }
}
