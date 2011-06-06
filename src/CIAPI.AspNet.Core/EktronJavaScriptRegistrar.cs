using System;
using System.Linq;
using System.Reflection;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CIAPI.AspNet.Core
{
    public class EktronJavaScriptRegistrar: IJavaScriptRegistrar
    {
        public void RegisterFromResource(WebControl control, Assembly resourceAssembly, string resourceNamePrefix, string resourceName)
        {
            var url = control.Page.ClientScript.GetWebResourceUrl(resourceAssembly.GetTypes()[0],
                                                                     resourceNamePrefix + "." + resourceName);

            //Ektron
            //JS.RegisterJSInclude(control, url, resourceName);
            System.Diagnostics.Debugger.Launch();
        }

    }
}