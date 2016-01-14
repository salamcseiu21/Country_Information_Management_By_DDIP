using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using CountryCityInformationManagementSystem.BLL;
using CountryCityInformationManagementSystem.Models;

namespace CCMSWebApp
{
    public partial class ViewCity : System.Web.UI.Page
    {
        private List<CityViewerModel> cityViewerModels = null;
        CountryManager countryManager = new CountryManager();
        CityManager cityManager = new CityManager();
        private string message;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadAllCountry();
               
                LoadAllCityInformation();
            }
        }

        private void LoadAllCountry()
        {

            try
            {
                List<Country> countries = countryManager.GetAll();
                countryDropDownList.DataSource = countries;
                countryDropDownList.DataValueField = "Id";
                countryDropDownList.DataTextField = "Name";
                countryDropDownList.DataBind();
            }
            catch (Exception exceptionObj)
            {

                message = exceptionObj.Message;
                if (exceptionObj.InnerException != null)
                {
                    message += "<br/>System Error:" + exceptionObj.InnerException.Message;
                }
                messageLabel.ForeColor = System.Drawing.Color.Red;
                messageLabel.Text = message;
            }
        }
        private void LoadAllCityInformation()
        {

            try
            {
                cityViewerModels = cityManager.GetCityInformation();
                showCityInformationGridView.DataSource = cityViewerModels;
                showCityInformationGridView.DataBind();
            }
            catch (Exception exceptionObj)
            {

                message = exceptionObj.Message;
                if (exceptionObj.InnerException != null)
                {
                    message += "<br/>System Error:" + exceptionObj.InnerException.Message;
                }
                messageLabel.ForeColor = System.Drawing.Color.Red;
                messageLabel.Text = message;
            }
        }
        protected void searchButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (serarchKeyRadioButton.SelectedValue == "1")
                {
                    string cityName = cityNameTextBox.Text;
                    showCityInformationGridView.DataSource = cityManager.GetCityInformation(cityName);
                    showCityInformationGridView.DataBind();
                }
                else if (serarchKeyRadioButton.SelectedValue == "2")
                {
                    string countryName = countryDropDownList.SelectedItem.Text;
                    showCityInformationGridView.DataSource = cityManager.GetCityInformationByCountryName(countryName);
                    showCityInformationGridView.DataBind();
                }
            }
            catch (Exception exceptionObj)
            {

                message = exceptionObj.Message;
                if (exceptionObj.InnerException != null)
                {
                    message += "<br/>System Error:" + exceptionObj.InnerException.Message;
                }
                messageLabel.ForeColor = System.Drawing.Color.Red;
                messageLabel.Text = message;
            }
        }

        protected void showCityInformationGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                if (serarchKeyRadioButton.SelectedValue == "1")
                {
                    showCityInformationGridView.PageIndex = e.NewPageIndex;
                    string cityName = cityNameTextBox.Text;
                    showCityInformationGridView.DataSource = cityManager.GetCityInformation(cityName);
                    showCityInformationGridView.DataBind();
                }
                else if (serarchKeyRadioButton.SelectedValue == "2")
                {
                    showCityInformationGridView.PageIndex = e.NewPageIndex;
                    string countryName = countryDropDownList.SelectedItem.Text;
                    showCityInformationGridView.DataSource = cityManager.GetCityInformationByCountryName(countryName);
                    showCityInformationGridView.DataBind();
                }
                else
                {
                    showCityInformationGridView.PageIndex = e.NewPageIndex;
                    LoadAllCityInformation();
                }
            }
            catch (Exception exceptionObj)
            {

                message = exceptionObj.Message;
                if (exceptionObj.InnerException != null)
                {
                    message += "<br/>System Error:" + exceptionObj.InnerException.Message;
                }
                messageLabel.ForeColor = System.Drawing.Color.Red;
                messageLabel.Text = message;
            }
        }
    }
}