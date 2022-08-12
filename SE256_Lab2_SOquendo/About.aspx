<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="SE256_Lab2_SOquendo.SiteMaster" %>


<asp:Content ID="Content1" ContentPlaceHolderID="NewProducts" runat="server">
    <div>
        Super Special Stuff is here to provide you with useless products you absolutely need. Also, look for our store on Amazon!
    </div>
</asp:Content>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>Your application description page.</h3>
    <p>Use this area to provide additional information.</p>
</asp:Content>