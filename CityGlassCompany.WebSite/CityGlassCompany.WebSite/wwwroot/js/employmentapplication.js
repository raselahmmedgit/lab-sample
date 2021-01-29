
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

    var initEmploymentApplication = function () {
        $('#startDate').datepicker({
            uiLibrary: 'bootstrap4'
        });
        $('#joinDate').datepicker({
            uiLibrary: 'bootstrap4'
        });

        $('#lastEmployerStartDateOne').datepicker({
            uiLibrary: 'bootstrap4'
        });

        $('#lastEmployerLeaveDateOne').datepicker({
            uiLibrary: 'bootstrap4'
        });

        $('#lastEmployerStartDateTwo').datepicker({
            uiLibrary: 'bootstrap4'
        });

        $('#lastEmployerLeaveDateTwo').datepicker({
            uiLibrary: 'bootstrap4', format: "MM/DD/YYYY"
        });

        $('#lastEmployerStartDateThree').datepicker({
            uiLibrary: 'bootstrap4'
        });

        $('#lastEmployerLeaveDateThree').datepicker({
            uiLibrary: 'bootstrap4'
        });

        $("input[name='isLegalInUSA']").on('click', function () {

            var radios = $("input[name='isLegalInUSA']");
            var selectedVal;
            for (var i = 0; i < radios.length; i++) {
                if (radios[i].type === 'radio' && radios[i].checked) {
                    // get value, set checked flag or do whatever you need to
                    selectedVal = radios[i].value;
                    break;
                }
            }

            if (selectedVal != undefined || selectedVal != null) {
                $('#legalInUSA').val(selectedVal);
            }

        });

        $("input[name='isCurrentlyEmployed']").on('click', function () {

            var radios = $("input[name='isCurrentlyEmployed']");
            var selectedVal;
            for (var i = 0; i < radios.length; i++) {
                if (radios[i].type === 'radio' && radios[i].checked) {
                    // get value, set checked flag or do whatever you need to
                    selectedVal = radios[i].value;
                    break;
                }
            }

            if (selectedVal != undefined || selectedVal != null) {
                $('#currentlyEmployed').val(selectedVal);
            }

        });

        $("input[name='isCanContactYouEmployer']").on('click', function () {

            var radios = $("input[name='isCanContactYouEmployer']");
            var selectedVal;
            for (var i = 0; i < radios.length; i++) {
                if (radios[i].type === 'radio' && radios[i].checked) {
                    // get value, set checked flag or do whatever you need to
                    selectedVal = radios[i].value;
                    break;
                }
            }

            if (selectedVal != undefined || selectedVal != null) {
                $('#canContactYouEmployer').val(selectedVal);
            }

        });

        $("input[name='isApplyBefore']").on('click', function () {

            var radios = $("input[name='isApplyBefore']");
            var selectedVal;
            for (var i = 0; i < radios.length; i++) {
                if (radios[i].type === 'radio' && radios[i].checked) {
                    // get value, set checked flag or do whatever you need to
                    selectedVal = radios[i].value;
                    break;
                }
            }

            if (selectedVal != undefined || selectedVal != null) {
                $('#applyBefore').val(selectedVal);
            }

        });

        $("input[name='isWorkBefore']").on('click', function () {

            var radios = $("input[name='isWorkBefore']");
            var selectedVal;
            for (var i = 0; i < radios.length; i++) {
                if (radios[i].type === 'radio' && radios[i].checked) {
                    // get value, set checked flag or do whatever you need to
                    selectedVal = radios[i].value;
                    break;
                }
            }

            if (selectedVal != undefined || selectedVal != null) {
                $('#workBefore').val(selectedVal);
            }

        });

        $("input[name='isMilitaryServiceRecord']").on('click', function () {

            var radios = $("input[name='isMilitaryServiceRecord']");
            var selectedVal;
            for (var i = 0; i < radios.length; i++) {
                if (radios[i].type === 'radio' && radios[i].checked) {
                    // get value, set checked flag or do whatever you need to
                    selectedVal = radios[i].value;
                    break;
                }
            }

            if (selectedVal != undefined || selectedVal != null) {
                $('#militaryServiceRecord').val(selectedVal);
            }

        });

        $("input[name='isKnowAboutThisPosition']").on('click', function () {

            var radios = $("input[name='isKnowAboutThisPosition']");
            var selectedVal;
            for (var i = 0; i < radios.length; i++) {
                if (radios[i].type === 'radio' && radios[i].checked) {
                    // get value, set checked flag or do whatever you need to
                    selectedVal = radios[i].value;
                    break;
                }
            }

            if (selectedVal != undefined || selectedVal != null) {
                $('#knowAboutThisPosition').val(selectedVal);
            }

        });

    };

    return {
        LoadDataTables: loadDataTables,
        Init: initEmploymentApplication,
    };
}();