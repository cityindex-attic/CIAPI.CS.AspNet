<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Logon.aspx.cs" 
    MasterPageFile="~/ResponsiveLayout.Master" Inherits="TestWebApplication.Logon" %>
<%@ Register Assembly="CIAPI.AspNet.Controls" Namespace="CIAPI.AspNet.Controls.Authentication" TagPrefix="cc1" %>

<asp:Content runat="server" ID="Content1" ContentPlaceHolderID="FeaturedContent">

        <cc1:Authentication ID="AuthenticationWidget" runat="server" 
            Width="400"
            AfterLogOnNavigateUrl="~/MyAccount.aspx"
            AfterLogOffNavigateUrl="~/Default.aspx"  />
</asp:Content>

<asp:Content runat="server" ID="BodyContent1" ContentPlaceHolderID="BodyContent">
    try: CC735158 / password
</asp:Content>