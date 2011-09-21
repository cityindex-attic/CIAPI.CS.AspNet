using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CIAPI.AspNet.Controls.Core
{
    public class ControlInjectorCssRegistrar : ICssRegistrar
    {
        private readonly Control _injectionTarget;

        public ControlInjectorCssRegistrar(Control injectionTarget)
        {
            _injectionTarget = injectionTarget;
        }

        public void RegisterFromResource(WebControl control, Type resourceType, string resourceNamePrefix, string resourceName)
        {
            var cssUrl = control.Page.ClientScript.GetWebResourceUrl(resourceType,
                                                                     resourceNamePrefix + "." + resourceName);

            var cssControl = new Literal {Text = @"<link href=""" + cssUrl + @""" type=""text/css"" rel=""stylesheet"" />"};
            _injectionTarget.Controls.Add(cssControl);
        }

    }
}