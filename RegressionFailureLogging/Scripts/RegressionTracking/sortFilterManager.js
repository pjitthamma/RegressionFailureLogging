// https://github.com/koalyptus/TableFilter/

    var filtersConfig = {
        base_path: 'tablefilter/',
        col_3: 'select',
        col_6: 'none',
        col_7: 'none',
        col_8: 'none',
        alternate_rows: true,
        //rows_counter: true,
        //btn_reset: true,
        //loader: true,
        //status_bar: true,
        no_results_message: true,
        mark_active_columns: true,
        //highlight_keywords: true,
        clear_filter_text: 'Please select...',
        col_types: [
            'string', 'string', 'string',
            'string', 'string'
        ],
        custom_options: {
            cols: [3],
            texts: [[
              'Script bug',
            ]],
            values: [[
              'Script bug',
            ]],
            sorts: [false]
        },
        extensions:[{ name: 'sort' }]
    };


// var tf = new TableFilter('regression-table', filtersConfig);
//tf.init();



var sortFilter_init = function () {
    new TableFilter('regression-table', filtersConfig).init();
};