<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SO_WebCalc_Demo.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:TextBox ID="txtLCD" runat="server" Width="180px"></asp:TextBox>
            <p>
                <asp:Button ID="btn1" runat="server" Text="1" OnClick="btn1_Click" />&nbsp;&nbsp;
                <asp:Button ID="btn2" runat="server" Text="2" OnClick="btn2_Click" />&nbsp;&nbsp;
                <asp:Button ID="btn3" runat="server" Text="3" OnClick="btn3_Click" />&nbsp;&nbsp;
                <asp:Button ID="btnClear" runat="server" Text="CLEAR" OnClick="btnClear_Click" />
                
            </p>        

            <p>
                <asp:Button ID="btn4" runat="server" Text="4" OnClick="btnNums_Click" />&nbsp;&nbsp;
                <asp:Button ID="btn5" runat="server" Text="5" OnClick="btnNums_Click" />&nbsp;&nbsp;
                <asp:Button ID="btn6" runat="server" Text="6" OnClick="btnNums_Click" />&nbsp;&nbsp;
                <asp:Button ID="btnPlus" runat="server" Text="+" OnClick="btnPlus_Click" Width="22px"/>&nbsp;&nbsp;
                <asp:Button ID="btnSub" runat="server" Text="-" OnClick="btnNums_Click" Width="22px" />
            </p>
            <p>
                <asp:Button ID="btn7" runat="server" Text="7" OnClick="btnNums_Click" />&nbsp;&nbsp;
                <asp:Button ID="btn8" runat="server" Text="8" OnClick="btnNums_Click" />&nbsp;&nbsp;
                <asp:Button ID="btn9" runat="server" Text="9" OnClick="btnNums_Click" />&nbsp;&nbsp;
                <asp:Button ID="btnMult" runat="server" Text="*" OnClick="btnNums_Click" Width="22px"/>&nbsp;&nbsp;
                <asp:Button ID="btnDiv" runat="server" Text="/" OnClick="btnDiv_Click" Width="22px" />

            </p>
            <p>
                   &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btn0" runat="server" Text="0" OnClick="btnNums_Click" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btnEquals" runat="server" Text="=" OnClick="btnEquals_Click" />&nbsp;&nbsp;
            </p>
        </div>
    </form>
</body>
</html>
