using System.Data.SqlClient;
using System.Web.Configuration;
namespace CountryCityInformationManagementSystem.DAL
{
    public class DBGateway
    {
        private SqlConnection connectionObj;
        private SqlCommand commandObj;
        public SqlConnection ConnectionObj
        {
            get
            {
                return connectionObj;
            }
        }

        public SqlCommand CommandObj
        {
            get
            {
                commandObj.Connection = connectionObj;
                return commandObj;
            }
        }

        

        public DBGateway()
        {
            connectionObj = new SqlConnection(WebConfigurationManager.ConnectionStrings["countryInformationManagementDB"].ConnectionString);
            commandObj=new SqlCommand();
        }
    }
}