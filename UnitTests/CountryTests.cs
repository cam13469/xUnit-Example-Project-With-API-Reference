using System.Collections;
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
}

public class ClosestCountryTestData : DataTemplate<string, string>
{
    public ClosestCountryTestData() : base(
        new string[] { "Australia", "France", "Rwanda" },
        new string[] { "Timor-Leste", "Andorra", "Burundi" })
    { }
}

public class GetCapitalCityTestData : DataTemplate<string, string>
{
    public GetCapitalCityTestData() : base(
        New("Australia", "France", "Indonesia"),
        New("Canberra", "Paris", "Jakarta")
        )
    { }
}