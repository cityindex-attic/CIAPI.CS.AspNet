<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Logon.aspx.cs" 
    MasterPageFile="~/Site1.master" Inherits="TestWebApplication.Logon" %>
<%@ Register Assembly="CIAPI.AspNet.Authentication" Namespace="CIAPI.AspNet.Authentication" TagPrefix="cc1" %>

<asp:Content runat="server" ID="BodyContent1" ContentPlaceHolderID="BodyContent">

    <div style="position: absolute; top:20%; left:30%;">
        <cc1:Authentication ID="AuthenticationWidget" runat="server" 
            IsDebug="true" 
            UseMockData="true" 
            Width="400"
            AfterLogOnNavigateUrl="~/MyAccount.aspx"
            AfterLogOffNavigateUrl="~/Default.aspx" />
    </div>
</asp:Content>