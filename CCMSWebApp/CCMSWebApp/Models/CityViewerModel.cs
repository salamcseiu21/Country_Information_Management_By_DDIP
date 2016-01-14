using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CountryCityInformationManagementSystem.BLL;

namespace CountryCityInformationManagementSystem.Models
{
                
    public class CityViewerModel
    {
        CityManager cityManager=new CityManager();
        public CityViewerModel(string cityName, string aboutCity, int noOfDewellers, string location, string weather, string countryName, string aboutCountry):this(cityName,noOfDewellers,countryName)
        {
           
            AboutCity = aboutCity;
            Location = location;
            Weather = weather;
            AboutCountry = aboutCountry;
        }

        public CityViewerModel()
        {
        }

        public CityViewerModel(string cityName, long noOfDewellers, string countryName)
        {
            CityName = cityName;
            NoOfDewellers = noOfDewellers;
            CountryName = countryName;
        }

        

        public int Id { get; set; }
        public string CityName { get; set; }
        public string AboutCity { get; set; }
        public long NoOfDewellers { get; set; }
        public string Location { get; set; }
        public string Weather { get; set; }
        public string CountryName  { get; set; }
        public string AboutCountry { get; set; }
        
    }
}