var list_settings = {
    REPORT_RECORD_TEMPLATE: '#report-record-template',
    REPORT_RECORD_LOCATION: '#regression-table-location',
    COMPILED_TEMPLATE: null
};

var list_init = function (params) {
    // compiled template
    list_settings.COMPILED_TEMPLATE = Handlebars.compile($(list_settings.REPORT_RECORD_TEMPLATE).html());
};

// Render 
var list_update = function (reportList) {

    // Build List
    var newList = "<h3 class='regression-table__noresult' style='text-align: center;'>No record for regression failure with this specific date</h3>";
    if (reportList && reportList.length > 0)
    {
        newList = list_settings.COMPILED_TEMPLATE({ reportList: reportList });
    }

    // render
    view_updateStatus("search done");
    $(list_settings.REPORT_RECORD_LOCATION).html(newList);

    // rebinding
    view_binding();
    sortFilter_init();
};