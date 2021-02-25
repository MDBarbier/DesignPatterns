namespace FlyweightDemo
{
    public interface IDrinkFlyweight
    {
        //Intrinsic state - shared/readonly
        public string Name { get; }

        //Extrinsic state
        public void Serve(string size);
    }
}
