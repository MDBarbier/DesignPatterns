using System;

namespace MediatorPatternDemo.Structural
{
    public class Colleague1 : Colleague
    {
        public override string Name { get; set; }

        public override void HandleNotification(string message)
        {
            Console.WriteLine($"Colleague named {Name} of type {nameof(Colleague1)} received notification message: {message}");
        }
    }
}
