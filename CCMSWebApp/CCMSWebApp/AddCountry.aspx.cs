using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CountryCityInformationManagementSystem.BLL;
using CountryCityInformationManagementSystem.Models;

namespace CCMSWebApp
{
    public partial class About : Page
    {
        CountryManager countryManager=new CountryManager();
        List<Country> countryList=new List<Country>();
        private string message;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadAllCountry();
            }
           
        }

        private void LoadAllCountry()
        {
            try
            {
                countryList = countryManager.GetAll();
                showCountryInforamotionGridView.DataSource = countryList;
                showCountryInforamotionGridView.DataBind();
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
                if (countryNameTextBox.Text.Length > 50)
                {
                    messageLabel.ForeColor = System.Drawing.Color.Red;
                    messageLabel.Text = "Please! Enter a Country Name within 50 character and then try";
                    return;
                }
                string name = countryNameTextBox.Text;
                string about = aboutCountryTextBox.Text;
                Country country = new Country(name, about);
                message = countryManager.Save(country);
                messageLabel.ForeColor = System.Drawing.Color.Black;
                messageLabel.Text = message;
                LoadAllCountry();
                ClearAllTextBox();
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

        private void ClearAllTextBox()
        {
            try
            {
                countryNameTextBox.Text = string.Empty;
                aboutCountryTextBox.Text = string.Empty;
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

        protected void showCountryInforamotionGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            try
            {
                showCountryInforamotionGridView.PageIndex = e.NewPageIndex;
                showCountryInforamotionGridView.DataSource = countryManager.GetAll();
                showCountryInforamotionGridView.DataBind();
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

        protected void cancelButton_Click(object sender, EventArgs e)
        {
           Response.Redirect("Default.aspx");
        }
    }
}