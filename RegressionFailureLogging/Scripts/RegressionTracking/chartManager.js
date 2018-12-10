// chartjs.org
var charts = {};

var chart_init = function () {
    chart1_setup();
};

var chart1_setup = function () {
    var testChart = $("#testChart");
    charts.chartOne = new Chart(testChart, {
        type: 'line',
        data: {
            labels: ["Red", "Blue", "Yellow", "Green", "Purple", "Orange"],
            datasets: [{
                label: '# of Votes',
                data: [12, 19, 3, 5, 2, 3]
            }]
        }
    });
};