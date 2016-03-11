using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace PokerServer.RestApi
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class AuthenticationService : IAuthenticationService
    {
        public UserSession Login(string username, SecureString password)
        {
            return new UserSession {Guid = new Guid(), Username = "Test"};
        }
    }
}
