//<script type="text/javascript" src="http://cdn.hcharts.cn/jquery/jquery-1.8.3.min.js"></script>
//  <script type="text/javascript" src="http://cdn.hcharts.cn/highcharts/highcharts.js"></script>
//  <script type="text/javascript" src="http://cdn.hcharts.cn/highcharts/exporting.js"></script>
//  <script type="text/javascript" src="http://cdn.hcharts.cn/highcharts/highcharts-3d.js"></script>

define(['plugins/http', 'durandal/app', 'knockout', 'layer', 'datatimepicker', '/lib/highcharts/highcharts.js'],
    function (http, app, ko, layer, datatimepicker, highcharts) {
        return {
            activate: function() {
                // Create the chart
              

                $("#container").load("http://www.hcharts.cn/demo/index.php?p=99");
            }
        }
    
});