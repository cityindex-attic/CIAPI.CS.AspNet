using System;
using System.ComponentModel;
using System.Reflection;
using System.Web.UI;
using CIAPI.AspNet.Controls.Core;

namespace CIAPI.AspNet.Controls.Authentication
{
    [DefaultProperty("Width")]
    [ToolboxData("<{0}:AuthenticationWidget1 runat=server></{0}:AuthenticationWidget1>")]
    public class Authentication : WebControlBase
    {
	    #region Attributes
        
        private readonly AuthenticationStateChecker _authenticationStateChecker;

        #endregion

        #region Properties

        public string ServiceUri { get; set; }
	    
        public bool IsDebug { get; set; }
	    public bool UseMockData { get; set; }
        
        public string AfterLogOnNavigateUrl { get; set; }
        public string AfterLogOffNavigateUrl { get; set; }
        
        public string LaunchPlatformUri { get; set; }

	    public string UserName { get { return _authenticationStateChecker.UserName; } }
	    public string Session { get { return _authenticationStateChecker.Session; } }
	    public bool IsAuthenticated { get  { return _authenticationStateChecker.IsAuthenticated; } }

        #endregion

        #region Constructors
        
        public Authentication()
        {
            UseMockData = false;
            IsDebug = true;
            _authenticationStateChecker = new AuthenticationStateChecker(this);
        }

        #endregion

        #region WebControlBase Members
        
        protected override void OnPreRender(EventArgs e)
		{
            base.OnPreRender(e);

            if (IsDebug)
            {
                JavaScriptRegistrar.RegisterFromResource(this, GetType().Assembly, "CIAPI.AspNet.Controls.Authentication", "js.libs.CIAPI.debug.js");
                JavaScriptRegistrar.RegisterFromResource(this, GetType().Assembly, "CIAPI.AspNet.Controls.Authentication", "js.libs.CIAPI.widget.debug.js");
                JavaScriptRegistrar.RegisterFromResource(this, GetType().Assembly, "CIAPI.AspNet.Controls.Authentication", "js.CIAPI.Authentication.debug.js");
            }
            else
            {
                JavaScriptRegistrar.RegisterFromResource(this, GetType().Assembly, "CIAPI.AspNet.Controls.Authentication", "js.libs.CIAPI.min.js");
                JavaScriptRegistrar.RegisterFromResource(this, GetType().Assembly, "CIAPI.AspNet.Controls.Authentication", "js.libs.CIAPI.widget.min.js");
                JavaScriptRegistrar.RegisterFromResource(this, GetType().Assembly, "CIAPI.AspNet.Controls.Authentication", "js.CIAPI.Authentication.min.js");
            }
		    
            if (UseMockData)
            {
                JavaScriptRegistrar.RegisterFromResource(this, GetType().Assembly, "CIAPI.AspNet.Controls.Authentication", "js.CIAPI.amplify.requests.mock.js");
            }

            JavaScriptRegistrar.RegisterFromResource(this, GetType().Assembly, "CIAPI.AspNet.Controls.Authentication", "js.AuthenticationWidget.js");
            CssRegistrar.RegisterFromResource(this, GetType(), "CIAPI.AspNet.Controls.Authentication", "css.CIAPI.Authentication.min.css");
        }

        protected override void RenderContents(HtmlTextWriter output)
        {
            if (string.IsNullOrEmpty(ServiceUri)) 
                throw new ArgumentNullException("CIAPI.AspNet.Controls.Authentication.ServiceUri", 
                                                "You must set the ServiceUri property to the Uri of the CityIndex Trading Api (e.g: https://ciapi.cityindex.com/TradingAPI )");
            
            var content = ResourceUtil.ReadText(GetType(), "AuthenticationWidget.html")
                            .ReplaceWebControlTemplateVars(this);

            content = LocaliseControl(content);

            content = content
                .Replace("<%=afterLogOn%>", GetAfterLogOnScript())
                .Replace("<%=afterLogOn%>", GetAfterLogOnScript())
                .Replace("<%=afterLogOff%>", GetAfterLogOffScript())
                .Replace("<%=LaunchPlatformUri%>", LaunchPlatformUri)
                .Replace("<%=serviceUri%>", ServiceUri);

            output.Write(content);
        }

        #endregion

        #region Helper Methods

        private string CreateStoreSessionThenRedirectScript(string navigateUrl)
        {
            const string SCRIPT = "AuthenticationWidget.storeConnectionInASPNETSession(CIAPI.connection, function() {{ {0} }});";
            return string.Format(SCRIPT, string.IsNullOrEmpty(navigateUrl) ?
                                  ""                                                           // do nothing if no NavigateUrl has been set
                                 : "window.location.href='" + ResolveUrl(navigateUrl) + "';"); // redirect to the NavigateUrl given
        }

        protected string GetAfterLogOffScript()
        {
            return CreateStoreSessionThenRedirectScript(AfterLogOffNavigateUrl);
        }

        protected string GetAfterLogOnScript()
	    {
            return CreateStoreSessionThenRedirectScript(AfterLogOnNavigateUrl);
        }
        #endregion

        protected string LocaliseControl(string content)
        {
            App_GlobalResources.AuthenticationWidget.Culture = UiCulture;
            
            var translations = string.Format("{{\"{0}\":{{", UiCulture.Name);
            foreach (var property in typeof(App_GlobalResources.AuthenticationWidget).GetProperties(BindingFlags.NonPublic | BindingFlags.Static))
            {
                if (property.PropertyType == typeof(string))
                {
                    translations += string.Format("\"{0}\":\"{1}\",", property.Name,
                        property.GetValue(null,null));
                }
                
            }
            translations = translations.TrimEnd(new[] {','});
            translations += "}}";

            content = content
                .Replace("<%=UiCulture%>", UiCulture.Name)
                .Replace("<%=translations%>", translations);
            return content;
        }
    }

}