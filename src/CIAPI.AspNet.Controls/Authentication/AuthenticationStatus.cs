using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;
using CIAPI.AspNet.Controls.Core;

namespace CIAPI.AspNet.Controls.Authentication
{
    public class AuthenticationStatus: Authentication
    {
        protected override void RenderContents(HtmlTextWriter output)
        {
            if (string.IsNullOrEmpty(ServiceUri)) throw new ArgumentNullException("CIAPI.AspNet.Controls.AuthenticationStatus.ServiceUri", "You must set the ServiceUri property to the Uri of the CityIndex Trading Api (e.g: https://ciapi.cityindex.com/TradingAPI )");
            var content = ResourceUtil.ReadText(GetType(), "AuthenticationStatus.html").ReplaceWebControlTemplateVars(this);
            content = content
              .Replace("{afterLogOff}", GetAfterLogOffScript())
              .Replace("{serviceUri}", ServiceUri)
              .Replace("{LogOnUri}", LogOnUri)
              .Replace("{ApplyNowUri}", ApplyNowUri)
              .Replace("{LaunchPlatformUri}", LaunchPlatformUri);
            output.Write(content);
        }

        public string LogOnUri { get; set; }
        public string ApplyNowUri { get; set; }
        public string LaunchPlatformUri { get; set; }
    }
}
