# Custom DI Container 📦

This project is a very lightweight Dependency Injection (DI) Container implemented in C#. It provides a simple and minimalistic approach to managing dependencies. My project doesn't come close to the .NET dependency injection container, but it was fun to study and create something that mimics its functionality 😛

## What is Dependency Injection?
Dependency injection (DI) is a design pattern used in software development to achieve loose coupling between components or modules within an application. In DI, instead of a component creating its dependencies directly, the dependencies are provided (injected) from outside. This allows for more flexible, maintainable, and testable code, as dependencies can be easily swapped or mocked during testing. DI helps to improve modularity, scalability, and the overall architecture of the software.
In a typical DI scenario:

- Dependencies are defined as interfaces.
- Classes that depend on these interfaces specify their dependencies through constructor parameters or setter methods.
- An external entity, often referred to as the "container", is responsible for creating instances of classes and injecting their dependencies.

## Project Overview
This project consists of a custom DI Container implementation and a simple console application demonstrating its usage. Here's a quick rundown of the components:

- `Container.cs`: This class represents the DI container. It provides methods for registering dependencies (`AddSingleton` and `AddTransient`) and resolving them (`GetService`).

- `Lifetime.cs`: This class represents the enumeration for the lifetime of registered services. It defines two options: Singleton (a single instance for the entire application) and Transient (a new instance every time it's requested).

- `IRandomNumber.cs`: This interface defines the contract for generating random numbers.

- `RandomNumber.cs`: This class implements the `IRandomNumber` interface. It generates a random Guid.

- `IService.cs`: This interface defines a service with a Print method.

- `Service.cs`: This class implements the `IService` interface. It provides a method to print a message.
