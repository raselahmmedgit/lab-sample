
var categoryObjData;

var Category = function () {

    var loadDataTablesWrapper = function (dataTableId, iDisplayLength, sAjaxSourceUrl) {

        $.fn.dataTable.ext.errMode = () => alert('We are facing some problem while processing the current request. Please try again later.');

        categoryObjData = $('#' + dataTableId).on('error.dt', function (e, settings, techNote, message) {
            console.log('We are facing some problem while processing the current request. Please try again later.', message);
        }).DataTable({

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
            //ajax: {
            //    url: sAjaxSourceUrl,
            //    type: 'GET'
            //},
            columns: [
                
                {
                    name: 'Name',
                    data: "name",
                    title: "Name",
                    sortable: false,
                    searchable: false
                },

                {
                    name: 'CategoryId',
                    data: "categoryId",
                    title: "Actions",
                    sortable: false,
                    searchable: false,
                    "mRender": function (data, type, row) {

                        return '<a href="javascript:;" data-href=\"/Category/Details/' + row.categoryId + '\" data-name="' + row.name + '" data-id="' + row.categoryId + '" title="Details" onclick="AppModal.DetailsCommon(this)" class="btn btn-success lnkDetailCommon">Details</a>'
                            + ' <a href="javascript:;" data-href=\"/Category/Edit/' + row.categoryId + '\" data-name="' + row.name + '" data-id="' + row.categoryId + '" title="Edit" onclick="AppModal.EditCommon(this)" style="margin-left: 5px;" class="btn btn-warning lnkEditCommon">Edit</a>'
                            + ' <a href="javascript:;" data-href=\"/Category/Delete/' + row.categoryId + '\" data-name="' + row.name + '" data-id="' + row.categoryId + '" title="Delete" onclick="AppModal.DeleteCommon(this)" style="margin-left: 5px;" class="btn btn-danger lnkDeleteCommon">Delete</a>';
                        //return data;

                    },
                    width: "25%"
                }

            ]
            
        });

    };

    var loadDataTables = function (dataTableId, iDisplayLength, sAjaxSourceUrl) {

        $.fn.dataTable.ext.errMode = () => alert('We are facing some problem while processing the current request. Please try again later.');

        categoryObjData = $('#' + dataTableId).on('error.dt', function (e, settings, techNote, message) {
            console.log('We are facing some problem while processing the current request. Please try again later.', message);
        }).DataTable({
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

                        return '<a href="javascript:;" data-href=\"/Category/Details/' + row[1] + '\" data-name="' + row[0] + '" data-id="' + row[1] + '" title="Details" onclick="AppModal.DetailsCommon(this)" class="btn btn-success">Details</a>'
                            + ' <a href="javascript:;" data-href=\"/Category/Edit/' + row[1] + '\" data-name="' + row[0] + '" data-id="' + row[1] + '" title="Edit" onclick="AppModal.EditCommon(this)" style="margin-left: 5px;" class="btn btn-warning">Edit</a>'
                            + ' <a href="javascript:;" data-href=\"/Category/Delete/' + row[1] + '\" data-name="' + row[0] + '" data-id="' + row[1] + '" title="Delete" onclick="AppModal.DeleteCommon(this)" style="margin-left: 5px;" class="btn btn-danger">Delete</a>';

                        //return data;

                    },
                    width: "25%"
                }
            ],
            "initComplete": function (settings, json) {
                var filterLabel = '#' + dataTableId + '_filter label'
                $(filterLabel).text('');
                console.log('initComplete');
            },
            "drawCallback": function (settings) {
                console.log('drawCallback');
            }
        });

    };

    var loadDataTablesWithSearch = function (iDisplayLength, sAjaxSourceUrl) {

        categoryObjData = $('#dataTablesCategory').DataTable({
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

    var loadCategoryDataTables = function (dataTableId, iDisplayLength, sAjaxSourceUrl) {

        categoryObjData = $('#' + dataTableId).DataTable({
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
                    name: 'Name',
                    data: 'name',
                    title: "Type Name",
                    sortable: false,
                    searchable: false
                },
                {
                    name: 'TypeId',
                    data: "categoryId",
                    title: "Actions",
                    sortable: false,
                    searchable: false,
                    "mRender": function (data, type, row) {

                        return '<a href="javascript:;" data-name="' + row.name + '" data-id="' + row.categoryId + '" class="btn btn-success lnkAppModal">Details</a>'
                            + ' <a href="javascript:;" data-name="' + row.name + '" data-id="' + row.categoryId + '" style="margin-left: 5px;" class="btn btn-warning lnkAppModal">Edit</a>'
                            + ' <a href="javascript:;" data-name="' + row.name + '" data-id="' + row.categoryId + '" style="margin-left: 5px;" class="btn btn-danger lnkAppModal">Delete</a>';
                        //return data;

                    },
                    width: "25%"
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