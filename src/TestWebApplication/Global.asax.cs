using System;
using System.Web;

namespace TestWebApplication
{
    public class Global : HttpApplication
    {
        protected void Session_Start(object sender, EventArgs e)
        {
            Response.Cookies["ASP.NET_SessionId"].Expires = DateTime.Now.AddHours(8);
        }
    }
}