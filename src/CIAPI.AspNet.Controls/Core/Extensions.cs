namespace CIAPI.AspNet.Controls.Core
{
    public static class Extensions
    {
        public static string ReplaceWebControlTemplateVars(this string text, WebControlBase control)
        {
            return text.Replace("<%=clientId%>", control.ClientID)
                .Replace("<%=width%>", control.Width.ToString());
        }
    }
}