## Threading

### Exercise 1: Create Multiple Threads

In this exercise, you create a simple console application and start two threads simultaneously.

{1} Create a new console application, and call it SimpleThreadingDemo.

{2} Create a new static method called Counting.

{3} In the new class, add an include statement (or the Imports statement for Visual Basic) to the System.Threading namespace.

{4} In the new method, create a for loop that counts from 1 to 10.

{5} Within the new for loop, write out the current count and the ManagedThreadId for the current thread.

{6} After writing out to the console, sleep the current thread for 10 milliseconds.

{7} Go back to the Main method, and create a new StartThread delegate that points to the Counting method.

{8} Now create two threads, each pointing to the Counting method.

{9} Start both threads.

{10} Join both threads to ensure that the application doesn't complete until the threads are done. Your code should look something like this:

```C#
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

class Program
{
 static void Main(string[] args)
 {
  ThreadStart starter = new ThreadStart(Counting);
  Thread first = new Thread(starter);
  Thread second = new Thread(starter);

  first.Start();
  second.Start();


  first.Join();
  second.Join();

  Console.Read();
 }

 static void Counting()
 {
  for (int i = 1; i <= 10; i++)
  {
   Console.WriteLine("Count: {0} - Thread: {1}",i, Thread.CurrentThread.ManagedThreadId);
   Thread.Sleep(10);
  }
 }
}
```

{11} Build the project, and resolve any errors.
Verify that the console application successfully shows the threads running concurrently.
You can determine this by checking whether each thread's counts are intermingled with those of other threads.
The exact nature of the intermingling is dependent on the type of hardware you have.
A single processor machine will be very ordered, but a multiprocessor (or multicore) machine will be somewhat random.

### Exercise 2: Use a Mutex to Create a Single-Instance Application

In this lab, you create a simple console application in which you will use a Mutex
to ensure there is only one instance of the application running at any point.

{1} Create a new console application called SingleInstance.

{2} In the main code file, include (or import for Visual Basic) System.Threading.

{3} In the main method of the console application, create a local Mutex variable and assign it a null (or Nothing in Visual Basic).

{4} Create a constant string to hold the name of the shared Mutex. Make the value `"RUNMEONCE"`.

{5} Create a try/catch block.

{6} Inside the try section of the try/catch block, call the Mutex.OpenExisting method,
using the constant string defined in step 4 as the name of the Mutex.
Then assign the result to the Mutex variable created in step 2.

{7} For the catch section of the try/catch block,
catch a WaitHandleCannotBeOpenedException to determine that the named Mutex doesn't exist.

{8} Next, test the Mutex variable created in step 2 for null (or Nothing in Visual Basic) to see whether the Mutex could be found.

{9} If the Mutex was not found, create the Mutex with the constant string from step

{10} If the Mutex was found, close the Mutex variable and exit the application. Your final code might look something like this:

```C#
using System.Threading;

class Program
{
 static void Main(string[] args)
 {
  Mutex oneMutex = null;
  const string MutexName = "RUNMEONLYONCE";

  try // Try and open the Mutex
  {
   oneMutex = Mutex.OpenExisting(MutexName);
  }
  catch (WaitHandleCannotBeOpenedException)
  {
   // Cannot open the mutex because it doesn't exist
  }

  // Create it if it doesn't exist
  if (oneMutex == null)
  {
   oneMutex = new Mutex(true, MutexName);
  }
  else
  {
   // Close the mutex and exit the application
   // because we can only have one instance
   oneMutex.Close();
   return;
  }


  Console.WriteLine("Our Application");
  Console.Read();
 }
}
```

{11} Build the project, and resolve any errors.
Verify that only one instance of the applcation can be run at once.

----

----

Prev: [Serialization](descSerializing.md)  
[Back to README](README.md)
