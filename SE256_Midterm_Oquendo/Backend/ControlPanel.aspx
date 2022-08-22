<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ControlPanel.aspx.cs" Inherits="SE256_Midterm_Oquendo.Backend.ControlPanel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="RecentlyAdded" runat="server">

</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <h2>Control Panel</h2>

        <table>
            <tr>
                <td><a href="VEntryMgr.aspx" runat="server">Add an Entry</a></td>
            </tr>
            <tr>
                <td><a href="VEntrySearch.aspx" runat="server">Search available catalogue</a></td>
            </tr>
            <tr>
                <td><asp:Button ID="btnLogout" runat="server" Text="Log Out" OnClick="btnLogout_Click" /></td>
            </tr>

        </table>

    </div>

</asp:Content>