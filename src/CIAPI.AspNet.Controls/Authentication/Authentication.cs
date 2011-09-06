using System;
using System.ComponentModel;
using System.Globalization;
using System.Web.UI;
using CIAPI.AspNet.Controls.Core;

namespace CIAPI.AspNet.Controls.Authentication
{
    [DefaultProperty("Width")]
    [ToolboxData("<{0}:AuthenticationWidget1 runat=server></{0}:AuthenticationWidget1>")]
    public class Authentication : WebControlBase
    {
        public enum SupportedLanguage { English, Polish }

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
        protected bool ShouldLaunchPlatformAfterLogOn { get; set; }

	    public string UserName { get { return _authenticationStateChecker.UserName; } }
	    public string Session { get { return _authenticationStateChecker.Session; } }
	    public bool IsAuthenticated { get  { return _authenticationStateChecker.IsAuthenticated; } }

        /// <summary>
        /// The culture to render the UI. E.g. "en", "pl"
        /// </summary>
        public string UiCulture { get; set; }

        #endregion

        #region Constructors
        
        public Authentication()
        {
            UseMockData = false;
            ShouldLaunchPlatformAfterLogOn = true;
            _authenticationStateChecker = new AuthenticationStateChecker(this);
        }

        #endregion

        #region WebControlBase Members
        
        protected override void OnPreRender(EventArgs e)
		{
            base.OnPreRender(e);

            //CssRegistrar.RegisterFromResource(this, GetType(), "CIAPI.AspNet.Controls.Authentication", "css.ci.default.ci.default.css");
            
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
        }

        protected override void RenderContents(HtmlTextWriter output)
        {
            if (string.IsNullOrEmpty(ServiceUri)) 
                throw new ArgumentNullException("CIAPI.AspNet.Controls.Authentication.ServiceUri", 
                                                "You must set the ServiceUri property to the Uri of the CityIndex Trading Api (e.g: https://ciapi.cityindex.com/TradingAPI )");
            
            var content = ResourceUtil.ReadText(GetType(), "AuthenticationWidget.html")
                            .ReplaceWebControlTemplateVars(this);

            #region Localize Control

            App_GlobalResources.AuthenticationWidget.Culture = !string.IsNullOrEmpty(UiCulture) 
                                                                    ? new CultureInfo(UiCulture) 
                                                                    : new CultureInfo(string.Empty);

            content = content
                .Replace("{UsernameText}", App_GlobalResources.AuthenticationWidget.UsernameText)
                .Replace("{PasswordText}", App_GlobalResources.AuthenticationWidget.PasswordText)
                .Replace("{LogInButtonText}", App_GlobalResources.AuthenticationWidget.LogInButtonText)
                .Replace("{LoggedInAsText}", App_GlobalResources.AuthenticationWidget.LoggedInAsText)
                .Replace("{LogOutButtonText}", App_GlobalResources.AuthenticationWidget.LogOutButtonText);

            #endregion

            content = content
                .Replace("{afterLogOn}", GetAfterLogOnScript())
                .Replace("{afterLogOff}", GetAfterLogOffScript())
                .Replace("{serviceUri}", ServiceUri);

            output.Write(content);
        }

        #endregion

        #region Helper Methods

        protected string GetAfterLogOffScript()
	    {
	        if (!string.IsNullOrEmpty(AfterLogOffNavigateUrl))
	        {
	            return "window.location.href='" + ResolveUrl(AfterLogOffNavigateUrl) + "';";
	        }
	        return "";
	    }
	    
	    protected string GetAfterLogOnScript()
	    {
	        var afterLogOnScript = "";
	        
            if (ShouldLaunchPlatformAfterLogOn)
            {
                afterLogOnScript += string.Format("window.open('{0}','','width=975,height=575');", LaunchPlatformUri);     
            }
	        
	        if (!string.IsNullOrEmpty(AfterLogOnNavigateUrl))
            {
                afterLogOnScript += "window.location.href='" + ResolveUrl(AfterLogOnNavigateUrl) + "'";
            }
            return afterLogOnScript;
        }


        #endregion
    }

}