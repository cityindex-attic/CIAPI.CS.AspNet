using System.Web.UI;

namespace CIAPI.AspNet.Controls.Core
{
    public class AuthenticationStateChecker
    {
        private readonly Control _parentControl;

        public AuthenticationStateChecker(Control parentControl)
        {
            _parentControl = parentControl;
        }

        public string UserName
        {
            get
            {
                return GetCookieValue("UserName");
            }
        }

        public string Session
        {
            get
            {
                return GetCookieValue("Session");
            }
        }

        public bool IsAuthenticated
        {
            get
            {
                return (UserName + Session).Trim() != string.Empty;
            }
        }

        private string GetCookieValue(string cookieName)
        {
            var httpCookie = _parentControl.Page.Request.Cookies[cookieName];
            if (httpCookie == null || string.IsNullOrEmpty(httpCookie.Value))
            {
                return string.Empty;
            }
            return httpCookie.Value;
        }
    }
}
