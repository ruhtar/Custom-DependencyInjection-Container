using Custom_DI_Container;
using Custom_DI_Container.Services;

var container = new Container();

container.AddSingleton<IRandomNumber, RandomNumber>();
container.AddTransient<IFirstService, FirstService>();
container.AddTransient<ISecondService, SecondService>();

var service1 = container.GetService<IFirstService>();
var service2 = container.GetService<IFirstService>();
var randoNumber1 = container.GetService<IRandomNumber>();
var randoNumber2 = container.GetService<IRandomNumber>();

service1.Print();
service2.Print();
Console.WriteLine($"Is RandomNumberService Singleton? {randoNumber2 == randoNumber1}");


Console.ReadLine();