<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BoxPlot.aspx.cs" Inherits="FinalEssay.BoxPlot" %>

<!DOCTYPE html>

<html>

	<head>
		<meta charset="utf-8">
		<title>ECharts</title>
		<!-- 引入 echarts.js -->
		<script src="js/echarts.min.js"></script>
        <script src="js/jquery-3.5.0.min.js"></script>
		<script src="http://echarts.baidu.com/gallery/vendors/echarts/extension/dataTool.min.js"></script>
	</head>

	<body>
		<!-- 为ECharts准备一个具备大小（宽高）的Dom -->
		<div id="main" style="width: 1000px;height:800px;"></div>
		<script type="text/javascript">
			// 基于准备好的dom，初始化echarts实例
			var myChart = echarts.init(document.getElementById('main'));
			var option;
            var Data = [];
			// Generate data.
            $.ajax({
                type: "GET",
                async: false, //同步执行
                url: "data/BoxPlot.json",
                dataType: "json", //返回数据形式为json
                success: function (result) {
                    Data = result; 
                },
                error: function (errorMsg) {
                    alert("图表请求数据失败啦!" + errorMsg);
                    console.log(errorMsg);
                }
            });
            var data = echarts.dataTool.prepareBoxplotData(Data);
            var option = {
                title: [
                    {
                        text: '期末考试成绩分布盒须图',
                        left: 'center',
                    },
                    {
                        text: 'upper: Q3 + 1.5 * IQR \nlower: Q1 - 1.5 * IQR',
                        borderColor: '#999',
                        borderWidth: 1,
                        textStyle: {
                            fontSize: 14
                        },
                        left: '10%',
                        top: '90%'
                    }
                ],
                tooltip: {
                    trigger: 'item',
                    axisPointer: {
                        type: 'shadow'
                    }
                },
                grid: {
                    left: '10%',
                    right: '10%',
                    bottom: '15%'
                },
                xAxis: {
                    type: 'category',
                    data: data.axisData,
                    boundaryGap: true,
                    nameGap: 30,
                    splitArea: {
                        show: false
                    },
                    axisLabel: {
                        formatter: 'expr {value}'
                    },
                    splitLine: {
                        show: false
                    }
                },
                yAxis: {
                    type: 'value',
                    splitArea: {
                        show: true
                    }
                },
                series: [
                    {
                        name: 'boxplot',
                        type: 'boxplot',
                        data: data.boxData,
                        tooltip: {
                            formatter: function (param) {
                                return [
                                    'upper: ' + param.data[5],
                                    'Q3: ' + param.data[4],
                                    'median: ' + param.data[3],
                                    'Q1: ' + param.data[2],
                                    'lower: ' + param.data[1]
                                ].join('<br/>');
                            }
                        }
                    },
                    {
                        name: 'outlier',
                        type: 'scatter',
                        data: data.outliers
                    }
                ]
            };
            myChart.setOption(option);

		</script>
        


 
	</body>

</html>

