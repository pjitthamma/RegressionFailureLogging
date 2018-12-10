var ajax_init = function(params) {

};

var ajax_updateReport = function(report, callback) {
    ajax_execute({
        url: '/Home/UpdateReport',
        requestObject: { 'data': report },
        responseType: 'text',
        callback: callback
    });
};

var ajax_fetchReport = function(criteria, callback) {
    ajax_execute({
        url: '/Home/FetchReport',
        requestObject: { 'criteria': criteria },
        responseType: 'JSON',
        callback: callback
    });
};

var ajax_execute = function(params) {
    $.ajax({
        type: "POST",
        url: params.url,
        contentType: 'application/json; charset=utf-8',
        data: JSON.stringify(params.requestObject),
        dataType: params.responseType,
        success: function (result) { params.callback(result); },
        error: function (xhr, status, error) {
            console.error(status);
            console.error(error);
        }
    });
};