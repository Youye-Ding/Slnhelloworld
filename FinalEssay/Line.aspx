<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Line.aspx.cs" Inherits="FinalEssay.Line" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Echarts</title>
    <meta charset="utf-8">
    <script src="js/jquery-3.5.0.min.js"></script>
    <script src="js/echarts.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="main" style="width: 1000px;height:600px;"></div>
     <script type="text/javascript">
         var myChart = echarts.init(document.getElementById('main'));
         var option = {
             title: {

             },
             tooltip: {
                 trigger: 'axis'
             },
             legend: {
                 data: ['江苏省通州高级中学', '江苏省西亭高级中学', '平潮中学']
             },
             grid: {
                 left: '3%',
                 right: '4%',
                 bottom: '3%',
                 containLabel: true
             },
             toolbox: {
                 feature: {
                     saveAsImage: {}
                 }
             },
             xAxis: {
                 type: 'category',
                 boundaryGap: false,
                 data: ['高一上期中', '高一上期末', '高一下期中','高一下期末']
             },
             yAxis: {
                 type: 'value',
                 min: 250
             },
             series: [
                 { name: '江苏省通州高级中学', type: 'line', data: [] },
                 { name: '江苏省西亭高级中学', type: 'line', data: [] },
                 { name: '平潮中学', type: 'line', data: [] }
             ]
         };
         myChart.setOption(option);
         $.ajax({
             type: "GET",
             async: false, //同步执行
             url: "data/Line.json",
             dataType: "json", //返回数据形式为json
             success: function (result) {
                 
                 myChart.setOption({

                     series: [{ data: result[0] },
                     { data: result[1] },
                     { data: result[2] }
                     ]
                 });
                 }
         });
     </script>
    </form>
</body>
</html>
