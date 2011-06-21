using System;
using System.Linq;
using System.Reflection;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CIAPI.AspNet.Core
{
    public class ControlInjectorCssRegistrar : ICssRegistrar
    {
        private readonly Control _injectionTarget;

        public ControlInjectorCssRegistrar(Control injectionTarget)
        {
            _injectionTarget = injectionTarget;
        }

        public void RegisterFromResource(WebControl control, Type resourceAssembly, string resourceNamePrefix, string resourceName)
        {
//            var scriptManager = GetPageScriptManager(control);

//            if (ResourceAddedAlready(scriptManager, resourceName)) return;
            var cssUrl = control.Page.ClientScript.GetWebResourceUrl(resourceAssembly,
                                                                     resourceNamePrefix + "." + resourceName);

            var cssControl = new Literal {Text = @"<link href=""" + cssUrl + @""" type=""text/css"" rel=""stylesheet"" />"};
            _injectionTarget.Controls.Add(cssControl);
//            ScriptManager.RegisterClientScriptBlock(control.Page, control.GetType(), resourceName, css, false);
        }

        private static ScriptManager GetPageScriptManager(Control control)
        {
            var scriptManager = ScriptManager.GetCurrent(control.Page);
            if (scriptManager==null)
            {
                throw new ArgumentNullException("control", 
                    string.Format("The {0} control must be on a page that has a ScriptManager on it", 
                        control.GetType().FullName));
            }
            return scriptManager;
        }

        private static bool ResourceAddedAlready(ScriptManager scriptManager, string resourceName)
        {
            return scriptManager.Scripts.Where(s => s.Name.EndsWith(resourceName)).Count() > 0;
        }

        
    }
}