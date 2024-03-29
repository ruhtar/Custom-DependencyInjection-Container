using Custom_DI_Container;
using Custom_DI_Container.Services;

var container = new Container();

container.RegisterTransient<IRandomNumber, RandomNumber>();
container.RegisterSingleton<IService, Service>();

var service = container.GetService<IService>();

service.Print();

Console.ReadLine();