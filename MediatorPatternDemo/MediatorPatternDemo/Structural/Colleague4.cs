using System;
using System.Collections.Generic;
using System.Text;

namespace MediatorPatternDemo.Structural
{
    public class Colleague4 : Colleague
    {
        public override string Name { get; set; }
        public override void HandleNotification(string message)
        {
            Console.WriteLine($"Colleague named {Name} of type {nameof(Colleague4)} received notification message: {message}");
        }
    }
}
