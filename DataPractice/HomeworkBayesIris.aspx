<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomeworkBayesIris.aspx.cs" Inherits="DataPractice.HomeworkBayesIris" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            花萼长度：<asp:TextBox ID="CalyxLength" runat="server" OnTextChanged="CalyxLength_TextChanged"></asp:TextBox>
            <br />
            <br />
            花萼宽度：<asp:TextBox ID="CalyxWidth" runat="server" OnTextChanged="CalyxWidth_TextChanged"></asp:TextBox>
            <br />
            <br />
            花瓣长度：<asp:TextBox ID="PetalLength" runat="server" OnTextChanged="PetalLength_TextChanged"></asp:TextBox>
            <br />
            <br />
            花萼宽度：<asp:TextBox ID="PetalWidth" runat="server" OnTextChanged="PetalWidth_TextChanged"></asp:TextBox>
        </div>
        <p>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="单击预测鸢尾兰类型" />
        </p>
    </form>
</body>
</html>
