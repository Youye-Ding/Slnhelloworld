<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="cityFromDynamicJson.aspx.cs" Inherits="Echarts.cityFromDynamicJson" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>C#动态生成JSON数据城市图</title>
     <script src="js/jquery-3.5.0.min.js"></script>
     <script src="js/echarts.min.js"></script>
</head>
<body>
  <form id="form1" runat="server">
   <div id="main" style="width: 600px;height: 400px"></div>
    <script type="text/javascript">
            var myChart = echarts.init(document.getElementById('main'));
            var dt = [];
            //通过Ajax获取数据
            $.ajax({
                     type: "GET",
                     async: false, //同步执行
                     url: "data/changshaBank.json",
                     dataType: "json", //返回数据形式为json
                     success: function (result) {
                         if (result) {
                             dt = result;
                         }
                     },
                     error: function (errorMsg) {
                         alert("图表请求数据失败啦!" + errorMsg);
                         console.log(errorMsg);
                     }
            });
            var option = {
                title: {
                    text: '长沙市',
                    subtext: '各区县',
                    x: 'center'
                },
                tooltip: {
                    trigger: 'item',
                    type: 'cross',
                    alwaysShowContent: false,
                    bordeRadius: 4,
                    borderWidth: 1,
                    borderColor: 'rgba(0,0,0,0.2)',
                    backgroundColor: 'rgba(255,255,255,0.9)',
                    padding: 0,
                    // position: "top",
                    textStyle: {
                        fontSize: 12,
                        color: '#333'
                    },
                    formatter: function (params) {
                        var color = "#FFB84D";
                        var a = "<div style='background-color:" + color + ";padding: 5px 10px;text-align:center;color:white;font-size: 16px;'>" + dt[params.dataIndex].name + "</div>";
                        var num = Math.ceil(params.data.name[1].length / 10);
                        a += "<div style='padding:3px;'>";
                        for (var i = 0; i < num; i++) {
                            a += dt[params.dataIndex].text + "<br>贷款金额:";
                            a += dt[params.dataIndex].value + "万<br>";
                        }
                        a += "</div>";
                        return a;
                    }
                },
                visualMap: {
                    min: 800,
                    max: 50000,
                    text: ['High', 'Low'],
                    x: 'left',
                    y: 'center',
                    realtime: false,
                    calculable: true,
                    inRange: {
                        color: ['lightskyblue', 'yellow', 'orangered']
                    }
                },
                toolbox: {
                    show: true,
                    orient: 'vertical',
                    x: 'right',
                    y: 'center',
                    borderColor: '#FFF',       // 工具箱边框颜色
                    borderWidth: 0,            // 工具箱边框线宽，单位px，默认为0（无边框）
                    padding: 5,                // 工具箱内边距，单位px，默认各方向内边距为5，
                    showTitle: false,
                    feature: {
                        saveAsImage: {
                            show: true,
                            title: '保存为图片',
                            type: 'jpeg'
                        },
                        restore: { show: true },
                    }
                },
                series: [{
                    name: '长沙',
                    type: 'map',
                    map: 'cs',
                    // symbol:'../images/shine.jpg',
                    //  symbolSize: 41,
                    roam: true,
                    label: {
                        normal: {
                            show: true
                        },
                        emphasis: {
                            show: true
                        }
                    },
                    data:dt,
                    layoutCenter: ['50%', '50%'],   //属性定义地图中心在屏幕中的位置，一般结合layoutSize 定义地图的大小
                    //            layoutSize: 11200,
                    itemStyle: {
                        normal: { label: { show: true } },
                        emphasis: { label: { show: true } }
                    }
                }]
            };
            $.get('mapdata/430100.json', function (csJson) {
                echarts.registerMap('cs', csJson);
                myChart.setOption(option);
            });
    </script>
   </form>
</body>
</html>
