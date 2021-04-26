
var dataTableObjData;

var Address = function () {

    var loadDataTables = function (dataTableAddressId, iDisplayLength, sAjaxSourceUrl) {

        $.fn.dataTable.ext.errMode = () => alert('We are facing some problem while processing the current request. Please try again later.');

        dataTableObjData = $('#' + dataTableAddressId).DataTable({
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
                App.SetDataTableSearch(dataTableAddressId);
            },
            "drawCallback": function (settings) {
            },

            ajax: sAjaxSourceUrl,
            columns: [
                {
                    name: 'AddressId',
                    data: 'addressId',
                    title: "AddressId",
                    sortable: false,
                    searchable: false,
                    visible: false
                },
                {
                    name: 'AddressLineOne',
                    data: 'addressLineOne',
                    title: "Address One",
                    sortable: false,
                    searchable: false
                },
                {
                    name: 'AddressId',
                    data: "addressId",
                    title: "Actions",
                    sortable: false,
                    searchable: false,
                    className: "w-20" ,
                    "mRender": function (data, type, row) {

                        return '<a href="/Address/Details/' + row.addressId + '\" title="Details" class="btn btn-success">Details</a>'
                            + ' <a href="/Address/Edit/' + row.addressId + '\" title="Edit" class="btn btn-warning ml-2">Edit</a>'
                            //+ ' <button data-href=\"/Address/Delete/' + row.addressId + '\" data-name="' + row.addressLineOne + '" data-addressId="' + row.addressId + '" title="Delete" onclick="AppModal.DeleteCommon(this)" class="btn btn-danger ml-2">Delete</button>';
                        //return data;

                    }
                }
            ]

        });

    };

    var initAddress = function () {
    };

    return {
        LoadDataTables: loadDataTables,
        InitAddress: initAddress
    };
}();