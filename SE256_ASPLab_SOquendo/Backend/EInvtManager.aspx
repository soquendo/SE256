<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EInvtManager.aspx.cs" Inherits="SE256_ASPLab_SOquendo.Backend.EInvtManager" %>

<asp:Content ID="Content1" ContentPlaceHolderID="LatestNews" runat="server">
    <br />
    <a href="~/Backend/ControlPanel.aspx" runat="server">Return to Control Panel</a>
    <br />

</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <table>

        <tr>
            <td>EInvt ID</td>
            <td><asp:Label ID="lblEInvt_ID" runat="server" /></td>
        </tr>

        <tr>
            <td>Color</td>
            <td><asp:TextBox ID="txtColor" runat="server" MaxLength="30" /></td>
        </tr>

        <tr>
            <td>Size</td>
            <td><asp:TextBox ID="txtSize" runat="server" MaxLength="20" /></td>
        </tr>

        <tr>
            <td>Style</td>
            <td><asp:TextBox ID="txtStyle" runat="server" MaxLength="25" /></td>
        </tr>

        <tr>
            <td>User's Email</td>
            <td><asp:TextBox ID="txtUserEmail" runat="server" MaxLength="30" /></td>
        </tr>  

        <tr>
            <td>Price</td>
            <td><asp:TextBox ID="txtPrice" runat="server" MaxLength="10"  /></td>
        </tr>

    </table>

    <br />
    <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click" />

    &nbsp;&nbsp;&nbsp;
    <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" />

    &nbsp;&nbsp;&nbsp;
    <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" />

    &nbsp;&nbsp;&nbsp;
    <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />

    <br />
    <br />
    <asp:Label ID="lblFeedback" runat="server" />


</asp:Content>
