﻿<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/ResponsiveLayout.Master"
 CodeBehind="Default.aspx.cs" Inherits="TestWebApplication.Default" %>
 
<asp:Content runat="server" ID="BodyContent1" ContentPlaceHolderID="FeaturedContent">
       <h3>Default</h3>
       <div class="ui-state-highlight" style="padding:10px">
            LoginState: <asp:Literal ID="LoginStateLiteral" runat="server" />
       </div>
       <div>
        Page Url: <span id="PageUri"></span><br />
        <script>
            $(document).ready(function () {
                $('#PageUri').html(document.location.href);
            });
        </script>
        <a href="#" onclick="window.open('/Default.aspx#myvar=va1', '' , 'width=550,height=350,location=yes'); return false;">Test window.open with hash fragment</a>;
       </div>
       Featured content; Featured content; Featured content; Featured content; Featured content; Featured content; 
       Featured content; Featured content; Featured content; Featured content; Featured content; Featured content; 
       Featured content; Featured content; Featured content; Featured content; Featured content; Featured content; 
       Featured content; Featured content; Featured content; Featured content; Featured content; Featured content; 
       Featured content; Featured content; Featured content; Featured content; Featured content; Featured content; 
       Featured content; Featured content; Featured content; Featured content; Featured content; Featured content; 
       Featured content; Featured content; Featured content; Featured content; Featured content; Featured content; 
       Featured content; Featured content; Featured content; Featured content; Featured content; Featured content; 

</asp:Content>  

<asp:Content runat="server" ID="Content1" ContentPlaceHolderID="BodyContent">
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

<asp:Content runat="server" ID="Content2" ContentPlaceHolderID="SidebarContent">
<h3>Why choose CityIndex</h3>
<p>One of the leading providers of spread betting and CFD trading in the UK, City Index has over 25 years’
    experience in the industry.</p>
<ul>
    <li>Thousands of global markets</li>
    <li>Tight spread from 1 point</li>
    <li>Low margins from 1%</li>
    <li>Spread betting & CFD trading from one platform</li>
    <p><a href="#" class="ui-ciapi-button-yellow">Apply now</a></p>
</ul>
</asp:Content>

