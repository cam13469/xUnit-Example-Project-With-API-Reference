using System.Device.Location;
using System.Diagnostics;

namespace WorldNavigation
{
    public class Country
    {
        public static Dictionary<string, Country> countries_by_name = new Dictionary<string, Country>();

        public string name;
        public Tuple<double, double> location;
        public string iso2;
        public Country(string name, Tuple<double, double> location, string iso2)
        {
            this.name = name;
            this.location = location;
            this.iso2 = iso2;

            countries_by_name[name] = this;
        }

        public double DistanceTo(Country country)
        {
            GeoCoordinate c1 = new GeoCoordinate(this.location.Item1, this.location.Item2);
            GeoCoordinate c2 = new GeoCoordinate(country.location.Item1, country.location.Item2);
            return Math.Round(c1.GetDistanceTo(c2) / 1000, 1);
        }

        public override string ToString()
        {
            return $"Name: {name}, location: ({location.Item1}, {location.Item2}, ISO: {iso2})";
        }
    }

    public static class CountryData
    {
        public static void CreateCountryData()
        {
            using (var reader = new StreamReader(@"C:\Users\cam13469\Documents\Project - Unit Testing\WorldNavigation\WorldNavigation\WorldData\country_data.csv"))
            {
                var header = reader.ReadLine();
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    new Country(values[3], new Tuple<double, double>(Convert.ToDouble(values[1]), Convert.ToDouble(values[2])), values[0]);
                }
            }
        }

        public static void Test()
        {
            CreateCountryData();
            Debug.WriteLine(Country.countries_by_name["Australia"]);

            Country c1 = Country.countries_by_name["Australia"];
            Country c2 = Country.countries_by_name["Ethiopia"];

            Debug.WriteLine(c1.DistanceTo(c2));
        }
    }
}
