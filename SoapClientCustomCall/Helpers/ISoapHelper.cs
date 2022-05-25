namespace SoapClientCustomCall.Helpers
{
    public interface ISoapHelper
    {
        string Send(string url, string action, string xmlContent);
    }
}
