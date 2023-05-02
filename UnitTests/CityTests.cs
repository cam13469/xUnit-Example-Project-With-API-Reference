
using WorldNavigation;

namespace UnitTests;

public static class CityTests
{
    internal static Navigator navigator = new();

    /// <summary>
    /// Tests that the GetMajorCities() method identifies all of the correct major cities of the given island countries
    /// </summary>
    /// <param name="country">The name of an island country</param>
    /// <param name="cities">The expected array of major city names</param>
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