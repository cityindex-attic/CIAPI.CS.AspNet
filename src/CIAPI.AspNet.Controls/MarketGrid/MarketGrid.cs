using System;
using System.ComponentModel;
using System.Web.UI;
using CIAPI.AspNet.Controls.Core;

namespace CIAPI.AspNet.Controls.MarketGrid
{
	[DefaultProperty("Text")]
	[ToolboxData("<{0}:ServerControl1 runat=server></{0}:ServerControl1>")]
	public class MarketGrid : WebControlBase
	{
	    protected override void OnPreRender(EventArgs e)
		{
            base.OnPreRender(e);

            JavaScriptRegistrar.RegisterFromResource(this, GetType().Assembly, "CIAPI.AspNet.Controls.MarketGrid", "js.libs.CIAPI.js");
            JavaScriptRegistrar.RegisterFromResource(this, GetType().Assembly, "CIAPI.AspNet.Controls.MarketGrid", "js.libs.knockout-1.2.0.js");
            JavaScriptRegistrar.RegisterFromResource(this, GetType().Assembly, "CIAPI.AspNet.Controls.MarketGrid", "js.libs.knockout.mapping-latest.js");
            JavaScriptRegistrar.RegisterFromResource(this, GetType().Assembly, "CIAPI.AspNet.Controls.MarketGrid", "js.marketGrid.js");
		}

		protected override void RenderContents(HtmlTextWriter output)
		{
			var content = ResourceUtil.ReadText(GetType(), "Body.html");
			output.Write(content);
		}
	}
}
