<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="homeworkAltname.aspx.cs" Inherits="ProjectionAlgorithm.homeworkAltname" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            输入姓名：<asp:TextBox ID="TextBox1" runat="server" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
        </div>
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="查找曾用名" />
    </form>
</body>
</html>
