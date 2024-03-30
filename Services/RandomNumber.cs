namespace Custom_DI_Container.Services
{
    internal interface IRandomNumber
    {
        string Generate();
    }

    internal class RandomNumber : IRandomNumber
    {
        private string _guid;

        public RandomNumber()
        {
            _guid = Guid.NewGuid().ToString();
        }

        public string Generate() => _guid;
    }
}
