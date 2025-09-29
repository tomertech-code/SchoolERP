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
