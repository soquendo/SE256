<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="VEntryMgr.aspx.cs" Inherits="SE256_Midterm_Oquendo.Backend.VEntryMgr" %>

<asp:Content ID="Content1" ContentPlaceHolderID="RecentlyAdded" runat="server">
    <br />
    <a href="~/Backend/ControlPanel.aspx" runat="server">Return to Control Panel</a>
    <br />

</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <table>

        <tr>
            <td>VEntry ID</td>
            <td><asp:Label ID="lblVEntry_ID" runat="server" /></td>
        </tr>

        <tr>
            <td>Movie Title</td>
            <td><asp:TextBox ID="txtTitle" runat="server" MaxLength="255" /></td>
        </tr>

        <tr>
            <td>Genre</td>
            <td>
                <!-- <asp:TextBox ID="txtGenre" runat="server" MaxLength="20" /> -->
                <asp:RadioButton ID="rdoAction" runat="server"
                    Checked="true" GroupName="Genre" Text="Action" />&nbsp;
                <asp:RadioButton ID="rdoAdventure" runat="server"
                    Checked="true" GroupName="Genre" Text="Adventure" />&nbsp;
                <asp:RadioButton ID="rdoComedy" runat="server"
                    Checked="true" GroupName="Genre" Text="Comedy" />&nbsp;
                <asp:RadioButton ID="rdoCrime" runat="server"
                    Checked="true" GroupName="Genre" Text="Crime" />&nbsp;
                <asp:RadioButton ID="rdoDrama" runat="server"
                    Checked="true" GroupName="Genre" Text="Drama" />&nbsp;
                <asp:RadioButton ID="rdoHorror" runat="server"
                    Checked="true" GroupName="Genre" Text="Horror" />&nbsp;
                <asp:RadioButton ID="rdoSciFi" runat="server"
                    Checked="true" GroupName="Genre" Text="Science Fiction" />&nbsp;
                <asp:RadioButton ID="rdoSuspense" runat="server"
                    Checked="true" GroupName="Genre" Text="Suspense" />&nbsp;

            </td>

        </tr>

        <tr>
            <td>Rating</td>
            <td><asp:TextBox ID="txtRating" runat="server" MaxLength="40" /></td>
        </tr>

        <tr>
            <td>Runtime</td>
            <td><asp:TextBox ID="txtRuntime" runat="server" MaxLength="3" /></td>
        </tr>

        <tr>
            <td>Year</td>
            <td><asp:Calendar ID="calYear" runat="server"  /></td>
        </tr>

        <tr>
            <td>Rental Price</td>
            <td><asp:TextBox ID="txtPrice" runat="server" MaxLength="10"  /></td>
        </tr>

        <tr>
            <td>Date Rental Expires</td>
            <td><asp:Calendar ID="calRentalExpires" runat="server" /></td>
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
