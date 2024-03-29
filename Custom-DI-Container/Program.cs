using Custom_DI_Container;
using Custom_DI_Container.Services;

var customContainer = new Container();

customContainer.RegisterSingleton<IService, Service>();

var service1 = customContainer.GetService<IService>();

//Testing singleton instance
Console.WriteLine($"(Singleton) The services are the same: {service1}");

service1.Print();

Console.ReadLine();