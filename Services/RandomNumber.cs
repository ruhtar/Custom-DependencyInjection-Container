internal interface IRandomNumber
{
    int Generate();
}

internal class RandomNumber : IRandomNumber
{
    private int _random;

    public RandomNumber()
    {
        _random = new Random().Next(1, 101);
    }

    public int Generate()
    {
        return _random;
    }
}
