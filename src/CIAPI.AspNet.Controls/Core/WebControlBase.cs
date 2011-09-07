using System.Globalization;
using System.Web.UI.WebControls;

namespace CIAPI.AspNet.Controls.Core
{
    public class WebControlBase : WebControl
    {
        private IJavaScriptRegistrar _javaScriptRegistrar;
        private ICssRegistrar _cssRegistrar;
        private CultureInfo _uiCulture;

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

        /// <summary>
        /// The culture of the control
        /// If not set, defaults to the current thread culture
        /// </summary>
        public CultureInfo UiCulture
        {
            get { return _uiCulture ?? (_uiCulture = System.Threading.Thread.CurrentThread.CurrentUICulture); }
            set { _uiCulture = value; }
        }
    }
}