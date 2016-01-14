using System.Collections.Generic;
using CountryCityInformationManagementSystem.DAL;
using CountryCityInformationManagementSystem.Models;

namespace CountryCityInformationManagementSystem.BLL
{
    public class CountryManager
    {
        CountryGateway countryGateway=new CountryGateway();

        public string Save(Country country)
        {
            if (IsCountryExits(country))
            {
                return "Country name must be unique";
            }
            if (countryGateway.Insert(country) > 0)
            {
                return "Save Sucessfully!";
            }
            return "Failed to save";
        }

        private bool IsCountryExits(Country country)
        {
            Country aCountry = countryGateway.GetCountryInformationByName(country.Name);
            if (aCountry != null)
            {
                return true;
            }
            return false;
        }

        public List<Country> GetAll()
        {
            return countryGateway.GetAll();
        }

       
    }
}