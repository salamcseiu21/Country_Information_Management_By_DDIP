using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using CountryCityInformationManagementSystem.Models;

namespace CountryCityInformationManagementSystem.DAL
{
    public class CityGateway:DBGateway
    {
        public int Insert(City aCity)
        {
            try
            {
                string query = "INSERT INTO t_City VALUES(@name,@about,@noOfDwellers,@location,@weather,@countryId)";
                CommandObj.CommandText = query;
                CommandObj.Parameters.Clear();
                CommandObj.Parameters.AddWithValue("@name", aCity.Name);
                CommandObj.Parameters.AddWithValue("@about", aCity.About);
                CommandObj.Parameters.AddWithValue("@noOfDwellers", aCity.NoOfDewellers);
                CommandObj.Parameters.AddWithValue("@location", aCity.Location);
                CommandObj.Parameters.AddWithValue("@weather", aCity.Weather);
                CommandObj.Parameters.AddWithValue("@countryId", aCity.CountryId);
                ConnectionObj.Open();
                int rowAffected = CommandObj.ExecuteNonQuery();
                ConnectionObj.Close();
                CommandObj.Dispose();
                return rowAffected;
            }
            catch (Exception exception)
            {
                throw new Exception("Unable not save",exception);
            }
            finally
            {
                ConnectionObj.Close();
                CommandObj.Dispose();
            }


        }

        public City GetCityInformationByName(string cityName)
        {
            try
            {
                string query = "SELECT * FROM t_City WHERE Name=@name";
                CommandObj.CommandText = query;
                CommandObj.Parameters.Clear();
                CommandObj.Parameters.AddWithValue("@name", cityName);
                ConnectionObj.Open();
                City city = null;
                SqlDataReader reader = CommandObj.ExecuteReader();
                if (reader.Read())
                {
                    city = new City();
                    city.Id = Convert.ToInt32(reader["Id"].ToString());
                    city.Name = reader["Name"].ToString();
                    city.About = reader["About"].ToString();
                    city.NoOfDewellers = Convert.ToInt64(reader["No_Of_Dwellers"].ToString());
                    city.Location = reader["Location"].ToString();
                    city.Weather = reader["Weather"].ToString();
                    city.CountryId = Convert.ToInt32(reader["CountryId"].ToString());
                }
                reader.Close();
                ConnectionObj.Close();
                return city;
            }
            catch (Exception exception)
            {
                throw new Exception("Unable to Get city information",exception);
            }
            finally
            {
                ConnectionObj.Close();
                CommandObj.Dispose();
            }
        }


        public List<City> GetAll()
        {
            string query = "SELECT * FROM t_City";
            CommandObj.CommandText = query;
            List<City> cities=new List<City>();
            ConnectionObj.Open();
            SqlDataReader reader = CommandObj.ExecuteReader();
            while (reader.Read())
            {
                City city=new City();
                city.Name = reader["Name"].ToString();
                city.About = reader["About"].ToString();
                city.Location = reader["Location"].ToString();
                city.Weather = reader["Weather"].ToString();
                city.NoOfDewellers = Convert.ToInt64(reader["No_Of_Dwellers"].ToString());
                cities.Add(city);
            }
            reader.Close();
            ConnectionObj.Close();
            return cities;
        }

        public List<CityViewerModel> GetCityInformation()
        {
            try
            {
                string query = "SELECT * FROM GetCountryInformation ORDER BY City_Name";
                CommandObj.CommandText = query;
                ConnectionObj.Open();
                List<CityViewerModel> listOfCityViewerModels=new List<CityViewerModel>();
                SqlDataReader reader = CommandObj.ExecuteReader();
                while(reader.Read())
                {
                    CityViewerModel cityViewerModel=new CityViewerModel();
                    cityViewerModel.Id = Convert.ToInt32(reader["Id"].ToString());
                    cityViewerModel.CityName = reader["City_Name"].ToString();
                    cityViewerModel.AboutCity = reader["About_City"].ToString();
                    cityViewerModel.NoOfDewellers = Convert.ToInt64(reader["No_of_Dwellers"].ToString());
                    cityViewerModel.Location = reader["Location"].ToString();
                    cityViewerModel.Weather = reader["Weather"].ToString();
                    cityViewerModel.CountryName = reader["Country_Name"].ToString();
                    cityViewerModel.AboutCountry = reader["About_Country"].ToString();
                    listOfCityViewerModels.Add(cityViewerModel);
                }
                reader.Close();
                ConnectionObj.Close();
                return listOfCityViewerModels;
            }
            catch (Exception exception)
            {
                throw new Exception("Unable to Get city information", exception);
            }
            finally
            {
                ConnectionObj.Close();
                CommandObj.Dispose();
            }  
        }

        public List<CityViewerModel> GetCityInformation(string cityName)
        {
            try
            {
                string query = "SELECT * FROM GetCountryInformation WHERE City_Name LIKE '%" + cityName + "%'";
                CommandObj.CommandText = query;
                ConnectionObj.Open();
                List<CityViewerModel> listOfCityViewerModels = new List<CityViewerModel>();
                SqlDataReader reader = CommandObj.ExecuteReader();
                while (reader.Read())
                {
                    CityViewerModel cityViewerModel = new CityViewerModel();
                    cityViewerModel.Id = Convert.ToInt32(reader["Id"].ToString());
                    cityViewerModel.CityName = reader["City_Name"].ToString();
                    cityViewerModel.AboutCity = reader["About_City"].ToString();
                    cityViewerModel.NoOfDewellers = Convert.ToInt64(reader["No_of_Dwellers"].ToString());
                    cityViewerModel.Location = reader["Location"].ToString();
                    cityViewerModel.Weather = reader["Weather"].ToString();
                    cityViewerModel.CountryName = reader["Country_Name"].ToString();
                    cityViewerModel.AboutCountry = reader["About_Country"].ToString();
                    listOfCityViewerModels.Add(cityViewerModel);
                }
                reader.Close();
                return listOfCityViewerModels;
            }
            catch (Exception exception)
            {
                throw new Exception("Unable to Get city information", exception);
            }
            finally
            {
                ConnectionObj.Close();
                CommandObj.Dispose();
            }    
        }

        public List<CityViewerModel> GetCityInformationByCountryName(string countryName)
        {
            try
            {
                string query = "SELECT * FROM GetCountryInformation WHERE Country_Name LIKE '%" + countryName + "%'";
                CommandObj.CommandText = query;
                ConnectionObj.Open();
                List<CityViewerModel> listOfCityViewerModels = new List<CityViewerModel>();
                CityViewerModel cityViewerModel = null;
                SqlDataReader reader = CommandObj.ExecuteReader();
                while (reader.Read())
                {
                    cityViewerModel = new CityViewerModel();
                    cityViewerModel.Id = Convert.ToInt32(reader["Id"].ToString());
                    cityViewerModel.CityName = reader["City_Name"].ToString();
                    cityViewerModel.AboutCity = reader["About_City"].ToString();
                    cityViewerModel.NoOfDewellers = Convert.ToInt64(reader["No_of_Dwellers"].ToString());
                    cityViewerModel.Location = reader["Location"].ToString();
                    cityViewerModel.Weather = reader["Weather"].ToString();
                    cityViewerModel.CountryName = reader["Country_Name"].ToString();
                    cityViewerModel.AboutCountry = reader["About_Country"].ToString();
                     listOfCityViewerModels.Add(cityViewerModel);
                }
                reader.Close();
                ConnectionObj.Close();
                return listOfCityViewerModels;
            }
            catch (Exception exception)
            {
                throw new Exception("Unable to Get city information", exception);
            }
            finally
            {
                ConnectionObj.Close();
                CommandObj.Dispose();
            }    
        }


        //-------------------Problem here------------------
        public List<CountryViewerModel> GetCountryInformatinByName(string countryName)
        {

            string query = "SELECT * FROM CountryInformationWithCity  WHERE Name LIKE '%" + countryName + "%' ORDER BY Name";
            CommandObj.CommandText = query;
            List<CountryViewerModel> countryViewerModels = new List<CountryViewerModel>();
            ConnectionObj.Open();
            SqlDataReader reader = CommandObj.ExecuteReader();
            while (reader.Read())
            {
                CountryViewerModel countryViewer = new CountryViewerModel();
                countryViewer.CountryName = reader["Name"].ToString();
                countryViewer.AboutCountry = reader["About"].ToString();
                countryViewer.NoOfCities = Convert.ToInt32(reader["Total_City"].ToString());
                countryViewer.NoOfCityDwellers = Convert.ToInt64(reader["Total_Dwellers"].ToString());
                countryViewerModels.Add(countryViewer);

            }
            reader.Close();
            ConnectionObj.Close();

            return countryViewerModels;
        }


        public List<CountryViewerModel> GetCountryInformation()
        {
            try
            {
                string query = "SELECT * FROM CountryInformationWithCity ORDER BY Name";
                CommandObj.CommandText = query;
                List<CountryViewerModel> countryViewerModels = new List<CountryViewerModel>();
                ConnectionObj.Open();
                SqlDataReader reader = CommandObj.ExecuteReader();
                while (reader.Read())
                {
                    CountryViewerModel countryViewerModel = new CountryViewerModel();
                    countryViewerModel.CountryName = reader["Name"].ToString();
                    countryViewerModel.AboutCountry = reader["About"].ToString();
                    countryViewerModel.NoOfCities = Convert.ToInt32(reader["Total_City"].ToString());
                    countryViewerModel.NoOfCityDwellers = Convert.ToInt64(reader["Total_Dwellers"].ToString());  
                    countryViewerModels.Add(countryViewerModel);

                }
                reader.Close();
                return countryViewerModels;
            }
            catch (Exception exception)
            {
                throw new Exception("Unable to collect country Information",exception);
            }
            finally
            {
                ConnectionObj.Close();
                CommandObj.Dispose();
            }
        }
    }
}