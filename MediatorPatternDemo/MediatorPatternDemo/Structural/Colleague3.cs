using System;
using System.Collections.Generic;
using System.Text;

namespace MediatorPatternDemo.Structural
{
    public class Colleague3 : Colleague
    {
        public override string Name { get; set; }
        public override void HandleNotification(string message)
        {
            Console.WriteLine($"Colleague named {Name} of type {nameof(Colleague3)} received notification message: {message}");
        }
    }
}
