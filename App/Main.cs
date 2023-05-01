using WorldNavigation;
using System.Diagnostics;
using System.Diagnostics.Metrics;

class App
{
    static void Main(string[] args)
    {
        /*CountryData.Test();
        CityData.Test();*/
        Navigator navigator = new();

        City? c1 = navigator.GetCapitalCity("South Korea");
        if (c1 != null)
            Debug.WriteLine(c1);
        else
            Debug.WriteLine("No Capital");

        City? c2 = navigator.GetCapitalCity("Canada");
        if (c2 != null)
            Debug.WriteLine(c2);
        else
            Debug.WriteLine("No Capital");

        Debug.WriteLine(c1.DistanceTo(c2));

        Debug.WriteLine(navigator.GetDistanceToClosestMajorCityInCountry("Australia", "Melbourne"));
        Debug.WriteLine(navigator.GetDistanceToClosestMajorCityInCountry("France", "Paris"));
        Debug.WriteLine(navigator.GetDistanceToClosestMajorCityInCountry("Nigeria", "Ondo"));
        Debug.WriteLine(navigator.GetDistanceToClosestMajorCityInCountry("Russia", "Moscow"));

        Debug.WriteLine(navigator.GetClosestCountry("Australia"));
        Debug.WriteLine(navigator.GetClosestCountry("Rwanda"));
        Debug.WriteLine(navigator.GetClosestCountry("France"));

        Debug.WriteLine(navigator.GetClosestCapitalCity("Australia", "Perth"));
        Debug.WriteLine(navigator.GetClosestCapitalCity("France", "Lyon"));
        Debug.WriteLine(navigator.GetCapitalCity("Greenland"));
        Debug.WriteLine(navigator.GetClosestCapitalCity("Germany", "Nuremberg"));

        Debug.WriteLine(navigator.GetClosestCountry("Nigeria"));

        print_cities(navigator.GetMajorCities("Australia"));
    }

    public static void print_cities(List<City> lst)
    {
        lst.ForEach(x => { Debug.WriteLine(x); }) ;
    }

    public static void print_countries(List<Country> lst)
    {
        lst.ForEach(x => { Debug.WriteLine(x); });
    }
}