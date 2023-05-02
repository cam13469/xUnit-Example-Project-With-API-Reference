# xUnit-Example-Project-With-API-Reference
A .NET Core xUnit example project to unit test a small code-base.

This repo is designed to provide an example of how the .NET Core xUnit unit testing library can be used to unit test a small code base. The repo contains the code base under which we are trying to test, along with the unit test project with all of the tests contained within. The project is deployed as an MS Solution so the project can be opened and edited in Visual Studio.

The code base is a small world navigation library which allows the user to filter location data about world countries, and major cities. Think of it as a poor-man's Google Maps.

There is no API or documentation for the library as it is used as an example to elucidate the potential of the xUnit library. If you are interested in exploring the functionality of the code base, look no further than the **navigator.cs** file for a list of methods (functionality is implied in the method names).

#### Run Options
To write your own code within the project without copying the code base, modify the **Main.cs** file in the **App** directory.

To run the unit tests, either use Visual Studio and the Test Explorer window, or navigate to the project root directory in a shell on your machine and run:

```Bash
dotnet test
```
