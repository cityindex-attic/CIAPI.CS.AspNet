using System;
using System.ComponentModel;
using System.Web.UI;
using CIAPI.AspNet.Core;

namespace CIAPI.AspNet.Authentication
{
	[DefaultProperty("Text")]
	[ToolboxData("<{0}:ServerControl1 runat=server></{0}:ServerControl1>")]
	public class Authentication : WebControlBase
	{
	    private bool _isAuthenticated = false;

	    protected override void OnPreRender(EventArgs e)
		{
            base.OnPreRender(e);

            CssRegistrar.RegisterFromResource(this, GetType(), "CIAPI.AspNet.Authentication", "css.style-0001.min.css");
            
            JavaScriptRegistrar.RegisterFromResource(this, GetType().Assembly, "CIAPI.AspNet.Authentication", "js.libs.CIAPI-0001.min.js");
            JavaScriptRegistrar.RegisterFromResource(this, GetType().Assembly, "CIAPI.AspNet.Authentication", "js.libs.CIAPI.widget-0001.min.js");
            JavaScriptRegistrar.RegisterFromResource(this, GetType().Assembly, "CIAPI.AspNet.Authentication", "js.CIAPI.Authentication-0001.min.js");
		}

		protected override void RenderContents(HtmlTextWriter output)
		{
			var content = ResourceUtil.ReadText(GetType(), "Body.html").ReplaceWebControlTemplateVars(this);
			output.Write(content);
		}

	    public bool IsAuthenticated
	    {
	        get {
	            return _isAuthenticated;
	        }
	    }
	}

}