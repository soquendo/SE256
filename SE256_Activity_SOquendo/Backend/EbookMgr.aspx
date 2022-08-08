<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EbookMgr.aspx.cs" Inherits="SE256_Activity_SOquendo.Backend.EbookMgr" %>
<asp:Content ID="Content1" ContentPlaceHolderID="BreakingNewsContent" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <table>

        <tr>
            <td>Book ID</td>
            <td><asp:Label ID="lblPerson_ID" runat="server" /></td>
        </tr>

        <tr>
            <td>Book Title</td>
            <td><asp:TextBox ID="txtTitle" runat="server" MaxLength="255" /></td>
        </tr>

        <tr>
            <td>Author's First Name</td>
            <td><asp:TextBox ID="txtAuthorFirst" runat="server" MaxLength="20" /></td>
        </tr>

        <tr>
            <td>Author's Last Name</td>
            <td><asp:TextBox ID="txtAuthorLast" runat="server" MaxLength="40" /></td>
        </tr>

        <tr>
            <td>Author's Email</td>
            <td><asp:TextBox ID="txtAuthorEmail" runat="server" MaxLength="20" /></td>
        </tr>

        <tr>
            <td>Date Published</td>
            <td><asp:Calendar ID="calDatePublished" runat="server"  /></td>
        </tr>



    </table>



</asp:Content>
