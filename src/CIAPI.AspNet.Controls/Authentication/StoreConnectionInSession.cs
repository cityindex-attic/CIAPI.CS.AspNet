using System.IO;
using System.Text;
using System.Web;
using System.Web.SessionState;
using System.Runtime.Serialization.Json;
using CIAPI.AspNet.Controls.Core;

namespace CIAPI.AspNet.Controls.Authentication
{

    /// <summary>
    /// This is used by the Authentication control to pass the client side CIAPI connection info to the server
    /// The following line must be added to Web.config / configurations / system.web / httpHanders
    ///    <add verb="POST" path="CIAPI.AspNet.Controls.Authentication/StoreConnectionInSession.ashx" type="CIAPI.AspNet.Controls.Authentication.StoreConnectionInSession, CIAPI.AspNet.Controls"/>
    /// </summary>
    public class StoreConnectionInSession: IHttpHandler, IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Session["CIAPI_connection"] = DeserializeJson<CIAPIConnection>(context.Request.Form["CIAPI_connection"]);
        }

        private static T DeserializeJson<T>(string json) where T:class
        {
            return new DataContractJsonSerializer(typeof(T))
                .ReadObject(
                    new MemoryStream(
                        Encoding.UTF8.GetBytes(json)
                    )
                ) as T;
        }

        public bool IsReusable
        {
            get { return false; }
        }
    }
}
