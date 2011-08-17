using System.Collections;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;
using CIAPI.AspNet.Controls.Core;

namespace CIAPI.AspNet.Controls.LoginView
{
    public class LoginView : WebControl, INamingContainer
    {
        private readonly AuthenticationStateChecker _authenticationStateChecker;
        private LoginViewData _loginViewData;

        public LoginView()
        {
            _authenticationStateChecker = new AuthenticationStateChecker(this);
        }

        [Browsable(false),
         DefaultValue(null),
         Description("What to show in the Logged in state"),
         TemplateContainer(typeof (LoginViewData)),
         PersistenceMode(PersistenceMode.InnerProperty),
         TemplateInstance(TemplateInstance.Single)]
        public virtual ITemplate LoggedInTemplate { get; set; }

        [Browsable(false),
         DefaultValue(null),
         Description("What to show to the anonymous user"),
         TemplateContainer(typeof (LoginViewData)),
         PersistenceMode(PersistenceMode.InnerProperty),
         TemplateInstance(TemplateInstance.Single)]
        public virtual ITemplate AnonymousTemplate { get; set; }

        public string UserName
        {
            get { return _authenticationStateChecker.UserName; }
        }

        public string Session
        {
            get { return _authenticationStateChecker.Session; }
        }

        public bool IsAuthenticated
        {
            get { return _authenticationStateChecker.IsAuthenticated; }
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
            ChildControlsCreated = true;
            base.DataBind();
        }
    }
}