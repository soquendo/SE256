<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ControlPanel.aspx.cs" Inherits="SE256_Lab2_SOquendo.Backend.ControlPanel" %>
<asp:Content ID="Content1" ContentPlaceHolderID="NewProducts" runat="server">

</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <h2>Control Panel</h2>

        <table>
            <tr>
                <td><a href="InventoryMgr.aspx" runat="server">Add to Inventory</a></td>
            </tr>
            <tr>
                <td><asp:Button ID="btnLogout" runat="server" Text="Log Out" OnClick="btnLogout_Click" /></td>
            </tr>
        </table>

    </div>

</asp:Content>
