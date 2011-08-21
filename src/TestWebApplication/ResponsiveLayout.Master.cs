using System;
using System.Configuration;
using CIAPI.AspNet.Controls.Core;

namespace TestWebApplication
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            AuthenticationStatus1.JavaScriptRegistrar = new ScriptManagerJavaScriptRegistrar();
            AuthenticationStatus1.CssRegistrar = new ControlInjectorCssRegistrar(this.Page.Header);
            AuthenticationStatus1.ServiceUri = ConfigurationManager.AppSettings["ServiceUri"];
            AuthenticationStatus1.UseMockData = Boolean.Parse(ConfigurationManager.AppSettings["UserMockData"]);

            AuthenticationStatus1.LogOnUri = this.ResolveUrl("~/Logon.aspx");
            AuthenticationStatus1.ApplyNowUri = "http://www.applyforanaccount.com/citestaccount/";
            AuthenticationStatus1.LaunchPlatformUri =
                string.Format("https://ciapipreprod.cityindextest9.co.uk/tp/fx/?UserName={0}&Session={1}&AuthenticationUri={2}",
                                AuthenticationStatus1.UserName, 
                                AuthenticationStatus1.Session, 
                                Server.UrlEncode(AuthenticationStatus1.LogOnUri));

          
        }
    }
}