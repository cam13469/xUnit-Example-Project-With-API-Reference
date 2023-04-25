using WorldNavigation;
using System.Diagnostics;

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

        Debug.WriteLine(navigator.GetDistanceToClosestMajorCity("Australia", "Melbourne"));
        Debug.WriteLine(navigator.GetDistanceToClosestMajorCity("France", "Paris"));
        Debug.WriteLine(navigator.GetDistanceToClosestMajorCity("Nigeria", "Ondo"));
        Debug.WriteLine(navigator.GetDistanceToClosestMajorCity("Russia", "Moscow"));

        Debug.WriteLine(navigator.GetClosestCountry("Australia"));
        Debug.WriteLine(navigator.GetClosestCountry("Rwanda"));

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