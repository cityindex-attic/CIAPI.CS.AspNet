<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="jQueryUI.master"
CodeBehind="ProtectedPage.aspx.cs" Inherits="TestWebApplication.ProtectedPage" %>

<%@ Register Assembly="CIAPI.AspNet.MarketGrid" Namespace="CIAPI.AspNet.MarketGrid" TagPrefix="cc1" %>
<%@ Register Assembly="CIAPI.AspNet.Authentication" Namespace="CIAPI.AspNet.Authentication" TagPrefix="cc1" %>

<asp:Content runat="server" ID="Content1" ContentPlaceHolderID="BodyContent">
    <H1>Protected page</H1>
    <div style="float:right; border:1px solid black; padding: 10px; margin: 5px">
        <cc1:Authentication ID="AuthenticationWidget" runat="server" 
            IsDebug="true" 
            UseMockData="true" 
            Width="200"
            AfterLogOffNavigateUrl="~/Default.aspx" />
    </div>

    <div>
       Some sensitive content goes here 
    </div>
</asp:Content>
