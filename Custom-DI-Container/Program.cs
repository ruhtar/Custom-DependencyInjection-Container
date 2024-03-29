using Custom_DI_Container;
using Custom_DI_Container.Services;

var container = new Container();

container.RegisterSingleton<IService, Service>();
//container.RegisterTransient<IService, Service>();

var service1 = container.GetService<IService>();
var service2 = container.GetService<IService>();

//Testing singleton instance
Console.WriteLine($"(Singleton) The services are the same: {service2 == service1}");

service1.Print();
service2.Print();

Console.ReadLine();