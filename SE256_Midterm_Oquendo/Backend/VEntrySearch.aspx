<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="VEntrySearch.aspx.cs" Inherits="SE256_Midterm_Oquendo.VEntrySearch" %>

<asp:Content ID="Content1" ContentPlaceHolderID="RecentlyAdded" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h1>VEntry Search</h1>

    <p>Optional Search Criteria to narrow search results</p>
    <p>
        Movie Title: <asp:TextBox ID="txtTitle" runat="server" Columns="30" />

        &nbsp;&nbsp;&nbsp;&nbsp;

        Genre: <asp:TextBox ID="txtGenre" runat="server" Columns="30" />
    </p>
    <br />

    <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />
    <br />
    <br />

    <asp:DataGrid ID="dgResults" runat="server" AutoGenerateColumns="false" >
        <Columns>
            <asp:BoundColumn DataField="Title" HeaderText="Movie Title" />
            <asp:BoundColumn DataField="Genre" HeaderText="Genre" />
            <asp:BoundColumn DataField="Rating" HeaderText="Rating" />
            <asp:BoundColumn DataField="Year" HeaderText="Year" />
            <asp:HyperLinkColumn Text="Edit" DataNavigateUrlFormatString="~/Backend/VEntryMgr.aspx?VEntry_ID={0}" DataNavigateUrlField="vEntry_ID" />
        </Columns>
    </asp:DataGrid>

    <br /><br />
    <br /><br />
    <!-- <h1>Another output option: Creating our own output while looping through records using a repeater and ItemTemplate</h1>
    <asp:Repeater ID="rptSearch" runat="server" >
        <HeaderTemplate>
            <asp:Label ID="lblHeader" runat="server" Text="Your results..." />

        </HeaderTemplate>

        <ItemTemplate>
            <br />
            <asp:Label ID="lblTitle" runat="server" Text='<%# Eval("Title") %>' />
            <asp:Label ID="lblAuthorFirst" runat="server" Text='<%# Eval("AuthorFirst") %>' />
            <asp:Label ID="lblAuthorLast" runat="server" Text='<%# Eval("AuthorLast") %>' />
            <asp:Label ID="lblDatePublished" runat="server" Text='<%# Eval("DatePublished") %>' />

            <%-- <asp:HyperLink ID="lnkID" runat="server" Text="Edit" NavigateUrl='EBookMgr.aspx?EBook_ID=<%# Eval("eBook_ID") %> />--%>

            <asp:HyperLink ID="HyperLink1" runat="server" Text="Edit" NavigateUrl='<%# Eval("EBook_ID", "EBookMgr.aspx?EBook_ID={0}" ) %>' />

            <%--NavigateUrl='<%# Eval("Id", "~/Details.aspx?Id={0}")--%>
            <br />
        </ItemTemplate>
    </asp:Repeater>

    <br /><br />
    <br /><br />
    <h1>Another output option: Creating our own output via a method that loops through each record and developing all the html</h1>
    <asp:Literal ID="litResults" runat="server" Text="" /> -->

</asp:Content>
