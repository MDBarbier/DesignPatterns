using System;
using System.Collections.Generic;
using System.Text;

namespace SingletonContainerDemo
{
    class MyService : IMyService
    {       

        //Constructor is private
        public MyService()
        {
            Console.WriteLine("inside constructor");
        }
    }
}
