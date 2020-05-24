<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomeworkBayesGender.aspx.cs" Inherits="DataPractice.HomeworkBayesGender" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            脚长：<asp:TextBox ID="FootSize" runat="server" OnTextChanged="FootSize_TextChanged"></asp:TextBox>
            <br />
            <br />
            体重：<asp:TextBox ID="Weight" runat="server" OnTextChanged="Weight_TextChanged"></asp:TextBox>
            <br />
            <br />
            身高：<asp:TextBox ID="Height" runat="server" OnTextChanged="Height_TextChanged"></asp:TextBox>
        </div>
        <p>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="单击按钮推断性别" />
        </p>
    </form>
</body>
</html>
