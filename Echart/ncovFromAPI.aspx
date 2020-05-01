<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ncovFromAPI.aspx.cs" Inherits="Echarts.ncovFromAPI" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>全国疫情地图</title>
     <script src="js/jquery-3.5.0.min.js"></script>
     <script src="js/echarts.min.js"></script>
     <script src="js/china.js"></script>
</head>
<body>
    <form id="form1" runat="server">
   <div id="main" style="width: 1000px;height: 800px"></div>
<script type="text/javascript">
    var myChart = echarts.init(document.getElementById('main'));
    var option = {
        backgroundColor: '#FFFFFF',
        title: {
            text: '全国疫情地图',
            subtext: '数据来自腾讯',
            x:'center'
        },
        tooltip : {
            trigger: 'item'
        },
        visualMap: {
            type: 'piecewise',
            pieces: [
              { min: 10000, max: 1000000, label: '大于等于10000人', color: '#372a28' },
              { min: 5000, max: 10000, label: '确诊5000-9999人', color: '#4e160f' },
              { min: 1000, max: 5000, label: '确诊1000-4999人', color: '#974236' },
              { min: 100, max: 1000, label: '确诊100-999人', color: '#ee7263' },
              { min: 1, max: 99, label: '确诊1-99人', color: '#f5bba7' },
            ]
        },
        toolbox: {
            show: true,
            orient: 'vertical',
            left: 'right',
            top: 'center',
            feature: {
                mark: { show: true },
                dataView: { show: true, readOnly: false },
                restore: { show: true },
                saveAsImage: { show: true }
            }
        },
        roamController: {
            show: true,
            left: 'right',
            mapTypeControl: {
                'china': true
            }
        },
        series: [{
            name: '总确诊人数',
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
            }
        }]
    };
    myChart.setOption(option);
</script>
    <script type="text/javascript">
                 //通过Ajax获取数据
                 $.ajax({
                     type: "GET",
                     async: false, //同步执行
                     url: "data/ncovData<%=datestr%>.json",
                     dataType: "json", //返回数据形式为json
                     success: function (result) {
                         if (result) {
                             myChart.setOption({
                                 series: {
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
