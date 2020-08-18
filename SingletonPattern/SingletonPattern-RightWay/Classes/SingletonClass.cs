using System;

namespace SingletonPattern_RightWay.Classes
{
    public sealed class SingletonClass
    {
        //Lazy field containing the actual instance
        private static readonly Lazy<SingletonClass> lazy = new Lazy<SingletonClass>(() => new SingletonClass());

        //Property to return the lazy instantiated field
        public static SingletonClass Instance { get 
            {
                Console.WriteLine("inside Instance prop");
                return lazy.Value; 
            } 
        }

        //Constructor is private
        private SingletonClass()
        {
            Console.WriteLine("inside constructor");
        }
    }
}
