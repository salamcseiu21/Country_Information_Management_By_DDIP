using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using CountryCityInformationManagementSystem.BLL;
using CountryCityInformationManagementSystem.Models;

namespace CCMSWebApp
{
    public partial class ViewCountry : System.Web.UI.Page
    {
        CityManager cityManager = new CityManager();
        private List<CountryViewerModel> countryList;
        private string message;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                LoadCountryInformation();
            }
        }

        private void LoadCountryInformation()
        {
            try
            {
                countryList = new List<CountryViewerModel>();
                countryList = cityManager.GetCountryInformation();
                showCuntryInformationGridView.DataSource = countryList;
                showCuntryInformationGridView.DataBind();
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
                string name = searchTextBox.Text;
                countryList = cityManager.GetCountryInformationByName(name);
                showCuntryInformationGridView.DataSource = countryList;
                showCuntryInformationGridView.DataBind();
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

        protected void showCuntryInformationGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                showCuntryInformationGridView.PageIndex = e.NewPageIndex;
                string name = searchTextBox.Text;
                showCuntryInformationGridView.DataSource = cityManager.GetCountryInformationByName(name);
                showCuntryInformationGridView.DataBind();
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