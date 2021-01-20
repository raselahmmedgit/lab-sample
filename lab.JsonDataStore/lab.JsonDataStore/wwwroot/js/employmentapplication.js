
var employmentApplicationObjData;

var EmploymentApplication = function () {

    var loadDataTables = function (dataTableId, iDisplayLength, sAjaxSourceUrl) {

        $.fn.dataTable.ext.errMode = () => alert('We are facing some problem while processing the current request. Please try again later.');

        employmentApplicationObjData = $('#' + dataTableId).DataTable({
            "bJQueryUI": true,
            "bAutoWidth": true,
            "sPaginationType": "full_numbers",
            "bPaginate": true,
            "iDisplayLength": iDisplayLength,
            "bSort": false,
            "bFilter": true,
            "bSortClasses": false,
            "lengthChange": false,
            "oLanguage": {
                "sLengthMenu": "Display _MENU_ records per page",
                "sZeroRecords": "Data not found.",
                "sInfo": "Page _START_ to _END_ (about _TOTAL_ results)",
                "sInfoEmpty": "Page 0 to 0 (about 0 results)",
                "sInfoFiltered": ""
            },
            "bProcessing": true,
            "bServerSide": true,
            "initComplete": function (settings, json) {
                $.blockUI();
                var filterLabel = '#' + dataTableId + '_filter label';
                $(filterLabel).text('');
                $.unblockUI();
            },
            "drawCallback": function (settings) {
            },

            ajax: sAjaxSourceUrl,
            columns: [
                {
                    name: 'FirstName',
                    data: 'firstName',
                    title: "First Name",
                    sortable: false,
                    searchable: false
                },
                {
                    name: 'LastName',
                    data: 'lastName',
                    title: "Last Name",
                    sortable: false,
                    searchable: false
                },
                {
                    name: 'Id',
                    data: "id",
                    title: "Actions",
                    sortable: false,
                    searchable: false,
                    "mRender": function (data, type, row) {

                        return '<a href=\"/EmploymentApplication/Details/' + row.id + '\" data-href=\"/EmploymentApplication/Details/' + row.id + '\" data-id="' + row.id + '" title="Details" class="btn btn-sm btn-success lnkDetailCommon">Details</a>'
                            + ' <a href=\"/EmploymentApplication/Edit/' + row.id + '\" data-href=\"/EmploymentApplication/Edit/' + row.id + '\" data-id="' + row.id + '" title="Edit" class="btn btn-sm btn-warning ml5 lnkEditCommon">Edit</a>'
                            + ' <a href="javascript:;" data-href=\"/EmploymentApplication/Delete/' + row.id + '\" data-id="' + row.id + '" title="Delete" onclick="AppModal.DeleteCommon(this)" class="btn btn-sm btn-danger ml5 lnkDeleteCommon">Delete</a>';
                        //return data;

                    },
                    width: "20%"
                }
            ]

        });

    };

    return {
        LoadDataTables: loadDataTables,
    };
}();