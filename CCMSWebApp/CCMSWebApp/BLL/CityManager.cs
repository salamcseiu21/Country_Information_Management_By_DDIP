using System.Collections.Generic;
using CountryCityInformationManagementSystem.DAL;
using CountryCityInformationManagementSystem.Models;

namespace CountryCityInformationManagementSystem.BLL
{
    public class CityManager
    {
        CityGateway cityGateway=new CityGateway();

        public string Save(City aCity)
        {
           
            if (IsCityExits(aCity))
            {
                return "City Name must be unique";
            }
            if (cityGateway.Insert(aCity)>0)
            {
                return "Save sucessfully!";
            }
            return "Failed to Save";
        }

        private bool IsCityExits(City aCity)
        {
          City city=cityGateway.GetCityInformationByName(aCity.Name);
            if (city != null)
            {
                return true;
            }
            return false;
        }

        public List<City> GetAll()
        {
            return cityGateway.GetAll();
        }

        public List<CityViewerModel> GetCityInformation()
        {
            return cityGateway.GetCityInformation();
        }
                
        public List<CityViewerModel> GetCityInformation(string cityName)
        {
            return cityGateway.GetCityInformation(cityName);
        }

        public List<CityViewerModel> GetCityInformationByCountryName(string countryName)
        {
            return cityGateway.GetCityInformationByCountryName(countryName);
        }

        

        public List<CountryViewerModel> GetCountryInformationByName(string countryName)
        {
            return cityGateway.GetCountryInformatinByName(countryName);
        }


        public List<CountryViewerModel> GetCountryInformation()
        {
            return cityGateway.GetCountryInformation();
        }
    }
    
}