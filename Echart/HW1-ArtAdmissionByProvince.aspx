<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HW1-ArtAdmissionByProvince.aspx.cs" Inherits="Echart.HW1_AdmissionByProvince" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>C#动态生成JSON数据实现折线图</title>
     <meta charset="utf-8">
     <script src="js/jquery-3.5.0.min.js"></script>
    <!-- 引入 ECharts 文件 -->
    <script src="js/echarts.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="main" style="width: 1200px;height:1000px;"></div>
     <script type="text/javascript">
         // 基于准备好的dom，初始化echarts实例
         var myChart = echarts.init(document.getElementById('main'));
         // 指定图表的配置项和数据
         var option = {
    title: {
        text: '文科录取分数线差'
    },
    tooltip: {
        trigger: 'axis'
    },
    legend: {
        data: ['安徽', '北京', '福建', '甘肃', '广东', '广西', '贵州', '海南', '河北', '河南', '黑龙江', '湖北', '湖南', '吉林', '江苏', '江西', '辽宁', '内蒙古',
            '宁夏' ,'青海' , '山东','山西' ,'陕西' ,'上海' ,'四川' ,'天津' ,'新疆' , '云南','浙江','重庆']
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
        data: [2017,2018,2019]
    },
    yAxis: {
        type: 'value'
    },
    series: [
        { name: '安徽', type: 'line', data: [] },
        { name: '北京', type: 'line', data: [] },
        { name: '福建', type: 'line',  data: [] },
        { name: '甘肃', type: 'line',  data: [] },
        { name: '广东', type: 'line', data: [] },
        { name: '广西', type: 'line', data: [] },
        { name: '贵州', type: 'line', data: [] },
        { name: '海南', type: 'line', data: [] },
        { name: '河北', type: 'line', data: [] },
        { name: '河南', type: 'line', data: [] },
        { name: '黑龙江', type: 'line', data: [] },
        { name: '湖北', type: 'line', data: [] },
        { name: '湖南', type: 'line', data: [] },
        { name: '吉林', type: 'line', data: [] },
        { name: '江苏', type: 'line', data: [] },
        { name: '江西', type: 'line', data: [] },
        { name: '辽宁', type: 'line', data: [] },
        { name: '内蒙古', type: 'line', data: [] },
        { name: '宁夏', type: 'line', data: [] },
        { name: '青海', type: 'line', data: [] },
        { name: '山东', type: 'line', data: [] },
        { name: '山西', type: 'line', data: [] },
        { name: '陕西', type: 'line', data: [] },
        { name: '上海', type: 'line', data: [] },
        { name: '四川', type: 'line', data: [] },
        { name: '天津', type: 'line', data: [] },
        { name: '新疆', type: 'line', data: [] },
        { name: '云南', type: 'line', data: [] },
        { name: '浙江', type: 'line', data: [] },
        { name: '重庆', type: 'line', data: [] }
    ]
         };
         myChart.setOption(option);
         $.ajax({
             type: "GET",
             async: false, //同步执行
             url: "data/ArtAdmissionByProvince.json",
             dataType: "json", //返回数据形式为json
             success: function (result) {
                 
                     myChart.setOption({

                         series: [{ data: result[0].value },
                             { data: result[1].value },
                             { data: result[2].value },
                             { data: result[3].value },
                             { data: result[4].value },
                             { data: result[5].value },
                             { data: result[6].value },
                             { data: result[7].value },
                             { data: result[8].value },
                             { data: result[9].value },
                             { data: result[10].value },
                             { data: result[11].value },
                             { data: result[12].value },
                             { data: result[13].value },
                             { data: result[14].value },
                             { data: result[15].value },
                             { data: result[16].value },
                             { data: result[17].value },
                             { data: result[18].value },
                             { data: result[19].value },
                             { data: result[20].value },
                             { data: result[21].value },
                             { data: result[22].value },
                             { data: result[23].value },
                             { data: result[24].value },
                             { data: result[25].value },
                             { data: result[26].value },
                             { data: result[27].value },
                             { data: result[28].value },
                             { data: result[29].value }

                    ] });
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
