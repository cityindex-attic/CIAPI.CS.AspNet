using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CIAPI.AspNet.Controls.LoginView
{
    public class LoginView: WebControl, INamingContainer
    {
        private LoginViewData _loginViewData;

        [Browsable(false), 
        DefaultValue(null), 
        Description("What to show in the Logged in state"), 
        TemplateContainer(typeof(LoginViewData)), 
        PersistenceMode(PersistenceMode.InnerProperty)]
        public virtual ITemplate LoggedInTemplate { get; set; }

        [Browsable(false),
       DefaultValue(null),
       Description("What to show to the anonymous user"),
       TemplateContainer(typeof(LoginViewData)),
       PersistenceMode(PersistenceMode.InnerProperty)]
        public virtual ITemplate AnonymousTemplate { get; set; }

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
            var httpCookie = Page.Request.Cookies[cookieName];
            if (httpCookie == null || string.IsNullOrEmpty(httpCookie.Value))
            {
                return string.Empty;
            }
            return httpCookie.Value;
        }

        public override ControlCollection Controls
        {
            get
            {
                this.EnsureChildControls();
                return base.Controls;
            }
        }

        protected override void CreateChildControls()
        {
            Controls.Clear();
            _loginViewData = new LoginViewData(UserName, Session);

            if (IsAuthenticated)
            {
                LoggedInTemplate.InstantiateIn(_loginViewData);    
            }
            else
            {
                AnonymousTemplate.InstantiateIn(_loginViewData);
            }
            
            Controls.Add(_loginViewData);
            
        }

        public override void DataBind()
        {
            CreateChildControls();
            this.ChildControlsCreated = true;
            base.DataBind();  
        }

    }
}
