<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ControlPanel.aspx.cs" Inherits="SE256_ASPLab_SOquendo.Backend.ControlPanel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="LatestNews" runat="server">

</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <h2>Control Panel</h2>

        <table>
            <tr>
                <td><a href="EInvtMgr.aspx" runat="server">Add an order</a></td>
            </tr>
            <tr>
                <td><a href="EInvtSearch.aspx" runat="server">Search current orders</a></td>
            </tr>
            <tr>
                <td><asp:Button ID="btnLogout" runat="server" Text="Log Out" OnClick="btnLogout_Click" /></td>
            </tr>

        </table>

    </div>

</asp:Content>