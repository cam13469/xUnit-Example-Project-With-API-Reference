
using System.Device.Location;
using System.Diagnostics;

namespace WorldNavigation
{
    public class City
    {
        public static Dictionary<int, City> cities_by_id = new Dictionary<int, City>();
        public static Dictionary<string, List<City>> cities_by_name = new Dictionary<string, List<City>>();
        public static Dictionary<string, List<City>> cities_by_country = new Dictionary<string, List<City>>();
        public static bool WasInstanced = false;

        public string name;
        public Tuple<double, double> location;
        public string country;
        public string iso2;
        public int population;
        public string type { get; }
        public int id;

        public City(string name, Tuple<double, double> location, string country, string iso2, int population, string type, int id)
        {
            this.name = name;
            this.location = location;
            this.country = country;
            this.iso2 = iso2;
            this.population = population;
            this.type = type;
            this.id = id;

            cities_by_id[id] = this;

            if (cities_by_name.ContainsKey(name))
                cities_by_name[name].Add(this);

            else
                cities_by_name[name] = new List<City> { this };

            List<City> cities = new();
            if (cities_by_country.ContainsKey(country))
                cities_by_country[country].Add(this);
            else
                cities_by_country[country] = new List<City> { this };
        }

        public double DistanceTo(City city)
        {
            GeoCoordinate c1 = new GeoCoordinate(this.location.Item1, this.location.Item2);
            GeoCoordinate c2 = new GeoCoordinate(city.location.Item1, city.location.Item2);
            return Math.Round(c1.GetDistanceTo(c2) / 1000, 1);
        }

        public override string ToString()
        {
            return $"Name: {name}, Location: ({location.Item1}, {location.Item2}), Country: {country}, type: {type}";
        }
    }

    public static class CityData
    {
        public static void CreateCityData()
        {
            City.WasInstanced = true;

            using (var reader = new StreamReader(@"C:\Users\cam13469\Documents\Project - Unit Testing\WorldNavigation\WorldNavigation\WorldData\city_data.csv"))
            {
                var header = reader.ReadLine();
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');

                    try
                    {
                        new City(
                        name: values[0],
                        location: new Tuple<double, double>(Convert.ToDouble(values[1]), Convert.ToDouble(values[2])),
                        country: values[3],
                        iso2: values[4],
                        population: Convert.ToInt32(values[6]),
                        type: values[5],
                        id: Convert.ToInt32(values[7])
                        );
                    }
                    catch (FormatException) { }
                    
                }
            }
        }

        public static void Test()
        {
            CreateCityData();

            City c1 = City.cities_by_id[1826645935];
            Debug.WriteLine(c1);

            List<City> c2 = City.cities_by_name["Melbourne"];
            c2.ForEach(x => Debug.WriteLine(x));

            List<City> c3 = City.cities_by_name["Canberra"];
            c3.ForEach(x => Debug.WriteLine(x));
        }
    }
}
