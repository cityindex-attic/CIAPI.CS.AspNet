using System;
using System.Web.UI.WebControls;

namespace CIAPI.AspNet.Controls.Core
{
    public interface ICssRegistrar
    {
        void RegisterFromResource(WebControl control, Type resourceAssembly, string resourceNamePrefix, string resourceName);
    }
}