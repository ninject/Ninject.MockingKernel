# Ninject.MockingKernel 

[![Build status](https://ci.appveyor.com/api/projects/status/kitij4ayps08ot1c?svg=true)](https://ci.appveyor.com/project/Ninject/ninject-mockingkernel)
[![codecov](https://codecov.io/gh/ninject/Ninject.MockingKernel/branch/master/graph/badge.svg)](https://codecov.io/gh/ninject/Ninject.MockingKernel)
[![NuGet Version](http://img.shields.io/nuget/v/Ninject.MockingKernel.svg?style=flat)](https://www.nuget.org/packages/Ninject.MockingKernel/)
[![NuGet Downloads](http://img.shields.io/nuget/dt/Ninject.MockingKernel.svg?style=flat)](https://www.nuget.org/packages/Ninject.MockingKernel/)

This extension provides integration between Ninject and Moq/NSubstitute/FakeItEasy, creating a "lightweight" auto-mocking container.

## Getting started

In your tests, you should use the MockingKernel instead of the StandardKernel. It adds the following features to Ninject:

1. The following syntax will bind a service to the mocked object of a `Mock<T>`. 
```C#
Bind<IService>().ToMock();
```
You can add additional interfaces to the mock:
```C#
Bind<IService>().ToMock(typeof(IInterface1), typeof(IInterface2));
```

2. If you request a service that has no binding, instead of creating an implicit self-binding, the MockingKernel
   will create an instance of `Mock<T>` and return the mocked object associated with it.

3. A `Reset()` method is available, which clears the Ninject cache of any activated instances, regardless of whether they
   remain in scope. You can call this method after each test to ensure that instances are reactivated, without having
   to dispose and re-initialize the kernel each time.

Hat tip to [Scott Reynolds](http://github.com/scottcreynolds) for the idea, and to [Sean Chambers](http://github.com/schambers) for dogfooding.

## Documentation
https://github.com/ninject/Ninject.MockingKernel/wiki