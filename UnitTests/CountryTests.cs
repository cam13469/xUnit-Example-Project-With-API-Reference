using System.Collections;
using System.Diagnostics;
using WorldNavigation;
namespace UnitTests;

public static class CountryTests
{
    internal static Navigator navigator = new();

    // Simple Fact check
    [Fact]
    internal static void GetCapitalCity_Australia_IsCanberra()
    {
        Assert.Equal("Canberra", navigator.GetCapitalCity("Australia")?.name);
    }

    [Theory]
    [ClassData(typeof(ClosestCountryTestData))]
    internal static void GetClosestCountry_SomeCountry_Verified(string country, string expected)
    {
        Assert.Equal(expected, navigator.GetClosestCountry(country).Item1.name);
    }

    [Theory]
    [ClassData(typeof(GetCapitalCityTestData))]
    internal static void GetCapitalCity_SomeCountry_Verified(string country, string expected)
    {
        Assert.Equal(expected, navigator.GetCapitalCity(country).name);
    }

    [Theory]
    [ClassData(typeof(DistanceBetweenCountriesTestData))]
    internal static void GetClosestCountry_SomeCountry_Within50km(string country, double expected)
    {
        double distance = navigator.GetClosestCountry(country).Item2;
        Assert.InRange(Math.Abs(distance - expected), -25, 25);
    }
}

public class ClosestCountryTestData : DataTemplate<string, string>
{
    public ClosestCountryTestData() : base(
        Data("Australia", "France", "Rwanda"),
        Data("Timor-Leste", "Andorra", "Burundi")
        )
    { }
}

public class GetCapitalCityTestData : DataTemplate<string, string>
{
    public GetCapitalCityTestData() : base(
        Data("Australia", "France", "Indonesia"),
        Data("Canberra", "Paris", "Jakarta")
        )
    { }
}

public class DistanceBetweenCountriesTestData : DataTemplate<string, double>
{
    public DistanceBetweenCountriesTestData() : base(
        Data("Australia", "France", "Nigeria"),
        Data(2019.0, 426.0, 450.0)
        )
    { }
}