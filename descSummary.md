## Summary

Serialization outputs an object as a series of bytes, whereas deserialization reads
a serialized object and defines the value of an object. Most custom classes can be
serialized by simply adding the Serializable attribute. In some cases, you might
be able to improve efficiency or provide for changes to the structure of classes by
modifying your class to change the default serialization behavior.
* XML serialization provides a way to store and transfer objects using open standards.
XML serialization can be customized to fit the exact requirements of an
XML schema, making it simple to convert objects into XML documents and
back into objects.  
* Custom serialization is required in situations where classes contain complex
information, significant changes have occurred to the structure of a class
between different versions, and where you need complete control over how
information is stored. You can perform custom serialization by imlement **ISerializable** interface.

----

The Thread class can be used to create multiple paths for simultaneous execution  
in your own applications.  
* Using the lock (SyncLock in Visual Basic) keyword will allow you to write threadsafe  
access to your code's data.  
* You must be careful in writing thread-safe code to avoid deadlock situations.  
* The ReaderWriterLock class can be used to write thread-safe code that is less  
prone to allowing only a single thread at a time to access its data.  
* The WaitHandle derived classes (Mutex, Semaphore, and Event classes) exemplify  
Windows operating-system-level synchronization objects.  
* Much of the .NET Framework supports the Asynchronous Programming Model  
(APM) to allow for asynchronous execution of code without having to directly  
deal with the ThreadPool or Threads.  
* The ThreadPool is a convenient class that enables fast creation of threads for  
queuing up code to run as well as for waiting for WaitHandle derived objects.  
* Timers are useful objects for firing off code on separate threads at specific intervals.  

----

Regular expressions have roots in UNIX and Perl, and they can seem complicated
and unnatural to .NET Framework developers. However, regular expressions
are extremely efficient and useful for validating text input, extracting text
data, and reformatting data.  
 In the past decade, the most commonly used encoding standard for text files has
gradually shifted from ASCII to Unicode. Unicode itself supports several different
encoding standards. While the .NET Framework uses the UTF-16 encoding
standard by default, you can specify other encoding standards to meet interoperability
requirements.

----

Next: [What I've done](Conclusion.md)  
Prev: [MultiThreading](descThreading.md)  
[Back to README](README.md)
