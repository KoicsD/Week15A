## What I have done

### Regex

In case of Regex exercise, I've simply typed the given code-example, and it worked.  
In case of the FIle-Encoding example, I was unable to find the given file, named `boot.ini`.
I've chosen `c:\Windows\WindowsUpdate.log` instead.
Ufortunatelly, *Notepad* seems to display the file with UTF-7 encoding properly.

### Serialization

In case of serialization I've managed to understand
that there are 2 different  way to decide
which member variables of a class-instance to be serialized.
I've made experiences on what kind of *Exception*s can be thrown
when trying to deserialize an object in a way
that is different from the way it has been serialized.  
I've also managed to simplify the *Mutex*-example.

### (Multi)Threading

In the simple threading example I've made an experience on
what is happening if the main thread does not wait (*Join*) the child threads.
To make the result more spectacular,
I've even made the milliseconds of the current datetime visible.  
In case of the *ThreadPool* example, threads queued in *ThreadPool* fails to write to the console
if main thread has already finished.
On the other hand, if I use *ReadKey* to block *Main*, it never releases controll,
and for this reason my application is unable to exit in a normal way.

### Possible Improvements and Conclusion

On the end of Week 15A it is obbious that I need to read several articles about regular expressions.  
I would create another project, connected to *Person* class,
in which I would serialize *Person* instances by *XMLSerializer*.  
And I also need to understand the conditions when a multithread application exits.

Overall, I've found Week 15A useful.

----

----

Prev: [MultiThreading](descThreading.md)  
[Back to README](README.md)
