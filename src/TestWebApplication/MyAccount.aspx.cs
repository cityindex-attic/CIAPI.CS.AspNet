using System;
using System.Configuration;
using System.Security.Authentication;
using CIAPI.AspNet.Controls.Core;

namespace TestWebApplication
{
    public partial class ProtectedPage : System.Web.UI.Page
	{
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            AuthenticationWidget.JavaScriptRegistrar = new ScriptManagerJavaScriptRegistrar();
            AuthenticationWidget.CssRegistrar = new ControlInjectorCssRegistrar(Header);
            AuthenticationWidget.ServiceUri = ConfigurationManager.AppSettings["ServiceUri"];
            AuthenticationWidget.UseMockData = Boolean.Parse(ConfigurationManager.AppSettings["UserMockData"]);
        }

		protected void Page_Load(object sender, EventArgs e)
        {
            var authenticationStateChecker = new AuthenticationStateChecker(this);

            if (!authenticationStateChecker.IsAuthenticated)
		    {
		       throw new AuthenticationException("You must be authenticated to view this page"); 
		    }

           
            LoginStateLiteral.Text = string.Format("You are logged in as {0}", authenticationStateChecker.UserName);

		}
	}
}