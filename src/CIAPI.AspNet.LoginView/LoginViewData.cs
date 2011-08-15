using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CIAPI.AspNet.LoginView
{
    [ToolboxItem(false)]
    public class LoginViewData : WebControl, INamingContainer
    {
        private readonly string _userName;
        private readonly string _session;

        public LoginViewData(string userName, string session)
        {
            _userName = userName;
            _session = session;
        }

        public string Session
        {
            get { return _session; }
        }

        public string UserName
        {
            get { return _userName; }
        }
    }
}