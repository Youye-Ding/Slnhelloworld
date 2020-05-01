<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="countryScatterFromDb.aspx.cs" Inherits="Echarts.countryScatterFromDb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>历史人物轨迹</title>
    <script src="js/jquery-3.5.0.min.js"></script>
    <script src="js/echarts.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
 <!-- 为ECharts准备一个具备大小（宽高）的Dom -->
    <div id="main" style="width: 100%;height:1000px;"></div>
    <script type="text/javascript">
        // 基于准备好的dom，初始化echarts实例
        var myChart = echarts.init(document.getElementById('main'));
        var myseries = []
        myChart.setOption({
                legend: {
                    data: ['唐人', '宋人']
                },
                geo: [{
                    map: 'china',
                    roam: true,
                    left: 350, //地图在网页上的位置
                    width: 600,
                    zoom: 2,//地图初始的放大系数
                    scaleLimit: {
                        min: 1.5,
                        max: 3
                    }
                }],
                tooltip: {
                    trigger: 'item',
                    formatter: function (params) {
                        return params.name; //图标显示名字
                    }
                },
                series: myseries
            });

            $.get('mapdata/china.json', function (chinaJson) {
                echarts.registerMap('china', chinaJson);
                myChart.setOption({
                    geo: {
                        map: 'china'
                    }
                });
            });
            //通过Ajax获取唐朝数据
            $.ajax({
                type: "GET",
                async: false, //同步执行
                url: "data/cbdbpointTang.json",
                dataType: "json", //返回数据形式为json
                success: function (result) {
                    if (result) {
                        var newSeries = {
                            coordinateSystem: 'geo',
                            name: '唐人',
                            type: 'scatter',
                            data: result
                        }
                        myseries.push(newSeries)
                        myChart.setOption({
                            series: myseries
                        });
                    }
                },
                error: function (errorMsg) {
                    alert("图表请求数据失败啦!" + errorMsg);
                    console.log(errorMsg);
                }
            });
            //通过Ajax获取宋朝数据
            $.ajax({
                type: "GET",
                async: false, //同步执行
                url: "data/cbdbpointSong.json",
                dataType: "json", //返回数据形式为json
                success: function (result) {
                    if (result) {
                        var newSeries = {
                            coordinateSystem: 'geo',
                            name: '宋人',
                            type: 'scatter',
                            data: result
                        }
                        myseries.push(newSeries)
                        myChart.setOption({
                            series: myseries
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
