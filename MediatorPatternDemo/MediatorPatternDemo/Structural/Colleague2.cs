using System;

namespace MediatorPatternDemo.Structural
{
    public class Colleague2 : Colleague
    {
        public override string Name { get; set; }
        public override void HandleNotification(string message)
        {
            Console.WriteLine($"Colleague named {Name} of type {nameof(Colleague2)} received notification message: {message}");
        }
    }
}
