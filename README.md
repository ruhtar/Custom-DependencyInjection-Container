# Custom DI Container 📦

This project is a very lightweight Dependency Injection (DI) Container implemented in C#. It provides a simple and minimalistic approach to managing dependencies. My project doesn't come close to the .NET dependency injection container, but it was fun to study and create something that mimics its functionality. 

## What is Dependency Injection?
Dependency Injection is a design pattern where the dependencies of a class are provided from the outside rather than created within the class itself. This pattern encourages modular design by decoupling classes from their dependencies, making them easier to manage, test, and reuse.
In a typical DI scenario:

- Dependencies are defined as interfaces.
- Classes that depend on these interfaces specify their dependencies through constructor parameters or setter methods.
- An external entity, often referred to as the "container", is responsible for creating instances of classes and injecting their dependencies.

## Project Overview
This project consists of a custom DI Container implementation and a simple console application demonstrating its usage. Here's a quick rundown of the components:

- Container.cs: This class represents the DI container. It provides methods for registering dependencies (AddSingleton and AddTransient) and resolving them (GetService).

- Lifetime.cs: An enumeration representing the lifetime of registered services. It defines two options: Singleton (a single instance for the entire application) and Transient (a new instance every time it's requested).

- IRandomNumber.cs: An interface defining the contract for generating random numbers.

- RandomNumber.cs: A class implementing the IRandomNumber interface. It generates random numbers.

- IService.cs: An interface defining a service with a Print method.

- Service.cs: A class implementing the IService interface. It provides a method to print a message.
