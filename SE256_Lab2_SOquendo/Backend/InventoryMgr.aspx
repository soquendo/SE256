<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="InventoryMgr.aspx.cs" Inherits="SE256_Lab2_SOquendo.Backend.InventoryMgr" %>

<asp:Content ID="Content1" ContentPlaceHolderID="NewProducts" runat="server">
    <br />
    <a href="~/Backend/ControlPanel.aspx" runat="server">Return to Control Panel</a>
    <br />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table>

        <tr>
            <td>Product ID</td>
            <td><asp:TextBox ID="txtProductID" runat="server" /></td>
        </tr>

        <tr>
            <td>Product Name</td>
            <td><asp:TextBox ID="txtProductName" runat="server" MaxLength="255" /></td>
        </tr>

        <tr>
            <td>Company</td>
            <td><asp:TextBox ID="txtCompany" runat="server" MaxLength="255" /></td>
        </tr>

        <tr>
            <td>Category</td>
            <td><asp:TextBox ID="txtCategory" runat="server" MaxLength="25" /></td>
        </tr>

        <tr>
            <td>Date Released</td>
            <td><asp:Calendar ID="calDateReleased" runat="server" /></td>
        </tr>

        <tr>
            <td>Item price</td>
            <td>$<asp:TextBox ID="txtPrice" runat="server" MaxLength="10" /></td>
        </tr>

    </table>

    <br />
    <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click" />

    <br />
    <br />
    <asp:Label ID="lblFeedback" runat="server" />

</asp:Content>
