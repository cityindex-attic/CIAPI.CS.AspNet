using System;
using CIAPI.AspNet.Core;

namespace TestWebApplication
{
	public partial class Default : System.Web.UI.Page
	{
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            AuthenticationWidget.JavaScriptRegistrar = new ScriptManagerJavaScriptRegistrar();
            AuthenticationWidget.CssRegistrar = new ControlInjectorCssRegistrar(Header);
        }

		protected void Page_Load(object sender, EventArgs e)
		{
		    isAuthenticatedLabel.Text = AuthenticationWidget.IsAuthenticated ? "Is Authenticated" : "Is NOT Authenticated (try CC735158 / password)";
		}
	}
}