<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BarScore.aspx.cs" Inherits="FinalEssay.BarScore" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
		<meta charset="utf-8">
		<title>ECharts</title>
		<script src="js/echarts.min.js"></script>
        <script src="js/jquery-3.5.0.min.js"></script>
		<script src="js/dataTool.min.js"></script>
	</head>
<body>
    <form id="form1" runat="server">
        <div id="main" style="width: 1000px;height:800px;"></div>
		<script type="text/javascript">
            var myChart = echarts.init(document.getElementById('main'));
            var option = {
                title: {
                    text: '各科考试情况分析'
                },
                legend: {},
                tooltip: {},
                dataset: {
                    source: []
                },
                xAxis: {
                    type: 'category',
                },
                yAxis: {
                    max:1
                },
                series: [
                    { type: 'bar' },
                    { type: 'bar' }
                ]
            };
            myChart.setOption(option);
             $.ajax({
                type: "GET",
                async: false, 
                url: "data/BarScore.json",
                dataType: "json", 
                success: function (result) {
                    myChart.setOption({
                        dataset: {
                            source: result
                        }
                    });
                 }

                
            });
        </script>
    </form>
</body>
</html>
