﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BasicEcharts.aspx.cs" Inherits="Echarts.BasicEcharts" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <meta charset ="utf-8">
    <script type="text/javascript" src="https://echarts.apache.org/examples/vendors/echarts/echarts.min.js"></script>
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
                 data: ["衬衫", "羊毛衫", "雪纺衫", "裤子", "高跟鞋", "袜子"]
             },
             yAxis: {},
             series: [{
                 name: '销量',
                 type: 'bar',
                 data: [5, 20, 36, 10, 10, 20]
             }]
         };

         // 使用刚指定的配置项和数据显示图表。
         myChart.setOption(option);
    </script>
    </form>
</body>
</html>
