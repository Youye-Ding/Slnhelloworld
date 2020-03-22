<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IDcard.aspx.cs" Inherits="Slnhelloworld.IDcard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            请输入身份证号：</div>
        <asp:TextBox ID="TextBox1" runat="server" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
        <p>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="验证身份证合法性" />
        </p>
    </form>
</body>
</html>
