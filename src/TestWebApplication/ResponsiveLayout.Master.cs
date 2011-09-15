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
               "https://ciapipreprod.cityindextest9.co.uk/tp/fx/index.html#UserName={CIAPI.connection.UserName}&Session={CIAPI.connection.Session}&AuthenticationUri=" +
               Server.UrlEncode(Request.Url.AbsoluteUri);
        }
    }
}