<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="d3BarDynamic.aspx.cs" Inherits="Echarts.HistoricalRanking.d3BarDynamic" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>动态bar图</title>
    <script src="../js/jquery-3.5.0.min.js"></script>
    <script src="https://d3js.org/d3.v5.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     
        <svg width="1900" height="1020"></svg>
        <script src="config.js"></script>
        <script src="imgs.js"></script>
        <script src="color_ranges.js"></script>
        <script src="visual.js"></script>
        <link rel="stylesheet" href="stylesheet.css">
    </div>
    </form>
     <script type="text/javascript">
         //通过Ajax获取数据
         $.ajax({
             type: "GET",
             async: false, //同步执行
             url: "../data/named3.json",
             dataType: "json", //返回数据形式为json
             success: function (result) {
                 if (result) {
                     draw(result);
                 }
             },
             error: function (errorMsg) {
                 alert("图表请求数据失败啦!" + errorMsg);
                 console.log(errorMsg);
             }
         });
    </script>
</body>
</html>
