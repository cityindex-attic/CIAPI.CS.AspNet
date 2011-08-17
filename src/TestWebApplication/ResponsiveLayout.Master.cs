using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TestWebApplication
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        private const int EnglishCultureId = 69;
        protected void Page_Load(object sender, EventArgs e)
        {
           LoginView1.DataBind();
           
           //You can only access the controls inside a LoginView template after DataBind has been called.
           if (LoginView1.IsAuthenticated)
           {
               LaunchLink.Text = "Launch platform";
               LaunchLink.NavigateUrl =
                   string.Format("https://ciapipreprod.cityindextest9.co.uk/tp/fx/?UserName={0}&Session={1}&CultureId={2}", 
                   LoginView1.UserName, LoginView1.Session, EnglishCultureId );
           }
           else
           {
               LogonLink.Text = "Log On";
               ApplyLink.Text = "Apply for an account";
           }
        }
    }
}