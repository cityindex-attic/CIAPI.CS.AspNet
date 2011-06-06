using System;
using System.Reflection;
using System.Web.UI.WebControls;

namespace CIAPI.AspNet.Core
{
    public interface ICssRegistrar
    {
        void RegisterFromResource(WebControl control, Type resourceAssembly, string resourceNamePrefix, string resourceName);
    }
}