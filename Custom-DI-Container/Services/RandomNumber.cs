namespace Custom_DI_Container.Services
{
    internal interface IRandomNumber
    {
        Guid Generate();
    }

    internal class RandomNumber : IRandomNumber
    {
        public Guid Generate() => Guid.NewGuid();
    }
}
