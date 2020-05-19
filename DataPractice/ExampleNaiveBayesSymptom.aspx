<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExampleNaiveBayesSymptom.aspx.cs" Inherits="DataPractice.ExampleNaiveBayesSymptom" %>

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
        <asp:DropDownList ID="ddlSymptom" runat="server">
        </asp:DropDownList>
        <asp:DropDownList ID="ddlJob" runat="server">
        </asp:DropDownList>
        <p>
            <asp:Button ID="btnOut" runat="server" Text="单击预测疾病" OnClick="btnOut_Click" />
        </p>
    </form>
</body>
</html>
