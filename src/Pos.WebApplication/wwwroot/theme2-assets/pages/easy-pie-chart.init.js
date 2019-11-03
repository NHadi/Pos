/**
* Theme: Ubold Admin Template
* Author: Coderthemes
* Easy pie chart
*/

!function($) {
    "use strict";

    var EasyPieChart = function() {};

    EasyPieChart.prototype.init = function() {
    	//initializing various types of easy pie charts
    	$('.easy-pie-chart-1').easyPieChart({
			easing: 'easeOutBounce',
			barColor : '#5d9cec',
			lineWidth: 10,
			animate: 1000,
            scaleColor: false,
            lineCap: 'square',
            trackColor: '#e5e5e5',
			onStep: function(from, to, percent) {
				$(this.el).find('.percent').text(Math.round(percent));
			}
		});
		$('.easy-pie-chart-2').easyPieChart({
			easing: 'easeOutBounce',
			barColor : '#fb6d9d',
			lineWidth: 10,
			trackColor : false,
			lineCap : 'butt',
			onStep: function(from, to, percent) {
				$(this.el).find('.percent').text(Math.round(percent));
			}
		});
		$('.easy-pie-chart-3').easyPieChart({
			easing: 'easeOutBounce',
			barColor : '#34d3eb',
			lineWidth: 10,
			lineCap : 'square',
			scaleColor: "transparent",
			onStep: function(from, to, percent) {
				$(this.el).find('.percent').text(Math.round(percent));
			}
		});
		$('.easy-pie-chart-4').easyPieChart({
			easing: 'easeOutBounce',
			barColor : '#5fbeaa',
			lineWidth: 10,
			onStep: function(from, to, percent) {
				$(this.el).find('.percent').text(Math.round(percent));
			}
		});
    },
    //init
    $.EasyPieChart = new EasyPieChart, $.EasyPieChart.Constructor = EasyPieChart
}(window.jQuery),

//initializing
function($) {
    "use strict";
    $.EasyPieChart.init()
}(window.jQuery);