<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Radar.aspx.cs" Inherits="FinalEssay.Radar" %>

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
                text: '三层成绩相关性图'
            },
            tooltip: {},
            legend: {
                data: ['第一层', '第二层', '第三层']
            },
            radar: {
                name: {
                    textStyle: {
                        color: '#fff',
                        backgroundColor: '#999',
                        borderRadius: 3,
                        padding: [3, 5]
                    }
                },
                indicator: [
                    { name: '平均分占总分', max: 1 },
                    { name: '生物相关性', max: 1 },
                    { name: '地理相关性', max: 1 },
                    { name: '历史相关性', max: 1 },
                    { name: '政治相关性', max: 1 }
                ]
            },
            series: [{
                type: 'radar',
                data: [
                    {
                        value: [],
                    },
                    {
                        value: [],
                    },
                    {
                        value: [],
                    }
                ]
            }]
        };
        myChart.setOption(option);
        $.ajax({
            type: "GET",
            async: false, //同步执行
            url: "data/Radar.json",
            dataType: "json", //返回数据形式为json
            success: function (result) {

                myChart.setOption({

                    series: [{
                        data: [
                            { value: result[0],name:'第一层' },
                            { value: result[1],name:'第二层' },
                            { value: result[2],name:'第三层' }
                        ]
                    }]
                });
            }
        });
        </script>
    </form>
</body>
</html>
