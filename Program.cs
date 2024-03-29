using Custom_DI_Container;
using Custom_DI_Container.Services;

var container = new Container();

container.AddTransient<IRandomNumber, RandomNumber>();
container.AddSingleton<IService, Service>();

var service = container.GetService<IService>();

service.Print();

Console.ReadLine();