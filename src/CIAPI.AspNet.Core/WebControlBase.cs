using System.Web.UI.WebControls;

namespace CIAPI.AspNet.Core
{
    public class WebControlBase : WebControl
    {
        private IJavaScriptRegistrar _javaScriptRegistrar;
        private ICssRegistrar _cssRegistrar;

        /// <summary>
        /// The class that can include Javascript references in the page
        /// </summary>
        public IJavaScriptRegistrar JavaScriptRegistrar { 
            get
            {
                if (_javaScriptRegistrar == null)
                {
                    _javaScriptRegistrar = new ScriptManagerJavaScriptRegistrar();
                }
                return _javaScriptRegistrar;
            }
            set
            {
                _javaScriptRegistrar = value;
            } 
        }

        /// <summary>
        /// The class that can include Css references in the page
        /// </summary>
        public ICssRegistrar CssRegistrar
        {
            get
            {
                if (_cssRegistrar == null)
                {
                    _cssRegistrar = new ScriptManagerCssRegistrar();
                }
                return _cssRegistrar;
            }
            set
            {
                _cssRegistrar = value;
            }
        }
    }
}