
var appMessage = {
    Error: 'We are facing some problem while processing the current request. Please try again later.',
    NotFound: 'Requested object not found.',
    SaveSuccess: 'Save successfully.',
    UpdateSuccess: 'Update successfully.',
    DeleteSuccess: 'Delete successfully.'
};
function isMobileOrTab(){
    var check = false;
    (function (a) { if (/(android|bb\d+|meego).+mobile|avantgo|bada\/|blackberry|blazer|compal|elaine|fennec|hiptop|iemobile|ip(hone|od)|iris|kindle|lge |maemo|midp|mmp|mobile.+firefox|netfront|opera m(ob|in)i|palm( os)?|phone|p(ixi|re)\/|plucker|pocket|psp|series(4|6)0|symbian|treo|up\.(browser|link)|vodafone|wap|windows ce|xda|xiino|android|ipad|playbook|silk/i.test(a) || /1207|6310|6590|3gso|4thp|50[1-6]i|770s|802s|a wa|abac|ac(er|oo|s\-)|ai(ko|rn)|al(av|ca|co)|amoi|an(ex|ny|yw)|aptu|ar(ch|go)|as(te|us)|attw|au(di|\-m|r |s )|avan|be(ck|ll|nq)|bi(lb|rd)|bl(ac|az)|br(e|v)w|bumb|bw\-(n|u)|c55\/|capi|ccwa|cdm\-|cell|chtm|cldc|cmd\-|co(mp|nd)|craw|da(it|ll|ng)|dbte|dc\-s|devi|dica|dmob|do(c|p)o|ds(12|\-d)|el(49|ai)|em(l2|ul)|er(ic|k0)|esl8|ez([4-7]0|os|wa|ze)|fetc|fly(\-|_)|g1 u|g560|gene|gf\-5|g\-mo|go(\.w|od)|gr(ad|un)|haie|hcit|hd\-(m|p|t)|hei\-|hi(pt|ta)|hp( i|ip)|hs\-c|ht(c(\-| |_|a|g|p|s|t)|tp)|hu(aw|tc)|i\-(20|go|ma)|i230|iac( |\-|\/)|ibro|idea|ig01|ikom|im1k|inno|ipaq|iris|ja(t|v)a|jbro|jemu|jigs|kddi|keji|kgt( |\/)|klon|kpt |kwc\-|kyo(c|k)|le(no|xi)|lg( g|\/(k|l|u)|50|54|\-[a-w])|libw|lynx|m1\-w|m3ga|m50\/|ma(te|ui|xo)|mc(01|21|ca)|m\-cr|me(rc|ri)|mi(o8|oa|ts)|mmef|mo(01|02|bi|de|do|t(\-| |o|v)|zz)|mt(50|p1|v )|mwbp|mywa|n10[0-2]|n20[2-3]|n30(0|2)|n50(0|2|5)|n7(0(0|1)|10)|ne((c|m)\-|on|tf|wf|wg|wt)|nok(6|i)|nzph|o2im|op(ti|wv)|oran|owg1|p800|pan(a|d|t)|pdxg|pg(13|\-([1-8]|c))|phil|pire|pl(ay|uc)|pn\-2|po(ck|rt|se)|prox|psio|pt\-g|qa\-a|qc(07|12|21|32|60|\-[2-7]|i\-)|qtek|r380|r600|raks|rim9|ro(ve|zo)|s55\/|sa(ge|ma|mm|ms|ny|va)|sc(01|h\-|oo|p\-)|sdk\/|se(c(\-|0|1)|47|mc|nd|ri)|sgh\-|shar|sie(\-|m)|sk\-0|sl(45|id)|sm(al|ar|b3|it|t5)|so(ft|ny)|sp(01|h\-|v\-|v )|sy(01|mb)|t2(18|50)|t6(00|10|18)|ta(gt|lk)|tcl\-|tdg\-|tel(i|m)|tim\-|t\-mo|to(pl|sh)|ts(70|m\-|m3|m5)|tx\-9|up(\.b|g1|si)|utst|v400|v750|veri|vi(rg|te)|vk(40|5[0-3]|\-v)|vm40|voda|vulc|vx(52|53|60|61|70|80|81|83|85|98)|w3c(\-| )|webc|whit|wi(g |nc|nw)|wmlb|wonu|x700|yas\-|your|zeto|zte\-/i.test(a.substr(0, 4))) check = true; })(navigator.userAgent || navigator.vendor || window.opera);
    return check;
}

jQuery.fn.selectText = function () {
    this.find('input').each(function () {
        if ($(this).prev().length == 0 || !$(this).prev().hasClass('p_copy')) {
            $('<p class="p_copy" style="position: absolute; z-index: -1;"></p>').insertBefore($(this));
        }
        $(this).prev().html($(this).val());
    });
    var doc = document;
    var element = this[0];
    console.log(this, element);
    if (doc.body.createTextRange) {
        var range = document.body.createTextRange();
        range.moveToElementText(element);
        range.select();
    } else if (window.getSelection) {
        var selection = window.getSelection();
        var range = document.createRange();
        range.selectNodeContents(element);
        selection.removeAllRanges();
        selection.addRange(range);
    }
};

var App = function () {
    var appAreaName = {
        Admin: 'Admin'
    };
    var loaderShow = function () {
        $("#preloader").addClass("preloader-light");
        $("#preloader").fadeIn(100);
    };

    var loaderHide = function () {
        $("#preloader").remove("preloader-light");
        $("#preloader").fadeOut(100);
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
                App.loaderShow();
            },
            success: function (successData) {
                if (!isAsync) {
                    App.loaderHide();
                }
                return typeof (callback) == 'function' ? callback(successData) : successData;
            },
            complete: function (xhr, status) {
                App.loaderHide();
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

    var appLayoutMessageErrorById = function (eId, message) {

        var appLayoutMessage = $(document.getElementById(eId));

        if (appLayoutMessage.length > 0) {
            appLayoutMessage.html("");

            var messageClass = 'alert alert-danger alert-dismissable';
            var messageHtml = message;

            var html = '';
            html += '<div class="' + messageClass + '" data-autodismiss="alert">';
            html += '<button type="button" class="close" data-dismiss="alert" aria-hidden="true">×</button><strong></strong>';
            html += messageHtml;
            html += '</div>';

            appLayoutMessage.html(html);
            appLayoutMessage.show();

            bindAutoAlertDismissable();
        }

    };

    var appLayoutMessageInfoById = function (eId, message) {

        var appLayoutMessage = $(document.getElementById(eId));

        if (appLayoutMessage.length > 0) {
            appLayoutMessage.html("");

            var messageClass = 'alert alert-info alert-dismissable';
            var messageHtml = message;

            var html = '';
            html += '<div class="' + messageClass + '" data-autodismiss="alert">';
            html += '<button type="button" class="close" data-dismiss="alert" aria-hidden="true">×</button><strong></strong>';
            html += messageHtml;
            html += '</div>';

            appLayoutMessage.html(html);
            appLayoutMessage.show();

            bindAutoAlertDismissable();
        }

    };

    var appLayoutMessageSuccessById = function (eId, message) {

        var appLayoutMessage = $(document.getElementById(eId));
        if (appLayoutMessage.length > 0) {
            appLayoutMessage.html("");

            var messageClass = 'alert alert-success alert-dismissable';
            var messageHtml = message;

            var html = '';
            html += '<div class="' + messageClass + '" data-autodismiss="alert">';
            html += '<button type="button" class="close" data-dismiss="alert" aria-hidden="true">×</button><strong></strong>';
            html += messageHtml;
            html += '</div>';

            appLayoutMessage.html(html);
            appLayoutMessage.show();

            bindAutoAlertDismissable();
        }

    };

    var appLayoutMessageById = function (eId, messagetype, message) {

        var appLayoutMessage = $(document.getElementById(eId));
        if (appLayoutMessage.length > 0) {
            appLayoutMessage.html("");

            var messageClass = 'alert alert-' + messagetype + ' alert-dismissable';
            var messageHtml = message;

            var html = '';
            html += '<div class="' + messageClass + '" data-autodismiss="alert">';
            html += '<button type="button" class="close" data-dismiss="alert" aria-hidden="true">×</button><strong></strong>';
            html += messageHtml;
            html += '</div>';

            appLayoutMessage.html(html);
            appLayoutMessage.show();

            bindAutoAlertDismissable();
        }

    };

    var appLayoutMessage = function (messagetype, message) {

        $("#AppLayoutMessage").html("");

        var messageClass = 'alert alert-' + messagetype + ' alert-dismissable';
        var messageHtml = message;

        var html = '';
        html += '<div class="' + messageClass + '" data-autodismiss="alert">';
        html += '<button type="button" class="close" data-dismiss="alert" aria-hidden="true">×</button><strong></strong>';
        html += messageHtml;
        html += '</div>';
        
        $("#AppLayoutMessage").html(html);
        $("#AppLayoutMessage").show();

        bindAutoAlertDismissable();
    };

    var toastrNotifier = function (error, errortype) {
        toastr.clear();
        toastr.options = {
            "closeButton": true,
            "debug": false,
            "positionClass": "toast-top-center",
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
            "positionClass": "toast-top-center",
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
            "positionClass": "toast-top-center",
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

    var toastrNotifierSuccess = function (message) {
        toastr.clear();
        toastr.options = {
            "closeButton": true,
            "debug": false,
            "positionClass": "toast-top-center",
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

        toastr['success'](message, "Success !");
    };

    var toUpperCase = function (strText) {

        var _strText;
        _strText = strText.toLowerCase().replace(/\b[a-z]/g, function (letter) {
            return letter.toUpperCase();
        });

        return _strText;
    };

    var displayLength = function () {
        var _displayLength = 10;
        return _displayLength;
    };

    var bindAutoAlertDismissable = function () {
        window.setTimeout(function () {

            var autoDismissElement = $("div[data-autodismiss='alert']");
            if (autoDismissElement.length > 0) {
                $("div[data-autodismiss='alert']").fadeTo(1000, 0).slideUp(1000, function () {
                    $(this).remove();
                });
            }

        }, 5000);
    };

    var setAutoAlertDismissable = function () {
        window.setInterval(function () {

            var autoDismissElement = $("div[data-autodismiss='alert']");
            if (autoDismissElement.length > 0) {
                $("div[data-autodismiss='alert']").fadeTo(1000, 0).slideUp(1000, function () {
                    $(this).remove();
                });
            }

        }, 5000);
    };

    var actionHandler = function () {
        setAutoAlertDismissable();
    };

    var initializeApp = function () {
        actionHandler();
        //getAndSetLocation();
        initializePopover();
    };

    var getAjax = function (getUrl, param) {

        $.getJSON(getUrl, param).done(function (data) {
            return data;
        }).fail(function (jqxhr, textStatus, error) {
            var msg = textStatus + ", " + error;
            toastr['error'](msg, "Error !");
        });

    };

    var getDataTableConfiguration = function (dataTableId, iDisplayLength, sAjaxSourceUrl,columns) {
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
                var keys = Object.keys(json.data[0]);
                tableColumns = keys;
                console.log(keys);
                loaderShow();
                var filterLabel = '#' + dataTableId + '_filter label'
                $(filterLabel).text('');
                loaderHide();
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

                return '<a href="javascript:;" data-typename="' + row.typeName + '" data-typeid="' + row.typeId + '" class="btn btn-success lnkAppModal">Details</a>'
                    + ' <a href="javascript:;" data-typename="' + row.typeName + '" data-typeid="' + row.typeId + '" style="margin-left: 5px;" class="btn btn-warning lnkAppModal">Edit</a>'
                    + ' <a href="javascript:;" data-typename="' + row.typeName + '" data-typeid="' + row.typeId + '" style="margin-left: 5px;" class="btn btn-danger lnkAppModal">Delete</a>';
                
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

    var initializePopover = function () {
        $(function () {
            $('[data-toggle="popover"]').popover()
        });
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

    //-----------------------------------------------------
    //start Utiliy
    var getAndSetLocation = function () {
        if (navigator.geolocation) {
            navigator.geolocation.getCurrentPosition(showPosition);
        }
    };
    var showPosition = function (position) {
        $("#UserLatitude").val(position.coords.latitude);
        $("#UserLongitude").val(position.coords.longitude);
    };
    var getUserLocalTimeZone = function () {
        var date = String(new Date());
        var timezone = date.substring(date.lastIndexOf('(') + 1).replace(')', '').trim();
        return timezone;
    };

    var base64ImageToBlob = function(str) {
        // extract content type and base64 payload from original string
        var pos = str.indexOf(';base64,');
        var type = str.substring(5, pos);
        var b64 = str.substr(pos + 8);

        // decode base64
        var imageContent = atob(b64);

        // create an ArrayBuffer and a view (as unsigned 8-bit)
        var buffer = new ArrayBuffer(imageContent.length);
        var view = new Uint8Array(buffer);

        // fill the view, using the decoded base64
        for (var n = 0; n < imageContent.length; n++) {
            view[n] = imageContent.charCodeAt(n);
        }

        // convert ArrayBuffer to Blob
        var blob = new Blob([buffer], { type: type });

        return blob;
    };

    var getImage = function(input, croppie) {
        if (input.files && input.files[0]) {
            var reader = new FileReader();
            reader.onload = function(e) {
                croppie.bind({
                    url: e.target.result
                });
            };
            reader.readAsDataURL(input.files[0]);
        }
    };

    //end Utiliy
    //-----------------------------------------------------

    var ajaxFormReset = function (formId) {
        var id = $("#" + formId);
        if (id.length > 0) {
            $(id).FormReset();
            $(id).FormValidationReset();
        }
    };

    var ajaxFormPostSuccess = function (result) {
        App.LoaderHide();
        console.log(result);
        if (result.success == false) {
            App.ToastrNotifierError(result.error);
        }
        else {
            App.ToastrNotifierSuccess(result.error);
        }
    };

    return {
        Init: initializeApp,
        LoaderShow: loaderShow,
        LoaderHide: loaderHide,

        SendAjaxRequest: sendAjaxRequest,
        LoadDropdown: loadDropdown,

        AppLayoutMessage: appLayoutMessage,
        AppLayoutMessageById: appLayoutMessageById,
        AppLayoutMessageInfoById: appLayoutMessageInfoById,
        AppLayoutMessageErrorById: appLayoutMessageErrorById,
        AppLayoutMessageSuccessById: appLayoutMessageSuccessById,

        ToastrNotifier: toastrNotifier,
        ToastrNotifierInfo: toastrNotifierInfo,
        ToastrNotifierError: toastrNotifierError,
        ToastrNotifierSuccess:toastrNotifierSuccess,

        DisplayLength: displayLength,

        GetAjax: getAjax,
        GetDataTableConfiguration: getDataTableConfiguration,

        AjaxJsonGet: ajaxJsonGet,
        AjaxJsonGetWithParam: ajaxJsonGetWithParam,
        AjaxJsonPost: ajaxJsonPost,
        AjaxJsonPostForDelete: ajaxJsonPostForDelete,
        AjaxJsonPostWithParam: ajaxJsonPostWithParam,
        AjaxJsonPostForDeleteWithParam: ajaxJsonPostForDeleteWithParam,
        ToCamelCase: toCamelCase,
        InitializePopover: initializePopover,
        AppAreaName: appAreaName,
        GetAndSetLocation: getAndSetLocation,
        GetUserLocalTimeZone: getUserLocalTimeZone,

        Base64ImageToBlob: base64ImageToBlob,
        GetImage: getImage,

        AjaxFormReset: ajaxFormReset,
        AjaxFormPostSuccess: ajaxFormPostSuccess

    };
}();

$(document).ready(function () {

    App.Init();

});

(function ($) {

    //re-set all client validation given a jQuery selected form or child
    $.fn.FormValidationReset = function () {

        var $form = this.closest('form');

        //reset jQuery Validate's internals
        $form.validate().resetForm();

        //reset unobtrusive validation summary, if it exists
        $form.find("[data-valmsg-summary=true]")
            .removeClass("validation-summary-errors")
            .addClass("validation-summary-valid")
            .find("ul").empty();

        //reset unobtrusive field level, if it exists
        $form.find("[data-valmsg-replace]")
            .removeClass("field-validation-error")
            .addClass("field-validation-valid")
            .empty();

        return $form;
    };

    //reset a form given a jQuery selected form or a child
    //by default validation is also reset
    $.fn.FormReset = function (resetValidation) {
        var $form = this.closest('form');

        $form[0].reset();

        if (resetValidation == undefined || resetValidation) {
            $form.FormValidationReset();
        }

        return $form;
    }
})(jQuery);