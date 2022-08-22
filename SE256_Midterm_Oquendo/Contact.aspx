<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="SE256_Midterm_Oquendo.Contact" %>

<asp:Content ID="Content1" ContentPlaceHolderID="RecentlyAdded" runat="server">
    <div>

    </div>
</asp:Content>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>Your contact page.</h3>
    <address>
        12 Retro Lane<br />
        Providence, RI 98052-6399<br />
        <abbr title="Phone">P:</abbr>
        401.555.5150
    </address>

    <address>
        <strong>Support:</strong>   <a href="mailto:Support@example.com">Support@example.com</a><br />
        <strong>Marketing:</strong> <a href="mailto:Marketing@example.com">Marketing@example.com</a>
    </address>
</asp:Content>
