using Custom_DI_Container;
using Custom_DI_Container.Services;

internal class Program
{
    private static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1. Test RandomNumber as a Singleton");
            Console.WriteLine("2. Test RandomNumber as a Transient");
            Console.WriteLine("3. Exit");
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    TestSingleton();
                    break;
                case "2":
                    TestTransient();
                    break;
                case "3":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid option. Please choose again.");
                    break;
            }
        }
    }

    static void TestSingleton()
    {
        var container = new Container();

        container.AddSingleton<IRandomNumber, RandomNumber>();
        container.AddTransient<IService, Service>();

        var service1 = container.GetService<IService>();
        var service2 = container.GetService<IService>();
        var randomNumber1 = container.GetService<IRandomNumber>();
        var randomNumber2 = container.GetService<IRandomNumber>();

        service1.Print();
        service2.Print();
        Console.WriteLine($"Is RandomNumber Singleton? {randomNumber2 == randomNumber1}");

        Console.WriteLine("Press Enter to continue...");
        Console.ReadLine();
    }

    static void TestTransient()
    {
        var container = new Container();

        container.AddTransient<IRandomNumber, RandomNumber>();
        container.AddTransient<IService, Service>();

        var service1 = container.GetService<IService>();
        var service2 = container.GetService<IService>();
        var randomNumber1 = container.GetService<IRandomNumber>();
        var randomNumber2 = container.GetService<IRandomNumber>();

        service1.Print();
        service2.Print();
        Console.WriteLine($"Is RandomNumber Singleton? {randomNumber2 == randomNumber1}");

        Console.WriteLine("Press Enter to continue...");
        Console.ReadLine();
    }
}