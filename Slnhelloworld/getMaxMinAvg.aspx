<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="getMaxMinAvg.aspx.cs" Inherits="Slnhelloworld.getMaxMinAvg" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="点击求解" />
        <br />
        <br />
        <asp:Label ID="Label1" runat="server"></asp:Label>
    </form>
</body>
</html>
