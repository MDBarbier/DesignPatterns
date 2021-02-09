namespace MediatorPatternDemo.Structural
{
    public abstract class Mediator
    {
        public abstract void Send(string message, Colleague colleague);
        public abstract void SendTo<T>(string from, string message) where T: Colleague;
    }
}
