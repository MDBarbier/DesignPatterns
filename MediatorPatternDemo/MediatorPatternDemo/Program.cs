using MediatorPatternDemo.Structural;
using System;

namespace MediatorPatternDemo
{
    /// <summary>
    /// The mediator pattern aims to simplify the communication between objects. If you have 6 objects that all need to communicate with each other that's a lot of references and messages.
    /// 
    /// With the mediator pattern you have a central object which keeps references to the others, and directs the messages around.
    /// 
    /// Roles in this pattern:
    ///  - Mediator: defines communication between the colleagues (typically abstract base class)
    ///  - Concreate Mediator: implements communications between colleagues (implements the mediator abstract class)
    ///  - Colleague: only communicates with the mediator (abstract base class, references only it's mediator)
    ///  - Concrete colleague: receives messages only from the mediator (implements the colleague, defines specific behaviour)
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting mediator pattern demo app");            
            
            StructuralExample();
        }

        private static void StructuralExample()
        {
            ConcreteMediator cm = new ConcreteMediator();

            //We can register colleages individually
            var c1 = cm.CreateColleague<Colleague1>("c1");
            var c2 = cm.CreateColleague<Colleague2>("c2");

            //Or en massee
            var c3 = new Colleague3() { Name = "c3" };
            var c4 = new Colleague4() { Name = "c4" };
            var c4a = new Colleague4() { Name = "c4a" };
            cm.RegisterMembers(c3, c4, c4a);

            //Each of these messages will be received by all registered colleagues except the sending one
            c1.Send("Hello world");
            c2.Send("hello to you too!!");
            c3.Send("Hello again");
            c4.Send("Bonjour");

            //The mediator allows the sending of a message to all colleagues of a particular type
            cm.SendTo<Colleague4>("System", "Please change your password");
        }
    }
}
