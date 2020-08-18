using System;

namespace SingletonPattern.Classes
{
    /// <summary>
    /// This is a simple example of the Singleton pattern which includes double locking for thread safety however it shouldn't be used because:
    /// 
    ///  This implementation attempts to be thread-safe without the necessity of taking out a lock every time. Unfortunately, there are four downsides to the pattern:
    ///    - It doesn't work in Java. This may seem an odd thing to comment on, but it's worth knowing if you ever need the singleton pattern in Java, and C# programmers may well also be Java programmers. The Java memory model doesn't ensure that the constructor completes before the reference to the new object is assigned to instance. The Java memory model underwent a reworking for version 1.5, but double-check locking is still broken after this without a volatile variable (as in C#).
    ///    - Without any memory barriers, it's broken in the ECMA CLI specification too. It's possible that under the.NET 2.0 memory model(which is stronger than the ECMA spec) it's safe, but I'd rather not rely on those stronger semantics, especially if there's any doubt as to the safety. Making the instance variable volatile can make it work, as would explicit memory barrier calls, although in the latter case even experts can't agree exactly which barriers are required.I tend to try to avoid situations where experts don't agree what's right and what's wrong!
    ///    - It's easy to get wrong. The pattern needs to be pretty much exactly as above - any significant changes are likely to impact either performance or correctness.
    ///    - It still doesn't perform as well as the later implementations.
    ///  (This excerpt from https://csharpindepth.com/articles/singleton by Jon Skeet)
    /// </summary>        
    public sealed class SingletonClass
    {
        private static SingletonClass singletonClass;

        //Must use a private readonly object as the lock, should be a one-to-one relationship between lock objects and lock statements
        private static readonly object Padlock = new object();

        //constructor is private so cannot be called from outside the class
        private SingletonClass()
        {
            Console.WriteLine("Constructor invoked");
        }

        //this public static method either returns existing instance of class, or if there is not one it creates and returns
        public static SingletonClass Instance
        {
            get
            {
                Console.WriteLine("Instance invoked");

                //this first stage of "double locking" pattern checks if there is an instance...
                if (singletonClass == null)
                {
                    //and the second stage of double locking ensures thread safety (this is resource expensive hence why the first stage exists)
                    lock (Padlock)
                    {
                        singletonClass = new SingletonClass();
                    } 
                }

                return singletonClass;
            }
        }
    }
}
