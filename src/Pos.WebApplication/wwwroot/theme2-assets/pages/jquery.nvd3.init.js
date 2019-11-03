/**
* Theme: Ubold Admin
* Author: Coderthemes
* Chart Nvd3 page
*/


(function($) {
    'use strict';

    function sinAndCos() {
        var sin = [],
            sin2 = [],
            cos = [];
        for (var i = 0; i < 100; i++) {
            sin.push({
                x: i,
                y: Math.sin(i / 9)
            });
            sin2.push({
                x: i,
                y: Math.sin(i / 10) * 0.25 + 0.5
            });
            cos.push({
                x: i,
                y: 0.5 * Math.cos(i / 10)
            });
        }
        return [{
            values: sin,
            key: 'Sine Wave',
            color: "#5d9cec"
        }, {
            values: cos,
            key: 'Cosine Wave',
            color: "#fb6d9d"
        }, {
            values: sin2,
            key: 'Custom sine',
            color: "#34d3eb"
        }];
    }
    nv.addGraph(function() {
        var lineChart = nv.models.lineChart();
        var height = 300;
        lineChart.useInteractiveGuideline(true);
        lineChart.xAxis.tickFormat(d3.format(',r'));
        lineChart.yAxis.axisLabel('Voltage (v)').tickFormat(d3.format(',.2f'));
        d3.select('.line-chart svg').attr('perserveAspectRatio', 'xMinYMid').datum(sinAndCos()).transition().duration(500).call(lineChart);
        nv.utils.windowResize(lineChart.update);
        return lineChart;
    });
    
    var historicalBarChart = [{
        key: 'Cumulative Return',
        values: [{
            'label': 'A Label',
            'value': -29.765957771107,
            'color': '#5fbeaa'
        }, {
            'label': 'B Label',
            'value': 50,
            'color': '#f05050'
        }, {
            'label': 'C Label',
            'value': 32.807804682612,
            'color': '#5d9cec'
        }, {
            'label': 'D Label',
            'value': 196.45946739256,
            'color': '#ffbd4a'
        }, {
            'label': 'E Label',
            'value': 15.79434030906893,
            'color': '#81c868'
        }, {
            'label': 'F Label',
            'value': -98.079782601442,
            'color': '#dcdcdc'
        }, {
            'label': 'G Label',
            'value': -13.925743130903,
            'color': '#7266ba'
        }, {
            'label': 'H Label',
            'value': -5.1387322875705,
            'color': '#fb6d9d'
        }]
    }];
    nv.addGraph(function() {
        var barChart = nv.models.discreteBarChart().x(function(d) {
            return d.label;
        }).y(function(d) {
            return d.value;
        }).staggerLabels(true).tooltips(false).showValues(true).duration(250);
        barChart.yAxis.axisLabel('Price change in USD');
        d3.select('.bar-chart svg').datum(historicalBarChart).call(barChart);
        nv.utils.windowResize(barChart.update);
        return barChart;
    });
    var i, j;
    nv.utils.symbolMap.set('thin-x', function(size) {
        size = Math.sqrt(size);
        return 'M' + (-size / 2) + ',' + (-size / 2) + 'l' + size + ',' + size + 'm0,' + -(size) + 'l' + (-size) + ',' + size;
    });
    var scatterChart;
    var colors = ['#5fbeaa', '#fb6d9d','#7266ba', '#ffbd4a','#81c868', '#dcdcdc','#555555	', '#fb6d9d','#98a6ad', '#5d9cec'];
    //d3.scale.category10().range()
    nv.addGraph(function() {
        scatterChart = nv.models.scatterChart().useVoronoi(true).color(colors).duration(300);
        scatterChart.xAxis.tickFormat(d3.format('.02f'));
        scatterChart.yAxis.axisLabel('Population dynamics').tickFormat(d3.format('.02f'));
        scatterChart.tooltipContent(function(obj) {
            return '<p>' + obj.series[0].key + '</p>';
        });
        d3.select('.scatter-chart svg').datum(randomData(4, 40)).call(scatterChart);
        nv.utils.windowResize(scatterChart.update);
        scatterChart.dispatch.on('stateChange', function(e) {
            ('New State:', JSON.stringify(e));
        });
        return scatterChart;
    });

    function randomData(groups, points) {
        var data = [],
            shapes = ['thin-x', 'circle', 'cross', 'triangle-up', 'triangle-down', 'diamond', 'square'],
            random = d3.random.normal();
        for (i = 0; i < groups; i++) {
            data.push({
                key: 'Group ' + i,
                values: []
            });
            for (j = 0; j < points; j++) {
                data[i].values.push({
                    x: random(),
                    y: random(),
                    size: Math.round(Math.random() * 100) / 100,
                    shape: shapes[j % shapes.length]
                });
            }
        }
        return data;
    }
    var long_short_data = [{
        'key': 'Series 1',
        'color': "#5d9cec",
        'values': [{
            'label': 'Group A',
            'value': -1.8746444827653
        }, {
            'label': 'Group B',
            'value': -8.0961543492239
        }, {
            'label': 'Group C',
            'value': -0.57072943117674
        }, {
            'label': 'Group D',
            'value': -2.4174010336624
        }, {
            'label': 'Group E',
            'value': -0.72009071426284
        }, {
            'label': 'Group F',
            'value': -0.77154485523777
        }, {
            'label': 'Group G',
            'value': -0.90152097798131
        }, {
            'label': 'Group H',
            'value': -0.91445417330854
        }, {
            'label': 'Group I',
            'value': -0.055746319141851
        }]
    }, {
        'key': 'Series 2',
        'color': "#34d3eb",
        'values': [{
            'label': 'Group A',
            'value': 25.307646510375
        }, {
            'label': 'Group B',
            'value': 16.756779544553
        }, {
            'label': 'Group C',
            'value': 18.451534877007
        }, {
            'label': 'Group D',
            'value': 8.6142352811805
        }, {
            'label': 'Group E',
            'value': 7.8082472075876
        }, {
            'label': 'Group F',
            'value': 5.259101026956
        }, {
            'label': 'Group G',
            'value': 0.30947953487127
        }, {
            'label': 'Group H',
            'value': 0
        }, {
            'label': 'Group I',
            'value': 0
        }]
    }];
    var multiChart;
    nv.addGraph(function() {
        multiChart = nv.models.multiBarHorizontalChart().x(function(d) {
            return d.label;
        }).y(function(d) {
            return d.value;
        }).duration(250);
        multiChart.yAxis.tickFormat(d3.format(',.2f'));
        d3.select('.multi-chart svg').datum(long_short_data).call(multiChart);
        nv.utils.windowResize(multiChart.update);
        return multiChart;
    });
    
    
    //Regular pie chart example
	nv.addGraph(function() {
	  var chart = nv.models.pieChart()
	      .x(function(d) { return d.label })
	      .y(function(d) { return d.value })
	      .showLabels(true);
	
	    d3.select("#chart1 svg")
	        .datum(exampleData)
	      	.transition().duration(1200)
	        .call(chart);
	
	  return chart;
	});
	
	//Donut chart example
	nv.addGraph(function() {
	  var chart = nv.models.pieChart()
	      .x(function(d) { return d.label })
	      .y(function(d) { return d.value })
	      .showLabels(true)     //Display pie labels
	      .labelThreshold(.05)  //Configure the minimum slice size for labels to show up
	      .labelType("percent") //Configure what type of data to show in the label. Can be "key", "value" or "percent"
	      .donut(true)          //Turn on Donut mode. Makes pie chart look tasty!
	      .donutRatio(0.35)     //Configure how big you want the donut hole size to be.
	      ;
	
	    d3.select("#chart2 svg")
	        .datum(exampleData())
	        .transition().duration(350)
	        .call(chart);
	
	  return chart;
	});
	
	//Pie chart example data. Note how there is only a single array of key-value pairs.
	function exampleData() {
	  return  [
	      { 
	        "label": "One",
	        "value" : 29.765957771107,
	        "color" : "#5fbeaa"
	      } , 
	      { 
	        "label": "Two",
	        "value" : 60,
	        'color': '#f05050'
	      } , 
	      { 
	        "label": "Three",
	        "value" : 39.69895,
	        'color': '#5d9cec'
	      } , 
	      { 
	        "label": "Four",
	        "value" : 160.45946739256,
	        'color': '#ffbd4a'
	      } , 
	      { 
	        "label": "Five",
	        "value" : 89.02525,
	        'color': '#81c868'
	      } , 
	      { 
	        "label": "Six",
	        "value" : 98.079782601442,
	        'color': '#7266ba'
	      } , 
	      { 
	        "label": "Seven",
	        "value" : 98.925743130903,
	        'color': '#fb6d9d'
	      } 
	      
	    ];
	}
})(jQuery);