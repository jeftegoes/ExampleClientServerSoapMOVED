using System.Web.Services;

namespace SoapWebService
{
    /// <summary>
    /// Summary description for Calculator
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Calculator : System.Web.Services.WebService
    {

        [WebMethod]
        public double Add(double x, double y) => x + y;

        [WebMethod]
        public double Divide(double x, double y) => x / y;

        [WebMethod]
        public double Multiply(double x, double y) => x * y;

        [WebMethod]
        public double Subtract(double x, double y) => x - y;
    }
}