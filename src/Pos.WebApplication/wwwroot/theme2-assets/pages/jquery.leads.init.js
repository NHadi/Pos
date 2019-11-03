
/**
* Theme: Ubold Admin Template
* Author: Coderthemes
* Leads
*/

!function($) {
    "use strict";

    var LeadsCharts = function() {};

    //creates Stacked chart
    LeadsCharts.prototype.createStackedChart  = function(element, data, xkey, ykeys, labels, lineColors) {
        Morris.Bar({
            element: element,
            data: data,
            xkey: xkey,
            ykeys: ykeys,
            stacked: true,
            labels: labels,
            hideHover: 'auto',
            resize: true, //defaulted to true
            gridLineColor: '#eeeeee',
            barColors: lineColors
        });
    },
    
    LeadsCharts.prototype.init = function() {

        
        //creating Stacked chart
        var $stckedData  = [
            { y: 'Mon', a: 45, b: 180 },
            { y: 'Tue', a: 75,  b: 65 },
            { y: 'Wed', a: 100, b: 90 },
            { y: 'Thur', a: 75,  b: 65 },
            { y: 'Fri', a: 100, b: 90 },
            { y: 'Sat', a: 75,  b: 65 },
            { y: 'Sun', a: 50,  b: 40 }
        ];
        this.createStackedChart('morris-bar-stacked', $stckedData, 'y', ['a', 'b'], ['Series A', 'Series B'], ['#5d9cec', '#ebeff2']);

    },
    //init
    $.LeadsCharts = new LeadsCharts, $.LeadsCharts.Constructor = LeadsCharts
}(window.jQuery),

//initializing 
function($) {
    "use strict";
    $.LeadsCharts.init();
}(window.jQuery);