<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HW2-GDPAndTargetProvince.aspx.cs" Inherits="Echart.HW2_GDPandTargetProvince" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>C#动态生成JSON数据国家图</title>
     <script src="js/jquery-3.5.0.min.js"></script>
     <script src="js/echarts.min.js"></script>
     <script src="js/china.js"></script>
</head>
<body>
    <form id="form1" runat="server">
   <div id="main" style="width: 100%;height: 1000px"></div>
<script type="text/javascript">
    var myChart = echarts.init(document.getElementById('main'));
     var option = {
        backgroundColor: '#404a59',
        title: {
            text: '2019年全国GDP分布及华东师范大学毕业生就业热点地区示意',
            subtext:'地图纯属虚构，港澳台数据暂缺',
            left: 'center',
            textStyle: {
                color: '#fff'
            }
        },
        tooltip : {
            trigger: 'item'
         },

        visualMap: {
            show : false,
            x: 'left',
            y: 'bottom',
            splitList: [
                    { start: 0, end: 20000 }, { start: 20000, end: 40000 },
                    { start: 40000, end: 60000 }, { start: 60000, end: 80000 },
                    { start: 80000, end: 120000 }
            ],
            color: ['#FF0000','#FF6600', '#FFFF33','#33FF00','#00FFFF']
        }
    };
     myChart.setOption(option);
</script>
    <script type="text/javascript">
              //通过Ajax获取数据
              $.ajax({
                  type: "GET",
                  async: false, //同步执行
                  url: "data/GlobalGDP.json",
                  dataType: "json", //返回数据形式为json
                  success: function (result) {
                      if (result) {
                          myChart.setOption({
                              series: [{
                                  name: 'GDP（单位：万元）',
                                  type: 'map',
                                  mapType: 'china',
                                  roam: true,
                                  label: {
                                      normal: {
                                          show: false
                                      },
                                      emphasis: {
                                          show: false
                                      }
                                  },
                                  data: result
                              }]
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
