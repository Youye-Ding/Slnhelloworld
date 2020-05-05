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
    var dataProvince = [
        { name: '江苏', value: 3.41 },
        { name: '上海', value: 5.44 },
        { name: '安徽', value: 1.7 },
        { name: '浙江', value: 5.49 },
        { name: '福建', value: 1.8 },
        { name: '北京', value: 2.81 },
        { name: '山东', value: 1.58 },
        { name: '广东', value: 2.01 },
        { name: '四川', value: 1.89 }
    ];
    var geoCoordMap = {
        '江苏': [119.78333, 32.05000],
        '上海': [121.55333, 31.20000],
        '安徽': [117.283042, 31.86119],
        '浙江': [120.20000, 30.26667],
        '福建': [118.30000, 26.08333],
        '北京': [116.41667, 39.91667],
        '山东': [117.000923, 36.675807],
        '广东': [113.23333, 23.16667],
        '四川': [104.06667, 30.66667]
    };
    var convertData = function (dataProvince) {
        var res = [];
        for (var i = 0; i < dataProvince.length; i++) {
            var geoCoord = geoCoordMap[dataProvince[i].name];
            if (geoCoord) {
                res.push({
                    name: dataProvince[i].name,
                    value: geoCoord.concat(dataProvince[i].value)
                });
            }
        }
        return res;
    };
     var option = {
        backgroundColor: '#404a59',
        title: {
            text: '2019年全国GDP分布及华东师范大学毕业生就业热点地区示意',
            subtext: '地图纯属虚构，港澳台数据暂缺',
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
                {start:0,end:1000},
                    { start: 1000, end: 20000 }, { start: 20000, end: 40000 },
                    { start: 40000, end: 60000 }, { start: 60000, end: 80000 },
                    { start: 80000, end: 120000 }
            ],
            color: ['#FF0000','#FF6600', '#FFFF33','#33FF00','#00FFFF','#9999FF']
         },
        geo: {
                    map: 'china',
                    label: {
                        emphasis: {
                            show: false
                        }
                    },
            roam: true,
            itemStyle: {
                normal: {
                    areaColor: '#323c48',
                    borderColor: '#111'
                },
                emphasis: {
                    areaColor: '#2a333d'
                }
            }
                },
    };
     myChart.setOption(option);
</script>
    <script type="text/javascript">
              //通过Ajax获取数据
        $.get('mapdata/china.json', function (chinaJson) {
                echarts.registerMap('china', chinaJson);
                myChart.setOption({
                    geo: {
                        map: 'china'
                    }
                });
            });
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
                              },
                                  {
                                      name: '就业比例',
                                      type: 'scatter',
                                      coordinateSystem: 'geo',
                                      data: convertData(dataProvince),
                                      symbolSize: function (val) {
                                          return val[2]*10;
                                      },
                                      label: {
                                          normal: {
                                              formatter: '{b}',
                                              position: 'right',
                                              show: false
                                          },
                                          emphasis: {
                                              show: true
                                          }
                                      }
                                      
                                  }
                              ]
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
