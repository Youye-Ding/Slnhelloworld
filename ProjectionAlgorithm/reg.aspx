﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="reg.aspx.cs" Inherits="ProjectionAlgorithm.reg" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            用户名：<asp:TextBox ID="userName" runat="server" OnTextChanged="userName_TextChanged"></asp:TextBox>
            <br />
            <br />
            密码：<asp:TextBox ID="passWord" runat="server" OnTextChanged="passWord_TextChanged" TextMode="Password"></asp:TextBox>
            <br />
            <br />
            确认密码：<asp:TextBox ID="ConpassWord" runat="server" OnTextChanged="ConpassWord_TextChanged" TextMode="Password"></asp:TextBox>
            <br />
            <br />
            真实姓名：<asp:TextBox ID="Truename" runat="server" OnTextChanged="Truename_TextChanged"></asp:TextBox>
            <br />
            <br />
            出生日期：<asp:Calendar ID="Calendar1" runat="server" OnSelectionChanged="Calendar1_SelectionChanged"></asp:Calendar>
            <br />
            性别：<asp:RadioButtonList ID="Gender" runat="server" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged">
                <asp:ListItem Value="Male">男</asp:ListItem>
                <asp:ListItem Value="Female">女</asp:ListItem>
            </asp:RadioButtonList>
        </div>
        <p>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="注册" />
&nbsp;&nbsp;&nbsp;
        </p>
    </form>
</body>
</html>
