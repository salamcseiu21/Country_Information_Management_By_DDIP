using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CountryCityInformationManagementSystem.Models
{
    public class City
    {
        public City(int id, string name, string about, long noOfDewellers, string location, string weather, int countryId):this(name,about,noOfDewellers,location,weather,countryId)
        {
            Id = id;
            
        }

        public City(string name, string about, long noOfDewellers, string location, string weather, int countryId):this()
        {
            Name = name;
            About = about;
            NoOfDewellers = noOfDewellers;
            Location = location;
            Weather = weather;
            CountryId = countryId;
        }

        public City()
        {
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string About { get; set; }
        public long NoOfDewellers   { get; set; }
        public string Location { get; set; }
        public string Weather { get; set; }
        public int CountryId { get; set; }

    }
}