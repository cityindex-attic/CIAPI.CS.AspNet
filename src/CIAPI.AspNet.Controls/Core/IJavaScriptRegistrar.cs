using System.Reflection;
using System.Web.UI.WebControls;

namespace CIAPI.AspNet.Controls.Core
{
    public interface IJavaScriptRegistrar
    {
        void RegisterFromResource(WebControl control, Assembly resourceAssembly, string resourceNamePrefix, string resourceName);
    }
}
