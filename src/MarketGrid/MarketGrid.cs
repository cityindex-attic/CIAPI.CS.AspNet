using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CIAPI.AspNet.MarketGrid
{
	[DefaultProperty("Text")]
	[ToolboxData("<{0}:ServerControl1 runat=server></{0}:ServerControl1>")]
	public class MarketGrid : WebControl
	{
		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);

			RegisterScript(Resources.JqueryJs1);
			RegisterScript(Resources.JqueryJs2);
			RegisterScript(Resources.JqueryJsUi);
			RegisterScript(Resources.JqueryJs3);

			RegisterScript(Resources.Json);
			RegisterScript(Resources.CiapiJs);
			RegisterScript(Resources.Knockout1);
			RegisterScript(Resources.Knockout2);
			RegisterScript(Resources.MarketGridJs);
		}

		private void RegisterScript(string name)
		{
			Page.ClientScript.RegisterClientScriptResource(GetType(), name);
		}

		protected override void RenderContents(HtmlTextWriter output)
		{
			var content = ResourceUtil.ReadText(GetType(), "Body.html");
			output.Write(content);
		}
	}
}
