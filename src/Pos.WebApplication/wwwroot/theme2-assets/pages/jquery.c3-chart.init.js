/**
* Theme: Ubold Dashboard
* Author: Coderthemes
* Chart c3 page
*/

!function($) {
    "use strict";

    var ChartC3 = function() {};

    ChartC3.prototype.init = function () {
        //generating chart 
        c3.generate({
            bindto: '#chart',
            data: {
                columns: [
                    ['data1', 30, 20, 50, 40, 60, 50],
                    ['data2', 200, 130, 90, 240, 130, 220],
                    ['data3', 300, 200, 160, 400, 250, 250]
                ],
                type: 'bar',
                colors: {
                    data1: '#dcdcdc',
                    data2: '#5d9cec',
                    data3: '#5fbeaa'
                }
                
            }
        });

        //combined chart
        c3.generate({
            bindto: '#combine-chart',
            data: {
                columns: [
                    ['data1', 30, 20, 50, 40, 60, 50],
                    ['data2', 200, 130, 90, 240, 130, 220],
                    ['data3', 300, 200, 160, 400, 250, 250],
                    ['data4', 200, 130, 90, 240, 130, 220],
                    ['data5', 130, 120, 150, 140, 160, 150]
                ],
                types: {
                    data1: 'bar',
                    data2: 'bar',
                    data3: 'spline',
                    data4: 'line',
                    data5: 'bar'
                },
                colors: {
                    data1: '#dcdcdc',
                    data2: '#5d9cec',
                    data3: '#36404a',
                    data4: '#fb6d9d',
                    data5: '#5fbeaa'
                },
                groups: [
                    ['data1','data2']
                ]
            },
            axis: {
                x: {
                    type: 'categorized'
                }
            }
        });
        
        //roated chart
        c3.generate({
            bindto: '#roated-chart',
            data: {
                columns: [
                ['data1', 30, 200, 100, 400, 150, 250],
                ['data2', 50, 20, 10, 40, 15, 25]
                ],
                types: {
                data1: 'bar'
                },
                colors: {
	                data1: '#5fbeaa',
	                data2: '#5d9cec'
	            },
            },
            axis: {
                rotated: true,
                x: {
                type: 'categorized'
                }
            }
        });

        //stacked chart
        c3.generate({
            bindto: '#chart-stacked',
            data: {
                columns: [
                    ['data1', 30, 20, 50, 40, 60, 50],
                    ['data2', 200, 130, 90, 240, 130, 220]
                ],
                types: {
                    data1: 'area-spline',
                    data2: 'area-spline'
                    // 'line', 'spline', 'step', 'area', 'area-step' are also available to stack
                },
                colors: {
                    data1: '#5fbeaa',
                    data2: '#5d9cec',
                }
            }
        });
        
        //Donut Chart
        c3.generate({
             bindto: '#donut-chart',
            data: {
                columns: [
                    ['data1', 46],
                    ['data2', 24],
                    ['data3', 30]
                ],
                type : 'donut'
            },
            donut: {
                title: "Dogs love:",
                width: 15,
				label: { 
					show:false
				}
            },
            color: {
            	pattern: ["#f4f8fb", "#5d9cec", "#5fbeaa"]
            }
        });
        
        //Pie Chart
        c3.generate({
             bindto: '#pie-chart',
            data: {
                columns: [
                    ['Lulu', 46],
                    ['Olaf', 24],
                    ['Item 3', 30]
                ],
                type : 'pie'
            },
            color: {
            	pattern: ["#f4f8fb", "#5d9cec", "#5fbeaa"]
            },
            pie: {
		        label: {
		          show: false
		        }
		    }
        });
        
        //Line regions
        c3.generate({
             bindto: '#line-regions',
            data: {
                columns: [
		            ['data1', 30, 200, 100, 400, 150, 250],
		            ['data2', 50, 20, 10, 40, 15, 25]
		        ],
		        regions: {
		            'data1': [{'start':1, 'end':2, 'style':'dashed'},{'start':3}], // currently 'dashed' style only
		            'data2': [{'end':3}]
		        },
		        colors: {
	                data1: '#5d9cec',
	                data2: '#fb6d9d'
	            },
            },
            
        });
        
        
        //Scatter Plot
        c3.generate({
             bindto: '#scatter-plot',
             data: {
		        xs: {
		            setosa: 'setosa_x',
		            versicolor: 'versicolor_x',
		        },
		        // iris data from R
		        columns: [
		            ["setosa_x", 3.5, 3.0, 3.2, 3.1, 3.6, 3.9, 3.4, 3.4, 2.9, 3.1, 3.7, 3.4, 3.0, 3.0, 4.0, 4.4, 3.9, 3.5, 3.8, 3.8, 3.4, 3.7, 3.6, 3.3, 3.4, 3.0, 3.4, 3.5, 3.4, 3.2, 3.1, 3.4, 4.1, 4.2, 3.1, 3.2, 3.5, 3.6, 3.0, 3.4, 3.5, 2.3, 3.2, 3.5, 3.8, 3.0, 3.8, 3.2, 3.7, 3.3],
		            ["versicolor_x", 3.2, 3.2, 3.1, 2.3, 2.8, 2.8, 3.3, 2.4, 2.9, 2.7, 2.0, 3.0, 2.2, 2.9, 2.9, 3.1, 3.0, 2.7, 2.2, 2.5, 3.2, 2.8, 2.5, 2.8, 2.9, 3.0, 2.8, 3.0, 2.9, 2.6, 2.4, 2.4, 2.7, 2.7, 3.0, 3.4, 3.1, 2.3, 3.0, 2.5, 2.6, 3.0, 2.6, 2.3, 2.7, 3.0, 2.9, 2.9, 2.5, 2.8],
		            ["setosa", 0.2, 0.2, 0.2, 0.2, 0.2, 0.4, 0.3, 0.2, 0.2, 0.1, 0.2, 0.2, 0.1, 0.1, 0.2, 0.4, 0.4, 0.3, 0.3, 0.3, 0.2, 0.4, 0.2, 0.5, 0.2, 0.2, 0.4, 0.2, 0.2, 0.2, 0.2, 0.4, 0.1, 0.2, 0.2, 0.2, 0.2, 0.1, 0.2, 0.2, 0.3, 0.3, 0.2, 0.6, 0.4, 0.3, 0.2, 0.2, 0.2, 0.2],
		            ["versicolor", 1.4, 1.5, 1.5, 1.3, 1.5, 1.3, 1.6, 1.0, 1.3, 1.4, 1.0, 1.5, 1.0, 1.4, 1.3, 1.4, 1.5, 1.0, 1.5, 1.1, 1.8, 1.3, 1.5, 1.2, 1.3, 1.4, 1.4, 1.7, 1.5, 1.0, 1.1, 1.0, 1.2, 1.6, 1.5, 1.6, 1.5, 1.3, 1.3, 1.3, 1.2, 1.4, 1.2, 1.0, 1.3, 1.2, 1.3, 1.3, 1.1, 1.3],
		        ],
		        
		        type: 'scatter'
		    },
		    color: {
            	pattern: ["#5d9cec", "#5fbeaa", "#5d9cec", "#5fbeaa"]
            },
		    axis: {
		        x: {
		            label: 'Sepal.Width',
		            tick: {
		                fit: false
		            }
		            
		        },
		        y: {
		            label: 'Petal.Width'
		        }
		    }
            
        });

    },
    $.ChartC3 = new ChartC3, $.ChartC3.Constructor = ChartC3

}(window.jQuery),

//initializing 
function($) {
    "use strict";
    $.ChartC3.init()
}(window.jQuery);



