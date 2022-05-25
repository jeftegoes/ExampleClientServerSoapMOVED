using System.ServiceModel.Dispatcher;

namespace SoapClientServiceReference.Interceptor
{
    public class MessageInterceptor : IClientMessageInspector
    {
        public string LastRequestXML { get; private set; }
        public string LastResponseXML { get; private set; }

        public void AfterReceiveReply(ref System.ServiceModel.Channels.Message reply, object correlationState)
        {
            LastResponseXML = reply.ToString();
        }

        public object BeforeSendRequest(ref System.ServiceModel.Channels.Message request, System.ServiceModel.IClientChannel channel)
        {
            LastRequestXML = request.ToString();
            return request;
        }
    }
}