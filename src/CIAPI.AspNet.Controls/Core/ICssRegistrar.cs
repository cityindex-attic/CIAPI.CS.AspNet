using System;
using System.Web.UI.WebControls;

namespace CIAPI.AspNet.Controls.Core
{
    public interface ICssRegistrar
    {
        void RegisterFromResource(WebControl control, Type resourceType, string resourceNamePrefix, string resourceName);
    }
}