namespace Custom_DI_Container.Services
{
    internal interface IService
    {
        void Print();
    }

    internal class Service : IService
    {
        private readonly IRandomNumber _randomNumber;

        public Service(IRandomNumber randomNumber)
        {
            _randomNumber = randomNumber;
        }

        public void Print()
        {
            Console.WriteLine($"Hello, world! Heres a Guid: {_randomNumber.Generate()}");
            Console.WriteLine();
        }
    }
}
