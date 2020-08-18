using SingletonPattern.Classes;
using System;

namespace SingletonPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting singleton demo");

            SingletonClass singleton = SingletonClass.Instance;
            singleton = SingletonClass.Instance;
            singleton = SingletonClass.Instance;
            singleton = SingletonClass.Instance;
            singleton = SingletonClass.Instance;
            singleton = SingletonClass.Instance;

            Console.WriteLine("Finished singleton demo");
        }
    }
}
