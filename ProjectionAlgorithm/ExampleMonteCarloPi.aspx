<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExampleMonteCarloPi.aspx.cs" Inherits="ProjectionAlgorithm.ExampleMonteCarloPi" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:TextBox ID="txtNum" runat="server" OnTextChanged="txtNum_TextChanged"></asp:TextBox>
        <p>
            <asp:CheckBox ID="chkPrintPoint" runat="server" OnCheckedChanged="chkPrintPoint_CheckedChanged" Text="显示随机样本" />
        </p>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="求Pi" />
    </form>
</body>
</html>
