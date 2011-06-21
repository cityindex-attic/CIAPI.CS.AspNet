using System;
using System.Security.Authentication;
using CIAPI.AspNet.Core;

namespace TestWebApplication
{
    public partial class ProtectedPage : System.Web.UI.Page
	{
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            AuthenticationWidget.JavaScriptRegistrar = new ScriptManagerJavaScriptRegistrar();
            AuthenticationWidget.CssRegistrar = new ScriptManagerCssRegistrar();
        }

		protected void Page_Load(object sender, EventArgs e)
		{
		    if(!AuthenticationWidget.IsAuthenticated)
		    {
		       throw new AuthenticationException("You must be authenticated to view this page"); 
		    }
		}
	}
}