<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EbookMgr.aspx.cs" Inherits="SE256_Activity_SOquendo.Backend.EbookMgr" %>

<asp:Content ID="Content1" ContentPlaceHolderID="BreakingNewsContent" runat="server">
    <br />
    <a href="~/Backend/ControlPanel.aspx" runat="server">Return to Control Panel</a>
    <br />

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

        <tr>
            <td>Number of Pages</td>
            <td><asp:TextBox ID="txtPages" runat="server" MaxLength="5"  /></td>
        </tr>

        <tr>
            <td>Price per copy</td>
            <td><asp:TextBox ID="txtPrice" runat="server" MaxLength="10"  /></td>
        </tr>

    </table>

    <br />
    <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click" />

    <br />
    <br />
    <asp:Label ID="lblFeedback" runat="server" />


</asp:Content>
