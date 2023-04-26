
namespace WorldNavigation
{
    public class Navigator
    {
        public Navigator()
        {
            CountryData.CreateCountryData();
            CityData.CreateCityData();
        }

        public List<City> GetCities(string country_name)
        {
            return City.cities_by_country[country_name];
        }

        public List<City> GetMajorCities(string country_name)
        {
            return City.cities_by_country[country_name].Where(city => city.type == "admin" || city.type == "primary").ToList();
        }

        public City GetCapitalCity(string country_name)
        {
            List<City> cities = City.cities_by_country[country_name];
            return cities.Where(city => city.type == "primary").First();
        }

        public Tuple<City, double> GetClosestCapitalCity(string country_name, string city_name)
        {
            List<City> cities = GetCities(country_name);
            City home_city = cities.Where(c => c.name == city_name).First();

            List<City> capitals = City.cities_by_id.Values
                .ToList()
                .Where(c => (c.name != city_name) && (c.type == "primary"))
                .ToList();

            Tuple<City, double> closest = new(null, double.MaxValue);
            foreach (City city in capitals)
            {
                if (home_city.DistanceTo(city) < closest.Item2)
                {
                    closest = new Tuple<City, double>(city, home_city.DistanceTo(city));
                }
            }

            return closest;
        }

        public Tuple<Country, double> GetClosestCountry(string country_name)
        {
            Country home_country = Country.countries_by_name[country_name];

            Tuple<Country, double> closest = new(null, double.MaxValue);
            foreach (Country country in Country.countries_by_name.Values)
            {
                if (country.name != country_name)
                {
                    if (home_country.DistanceTo(country) < closest.Item2)
                    {
                        closest = new Tuple<Country, double>(country, home_country.DistanceTo(country));
                    }
                }
            }

            return closest;
        }   


        public Tuple<City, double> GetDistanceToClosestMajorCityInCountry(string country_name, string city_name)
        {
            List<City> cities = GetMajorCities(country_name);
            City home_city = City.cities_by_name[city_name].Where(city => city.country == country_name).First();

            Tuple<City, double> closest = new(null, double.MaxValue);
            foreach (City city in cities)
            {
                if (city.name != city_name)
                {
                    if (home_city.DistanceTo(city) < closest.Item2)
                    {
                        closest = new Tuple<City, double> (city, home_city.DistanceTo(city));
                    }
                }
            }

            return closest;
        }
    }
}