using Custom_DI_Container;
using Custom_DI_Container.Services;

internal class Program
{
    private static void Main()
    {
        while (true)
        {
            Console.WriteLine("Choose an option:" + "\n");
            Console.WriteLine("1. Test RandomNumber as a Singleton" + "\n");
            Console.WriteLine("2. Test RandomNumber as a Transient" + "\n");
            Console.WriteLine("3. Exit" + "\n");
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    TestsLifetime(Lifetime.Singleton);
                    break;
                case "2":
                    TestsLifetime(Lifetime.Transient);
                    break;
                case "3":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid option. Please choose again." + "\n");
                    break;
            }
        }
    }

    static void TestsLifetime(Lifetime lifetime)
    {
        var container = new Container();

        if (lifetime == Lifetime.Singleton)
        {
            container.AddSingleton<IRandomNumber, RandomNumber>();
        }
        else
        {
            container.AddTransient<IRandomNumber, RandomNumber>();
        }

        container.AddTransient<IService, Service>();

        var service1 = container.GetService<IService>();
        var service2 = container.GetService<IService>();
        var randomNumber1 = container.GetService<IRandomNumber>();
        var randomNumber2 = container.GetService<IRandomNumber>();

        var isSingleton = randomNumber2 == randomNumber1;
        if (isSingleton)
        {
            Console.WriteLine($"RandomNumber is a Singleton instance." + "\n");
        }
        else
        {
            Console.WriteLine($"RandomNumber is a Transient instance." + "\n");
        }

        service1.Print();
        service2.Print();

        Console.WriteLine("Press Enter to continue..." + "\n");
        Console.ReadLine();
    }
}