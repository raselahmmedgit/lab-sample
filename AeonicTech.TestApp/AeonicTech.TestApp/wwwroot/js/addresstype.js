
var dataTableObjData;

var AddressType = function () {

    var loadDataTables = function (dataTableTypeId, iDisplayLength, sAjaxSourceUrl) {

        $.fn.dataTable.ext.errMode = () => alert('We are facing some problem while processing the current request. Please try again later.');

        dataTableObjData = $('#' + dataTableTypeId).DataTable({
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
                App.SetDataTableSearch(dataTableTypeId);
            },
            "drawCallback": function (settings) {
            },

            ajax: sAjaxSourceUrl,
            columns: [
                {
                    name: 'TypeId',
                    data: 'typeId',
                    title: "TypeId",
                    sortable: false,
                    searchable: false,
                    visible: false
                },
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
                    className: "w-20" ,
                    "mRender": function (data, type, row) {

                        return '<a href="/AddressType/Details/' + row.typeId + '\" title="Details" class="btn btn-success">Details</a>'
                            + ' <a href="/AddressType/Edit/' + row.typeId + '\" title="Edit" class="btn btn-warning ml-2">Edit</a>'
                            //+ ' <button data-href=\"/AddressType/Delete/' + row.typeId + '\" data-name="' + row.typeName + '" data-typeId="' + row.typeId + '" title="Delete" onclick="AppModal.DeleteCommon(this)" class="btn btn-danger ml-2">Delete</button>';
                        //return data;

                    }
                }
            ]

        });

    };

    var initAddressType = function () {
    };

    return {
        LoadDataTables: loadDataTables,
        InitAddressType: initAddressType
    };
}();