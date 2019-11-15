
var dataTablesCategory;

var Category = function () {

    var loadDataTablesWrapper = function (dataTableId, iDisplayLength, sAjaxSourceUrl) {

        $.fn.dataTable.ext.errMode = () => alert('We are facing some problem while processing the current request. Please try again later.');

        $('#' + dataTableId).on('error.dt', function (e, settings, techNote, message) {
            console.log('We are facing some problem while processing the current request. Please try again later.', message);
        }).DataTable({
            serverSide: true,
            ajax: sAjaxSourceUrl,
            //ajax: {
            //    url: sAjaxSourceUrl,
            //    type: 'GET'
            //},
            columns: [
                
                {
                    name: 'Name',
                    data: "Name",
                    title: "Type Name",
                    sortable: false,
                    searchable: false
                },

                {
                    name: 'CategoryId',
                    data: 'CategoryId',
                    title: "Id",
                    sortable: false,
                    searchable: false,
                    visible: false,
                    //render: "<button>Click!</button>"
                }

            ]
            //,
            //initcomplete : function (settings, json) {
            //    var filterLabel = '#' + dataTableId + '_filter label'
            //    $(filterLabel).text('');
            //    $.unblockUI();
            //},
        });

    };

    var loadDataTables = function (dataTableId, iDisplayLength, sAjaxSourceUrl) {

        $('#' + dataTableId).DataTable({
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
                "sInfoEmpty": "Page 0 to 0 (about 0 results)"
            },
            "bProcessing": true,
            "bServerSide": true,
            "sAjaxSource": sAjaxSourceUrl,
            "sServerMethod": "GET",
            "aoColumns": [
                { "sName": "Name" },
                {
                    "sName": "CategoryId",
                    "bSearchable": false,
                    "bSortable": false,
                    "mRender": function (data, type, row) {
                        //return '<a data-chart="bar" href="javascript:;" onclick="' + data + '" class="btn btn-sm btn-primary">Select</a>';
                        return '<a href="javascript:;" data-name="' + row[0] + '" data-id="' + row[1] + '" class="btn btn-sm btn-primary lnkAppModal">Details</a>';
                        //return data;

                    }
                }
            ],
            "initComplete": function (settings, json) {
                var filterLabel = '#' + dataTableId + '_filter label'
                $(filterLabel).text('');
                console.log('initComplete');
            },
            "drawCallback": function (settings) {
                console.log('drawCallback');
            },
            "error": function (settings) {
                console.log('error');
            }
        });

    };

    var loadDataTablesWithSearch = function (iDisplayLength, sAjaxSourceUrl) {

        dataTablesCategory = $('#dataTablesCategory').DataTable({
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
                "sInfoEmpty": "Page 0 to 0 (about 0 results)"
            },
            "bProcessing": true,
            "bServerSide": true,
            "sAjaxSource": sAjaxSourceUrl,
            "sServerMethod": "GET",
            "aoColumns": [
                { "sName": "Name" },
                {
                    "sName": "CategoryId",
                    "bSearchable": false,
                    "bSortable": false,
                    "mRender": function (data, type, row) {
                        //return '<a data-chart="bar" href="javascript:;" onclick="' + data + '" class="btn btn-sm btn-primary">Select</a>';
                        return '<a href="javascript:;" data-name="' + row[0] + '" data-id="' + row[1] + '" class="btn btn-sm btn-primary lnkAppModal">Details</a>';
                        //return data;

                    }
                }
            ],
            "initComplete": function (settings, json) {
                var filterLabel = '#dataTablesCategory_filter label'
                $(filterLabel).text('');
                $.unblockUI();
            },
            "drawCallback": function (settings) {
                $.unblockUI();
            }
        });

        $("#dataTablesCategory thead input#txtName").on('keyup', function () {
            dataTablesCategory.column($(this).parent().index() + ':visible').search(this.value).draw();
        });

        //$("#dataTablesCategory thead input#dpDateOfBirth").on('change', function (e) {
        //    dataTablesCategory.column($(this).parent().index() + ':visible').search(this.value).draw();
        //})

        //$("#dataTablesCategorySearch").on('keyup', function () {
        //    dataTablesCategory.search(this.value).draw();
        //});

        //$("#dataTablesCategorySearchButton").on('click', function () {
        //    dataTablesCategory.search($("#dataTablesCategorySearch").val()).draw();
        //});

    };

    var initDataTableConfiguration = function (url) {

        //start DataTables Script

        categoryObjData = $('#dataTablesCategory').dataTable({
            "bJQueryUI": true,
            "bAutoWidth": false,
            "sPaginationType": "full_numbers",
            "bSort": false,
            "oLanguage": {
                "sLengthMenu": "Display _MENU_ records per page",
                "sZeroRecords": "Data not found.",
                "sInfo": "Showing _START_ to _END_ of _TOTAL_ records",
                "sInfoEmpty": "Showing 0 to 0 of 0 records",
                "sInfoFiltered": "(filtered from _MAX_ total records)"
            },
            "bProcessing": true,
            "bServerSide": true,
            "sAjaxSource": url,
            "aoColumns": [
                { "sName": "Name" },
                {
                    "sName": "CategoryId",
                    "bSearchable": false,
                    "bSortable": false,
                    "fnRender": function (oObj) {

                        alert(oObj);

                        return
                        '<a class="lnkDetails" title="Details" rel="Category" href=\"/Category/Details/' +
                            oObj.aData[0] + '\" >Detail</a>' +
                            '<a class="lnkEdit" title="Edit" rel="Category" form="editForm" href=\"/Category/Edit/' +
                            oObj.aData[0] + '\" >Edit</a>' +
                            '<a class="lnkDelete" title="Delete" rel="Category" form="deleteForm" href=\"/Category/Delete/' +
                            oObj.aData[0] + '\" >Delete</a>';

                    }
                }

            ]
        });

        //end DataTables Script

    };

    var loadAddressTypeDataTables = function (dataTableId, iDisplayLength, sAjaxSourceUrl) {

        addressTypeObjData = $('#' + dataTableId).DataTable({
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
                var filterLabel = '#' + dataTableId + '_filter label'
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

                        return '<a href="JavaScript:Void(0);" data-typename="' + row.typeName + '" data-typeid="' + row.typeId + '" class="btn btn-success lnkAppModal">Details</a>'
                            + ' <a href="JavaScript:Void(0);" data-typename="' + row.typeName + '" data-typeid="' + row.typeId + '" style="margin-left: 5px;" class="btn btn-warning lnkAppModal">Edit</a>'
                            + ' <a href="JavaScript:Void(0);" data-typename="' + row.typeName + '" data-typeid="' + row.typeId + '" style="margin-left: 5px;" class="btn btn-danger lnkAppModal">Delete</a>';
                        //return data;

                    },
                    width: "20%"
                }
            ]

        });

    };

    return {
        LoadDataTables: loadDataTables,
        LoadDataTablesWrapper: loadDataTablesWrapper,
        LoadDataTablesWithSearch: loadDataTablesWithSearch,
    };
}();