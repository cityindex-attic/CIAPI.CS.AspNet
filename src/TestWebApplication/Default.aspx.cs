using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CIAPI.AspNet.Core;

namespace TestWebApplication
{
	public partial class Default : System.Web.UI.Page
	{
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            AuthenticationWidget.JavaScriptRegistrar = new ScriptManagerJavaScriptRegistrar();
            AuthenticationWidget.CssRegistrar = new ScriptManagerCssRegistrar();
        }

		protected void Page_Load(object sender, EventArgs e)
		{
		    isAuthenticatedLabel.Text = AuthenticationWidget.IsAuthenticated ? "Is Authenticated" : "Is NOT Authenticated";
		}
	}
}