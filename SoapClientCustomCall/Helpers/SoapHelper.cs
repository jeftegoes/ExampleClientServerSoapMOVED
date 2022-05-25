using System.Net;
using System.Xml;

namespace SoapClientCustomCall.Helpers
{
    public class SoapHelper : ISoapHelper
    {
        public string Send(string url, string action, string xmlContent)
        {

            var soapEnvelopeXml = CreateSoapEnvelope(xmlContent);
            var webRequest = CreateWebRequest(url, action);
            InsertSoapEnvelopeIntoWebRequest(soapEnvelopeXml, webRequest);

            string soapResult;

            using (WebResponse webResponse = (HttpWebResponse)webRequest.GetResponse())
            {
                using (StreamReader rd = new StreamReader(webResponse.GetResponseStream()))
                {
                    soapResult = rd.ReadToEnd();
                }
                Console.Write(soapResult);
            }

            return soapResult;
        }

        private HttpWebRequest CreateWebRequest(string url, string action)
        {
            var webRequest = (HttpWebRequest)WebRequest.Create(url);

            webRequest.Headers.Add("SOAPAction", action);
            webRequest.ContentType = "text/xml;charset=\"utf-8\"";
            webRequest.Accept = "text/xml";
            webRequest.Method = "POST";

            return webRequest;
        }

        private XmlDocument CreateSoapEnvelope(string xml)
        {
            XmlDocument soapEnvelopeDocument = new XmlDocument();

            soapEnvelopeDocument.LoadXml(xml);

            return soapEnvelopeDocument;
        }

        private void InsertSoapEnvelopeIntoWebRequest(XmlDocument soapEnvelopeXml, HttpWebRequest webRequest)
        {
            using (Stream stream = webRequest.GetRequestStream())
            {
                soapEnvelopeXml.Save(stream);
            }
        }
    }
}
