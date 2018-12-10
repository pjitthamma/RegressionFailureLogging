$(document).ready(function () {
    var pageName = $("#pagename").attr("value");

    if (pageName == "index") {
        InitializeIndexJS();
    } else if (pageName == "index2") {
        InitializeIndex2JS();
    }
});

var InitializeIndexJS = function () {
    view_init();
    list_init();
    sortFilter_init();
};

var InitializeIndex2JS = function () {
    view_init();
    chart_init();
};