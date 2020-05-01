<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="countryClick.aspx.cs" Inherits="Echarts.countryClick" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>地图下钻</title>
     <script src="js/jquery-3.5.0.min.js"></script>
     <script src="js/echarts.min.js"></script>
     <script src="js/china.js"></script>
     <script src="js/province/guangdong.js"></script> 
</head>
<body>
    <form id="form1" runat="server">
   <div id="main" style="width: 1000px;height: 800px"></div>
<script type="text/javascript">
    var guangdongData = [];
    function drawMap(darwMapType, data) {
        var option = {
            backgroundColor: '#FFFFFF',
            title: {
                text: '全国地图',
                subtext: '纯属虚构',
                x:'center'
            },
            tooltip : {
                trigger: 'item'
            },
            visualMap: {
                show : false,
                x: 'left',
                y: 'bottom',
                splitList: [
                    { start: 0, end: 10000 }, { start: 10000, end: 20000 },
                    { start: 20000, end: 30000 }, { start: 30000, end: 40000 },
                    { start: 40000, end: 50000 }
                ],
                color: ['#16CC33', '#10FF00', '#16FF33', '#139900', '#13CC00']
            },
            series: [{
                name: '随机数据',
                type: 'map',
                mapType: darwMapType, 
                roam: true,
                label: {
                    normal: {
                        show: false
                    },
                    emphasis: {
                        show: false
                    }
                },
                data:data
            }]
        };
        echarts.dispose(document.getElementById('main'));//先去掉原来的地图
        var myChart = echarts.init(document.getElementById('main'));
        myChart.setOption(option);
        myChart.on("dblclick", function (param) {
            alert(param.name)
            drawMap(param.name, guangdongData);
        });
    }
</script>
 <script type="text/javascript">
     //通过Ajax获取数据
     $.ajax({
         type: "GET",
         async: false, //同步执行
         url: "data/ChineseBank.json",
         dataType: "json", //返回数据形式为json
         success: function (result) {
             if (result) {
                 drawMap('china', result);
             }
         },
         error: function (errorMsg) {
             alert("图表请求数据失败啦!" + errorMsg);
             console.log(errorMsg);
         }
     });
     //通过Ajax获取数据
     $.aja4x({
         type: "GET",
         async: false, //同步执行
         url: "data/GuangdongBank.json",
         dataType: "json", //返回数据形式为json
         success: function (result) {
             if (result) {
                 guangdongData = result
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
