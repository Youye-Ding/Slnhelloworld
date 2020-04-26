<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="barFromJson.aspx.cs" Inherits="Echarts.barFromJson" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>JSON数据实现柱状图</title>
     <meta charset="utf-8">
    <script src="js/jquery-3.5.0.min.js"></script>
    <script src="js/echarts.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    
    <div id="main" style="width: 600px;height:400px;"></div>
    
     <script type="text/javascript">
         // 基于准备好的dom，初始化echarts实例
         var myChart = echarts.init(document.getElementById('main'));
         // 指定图表的配置项和数据
         var option = {
             title: {
                 text: 'ECharts 入门示例'
             },
             tooltip: {},
             legend: {
                 data: ['销量']
             },
             xAxis: {
                 data: []
             },
             yAxis: {},
             series: [{
                 name: '销量',
                 type: 'bar',
                 data: []
             }]
         };
         // 使用刚指定的配置项和数据显示图表。
         myChart.setOption(option);
        // debugger;
         //通过Ajax获取数据
         $.ajax({
             type: "GET",
             async: false, //同步执行
             url: "data/barJson.json",
             dataType: "json", //返回数据形式为json
             success: function (result) {
                 if (result) {
                     myChart.setOption({
                         xAxis: {
                             data: result[0]
                         },
                         series: {
                             name: '销售',
                             data: result[1]
                         }
                     });
                 }
             },
             error: function (errorMsg) {
                 alert("图表请求数据失败啦!" + errorMsg);
                 console.log(errorMsg);
             }
         });
    </script>
    </form>
</body>
</html>
