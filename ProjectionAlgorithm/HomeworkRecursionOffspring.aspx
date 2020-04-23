<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomeworkRecursionOffspring.aspx.cs" Inherits="ProjectionAlgorithm.HomeworkRecursionOffspring" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            请输入一个历史人名：</div>
        <p>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        </p>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="单击查询人物后代" />
    </form>
</body>
</html>
