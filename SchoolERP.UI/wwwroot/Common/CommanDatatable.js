function initDataTable(tableId, title = 'Report') {
    const table = $('#' + tableId).DataTable({
        dom:
            // Top: Length menu and Search in one row
            "<'row align-items-center mb-3'<'col-sm-6'l><'col-sm-6'f>>" +

            // Buttons
            "<'row mb-2'<'col-12'B>>" +

            // Table
            "<'row'<'col-12'tr>>" +

            // Bottom: Info and Pagination
            "<'row mt-2'<'col-sm-5'i><'col-sm-7'p>>",

        buttons: [
            {
                extend: 'csvHtml5',
                title: title,
                className: 'btn btn-sm btn-outline-primary me-1'
            },
            {
                extend: 'excelHtml5',
                title: title,
                className: 'btn btn-sm btn-outline-success me-1'
            },
            {
                extend: 'print',
                title: title,
                className: 'btn btn-sm btn-outline-dark'
            }
        ],

        responsive: true,

        lengthMenu: [[10, 25, 50, 100], [10, 25, 50, 100]],
        pageLength: 10,

        order: [], // Disable initial ordering (let user choose)

        columnDefs: [
            {
                targets: 0, // First column as serial number
                orderable: false,
                searchable: false,
                render: function (data, type, row, meta) {
                    return meta.row + 1 + meta.settings._iDisplayStart;
                }
            }
        ],

        language: {
            lengthMenu: `<span class="me-2">Row Per Page</span> _MENU_ <span class="ms-2">Entries</span>`,
            search: "",
            searchPlaceholder: "Search...",
            paginate: {
                previous: "&laquo;",
                next: "&raquo;"
            },
            info: "Showing _START_ to _END_ of _TOTAL_ entries",
            zeroRecords: "No matching records found",
            infoEmpty: "No entries to show",
            infoFiltered: "(filtered from _MAX_ total entries)"
        },

        initComplete: function () {
            // Style the length dropdown using Bootstrap
            const lengthSelect = document.querySelector(`#${tableId}_length select`);
            if (lengthSelect) {
                lengthSelect.classList.add('form-select', 'form-select-sm', 'd-inline-block', 'w-auto');
            }

            // Style the search input using Bootstrap
            const searchInput = document.querySelector(`#${tableId}_filter input`);
            if (searchInput) {
                searchInput.classList.add('form-control', 'form-control-sm');
                searchInput.placeholder = 'Search...';
            }
        }
    });

    return table;
}

//This is the other datatable 

function initializeDataTable(tableSelector) {

    const initialOrder = (tableSelector === "#Comment") ? [[1, 'asc']] : [];
    return $(tableSelector).DataTable({
        lengthChange: true,
        dom: 'lBfrtip',
        retrieve: true,
        destroy: true,
        pageLength: -1,
        lengthMenu: [[10, 25, 50, -1], [10, 25, 50, "All"]],
        order: initialOrder,
        //columnDefs: [
        //    { orderable: false, targets: 0 } // Disable sorting on serial number column
        //],
        rowCallback: function (row, data, displayIndex) {
            $(row).find('.ser-no')
                .html(displayIndex + 1);
        },
        buttons: [
            {
                extend: 'excel',
                text: 'Excel',
                exportOptions: {
                    columns: ':visible:not(:last-child)',
                    format: {
                        body: function (data, row, column, node) {
                            // 🔄 CHANGED: added logic to remove `.noExport` content
                            if (typeof data === 'string' && data.indexOf('<') >= 0) {
                                var el = $('<div>' + data + '</div>'); // ✅ ADDED
                                el.find('.noExport').remove();        // ✅ ADDED
                                return column === 0 ? row + 1 : el.text().trim(); // ✅ ADDED
                            }
                            return column === 0 ? row + 1 : data;
                        }
                    }
                }
            },
            {
                extend: 'csv',
                exportOptions: {
                    columns: ':visible:not(:last-child)',
                    format: {
                        body: function (data, row, column, node) {
                            // 🔄 CHANGED: added logic to remove `.noExport` content
                            if (typeof data === 'string' && data.indexOf('<') >= 0) {
                                var el = $('<div>' + data + '</div>'); // ✅ ADDED
                                el.find('.noExport').remove();        // ✅ ADDED
                                return column === 0 ? row + 1 : el.text().trim(); // ✅ ADDED
                            }
                            return column === 0 ? row + 1 : data;
                        }
                    }
                }
            },
            {
                extend: 'pdfHtml5',
                text: 'PDF',
                exportOptions: {
                    columns: ':visible:not(:last-child)'
                },
                action: function (e, dt, node, config) {
                    PdfDiv(tableSelector); // dynamically use the table passed
                }
            }
        ],
        searchBuilder: {
            conditions: {
                num: {
                    'MultipleOf': {
                        conditionName: 'Multiple Of',
                        init: function (that, fn, preDefined = null) {
                            var el = $('<input>').on('input', function () { fn(that, this); });
                            if (preDefined !== null) {
                                $(el).val(preDefined[0]);
                            }
                            return el;
                        },
                        inputValue: function (el) {
                            return $(el[0]).val();
                        },
                        isInputValid: function (el, that) {
                            return $(el[0]).val().length !== 0;
                        },
                        search: function (value, comparison) {
                            return value % comparison === 0;
                        }
                    }
                }
            }
        }
    });
}

function PdfDiv(tableSelector, watermarkSelector = "#IpAddress") {
    debugger;
    const table = $(tableSelector).DataTable();
    const filteredData = table.rows({ search: 'applied' }).data().toArray();

    let headers = [];
    table.columns(':visible').header().each(function (header, index) {
        // Skip the columns with the 'noExport' class
        if (!$(header).hasClass('noExport') && index !== table.columns().count() - 1) {
            headers.push($(header).text().trim());
        }
    });

    let data = [];
    for (let i = 0; i < filteredData.length; i++) {
        let rowData = [];
        for (let j = 0; j < filteredData[i].length - 1; j++) {
            // Skip data for columns with 'noExport' class
            if ($(table.column(j).header()).hasClass('noExport')) {
                continue;
            }

            let cellData = filteredData[i][j];
            if (typeof cellData === 'string' && cellData.indexOf('<') >= 0) {
                let $html = $('<div>' + cellData + '</div>');
                $html.find('.noExport').remove();
                let cleanText = $html.html()
                    .replace(/<br\s*\/?>/gi, '\n')
                    .replace(/<\/?[^>]+(>|$)/g, "")
                    .trim();
                rowData.push(j === 0 ? i + 1 : cleanText);
            } else {
                rowData.push(j === 0 ? i + 1 : cellData);
            }
        }
        data.push(rowData);
    }

    let tableHTML = '<table><thead><tr>';
    headers.forEach(header => {
        tableHTML += `<th>${header}</th>`;
    });
    tableHTML += '</tr></thead><tbody>';
    data.forEach(row => {
        tableHTML += '<tr>';
        row.forEach(cell => {
            tableHTML += `<td>${cell}</td>`;
        });
        tableHTML += '</tr>';
    });
    tableHTML += '</tbody></table>';

    const watermarkText = $(watermarkSelector).html() || '';
    const popupWin = window.open('', '_blank', 'top=100,width=900,height=500,location=no');
    popupWin.document.open();

    const tableStyles = `
        <style>
            table {
                width: 100%;
                border-collapse: collapse;
                margin-bottom: 20px;
            }
            th, td {
                padding: 8px;
                border: 1px solid #ddd;
                text-align: center;
            }
            th {
                background-color: #f2f2f2;
                color: black;
            }
        </style>`;

    popupWin.document.write(`
        <html>
        <head>${tableStyles}</head>
        <body onload="window.print()">
            ${tableHTML}
            <div style="transform: rotate(-45deg);z-index:10000;opacity: 0.3;
                position:fixed;left: 6%; top: 39%;font-size: 80px;
                display: grid;justify-content: center;align-content: center;">
                ${watermarkText}
            </div>
        </body>
        </html>`);
    popupWin.document.close();
}
