<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EBookSearch.aspx.cs" Inherits="SE256_Activity_SOquendo.EBookSearch" %>

<asp:Content ID="Content1" ContentPlaceHolderID="BreakingNewsContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h1>EBook Search</h1>

    <p>Optional Search Criteria to narrow search results</p>
    <p>
        Book Title: <asp:TextBox ID="txtTitle" runat="server" Columns="30" />
    </p>
</asp:Content>
