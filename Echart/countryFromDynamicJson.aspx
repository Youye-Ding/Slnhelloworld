<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="countryFromDynamicJson.aspx.cs" Inherits="Echarts.countryFromDynamicJson" %>

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
   <div id="main" style="width: 800px;height: 600px"></div>
<script type="text/javascript">
    var myChart = echarts.init(document.getElementById('main'));
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
        }
    };
     myChart.setOption(option);
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
                          myChart.setOption({
                              series: [{
                                  name: '随机数据',
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
