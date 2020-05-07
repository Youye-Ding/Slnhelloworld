<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="getDataFromCsv.aspx.cs" Inherits="dataPractice.getDataFromCsv" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
       请输入CSV路径： <asp:TextBox ID="txtFilePath" runat="server" Height="34px" Width="524px"></asp:TextBox>
        </br>
        <asp:Button ID="Button1" runat="server" Text="获取CSV数据" OnClick="Button1_Click" />
    
    </div>
    </form>
</body>
</html>
