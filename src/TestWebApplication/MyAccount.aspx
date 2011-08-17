<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/ResponsiveLayout.Master"
CodeBehind="MyAccount.aspx.cs" Inherits="TestWebApplication.ProtectedPage" %>

<%@ Register Assembly="CIAPI.AspNet.Controls" Namespace="CIAPI.AspNet.Controls.Authentication" TagPrefix="cc1" %>

<asp:Content runat="server" ID="Content1" ContentPlaceHolderID="FeaturedContent">
    <h3>My Account</h3>
    <div class="ui-state-highlight" style="padding:10px">
        LoginState: <asp:Literal ID="LoginStateLiteral" runat="server" />
    </div>
    <p>Private data goes here</p>
</asp:Content>

<asp:Content runat="server" ID="Content3" ContentPlaceHolderID="BodyContent">
       Body content; Body content; Body content; Body content; Body content; Body content; Body content; Body content; 
       Body content; Body content; Body content; Body content; Body content; Body content; Body content; Body content; 
       Body content; Body content; Body content; Body content; Body content; Body content; Body content; Body content; 
       Body content; Body content; Body content; Body content; Body content; Body content; Body content; Body content; 
       Body content; Body content; Body content; Body content; Body content; Body content; Body content; Body content; 
       Body content; Body content; Body content; Body content; Body content; Body content; Body content; Body content; 
       Body content; Body content; Body content; Body content; Body content; Body content; Body content; Body content; 
       Body content; Body content; Body content; Body content; Body content; Body content; Body content; Body content; 
       Body content; Body content; Body content; Body content; Body content; Body content; Body content; Body content; 
       Body content; Body content; Body content; Body content; Body content; Body content; Body content; Body content; 
</asp:Content>

<asp:Content runat="server" ID="Content2" ContentPlaceHolderID="AuthenticationAsideContent">
    <cc1:Authentication ID="AuthenticationWidget" runat="server" 
        IsDebug="true" 
        UseMockData="true" 
        Width="200"
        AfterLogOffNavigateUrl="~/Default.aspx" />
</asp:Content>

<asp:Content runat="server" ID="Content4" ContentPlaceHolderID="SidebarContent">
       Sidebar content; Sidebar content; Sidebar content; Sidebar content; Sidebar content; Sidebar content; Sidebar content; Sidebar content; 
       Sidebar content; Sidebar content; Sidebar content; Sidebar content; Sidebar content; Sidebar content; Sidebar content; Sidebar content; 
       Sidebar content; Sidebar content; Sidebar content; Sidebar content; Sidebar content; Sidebar content; Sidebar content; Sidebar content; 
       Sidebar content; Sidebar content; Sidebar content; Sidebar content; Sidebar content; Sidebar content; Sidebar content; Sidebar content; 
       Sidebar content; Sidebar content; Sidebar content; Sidebar content; Sidebar content; Sidebar content; Sidebar content; Sidebar content; 
       Sidebar content; Sidebar content; Sidebar content; Sidebar content; Sidebar content; Sidebar content; Sidebar content; Sidebar content; 
       Sidebar content; Sidebar content; Sidebar content; Sidebar content; Sidebar content; Sidebar content; Sidebar content; Sidebar content; 
       Sidebar content; Sidebar content; Sidebar content; Sidebar content; Sidebar content; Sidebar content; Sidebar content; Sidebar content; 
       Sidebar content; Sidebar content; Sidebar content; Sidebar content; Sidebar content; Sidebar content; Sidebar content; Sidebar content; 
       Sidebar content; Sidebar content; Sidebar content; Sidebar content; Sidebar content; Sidebar content; Sidebar content; Sidebar content; 
</asp:Content>
