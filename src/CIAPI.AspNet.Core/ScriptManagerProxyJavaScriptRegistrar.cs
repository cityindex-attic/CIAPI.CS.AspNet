using System;
using System.Linq;
using System.Reflection;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CIAPI.AspNet.Core
{
    public class ScriptManagerProxyJavaScriptRegistrar: IJavaScriptRegistrar
    {
        public void RegisterFromResource(WebControl control, Assembly resourceAssembly, string resourceNamePrefix, string resourceName)
        {
            var scriptManager = GetPageScriptManager(control);

            if (ResourceAddedAlready(scriptManager, resourceName)) return;

            scriptManager.Scripts.Add(
                new ScriptReference(resourceNamePrefix + "." + resourceName, resourceAssembly.FullName));
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