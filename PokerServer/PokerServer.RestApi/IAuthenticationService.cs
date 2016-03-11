using System;
using System.Runtime.Serialization;
using System.Security;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace PokerServer.RestApi
{
    [ServiceContract]
    public interface IAuthenticationService
    {
        [OperationContract]
        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "Login/")]
        UserSession Login(string username, SecureString password);
    }

    [DataContract]
    public class UserSession
    {
        [DataMember]
        public Guid Guid { get; set; }

        [DataMember]
        public string Username { get; set; }
    }
}
