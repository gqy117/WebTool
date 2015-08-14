(function () {
    "use strict";

    window.myDataTable = {
        fcmcAddRows: function fcmcAddRows(obj, numberColumns, targetRows) {
            var tableRows = obj.find('tbody tr'); // grab the existing data rows
            var numberNeeded = targetRows - tableRows.length; // how many blank rows are needed to fill up to targetRows
            var lastRow = tableRows.last(); // cache the last data row
            var lastRowCells = lastRow.children('td'); // how many visible columns are there?
            var cellString;
            var highlightColumn;
            var rowClass;

            // The first row to be added actually ends up being the last row of the table.
            // Check to see if it should be odd or even.
            if (targetRows % 2) {
                rowClass = "odd";
            } else {
                rowClass = "even"; //
            }

            // We only sort on 1 column, so let's find it based on its classname
            lastRowCells.each(function (index) {
                if ($(this).hasClass('sorting_1')) {
                    highlightColumn = index;
                }
            });

            /* Iterate through the number of blank rows needed, building a string that will
             * be used for the HTML of each row. Another iterator inside creates the desired
             * number of columns, adding the sorting class to the appropriate TD.
             */
            for (var i = 0; i < numberNeeded; i++) {
                cellString = "";
                for (var j = 0; j < numberColumns; j++) {
                    if (j === highlightColumn) {
                        cellString += '<td class="sorting_1">&nbsp;</td>';
                    } else {
                        cellString += '<td>&nbsp;</td>';
                    }
                }

                // Add the TR and its contents to the DOM, then toggle the even/odd class
                // in preparation for the next.
                lastRow.after('<tr class="' + rowClass + '">' + cellString + '</tr>');
                rowClass = (rowClass === "even") ? "odd" : "even";
            }
        },
        createTable: function CreateTable(tableName, sAjaxSource, isProcessing) {
            var context = this;

            if (!isProcessing) {
                isProcessing = false;
            }
            var sProcessing = "<div class='modal-backdrop fade in' style='z-index: 10049;'></div>";
            sProcessing += "<div class='modal-scrollable' style='z-index: 10050;'>";
            sProcessing += "<div class='loading-spinner fade in' style='width: 200px; margin-left: -100px; z-index: 10050;'>";
            sProcessing += "<img src='/Content/assets/img/ajax-modal-loading.gif' align='middle'>&nbsp;";
            sProcessing += "<span style='font-weight:300; color: #eee; font-size: 18px; font-family:Open Sans;'>&nbsp;" + window.UIResource.Loading + "...</span>";
            sProcessing += "</div>";
            sProcessing += "</div>";

            var myTable = $(tableName).dataTable({
                "sDom": "<'row-fluid'<'span6'l><'span6'f>r>t<'row-fluid'<'span6'i><'span6'p>>",
                "sPaginationType": "bootstrap",
                "oLanguage": {
                    "sLengthMenu": "_MENU_" + window.window.UIResource.RecordsPerPage,//" records per page",
                    "oPaginate": {
                        "sPrevious": window.UIResource.Prev,
                        "sNext": window.UIResource.Next
                    },
                    "sProcessing": sProcessing,
                    "sSearch": window.UIResource.Search + ":",
                },
                /*"aoColumnDefs": [{
                    'bSortable': false,
                    'aTargets': [-1]
                }],*/
                bProcessing: isProcessing,
                "bLengthChange": false,
                "aoColumnDefs": [{ "bVisible": false, "aTargets": [0] }],
                "bServerSide": true,
                "bFilter": true,
                'sAjaxSource': sAjaxSource,
                "fnInfoCallback": function (oSettings, iStart, iEnd, iMax, iTotal) {
                    //ShowLoading();
                    return window.UIResource.Showing + " " + iStart + " " + window.UIResource.to + " " + iEnd + " " + window.UIResource.Paging_of + " " + iTotal + " " + window.UIResource.record;
                },
                "fnPreDrawCallback": function () {
                    // gather info to compose a message
                    return true;
                },
                "fnDrawCallback": function (oSettings) {
                    // in case your overlay needs to be put away automatically you can put it here
                    var columns_in_row = $(this).children('thead').children('tr').children('th').length;
                    var show_num = oSettings._iDisplayLength;
                    context.fcmcAddRows(this, columns_in_row, show_num);

                    //ToolTip
                    $(tableName + ' tbody tr td').each(function () {
                        this.setAttribute('title', $(this).text());
                    });
                },

                /*"aoColumns": [
                    { "sName": "WOLName" },
                    { "sName": "HostName" },
                    { "sName": "MACAddress" },
                    { "sName": "SubnetMask" },
                     { "sName": "Port" },
                     { "sName": "Protocol" },
                ]*/
            });

            //Search
            $('.dataTables_filter input')
            .unbind('keypress keyup')
            .bind('keypress keyup', function (e) {
                if (e.keyCode !== 13) return;
                myTable.fnFilter($(this).val());
            });



            //IE8 width issue
            $(tableName).css("width", "100%");
        }
    };
})();