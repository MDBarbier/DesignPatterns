using System.Collections.Generic;
using System.Linq;

namespace MediatorPatternDemo.Structural
{
    public class ConcreteMediator : Mediator
    {
        List<Colleague> colleagues = new List<Colleague>();

        public void Register(Colleague colleague)
        {
            colleague.SetMediator(this);
            this.colleagues.Add(colleague);
        }

        public T CreateColleague<T>() where T: Colleague, new()
        {
            var c = new T();
            c.SetMediator(this);
            this.colleagues.Add(c);
            return c;
        }

        public override void Send(string message, Colleague colleague)
        {            
            this.colleagues.Where(a => a != colleague).ToList().ForEach(a => a.HandleNotification(message));
        }
    }
}
