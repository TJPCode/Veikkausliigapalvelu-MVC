$(document).ready(function () {
    $("#startDate").datepicker({
        defaultDate: "1.4.2015", // Default date changed to help testing.
        minDate: "-2y",
        numberOfMonths: 1,
        dateFormat: "dd.mm.yy",
        onSelect: function (selected) {
            // Prevent selecting later day than in endDate.
            $("#endDate").datepicker("option", "minDate", selected)
            checkDates();
        }
    });
    $("#endDate").datepicker({
        defaultDate: "1.11.2015", // Default date changed to help testing.
        minDate: "-2y",
        numberOfMonths: 1,
        dateFormat: "dd.mm.yy",
        onSelect: function (selected) {
            // Prevent selecting earlier day than in startDate.
            $("#startDate").datepicker("option", "maxDate", selected)
            checkDates();
        }
    });
    $("#button").attr("disabled", "disabled");

    // Check start date and end date has day selected. Then enable button.
    function checkDates() {
        var sDate = $("#startDate").datepicker("getDate");
        var eDate = $("#endDate").datepicker("getDate");
        if (sDate == null || eDate == null) {
            $("#button").attr("disabled", "disabled");
        }
        else {
            $("#button").removeAttr("disabled");
        }
    }
});