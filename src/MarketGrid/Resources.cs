using System.Web.UI;
using CIAPI.AspNet.MarketGrid;

[assembly: WebResource(Resources.JqueryJs1, "application/x-javascript")]
[assembly: WebResource(Resources.JqueryJs2, "application/x-javascript")]
[assembly: WebResource(Resources.JqueryJsUi, "application/x-javascript")]
[assembly: WebResource(Resources.JqueryJs3, "application/x-javascript")]
[assembly: WebResource(Resources.Json, "application/x-javascript")]
[assembly: WebResource(Resources.CiapiJs, "application/x-javascript")]
[assembly: WebResource(Resources.Knockout1, "application/x-javascript")]
[assembly: WebResource(Resources.Knockout2, "application/x-javascript")]
[assembly: WebResource(Resources.MarketGridJs, "application/x-javascript")]

namespace CIAPI.AspNet.MarketGrid
{
	static class Resources
	{
		public const string JqueryJs1 = "CIAPI.AspNet.MarketGrid.js.libs.jquery-1.5.1.min.js";
		public const string JqueryJs2 = "CIAPI.AspNet.MarketGrid.js.libs.jquery.tmpl.js";

		public const string JqueryJsUi =
			"CIAPI.AspNet.MarketGrid.js.libs.jquery_ui_1._8._11.custom.js.jquery-ui-1.8.11.custom.min.js";

		public const string JqueryJs3 = "CIAPI.AspNet.MarketGrid.js.libs.jquery.sparkline.min.js";

		public const string Json = "CIAPI.AspNet.MarketGrid.js.libs.json2.js";

		public const string CiapiJs = "CIAPI.AspNet.MarketGrid.js.libs.CIAPI.js";

		public const string Knockout1 = "CIAPI.AspNet.MarketGrid.js.libs.knockout-1.2.0.debug.js";
		public const string Knockout2 = "CIAPI.AspNet.MarketGrid.js.libs.knockout.mapping-latest.js";

		public const string MarketGridJs = "CIAPI.AspNet.MarketGrid.js.marketGrid.js";
	}
}

