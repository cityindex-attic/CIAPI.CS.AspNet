<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/jQueryUI.master"
 CodeBehind="Default.aspx.cs" Inherits="TestWebApplication.Default" %>
<%@ Register Assembly="CIAPI.AspNet.MarketGrid" Namespace="CIAPI.AspNet.MarketGrid" TagPrefix="cc1" %>
<%@ Register Assembly="CIAPI.AspNet.Authentication" Namespace="CIAPI.AspNet.Authentication" TagPrefix="cc1" %>

<asp:Content runat="server" ID="BodyContent1" ContentPlaceHolderID="BodyContent">
    <div style="border:1px solid black; padding: 10px; margin: 5px">
        <asp:Literal ID="isAuthenticatedLabel" runat="server" />
    </div>

    <div style="position: absolute; top:20%; left:30%;">
        <cc1:Authentication ID="AuthenticationWidget" runat="server" 
            IsDebug="true" 
            UseMockData="true" 
            Width="400"
            AfterLogOnNavigateUrl="~/ProtectedPage.aspx" />
<%--        <cc1:MarketGrid runat="server" />--%>
    </div>
</asp:Content>
