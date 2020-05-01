<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="d3BarBasic.aspx.cs" Inherits="Echarts.HistoricalRanking.d3BarBasic" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="../js/jquery-3.5.0.min.js"></script>
    <script src="https://d3js.org/d3.v5.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <input type="file" id="inputfile" name="fileContent">
        <svg width="1900" height="1020"></svg>
        <script src="config.js"></script>
        <script src="imgs.js"></script>
        <script src="color_ranges.js"></script>
        <script src="visual.js"></script>
        <link rel="stylesheet" href="stylesheet.css">
    </div>
    </form>
</body>
</html>
