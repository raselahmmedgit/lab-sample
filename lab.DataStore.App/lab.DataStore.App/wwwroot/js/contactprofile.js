
var contactProfileObjData;

var ContactProfile = function () {

    var loadDataTables = function (dataTableId, iDisplayLength, sAjaxSourceUrl) {

        $.fn.dataTable.ext.errMode = () => alert('We are facing some problem while processing the current request. Please try again later.');

        contactProfileObjData = $('#' + dataTableId).DataTable({
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
                    name: 'TypeName',
                    data: 'typeName',
                    title: "Type Name",
                    sortable: false,
                    searchable: false
                },
                {
                    name: 'TypeId',
                    data: "typeId",
                    title: "Actions",
                    sortable: false,
                    searchable: false,
                    "mRender": function (data, type, row) {

                        return '<a href="javascript:;" data-href=\"/ContactProfile/Details/' + row.typeId + '\" data-name="' + row.typeName + '" data-id="' + row.typeId + '" title="Details" onclick="AppModal.DetailsCommon(this)" class="btn btn-success lnkDetailCommon">Details</a>'
                            + ' <a href="javascript:;" data-href=\"/ContactProfile/Edit/' + row.typeId + '\" data-name="' + row.typeName + '" data-id="' + row.typeId + '" title="Edit" onclick="AppModal.EditCommon(this)" style="margin-left: 5px;" class="btn btn-warning lnkEditCommon">Edit</a>'
                            + ' <a href="javascript:;" data-href=\"/ContactProfile/Delete/' + row.typeId + '\" data-name="' + row.typeName + '" data-id="' + row.typeId + '" title="Delete" onclick="AppModal.DeleteCommon(this)" style="margin-left: 5px;" class="btn btn-danger lnkDeleteCommon">Delete</a>';
                        //return data;

                    },
                    width: "22%"
                }
            ]

        });

    };

    return {
        LoadDataTables: loadDataTables,
    };
}();