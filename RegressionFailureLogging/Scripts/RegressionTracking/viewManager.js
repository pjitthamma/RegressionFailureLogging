var view_settings = {
    CALENDAR: "#calendar-filtering",
    SAVE_BUTTON: "#save-button",
    SEARCH_BUTTON: "#search-button",
    STATUS_LABEL: "#status-label div",
    LOADING_LABEL: "#status-label img",
    REGRESSION_RECORDS: ".regression-table__record",
    CATEGORY_CONTAINER: ".btn-group",
    CATEGORY_BUTTON: ".dropdown-button",
    CATEGORY_COMMENT: ".regression-table__comment",
    CATEGORY_ITEM: ".dropdown-item",
    LOGMESSAGE_COLUMN: ".regression-table__msg",
    TOGGLE_LOG_BUTTON: ".toggle-logmsg-btn",
    TOGGLE_DETAIL_BUTTON: ".toggle-detail-btn",
    OVERFLOW_LOGMESSAGE: ".of-msg"
};
    
var view_init = function () {
    view_binding();
    view_calendar_init();
};

var view_binding = function() {
    $(view_settings.SAVE_BUTTON).off('click').on('click', view_saveReport);
    $(view_settings.SEARCH_BUTTON).off('click').on('click', view_search);
    $(view_settings.CATEGORY_ITEM).off('click').on('click', view_updateCategoryColumn);
    $(view_settings.TOGGLE_LOG_BUTTON + ", " + view_settings.TOGGLE_DETAIL_BUTTON).off('click').on('click', view_toggleLogMessage);
};

// reference : https://github.com/uxsolutions/bootstrap-datepicker
var view_calendar_init = function () {
    $(view_settings.CALENDAR).datepicker({
        autoclose: true,
        format: "dd/mm/yyyy",
        todayHighlight: true
    });
};

// Get all 'Category' value from table, and send to severside
var view_saveReport = function () {
    view_updateStatus();

    var recordList = [];
    $.each($(view_settings.REGRESSION_RECORDS), function (i, record) {

        var category = $(record).find(view_settings.CATEGORY_BUTTON).text();
        var comment = $(record).find(view_settings.CATEGORY_COMMENT).val();

        if (category || comment) {
            recordList.push({
                RecordId: parseInt($(record).attr("data-id")),
                Category: category,
                Comment: comment
            });
        }
    });

    ajax_updateReport(recordList, view_updateStatus);
};

var view_updateStatus = function (text) {
    $(view_settings.LOADING_LABEL).toggleClass("hide");

    if (text) {
        $(view_settings.STATUS_LABEL).removeClass("hide");
        $(view_settings.STATUS_LABEL).text(text);
        setTimeout(function () {
            $(view_settings.STATUS_LABEL).addClass("hide");
        }, 2000);
    }
};

// Set text after select category items
var view_updateCategoryColumn = function() {
    var thisItem = $(this);
    var categoryValue = thisItem.text();

    thisItem.
        parents(view_settings.CATEGORY_CONTAINER).
        find(view_settings.CATEGORY_BUTTON).
        text(categoryValue);
};

// Show / Hide overflow message
var view_toggleLogMessage = function(e) {
    var toggleButton = $(this);
    var overflowMessage = toggleButton.parent().find(view_settings.OVERFLOW_LOGMESSAGE);

    if (overflowMessage.hasClass("hide")) {
        toggleButton.text("show less");
        overflowMessage.removeClass("hide");
    } else {
        toggleButton.text("show more");
        overflowMessage.addClass("hide");
    }

    e.preventDefault();
    e.stopPropagation();
};

// Search report for specific criteria (date, etc.)
var view_search = function () {
    // notify
    view_updateStatus();

    // handle
    var date = $(view_settings.CALENDAR).datepicker('getDates');
    if (date == null || date == undefined || date.length < 1) {
        console.log('JS cannot get date');
        return;
    }

    // fetch data
    ajax_fetchReport(
    {
        Date: date[0].getDate(),
        Month: date[0].getMonth() + 1,
        Year: date[0].getFullYear(),
    }, list_update);
};