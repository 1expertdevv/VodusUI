var startDate, endDate;

// Custom filtering function which will search data in column four between two values
$.fn.dataTable.ext.search.push(
    function (settings, data, dataIndex) {
        var start = startDate.val();
        var end = endDate.val();
        var date = new Date(data[4]);

        if (
            (start === null && end === null) ||
            (start === null && date <= end) ||
            (start <= date && end === null) ||
            (start <= date && date <= end)
        ) {
            return true;
        }
        return false;
    }
);

$(document).ready(function () {
    // Create date inputs
    startDate = new DateTime($('#startDate'), {
        format: 'MMMM Do YYYY'
    });
    endDate = new DateTime($('#endDate'), {
        format: 'MMMM Do YYYY'
    });

    // DataTables initialisation
    var table = $('#tblLocations').DataTable();

    // Refilter the table
    $('#startDate, #endDate').on('change', function () {

        let sdate = $('#startDate').val();
        let edate = $('#endDate').val();
        if (sdate == '' && edate == '') {
            alert("cls");
            window.location.reload();
        }
        alert("ok");
        table.draw();
    });

    $("#tblLocations").sortable({
        items: 'tr:not(tr:first-child)',
        cursor: 'pointer',
        axis: 'y',
        dropOnEmpty: false,
        start: function (e, ui) {
            ui.item.addClass("selected");
        },
        stop: function (e, ui) {
            ui.item.removeClass("selected");
            //$(this).find("tr").each(function (index) {
            //    if (index > 0) {
            //        $(this).find("td").eq(2).html(index);
            //    }
            //});
        }
    });
});