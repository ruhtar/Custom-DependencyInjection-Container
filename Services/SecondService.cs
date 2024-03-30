namespace Custom_DI_Container.Services
{
    internal interface ISecondService
    {
        void Print();
    }

    internal class SecondService : ISecondService
    {
        private readonly IFirstService _firstService;

        public SecondService(IFirstService firstService)
        {
            _firstService = firstService;
        }

        public void Print()
        {
            _firstService.Print();
            Console.WriteLine();
        }
    }
}
