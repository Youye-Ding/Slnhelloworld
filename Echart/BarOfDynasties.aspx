<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="barFromDynamicJson.aspx.cs" Inherits="Echarts.barFromDynamicJson" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>C#动态生成JSON数据实现柱状图</title>
     <meta charset="utf-8">
     <script src="js/jquery-3.5.0.min.js"></script>
    <!-- 引入 ECharts 文件 -->
    <script src="js/echarts.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="main" style="width: 1500px;height:400px;"></div>
     <script type="text/javascript">
         // 基于准备好的dom，初始化echarts实例
         var myChart = echarts.init(document.getElementById('main'));
         // 指定图表的配置项和数据
         var option = {
             title: {
                 text: '朝代人数分布图'
             },
             tooltip: {},
             legend: {
                 data: ['人数']
             },
             xAxis: {
                 data: []
             },
             yAxis: {},
             series: [{
                 name: '人数',
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
             url: "data/BarOfDynasties.json",
             dataType: "json", //返回数据形式为json
             success: function (result) {
                 if (result) {
                     myChart.setOption({
                         xAxis: {
                             data: result[0]
                         },
                         series: {
                             name: '人数',
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
