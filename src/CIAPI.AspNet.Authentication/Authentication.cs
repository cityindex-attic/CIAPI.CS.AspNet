using System;
using System.ComponentModel;
using System.Reflection;
using System.Web.UI;
using CIAPI.AspNet.Core;

namespace CIAPI.AspNet.Authentication
{
	[DefaultProperty("Text")]
	[ToolboxData("<{0}:ServerControl1 runat=server></{0}:ServerControl1>")]
	public class Authentication : WebControlBase
	{
	    protected override void OnPreRender(EventArgs e)
		{
            base.OnPreRender(e);

		    JavaScriptRegistrar.RegisterFromResource(this, GetType().Assembly, "CIAPI.AspNet.Authentication", "js.libs.CIAPI.js");
            JavaScriptRegistrar.RegisterFromResource(this, GetType().Assembly, "CIAPI.AspNet.Authentication", "js.libs.knockout-1.2.0.js");
            JavaScriptRegistrar.RegisterFromResource(this, GetType().Assembly, "CIAPI.AspNet.Authentication", "js.libs.knockout.mapping-latest.js");
            JavaScriptRegistrar.RegisterFromResource(this, GetType().Assembly, "CIAPI.AspNet.Authentication", "js.authentication.js");
		}

		protected override void RenderContents(HtmlTextWriter output)
		{
			var content = ResourceUtil.ReadText(GetType(), "Body.html");
			output.Write(content);
		}
	}
}
