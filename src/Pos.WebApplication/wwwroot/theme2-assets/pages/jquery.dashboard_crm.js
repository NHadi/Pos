
/**
* Theme: Ubold Admin Template
* Author: Coderthemes
* Morris Chart
*/

!function($) {
    "use strict";

    var DashboardCRM = function() {
    	this.$realData = []
    };
    
     //creates line chart
    DashboardCRM.prototype.createLineChart = function(element, data, xkey, ykeys, labels, opacity, Pfillcolor, Pstockcolor, lineColors) {
        Morris.Line({
          element: element,
          data: data,
          xkey: xkey,
          ykeys: ykeys,
          labels: labels,
          fillOpacity: opacity,
          pointFillColors: Pfillcolor,
          pointStrokeColors: Pstockcolor,
          behaveLikeLine: true,
          gridLineColor: '#eef0f2',
          hideHover: 'auto',
          resize: true, //defaulted to true
          lineColors: lineColors
        });
    },
    
    //creates Bar chart
    DashboardCRM.prototype.createBarChart  = function(element, data, xkey, ykeys, labels, lineColors) {
        Morris.Bar({
            element: element,
            data: data,
            xkey: xkey,
            ykeys: ykeys,
            labels: labels,
            hideHover: 'auto',
            resize: true, //defaulted to true
            gridLineColor: '#eeeeee',
            barColors: lineColors
        });
    },
    
    //creates Donut chart
    DashboardCRM.prototype.createDonutChart = function(element, data, colors) {
        Morris.Donut({
            element: element,
            data: data,
            resize: true, //defaulted to true
            colors: colors
        });
    },
    
    DashboardCRM.prototype.init = function() {

        //create line chart
        var $data  = [
            {y: '2007', a: 0, b: 0, c:0},
            {y: '2008', a: 150, b: 45, c:15},
            {y: '2009', a: 60, b: 150, c:195},
            {y: '2010', a: 180, b: 36, c:21},
            {y: '2011', a: 90, b: 60, c:360},
            {y: '2012', a: 75, b: 240, c:120},
            {y: '2013', a: 30, b: 30, c:30}
          ];
        this.createLineChart('morris-line-chart', $data, 'y', ['a', 'b', 'c'], ['Deal-Won ', 'Deal-Lost', 'Deal-Pending'],['0.1'],['#ffffff'],['#999999'], ['#2bbbad','#ef4554','#ff8800']);
        
        //creating bar chart
        var $barData  = [
            { y: '2009', a: 100, b: 90 },
            { y: '2010', a: 75,  b: 65 },
            { y: '2011', a: 50,  b: 40 },
            { y: '2012', a: 75,  b: 65 },
            { y: '2013', a: 50,  b: 40 },
            { y: '2014', a: 75,  b: 65 },
            { y: '2015', a: 100, b: 90}
        ];
        this.createBarChart('morris-bar-chart', $barData, 'y', ['a', 'b'], ['Won Deals ', 'Lost Deals '], ['#2bbbad', '#4285f4']);
        
        //creating donut chart
        var $donutData = [
                {label: "Group 1", value: 12},
                {label: "Group 2", value: 30},
                {label: "Group 3", value: 20}
            ];
        this.createDonutChart('morris-donut-example', $donutData, ['#ebeff2', '#2bbbad', '#4285f4']);

    },
    //init
    $.DashboardCRM = new DashboardCRM, $.DashboardCRM.Constructor = DashboardCRM
}(window.jQuery),

//initializing 
function($) {
    "use strict";
    $.DashboardCRM.init();
}(window.jQuery);