﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="ProjectionAlgorithm.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <p>
            用户名：<asp:TextBox ID="TuserName" runat="server" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
        </p>
        <p>
            密码：<asp:TextBox ID="TpassWord" runat="server" OnTextChanged="passWord_TextChanged" TextMode="Password"></asp:TextBox>
        </p>
        <asp:Button ID="Reg2" runat="server" OnClick="Reg2_Click" Text="注册" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Log" runat="server" OnClick="Log_Click" Text="登录" />
    </form>
</body>
</html>
