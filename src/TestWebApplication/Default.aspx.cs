using System;
using CIAPI.AspNet.Controls.Core;

namespace TestWebApplication
{
	public partial class Default : System.Web.UI.Page
	{

		protected void Page_Load(object sender, EventArgs e)
		{
		    var authenticationStateChecker = new AuthenticationStateChecker(this);
            if (authenticationStateChecker.IsAuthenticated)
            {
                LoginStateLiteral.Text = string.Format("You are logged in as {0}", authenticationStateChecker.UserName);
            }
            else
            {
                LoginStateLiteral.Text = "You are NOT logged in";
            }
		}


	}
}