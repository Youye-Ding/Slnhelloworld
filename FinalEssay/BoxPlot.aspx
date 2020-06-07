<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BoxPlot.aspx.cs" Inherits="FinalEssay.BoxPlot" %>

<!DOCTYPE html>

<html>

	<head>
		<meta charset="utf-8">
		<title>ECharts</title>
		<script src="js/echarts.min.js"></script>
        <script src="js/jquery-3.5.0.min.js"></script>
		<script src="js/dataTool.min.js"></script>
	</head>

	<body>
		<div id="main" style="width: 1000px;height:800px;"></div>
		<script type="text/javascript">
			var myChart = echarts.init(document.getElementById('main'));
			var option;
            var Data = [];
            $.ajax({
                type: "GET",
                async: false, 
                url: "data/BoxPlot.json",
                dataType: "json", 
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
                    data: ['江苏省通州高级中学','江苏省西亭中学','平潮中学','金沙中学','三余中学'],
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

