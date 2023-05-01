
using WorldNavigation;

namespace UnitTests;

public static class CityTests
{
    internal static Navigator navigator = new();

    [Theory]
    [MemberData(nameof(MajorCitiesTestData.Islands), MemberType = typeof(MajorCitiesTestData))]
    internal static void GetMajorCities_Island_ArrayMajorCities(string country, string[] cities)
    {
        string[] names = (from c in navigator.GetMajorCities(country) select c.name).ToArray();
        Assert.True(cities.All(names.Contains));
        
    }
}

public static class MajorCitiesTestData
{
    public static IEnumerable<object[]> Islands()
    {
        yield return new object[] { 
            "Australia",
            new string[] {  "Melbourne",
                            "Adelaide",
                            "Perth",
                            "Darwin",
                            "Hobart",
                            "Brisbane",
                            "Sydney",
                            "Canberra" }
        };
    }
}