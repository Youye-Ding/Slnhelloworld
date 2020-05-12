<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomeworkMonteCarloIntegral.aspx.cs" Inherits="DataPractice.HomwworkMonteCarloIntegral" %>

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
        请输入随机样本的数量：<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="单击计算e值" />
    </form>
</body>
</html>
