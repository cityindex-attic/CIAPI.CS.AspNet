using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web.UI.WebControls;

namespace CIAPI.AspNet.Core
{
    public interface IJavaScriptRegistrar
    {
        void RegisterFromResource(WebControl control, Assembly resourceAssembly, string resourceNamePrefix, string resourceName);
    }
}
