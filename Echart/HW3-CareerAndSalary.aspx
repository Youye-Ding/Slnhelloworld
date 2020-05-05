<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HW3-CareerAndSalary.aspx.cs" Inherits="Echart.HW3_CareerAndSalary" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>C#动态生成JSON数据实现饼图</title>
     <meta charset="utf-8">
    <script src="js/jquery-3.5.0.min.js"></script>
    <!-- 引入 ECharts 文件 -->
    <script src="js/echarts.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="main" style="width: 600px;height:400px;"></div>
    <script>
        // 绘制图表。
        // 基于准备好的dom，初始化echarts实例
        var myChart = echarts.init(document.getElementById('main'));
        // 指定图表的配置项和数据
        var option = {
            title: {
                text: '华东师范大学毕业生行业分布',
                x: 'center'
            },
            series: {
                type: 'pie',
                data: []
            }
        }
        // 使用刚指定的配置项和数据显示图表。
        myChart.setOption(option);
    </script>
     <script type="text/javascript">
         //通过Ajax获取数据
         $.ajax({
             type: "GET",
             async: false, //同步执行
             url: "data/Career.json",
             dataType: "json", //返回数据形式为json
             success: function (result) {
                 if (result) {
                     myChart.setOption({
                         series: {
                             type: 'pie',
                             data: result
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
