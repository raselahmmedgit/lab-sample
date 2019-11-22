//-----------------------------------------------------
//start App


var appMessage = {
    Error: 'We are facing some problem while processing the current request. Please try again later.',
    NotFound: 'Requested object not found.',
    SaveSuccess: 'Save successfully.',
    UpdateSuccess: 'Update successfully.',
    DeleteSuccess: 'Delete successfully.'
};

var App = function () {

    var loaderShow = function () {

        $.blockUI();
    };

    var loaderHide = function () {

        $.unblockUI();
    };

    var sendAjaxRequest = function (url, data, isPost, callback, isAsync, isJson, target) {
        isJson = typeof (isJson) == 'undefined' ? true : isJson;
        var contentType = (isJson) ? "application/json" : "text/plain";
        var dataType = (isJson) ? "json" : "html";
        if (!isAsync) {
            App.loaderShow();
        }

        return $.ajax({
            type: isPost ? "POST" : "GET",
            url: url,
            data: isPost ? JSON.stringify(data) : data,
            contentType: contentType,
            dataType: dataType,
            beforeSend: function (xhr) {
                loaderShow();
            },
            success: function (successData) {
                if (!isAsync) {
                    loaderHide();
                }
                return typeof (callback) == 'function' ? callback(successData) : successData;
            },
            complete: function (xhr, status) {
                loaderHide();
            },
            error: function (exception) {
                return false;
            },
            async: isAsync
        });
    };

    var arrayToTree = function (arr, parent) {
        //arr.sort(function (a, b) { return parseInt(b.Level) - parseInt(a.Level) });
        var out = [];
        for (var i in arr) {
            if (arr[i].ParentId == parent) {
                var data = new Object();
                data.text = arr[i].Name;
                if (arr[i].Level == 3) {
                    data.id = arr[i].Id;
                } else {
                    var children = arrayToTree(arr, arr[i].Id);
                    if (children.length) {
                        data.children = children;
                    }
                }
                out.push(data);
            }
        }
        return out;
    };

    var loadDropdown = function (targetDropdown, dataSourceUrl, filterByValue) {

        App.sendAjaxRequest(dataSourceUrl, filterByValue, true, function (options) {
            var optionHtml = '';

            if ($.isArray(options) && (options.length > 0)) {

                $(options).each(function (index, option) {
                    optionHtml += '<option value="' + option.Value + '">' + option.Text + '</option>';
                });

            }

            $('#' + targetDropdown).html(optionHtml);

        }, true);

        $('#' + targetDropdown).val(0);

    };

    var toastrNotifier = function (error, errortype) {
        toastr.clear();
        toastr.options = {
            "closeButton": true,
            "debug": false,
            "positionClass": "toast-top-right",
            "onclick": null,
            "showDuration": "1000",
            "hideDuration": "1000",
            "timeOut": "5000",
            "extendedTimeOut": "1000",
            "showEasing": "swing",
            "hideEasing": "linear",
            "showMethod": "fadeIn",
            "hideMethod": "fadeOut"
        };

        var errorText = error;
        var errorTypeUpperCase = toUpperCase(errortype);
        var errorTypeText = (errorTypeUpperCase + " !");
        toastr[errortype](errorText, errorTypeText);

    };

    var toastrNotifierError = function (error) {
        toastr.clear();
        toastr.options = {
            "closeButton": true,
            "debug": false,
            "positionClass": "toast-top-right",
            "onclick": null,
            "showDuration": "1000",
            "hideDuration": "1000",
            "timeOut": "5000",
            "extendedTimeOut": "1000",
            "showEasing": "swing",
            "hideEasing": "linear",
            "showMethod": "fadeIn",
            "hideMethod": "fadeOut"
        };

        toastr['error'](error, "Error !");
    };

    var toastrNotifierInfo = function (error) {
        toastr.clear();
        toastr.options = {
            "closeButton": true,
            "debug": false,
            "positionClass": "toast-top-right",
            "onclick": null,
            "showDuration": "1000",
            "hideDuration": "1000",
            "timeOut": "5000",
            "extendedTimeOut": "1000",
            "showEasing": "swing",
            "hideEasing": "linear",
            "showMethod": "fadeIn",
            "hideMethod": "fadeOut"
        };

        toastr['info'](error, "Info !");
    };

    var toUpperCase = function (strText) {

        var _strText;
        _strText = strText.toLowerCase().replace(/\b[a-z]/g, function (letter) {
            return letter.toUpperCase();
        });

        return _strText;
    };

    var displayLength = function () {
        var _displayLength = 5;
        return _displayLength;
    };

    var actionHandler = function () {

    };

    var initializeApp = function () {
        actionHandler();
    };

    var getAjax = function (getUrl, param) {

        $.getJSON(getUrl, param).done(function (data) {
            return data;
        }).fail(function (jqxhr, textStatus, error) {
            var msg = textStatus + ", " + error;
            toastr['error'](msg, "Error !");
        });

    };

    var getDataTableConfiguration = function (dataTableId, iDisplayLength, sAjaxSourceUrl, columns) {
        return {
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
            columns: generateDataTableColumns(columns)
        };
    };

    var generateDataTableColumns = function (columns) {
        var tableColumns = [];
        if (columns.length > 0) {
            for (var i = 0; i < columns.length; i++) {
                var column = {
                    name: toCamelCase(columns[i]),
                    data: toCamelCase(columns[i]),
                    title: columns[i],
                    sortable: false,
                    searchable: false
                };
                tableColumns.push(column);
            }
        }
        var actionColumn = {
            title: "Actions",
            "mRender": function (data, type, row) {

                return row;

            },
            width: "20%"
        };
        tableColumns.push(actionColumn);
        return tableColumns;
    }

    var toCamelCase = function (str) {
        return str.replace(/(?:^\w|[A-Z]|\b\w)/g, function (word, index) {
            return index == 0 ? word.toLowerCase() : word.toUpperCase();
        }).replace(/\s+/g, '');
    };

    //-----------------------------------------------------
    //start Ajax Get Methods

    var ajaxJsonGet = function (getUrl) {

        $.ajax({
            url: getUrl,
            type: 'GET',
            dataType: 'json',
            contentType: 'application/json; charset=utf-8',
            beforeSend: function () {
                OpenAppProgressModal();
            },
            success: function (result) {
                var messageType = result.messageType;
                var messageText = result.messageText;
                LoadAppMessageModal(messageType, messageText);
            },
            error: function (objAjaxRequest, strError) {
                var respText = objAjaxRequest.responseText;
                var messageText = respText;
                LoadErrorAppMessageModalWithText(messageText);
            }

        });

    }

    var ajaxJsonGetWithParam = function (getUrl, paramValue) {

        $.ajax({
            url: getUrl,
            type: 'GET',
            dataType: 'json',
            data: paramValue,
            contentType: 'application/json; charset=utf-8',
            beforeSend: function () {
                OpenAppProgressModal();
            },
            success: function (result) {
                var messageType = result.messageType;
                var messageText = result.messageText;
                LoadAppMessageModal(messageType, messageText);
            },
            error: function (objAjaxRequest, strError) {
                var respText = objAjaxRequest.responseText;
                var messageText = respText;
                LoadErrorAppMessageModalWithText(messageText);
            }

        });

    }

    //end Ajax Get Methods
    //-----------------------------------------------------

    //-----------------------------------------------------
    //start Ajax Post Methods

    var ajaxJsonPost = function (postUrl) {

        $.ajax({
            url: postUrl,
            type: 'POST',
            dataType: 'json',
            contentType: 'application/json; charset=utf-8',
            beforeSend: function () {
                OpenAppProgressModal();
            },
            success: function (result) {
                var messageType = result.messageType;
                var messageText = result.messageText;
                LoadAppMessageModal(messageType, messageText);
            },
            error: function (objAjaxRequest, strError) {
                var respText = objAjaxRequest.responseText;
                var messageText = respText;
                LoadErrorAppMessageModalWithText(messageText);
            }

        });

    }

    var ajaxJsonPostForDelete = function (postUrl) {

        $.ajax({
            url: postUrl,
            type: 'POST',
            dataType: 'json',
            contentType: 'application/json; charset=utf-8',
            beforeSend: function () {
                OpenAppProgressModal();
            },
            success: function (result) {
                var messageType = result.messageType;
                var messageText = result.messageText;
                LoadAppMessageModal(messageType, messageText);
                DataTableRefreshInIndexPage();
            },
            error: function (objAjaxRequest, strError) {
                var respText = objAjaxRequest.responseText;
                var messageText = respText;
                LoadErrorAppMessageModalWithText(messageText);
            }

        });

    }

    var ajaxJsonPostWithParam = function (postUrl, paramValue) {

        $.ajax({
            url: postUrl,
            type: 'POST',
            dataType: 'json',
            data: paramValue,
            contentType: 'application/json; charset=utf-8',
            beforeSend: function () {
                OpenAppProgressModal();
            },
            success: function (result) {
                var messageType = result.messageType;
                var messageText = result.messageText;
                LoadAppMessageModal(messageType, messageText);
            },
            error: function (objAjaxRequest, strError) {
                var respText = objAjaxRequest.responseText;
                var messageText = respText;
                LoadErrorAppMessageModalWithText(messageText);
            }

        });

    }

    var ajaxJsonPostForDeleteWithParam = function (postUrl, paramValue) {

        $.ajax({
            url: postUrl,
            type: 'POST',
            dataType: 'json',
            data: paramValue,
            contentType: 'application/json; charset=utf-8',
            beforeSend: function () {
                OpenAppProgressModal();
            },
            success: function (result) {
                var messageType = result.messageType;
                var messageText = result.messageText;
                LoadAppMessageModal(messageType, messageText);
                DataTableRefreshInIndexPage(); //Have to add index page
            },
            error: function (objAjaxRequest, strError) {
                var respText = objAjaxRequest.responseText;
                var messageText = respText;
                LoadErrorAppMessageModalWithText(messageText);
            }

        });

    }

    //end Ajax Post Methods
    //-----------------------------------------------------

    return {
        Init: initializeApp,
        LoaderShow: loaderShow,
        LoaderHide: loaderHide,
        SendAjaxRequest: sendAjaxRequest,
        LoadDropdown: loadDropdown,
        ToastrNotifier: toastrNotifier,
        ToastrNotifierInfo: toastrNotifierInfo,
        ToastrNotifierError: toastrNotifierError,
        DisplayLength: displayLength,
        GetAjax: getAjax,
        GetDataTableConfiguration: getDataTableConfiguration,
        ToCamelCase: toCamelCase,

        AjaxJsonGet: ajaxJsonGet,
        AjaxJsonGetWithParam: ajaxJsonGetWithParam,
        AjaxJsonPost: ajaxJsonPost,
        AjaxJsonPostForDelete: ajaxJsonPostForDelete,
        AjaxJsonPostWithParam: ajaxJsonPostWithParam,
        AjaxJsonPostForDeleteWithParam: ajaxJsonPostForDeleteWithParam
    };
}();

//end App
//-----------------------------------------------------

//-----------------------------------------------------
//start AppModal

var AppModal = function () {

    //-----------------------------------------------------
    //start Common
    var commonModalBegin = function () {

        App.LoaderShow();

    }

    var commonModalComplete = function (dataTableId) {

        reloadDataTablesById(dataTableId);

        App.LoaderHide();

    }

    var commonModalSuccessForReplaceMode = function () {

        var appCommonModalMessageValue = $("#appCommonModalMessage").html().trim();

        var appCommonModalMessageValueList = appCommonModalMessageValue.split("_");

        var statusValue = appCommonModalMessageValueList[0];
        var errorType = appCommonModalMessageValueList[1];
        var errorMessage = appCommonModalMessageValueList[2];

        if (statusValue == "True") {

            //close bootstrap modal
            closeCommonModal();

            App.ToastrNotifier(errorMessage, errorType);

        }
        else {

            var errorClass = 'alert alert-' + errorType;

            $("#appCommonModalMessage").html("");
            $('#appCommonModalMessage').removeClass();
            $('#appCommonModalMessage').addClass(errorClass);
            $("#appCommonModalMessage").html(errorMessage);
            $("#appCommonModalMessage").show();

            //bootstrapper ui progress close
            CloseAppProgress();

        }
        //check status

    }

    var commonModalSuccess = function (response) {

        if (response != undefined || response != null) {

            if (response.success == true) {

                //close bootstrap modal
                closeCommonModal();

                App.ToastrNotifier(response.error, response.errortype);

            }
            else {

                var errorClass = 'alert alert-' + response.errortype;
                var errorMessage = response.error;

                $("#appCommonModalMessage").html("");
                $('#appCommonModalMessage').removeClass();
                $('#appCommonModalMessage').addClass(errorClass);
                $("#appCommonModalMessage").html(errorMessage);
                $("#appCommonModalMessage").show();

                //bootstrapper ui progress close
                CloseAppProgress();
            }

        }
        //check null
    }

    var commonModalFailureForReplaceMode = function () {

        var appCommonModalMessageValue = $("#appCommonModalMessage").html().trim();

        var appCommonModalMessageValueList = appCommonModalMessageValue.split("_");

        var statusValue = appCommonModalMessageValueList[0];
        var errorType = appCommonModalMessageValueList[1];
        var errorMessage = appCommonModalMessageValueList[2];

        if (statusValue == "True") {

            //close bootstrap modal
            closeCommonModal();

            App.ToastrNotifier(errorMessage, errorType);

        }
        else {

            var errorClass = 'alert alert-' + errorType;

            $("#appCommonModalMessage").html("");
            $('#appCommonModalMessage').removeClass();
            $('#appCommonModalMessage').addClass(errorClass);
            $("#appCommonModalMessage").html(errorMessage);
            $("#appCommonModalMessage").show();

            //bootstrapper ui progress close
            CloseAppProgress();

        }
        //check status

    }

    var commonModalFailure = function (response) {

        if (response != undefined || response != null) {

            if (response.success == true) {

                //close bootstrap modal
                closeCommonModal();

                App.ToastrNotifier(response.error, response.errortype);

            }
            else {

                var errorClass = 'alert alert-' + response.errortype;
                var errorMessage = response.error;

                $("#appCommonModalMessage").html("");
                $('#appCommonModalMessage').removeClass();
                $('#appCommonModalMessage').addClass(errorClass);
                $("#appCommonModalMessage").html(errorMessage);
                $("#appCommonModalMessage").show();

                //bootstrapper ui progress close
                CloseAppProgress();
            }

        }
        //check null
    }

    // private function
    var commonModalFormValidation = function (fromId) {

        //validation
        var $form = $("#" + fromId);
        // Unbind existing validation
        $form.unbind();
        $form.data("validator", null);
        // Check document for changes
        $.validator.unobtrusive.parse(document);
        // Re add validation with changes
        $form.validate($form.data("unobtrusiveValidation").options);

    }

    var loadAddOrEditCommonModal = function (viewUrl, modalTitle, modalForm) {

        titleCommonModal(modalTitle);

        $.get(viewUrl, function (data) {

            //bootstrap modal content
            contentCommonModal(data);

            commonModalFormValidation(modalForm);

            //bootstrap modal open
            openCommonModal();
        });

    };

    var loadDetailsCommonModal = function (viewUrl, modalTitle) {

        titleCommonModal(modalTitle);

        $.get(viewUrl, function (data) {

            //bootstrap modal content
            contentCommonModal(data);

            //bootstrap modal open
            openCommonModal();
        });

    };

    var loadCommonModal = function (viewUrl, modalTitle, modalForm) {

        titleCommonModal(modalTitle);

        $.get(viewUrl, function (data) {

            //bootstrap modal content
            contentCommonModal(data);

            commonModalFormValidation(modalForm);

            //bootstrap modal open
            openCommonModal();
        });

    };

    var loadCommonModalWithoutForm = function (viewUrl, modalTitle) {

        titleCommonModal(modalTitle);

        $.get(viewUrl, function (data) {

            //bootstrap modal content
            contentCommonModal(data);

            //bootstrap modal open
            openCommonModal();
        });

    };

    var titleCommonModal = function (title) {

        //title bootstrap modal
        $('#appCommonModal').find("#appCommonModalTitle").html('');
        $('#appCommonModal').find("#appCommonModalTitle").html(title);
    }

    var contentCommonModal = function (content) {

        //content bootstrap modal
        $('#appCommonModal').find("#appCommonModalBody").html('');
        $('#appCommonModal').find("#appCommonModalBody").html(content);

    }

    var openCommonModal = function () {

        //open bootstrap modal
        $('#appCommonModal').modal('show');

    }

    var closeCommonModal = function () {

        //open bootstrap modal
        $('#appCommonModal').modal('hide');

    }
    // private function

    //end Common
    //-----------------------------------------------------


    //-----------------------------------------------------
    //start Delete
    // private function
    var loadDeleteModal = function (viewUrl, modalTitle) {

        debugger;

        titleDeleteModal(modalTitle);

        //hidden field value
        $("#hdDeleteId").val("");
        $("#hdDeletePostUrl").val("");
        $("#hdDeleteId").val(viewUrl);
        $("#hdDeletePostUrl").val(viewUrl);

        //bootstrap modal open
        openDeleteModal();

    };

    var titleDeleteModal = function (title) {

        //title bootstrap modal
        $('#appDeleteModal').find("#appDeleteModalTitle").html('');
        $('#appDeleteModal').find("#appDeleteModalTitle").html(title);
    }

    var contentDeleteModal = function (content) {

        //content bootstrap modal
        $('#appDeleteModal').find("#appDeleteModalBody").html('');
        $('#appDeleteModal').find("#appDeleteModalBody").html(content);

    }
    // private function

    var openDeleteModal = function () {

        //open bootstrap modal
        $('#appDeleteModal').modal('show');

    }

    var closeDeleteModal = function () {

        //open bootstrap modal
        $('#appDeleteModal').modal('hide');

    }

    var yesDelete = function () {

        debugger;

        var hdDeleteIdValue = $("#hdDeleteId").val().trim();
        var hdDeletePostUrlValue = $("#hdDeletePostUrl").val().trim();

        //App.AjaxJsonPost(hdDeletePostUrlValue);
        //App.AjaxJsonPostForDelete(hdDeletePostUrlValue);

        App.SendAjaxRequest(hdDeletePostUrlValue, null, true, function (response) {

            debugger;

            //close bootstrap modal
            closeDeleteModal();

            if (response != undefined || response != null) {

                App.ToastrNotifier(response.error, response.errortype);

            }

        }, true);

        return null;
    }

    var noDelete = function () {

        $("#hdDeleteId").val("");
        $("#hdDeletePostUrl").val("");

        //close bootstrap modal
        closeDeleteModal();

    }

    //end Delete
    //-----------------------------------------------------


    //-----------------------------------------------------
    //start Message

    // private function
    //Common Message Modal with messageType, messageText
    var loadMessageModal = function (messageType, messageText) {

        var modalTitle = messageType;

        titleMessageModal(modalTitle);

        var modalContent = getMessageModalContent(modalTitle, messageText);

        contentMessageModal(modalContent);

        //bootstrapper ui progress close
        CloseAppProgress();

        //bootstrapper ui message modal open
        openMessageModal();

    };

    //Common Message Modal with messageType, messageText for ajax success
    var loadMessageModalForAjaxSuccess = function (messageType, messageText) {

        var modalTitle = messageType;

        titleMessageModal(modalTitle);

        var modalContent = getMessageModalContent(modalTitle, messageText);

        contentMessageModal(modalContent);

        //bootstrapper ui message modal open
        openMessageModal();

    };

    //Info Message Modal
    var loadInfoMessageModalWithText = function (messageText) {

        var modalTitle = "Info";

        titleMessageModal(modalTitle);

        var modalContent = getMessageModalContent(modalTitle, messageText);

        contentMessageModal(modalContent);

        //bootstrapper ui progress close
        CloseAppProgress();

        //bootstrapper ui message modal open
        openMessageModal();

    };

    //Warn Message Modal
    var loadWarnMessageModalWithText = function (messageText) {

        var modalTitle = "Warn";

        titleMessageModal(modalTitle);

        var modalContent = getMessageModalContent(modalTitle, messageText);

        contentMessageModal(modalContent);

        //bootstrapper ui progress close
        CloseAppProgress();

        //bootstrapper ui message open
        OpenAppMessage();

    };

    //Success Message Modal
    var loadSuccessMessageModalWithText = function (messageText) {

        var modalTitle = "Success";

        titleMessageModal(modalTitle);

        var modalContent = getMessageModalContent(modalTitle, messageText);

        contentMessageModal(modalContent);

        //bootstrapper ui progress close
        CloseAppProgress();

        //bootstrapper ui message modal open
        openMessageModal();

    };

    //Error Message Modal
    var loadErrorMessageModalWithText = function (messageText) {

        var modalTitle = "Error";

        titleMessageModal(modalTitle);

        var modalContent = getMessageModalContent(modalTitle, messageText);

        contentMessageModal(modalContent);

        //bootstrapper ui progress close
        CloseAppProgress();

        //bootstrapper ui message modal open
        openMessageModal();

    };

    var getMessageModalContent = function (messageType, messageText) {

        var content = "<div id='messageModalPage' class='messageModalPage'><div class='row'><div style='margin-bottom: 10px !important;' class='alert alert-" + messageType + "'>" + messageText + "</div> </div></div></div>";

        return content;

    }

    var titleMessageModal = function (title) {

        var upperTitle = title.toLowerCase().replace(/\b[a-z]/g, function (letter) {
            return letter.toUpperCase();
        });

        //title bootstrap modal
        $('#appMessageModal').find("#appMessageModalTitle").html('');
        $('#appMessageModal').find("#appMessageModalTitle").html(upperTitle);
    }

    var contentMessageModal = function (content) {

        //content bootstrap modal
        $('#appMessageModal').find("#appMessageModalBody").html('');
        $('#appMessageModal').find("#appMessageModalBody").html(content);

    }

    // private function

    var openMessageModal = function () {

        //open bootstrap modal
        $('#appMessageModal').modal('show');

    }

    var closeMessageModal = function () {

        //open bootstrap modal
        $('#appMessageModal').modal('hide');

    }

    var okMessage = function () {

        //close bootstrap modal
        closeMessageModal();

    }

    //end Message
    //-----------------------------------------------------


    //-----------------------------------------------------
    //start Reload Data Tables Funtion
    var reloadDataTables = function () {
        //Get Data Tables
        var dataTableObj = $('#dataTables').DataTable();
        dataTableObj.ajax.reload();
    }

    var reloadDataTablesById = function (dataTableId) {
        var _id = "#" + dataTableId;
        //Get Data Tables
        var dataTableObj = $(_id).DataTable();
        dataTableObj.ajax.reload();
    }
    //end Reload Data Tables Funtion
    //-----------------------------------------------------


    //-----------------------------------------------------
    //add Common
    var addCommon = function (elm) {

        //change the title of the dialog
        var linkObj = $(elm);
        var viewUrl = linkObj.attr('data-href');
        var modalTitle = linkObj.attr('title');
        var modalForm = "appCommonModalForm";

        loadCommonModal(viewUrl, modalTitle, modalForm);

        return false;

    };
    //-----------------------------------------------------

    //-----------------------------------------------------
    //detail Common
    var detailsCommon = function (elm) {

        //change the title of the dialog
        var linkObj = $(elm);
        var viewUrl = linkObj.attr('data-href');
        var modalTitle = linkObj.attr('title');

        loadCommonModalWithoutForm(viewUrl, modalTitle);

        return false;

    };
    //-----------------------------------------------------

    //-----------------------------------------------------
    //edit Common
    var editCommon = function (elm) {

        //change the title of the dialog
        var linkObj = $(elm);
        var viewUrl = linkObj.attr('data-href');
        var modalTitle = linkObj.attr('title');
        var modalForm = "appCommonModalForm";

        loadCommonModal(viewUrl, modalTitle, modalForm);

        return false;

    };
    //-----------------------------------------------------

    //-----------------------------------------------------
    //delete Common
    var deleteCommon = function (elm) {

        //change the title of the dialog
        var linkObj = $(elm);
        var viewUrl = linkObj.attr('data-href');
        var modalTitle = linkObj.attr('title');

        loadDeleteModal(viewUrl, modalTitle);

        return false;

    };
    //-----------------------------------------------------

    //-----------------------------------------------------
    //start Common, Delete, Message Funtion
    var createAppCommonModal = function () {
        if ($('#appCommonModal').length == 0) {
            $(document.body).append('<div class="modal fade text-left" id="appCommonModal" tabindex="-1" role="dialog" aria-labelledby="appCommonModalTitle" aria-hidden="true" > <div class="modal-dialog"> <div class="modal-content"> <div class="modal-header"> <label class="modal-title text-text-bold-600" id="appCommonModalTitle"></label> <button type="button" class="close" data-dismiss="modal" aria-label="Close"> <span aria-hidden="true">&times;</span> </button> </div> <div class="modal-body" id="appCommonModalBody"> </div> </div> </div></div>');
        } else {
            $('#appCommonModal').find("#appCommonModalTitle").html('');
            $('#appCommonModal').find("#appCommonModalBody").html('');
            //$('#appCommonModal').find("#appCommonModalFooter").html('');
        }
    }

    var createAppDeleteModal = function () {
        if ($('#appDeleteModal').length == 0) {
            $(document.body).append('<div class="modal fade text-left" id="appDeleteModal" tabindex="-1" role="dialog" aria-labelledby="appDeleteModalTitle" aria-hidden="true" > <div class="modal-dialog"> <div class="modal-content"> <div class="modal-header"> <label class="modal-title text-text-bold-600" id="appDeleteModalTitle"></label> <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button> </div> <div class="modal-body" id="appDeleteModalBody"> <div id="deleteModalPage" class="deleteModalPage form-win col-xs-12"> <div class="row"> <input type="hidden" name="hdDeleteId" id="hdDeleteId" value="" /> <input type="hidden" name="hdDeletePostUrl" id="hdDeletePostUrl" value="" /> </div> <div class="row"> <div class="col-md-12"><div class="alert alert-warning"><strong>Do you want to delete this?</strong></div></div> </div> </div> <div class="modal-footer" id="appDeleteModalFooter"> <button type="button" class="btn btn-success" id="btnYesDelete" name="btnYesDelete" onclick="AppModal.YesDelete()" style="width: 60px;">Yes</button> <button type="button" class="btn btn-warning" id="btnNoDelete" name="btnNoDelete" onclick="AppModal.NoDelete()" style="width: 60px;">No</button> </div> </div> </div> </div></div>');
        } else {
            $('#appDeleteModal').find("#appDeleteModalTitle").html('');
            $('#appDeleteModal').find("#appDeleteModalBody").html('');
        }
    }

    var createAppMessageModal = function () {
        if ($('#appMessageModal').length == 0) {
            $(document.body).append('<div class="modal fade text-left" id="appMessageModal" tabindex="-1" role="dialog" aria-labelledby="appMessageModalTitle" aria-hidden="true"> <div class="modal-dialog"> <div class="modal-content"> <div class="modal-header"> <label class="modal-title text-text-bold-600" id="appMessageModalTitle"></label> <button type="button" class="close" data-dismiss="modal" aria-label="Close"> <span aria-hidden="true">&times;</span> </button> </div> <div class="modal-body" id="appMessageModalBody"></div> <div class="modal-footer" id="appMessageModalFooter"> <button type="button" class="btn btn-primary" data-dismiss="modal" style="width: 60px;">Ok</button> </div> </div> </div></div>');
        } else {
            $('#appMessageModal').find("#appMessageModalTitle").html('');
            $('#appMessageModal').find("#appMessageModalBody").html('');
            //$('#appMessageModal').find("#appMessageModalFooter").html('');
        }
    }

    //end Common, Delete, Message Funtion
    //-----------------------------------------------------


    var initializeAppModal = function () {

        createAppCommonModal();
        createAppDeleteModal();
        createAppMessageModal();

    };

    return {
        Init: initializeAppModal,

        AddCommon: addCommon,
        DetailsCommon: detailsCommon,
        EditCommon: editCommon,
        DeleteCommon: deleteCommon,

        ReloadDataTables: reloadDataTables,
        ReloadDataTablesById: reloadDataTablesById,

        CloseCommonModal: closeCommonModal,

        CommonModalBegin: commonModalBegin,
        CommonModalComplete: commonModalComplete,
        CommonModalSuccessForReplaceMode: commonModalSuccessForReplaceMode,
        CommonModalSuccess: commonModalSuccess,
        CommonModalFailureForReplaceMode: commonModalFailureForReplaceMode,
        CommonModalFailure: commonModalFailure,

        YesDelete: yesDelete,
        NoDelete: noDelete,

        OpenMessageModal: openMessageModal,
        CloseMessageModal: closeMessageModal,
        OkMessage: okMessage
    };
}();

//end AppModal
//-----------------------------------------------------


$(document).ready(function () {

    App.Init();
    AppModal.Init();

});