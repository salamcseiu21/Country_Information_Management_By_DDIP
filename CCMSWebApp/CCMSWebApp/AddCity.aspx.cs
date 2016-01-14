using System;
using System.Web.UI.WebControls;
using CountryCityInformationManagementSystem.BLL;
using CountryCityInformationManagementSystem.Models;

namespace CCMSWebApp
{
    public partial class AddCity : System.Web.UI.Page
    {
        CountryManager countryManager=new CountryManager();
        CityManager cityManager=new CityManager();
        private string message;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillDropDownListWithCountryInforamtion();
                LoadAllCity();
            }
        }

        private void LoadAllCity()
        {
            try
            {
                cityWithCountryGridView.DataSource = cityManager.GetCityInformation();
                cityWithCountryGridView.DataBind();
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

        private void FillDropDownListWithCountryInforamtion()
        {
            try
            {
                countryDropDownList.DataSource = countryManager.GetAll();
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

        protected void cityWithCountryGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                cityWithCountryGridView.PageIndex = e.NewPageIndex;
                cityWithCountryGridView.DataSource = cityManager.GetCityInformation();
                cityWithCountryGridView.DataBind();
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

        protected void saveButton_Click(object sender, EventArgs e)
        {

            try
            {
                if (cityNameTextBox.Text.Length > 50)
                {
                    messageLabel.ForeColor = System.Drawing.Color.Red;
                    messageLabel.Text = "Please! Enter a City Name  within 50 character and then try";
                    return;
                }
                string name = cityNameTextBox.Text;
                string about = aboutCityTextBox.Text;
                long noofDwellers = Convert.ToInt64(dwellersTextBox.Text);
                string location = locationTextBox.Text;
                string weather = weatherTextBox.Text;
                int countryId = Convert.ToInt32(countryDropDownList.SelectedValue);
                City aCity=new City(name,about,noofDwellers,location,weather,countryId);
                message = cityManager.Save(aCity);
                messageLabel.ForeColor = System.Drawing.Color.Black;
                messageLabel.Text = message;
                LoadAllCity();
                ClearAlltextBoxes();
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

        private void ClearAlltextBoxes()
        {
            cityNameTextBox.Text = string.Empty;
            aboutCityTextBox.Text = string.Empty;
            dwellersTextBox.Text = string.Empty;
            locationTextBox.Text = string.Empty;
            weatherTextBox.Text = string.Empty;
        }

        protected void cancelButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
    }
}