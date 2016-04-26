using System;
using System.Threading;

namespace SingleInstanceExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Mutex mutex;
            const string mutexName = "RUNMEONCE";

            /*try
            {
                mutex = Mutex.OpenExisting(mutexName);
                mutex.Close();
                return;
            }
            catch (WaitHandleCannotBeOpenedException)
            {
                mutex = new Mutex(true, mutexName);
            }*/

            if (Mutex.TryOpenExisting(mutexName, out mutex))
            {
                mutex.Close();
                return;
            }
            else
            {
                mutex = new Mutex(true, mutexName);
            }

            Console.WriteLine("Our Application");
            Console.ReadKey();
        }
    }
}
