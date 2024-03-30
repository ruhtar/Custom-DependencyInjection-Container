namespace Custom_DI_Container.Services
{
    internal interface IFirstService
    {
        void Print();
    }

    internal class FirstService : IFirstService
    {
        private readonly IRandomNumber _randomNumber;

        public FirstService(IRandomNumber randomNumber)
        {
            _randomNumber = randomNumber;
        }

        public void Print()
        {
            Console.WriteLine($"Hello, world! Your lucky number is: {_randomNumber.Generate()}");
            Console.WriteLine();
        }
    }
}
