<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Caeser.aspx.cs" Inherits="Slnhelloworld.Caeser" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            请输入一组字符串：<br />
        </div>
        <asp:TextBox ID="TextBox1" runat="server" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
        <br />
        <br />
        请输入偏移量：<br />
        <br />
        <asp:TextBox ID="TextBox2" runat="server" OnTextChanged="TextBox2_TextChanged"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="点击生成密码" />
        <p>
            <asp:Label ID="Label1" runat="server" Text="密码将在这里出现"></asp:Label>
        </p>
    </form>
</body>
</html>
