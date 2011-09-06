using System;
using System.Configuration;
using CIAPI.AspNet.Controls.Core;

namespace TestWebApplication
{
    public partial class Logon : System.Web.UI.Page
    {
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            AuthenticationWidget.JavaScriptRegistrar = new ScriptManagerJavaScriptRegistrar();
            AuthenticationWidget.CssRegistrar = new ControlInjectorCssRegistrar(Header);
            AuthenticationWidget.ServiceUri = ConfigurationManager.AppSettings["ServiceUri"];
            AuthenticationWidget.UseMockData = Boolean.Parse(ConfigurationManager.AppSettings["UserMockData"]);
            AuthenticationWidget.LaunchPlatformUri =
               string.Format("https://ciapipreprod.cityindextest9.co.uk/tp/fx/#UserName={0}&Session={1}&AuthenticationUri={2}",
                               AuthenticationWidget.UserName,
                               AuthenticationWidget.Session,
                               Server.UrlEncode(Request.Url.AbsoluteUri));
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
    }
}