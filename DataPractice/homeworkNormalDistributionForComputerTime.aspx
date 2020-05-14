<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="homeworkNormalDistributionForComputerTime.aspx.cs" Inherits="DataPractice.data.homeworkNormalDistributionForComputerTime" %>

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
        请输入开机时间（单位：秒）：<asp:TextBox ID="TextBox1" runat="server" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
        <br />
        <p>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="计算开机时间排名" />
        </p>
    </form>
</body>
</html>
