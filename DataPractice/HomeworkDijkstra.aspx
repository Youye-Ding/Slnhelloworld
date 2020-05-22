<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomeworkDijkstra.aspx.cs" Inherits="DataPractice.HomeworkDijkstra" %>

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
        <asp:DropDownList ID="ddlPointA" runat="server">
        </asp:DropDownList>
        <asp:DropDownList ID="ddlPointB" runat="server">
        </asp:DropDownList>
        <p>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="单击求算最短距离" />
        </p>
    </form>
</body>
</html>
