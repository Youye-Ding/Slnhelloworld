﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="homeworkTryDate.aspx.cs" Inherits="Slnhelloworld.homeworkTryDate" %>

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
        <asp:TextBox ID="TextBox1" runat="server" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
        <p>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="校验日期" />
        </p>
    </form>
</body>
</html>
