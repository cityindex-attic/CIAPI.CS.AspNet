using System.Web.UI;
using CIAPI.AspNet.Controls.Authentication;

namespace CIAPI.AspNet.Controls.Core
{
    public class AuthenticationStateChecker
    {
        private readonly Control _parentControl;

        public AuthenticationStateChecker(Control parentControl)
        {
            _parentControl = parentControl;
        }

        public CIAPIConnection CIAPIConnection
        {
            get
            {
                if (_parentControl.Page.Session["CIAPI_connection"] == null)
                    return new CIAPIConnection();
                return (CIAPIConnection) _parentControl.Page.Session["CIAPI_connection"];
            }
        }

        public string UserName
        {
            get
            {
                return CIAPIConnection.UserName;
            }
        }

        public string Session
        {
            get
            {
                return CIAPIConnection.Session;
            }
        }

        public bool IsAuthenticated
        {
            get
            {
               return CIAPIConnection.isConnected;
            }
        }
    }
}
