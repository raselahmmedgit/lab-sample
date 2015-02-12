//-----------------------------------------------------
//start Common
function AppCommonModalBegin() {

	OpenAppProgressModal();

}

function AppCommonModalComplete() {

	CloseAppProgressModal();

}

//function AppCommonModalSuccess() {

//    var updateTargetIdValue = $("#updateTargetId").html().trim();

//    var updateTargetIdValueList = updateTargetIdValue.split("|");

//    var statusValue = updateTargetIdValueList[0];
//    var messageTypeValue = updateTargetIdValueList[1];
//    var messageTextValue = updateTargetIdValueList[2];

//    if (statusValue == "True") {

//        //close bootstrap modal
//        CloseAppCommonModal();

//        LoadAppMessageModalForAjaxSuccess(messageTypeValue, messageTextValue);

//        DataTableRefreshInIndexPage(); //Have to add index page
//    }
//    else {


//        //kendo ui progress modal close
//        CloseAppProgressModal();

//        $("#updateTargetId").html("");
//        $("#updateTargetId").html(messageTextValue);
//        $("#updateTargetId").show();
//    }
//}

function AppCommonModalSuccess() {

	var updateTargetIdValue = $("#updateTargetId").html().trim();

	var updateTargetIdValueList = updateTargetIdValue.split("|");

	var statusValue = updateTargetIdValueList[0];
	var actionName = updateTargetIdValueList[1];
	var messageTypeValue = updateTargetIdValueList[2];
	var messageTextValue = updateTargetIdValueList[3];

	if (statusValue == "True") {

		if (actionName == "Add") {

			$("#updateTargetId").html("");
			$('#updateTargetId').removeClass('callout-warning');
			$('#updateTargetId').addClass('callout-info');
			$("#updateTargetId").html(messageTextValue);
			$("#updateTargetId").show();

		}
		else if (actionName == "Edit") {

			//close bootstrap modal
			CloseAppCommonModal();

			LoadAppMessageModalForAjaxSuccess(messageTypeValue, messageTextValue);
		}

		DataTableRefreshInIndexPage(); //Have to add index page
	}
	else {


		//kendo ui progress modal close
		CloseAppProgressModal();

		$("#updateTargetId").html("");
		$('#updateTargetId').removeClass('callout-info');
		$('#updateTargetId').addClass('callout-warning');
		$("#updateTargetId").html(messageTextValue);
		$("#updateTargetId").show();
	}
}

function AppCommonModalFormValidation(fromId) {

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

function LoadAddOrEditAppCommonModal(viewUrl, modalTitle, modalForm) {

	TitleAppCommonModal(modalTitle);

	$.get(viewUrl, function (data) {

		//bootstrap modal content
		ContentAppCommonModal(data);

		AppCommonModalFormValidation(modalForm);

		//bootstrap modal open
		OpenAppCommonModal();
	});

};

function LoadDetailsAppCommonModal(viewUrl, modalTitle) {

	TitleAppCommonModal(modalTitle);

	$.get(viewUrl, function (data) {

		//bootstrap modal content
		ContentAppCommonModal(data);

		//bootstrap modal open
		OpenAppCommonModal();
	});

};

function LoadAppCommonModal(viewUrl, modalTitle, modalForm) {

	TitleAppCommonModal(modalTitle);

	$.get(viewUrl, function (data) {

		//bootstrap modal content
		ContentAppCommonModal(data);

		AppCommonModalFormValidation(modalForm);

		//bootstrap modal open
		OpenAppCommonModal();
	});

};

function LoadAppCommonModalWithoutForm(viewUrl, modalTitle) {

	TitleAppCommonModal(modalTitle);

	$.get(viewUrl, function (data) {

		//bootstrap modal content
		ContentAppCommonModal(data);

		//bootstrap modal open
		OpenAppCommonModal();
	});

};

function TitleAppCommonModal(title) {

	//title bootstrap modal
	$('#appCommonModal').find("#appCommonModalTitle").html('');
	$('#appCommonModal').find("#appCommonModalTitle").html(title);
}

function ContentAppCommonModal(content) {

	//content bootstrap modal
	$('#appCommonModal').find("#appCommonModalBody").html('');
	$('#appCommonModal').find("#appCommonModalBody").html(content);

}

function OpenAppCommonModal() {

	//open bootstrap modal
	$('#appCommonModal').modal('show');

}

function CloseAppCommonModal() {

	//open bootstrap modal
	$('#appCommonModal').modal('hide');

}
//end Common
//-----------------------------------------------------

//-----------------------------------------------------
//start Delete
function LoadAppDeleteModal(viewUrl, modalTitle) {

	TitleAppDeleteModal(modalTitle);

	//hidden field value
	$("#hdDeleteId").val("");
	$("#hdDeletePostUrl").val("");
	$("#hdDeleteId").val(viewUrl);
	$("#hdDeletePostUrl").val(viewUrl);

	//bootstrap modal open
	OpenAppDeleteModal();

};

function TitleAppDeleteModal(title) {

	//title bootstrap modal
	$('#appDeleteModal').find("#appDeleteModalTitle").html('');
	$('#appDeleteModal').find("#appDeleteModalTitle").html(title);
}

function ContentAppDeleteModal(content) {

	//content bootstrap modal
	$('#appDeleteModal').find("#appDeleteModalBody").html('');
	$('#appDeleteModal').find("#appDeleteModalBody").html(content);

}

function OpenAppDeleteModal() {

	//open bootstrap modal
	$('#appDeleteModal').modal('show');

}

function CloseAppDeleteModal() {

	//open bootstrap modal
	$('#appDeleteModal').modal('hide');

}

function YesDelete() {

	var hdDeleteIdValue = $("#hdDeleteId").val().trim();
	var hdDeletePostUrlValue = $("#hdDeletePostUrl").val().trim();

	//AjaxJsonPost(hdDeletePostUrlValue);
	AjaxJsonPostForDelete(hdDeletePostUrlValue);

	//close bootstrap modal
	CloseAppDeleteModal();

}

function NoDelete() {

	$("#hdDeleteId").val("");
	$("#hdDeletePostUrl").val("");

	//close bootstrap modal
	CloseAppDeleteModal();

}
//end Delete
//-----------------------------------------------------

//-----------------------------------------------------
//start Message

//Common Message Modal with messageType, messageText
function LoadAppMessageModal(messageType, messageText) {

	var modalTitle = messageType;

	TitleAppMessageModal(modalTitle);

	var modalContent = GetAppMessageModalContent(modalTitle, messageText);

	ContentAppMessageModal(modalContent);

	//kendo ui progress modal close
	CloseAppProgressModal();

	//kendo ui message modal open
	OpenAppMessageModal();

};

//Common Message Modal with messageType, messageText for ajax success
function LoadAppMessageModalForAjaxSuccess(messageType, messageText) {

	var modalTitle = messageType;

	TitleAppMessageModal(modalTitle);

	var modalContent = GetAppMessageModalContent(modalTitle, messageText);

	ContentAppMessageModal(modalContent);

	//kendo ui message modal open
	OpenAppMessageModal();

};

//Info Message Modal
function LoadInfoAppMessageModalWithText(messageText) {

	var modalTitle = "Info";

	TitleAppMessageModal(modalTitle);

	var modalContent = GetAppMessageModalContent(modalTitle, messageText);

	ContentAppMessageModal(modalContent);

	//kendo ui progress modal close
	CloseAppProgressModal();

	//kendo ui message modal open
	OpenAppMessageModal();

};

//Warn Message Modal
function LoadWarnAppMessageModalWithText(messageText) {

	var modalTitle = "Warn";

	TitleAppMessageModal(modalTitle);

	var modalContent = GetAppMessageModalContent(modalTitle, messageText);

	ContentAppMessageModal(modalContent);

	//kendo ui progress modal close
	CloseAppProgressModal();

	//kendo ui message modal open
	OpenAppMessageModal();

};

//Success Message Modal
function LoadSuccessAppMessageModalWithText(messageText) {

	var modalTitle = "Success";

	TitleAppMessageModal(modalTitle);

	var modalContent = GetAppMessageModalContent(modalTitle, messageText);

	ContentAppMessageModal(modalContent);

	//kendo ui progress modal close
	CloseAppProgressModal();

	//kendo ui message modal open
	OpenAppMessageModal();

};

//Error Message Modal
function LoadErrorAppMessageModalWithText(messageText) {

	var modalTitle = "Error";

	TitleAppMessageModal(modalTitle);

	var modalContent = GetAppMessageModalContent(modalTitle, messageText);

	ContentAppMessageModal(modalContent);

	//kendo ui progress modal close
	CloseAppProgressModal();

	//kendo ui message modal open
	OpenAppMessageModal();

};

function GetAppMessageModalContent(messageType, messageText) {

	var content = "<div id='messageModalPage' class='messageModalPage'><div class='row'><div style='margin-bottom: 10px !important;' class='alert alert-" + messageType + "'>" + messageText + "</div> </div></div></div>";

	return content;

}

function TitleAppMessageModal(title) {

	var upperTitle = title.toLowerCase().replace(/\b[a-z]/g, function (letter) {
		return letter.toUpperCase();
	});

	//title bootstrap modal
	$('#appMessageModal').find("#appMessageModalTitle").html('');
	$('#appMessageModal').find("#appMessageModalTitle").html(upperTitle);
}

function ContentAppMessageModal(content) {

	//content bootstrap modal
	$('#appMessageModal').find("#appMessageModalBody").html('');
	$('#appMessageModal').find("#appMessageModalBody").html(content);

}

function OpenAppMessageModal() {

	//open bootstrap modal
	$('#appMessageModal').modal('show');

}

function CloseAppMessageModal() {

	//open bootstrap modal
	$('#appMessageModal').modal('hide');

}

function OkMessage() {

	//close bootstrap modal
	CloseAppMessageModal();

}

//end Message
//-----------------------------------------------------

//-----------------------------------------------------
//start Progress

function OpenAppProgressModal() {

	//open bootstrap modal
	$('#appProgressModal').modal('show');

}

function CloseAppProgressModal() {

	//open bootstrap modal
	$('#appProgressModal').modal('hide');

}

//end Progress
//-----------------------------------------------------

//-----------------------------------------------------
//start Refresh Data Tables Funtion
function DataTablesRefresh() {
	//Get Grid
	var kdGrid = $('#grid').data('kendoGrid');
	kdGrid.dataSource.read();
}

function DataTablesRefresh(gridId) {
	var _id = "#" + gridId;
	//Get Grid
	var kdGrid = $(_id).data('kendoGrid');
	kdGrid.dataSource.read();
}
//end Refresh Data Tables Funtion
//-----------------------------------------------------

//-----------------------------------------------------
//start Common, Delete, Message, Progress Funtion
function CreateAppCommonModal() {
	if ($('#appCommonModal').length == 0) {
		$(document.body).append('<div class="modal fade" id="appCommonModal" tabindex="-1" role="dialog" aria-labelledby="appCommonModalTitle" aria-hidden="true"><div class="modal-dialog"><div class="modal-content"><div class="modal-header"><button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button><h4 class="modal-title" id="appCommonModalTitle"></h4></div><div class="modal-body" id="appCommonModalBody"></div></div></div></div>');
	} else {
		$('#appCommonModal').find("#appCommonModalTitle").html('');
		$('#appCommonModal').find("#appCommonModalBody").html('');
		//$('#appCommonModal').find("#appCommonModalFooter").html('');
	}
}

function CreateAppDeleteModal() {
	if ($('#appDeleteModal').length == 0) {
	    $(document.body).append('<div class="modal fade" id="appDeleteModal" tabindex="-1" role="dialog" aria-labelledby="appDeleteModalTitle" aria-hidden="true"><div class="modal-dialog"><div class="modal-content"><div class="modal-header"><button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button><h4 class="modal-title" id="appDeleteModalTitle"></h4></div><div class="modal-body" id="appDeleteModalBody"><div id="deleteModalPage" class="deleteModalPage form-win col-xs-12"><div class="row"><input type="hidden" name="hdDeleteId" id="hdDeleteId" value="" /><input type="hidden" name="hdDeletePostUrl" id="hdDeletePostUrl" value="" /></div><div class="row"><div class="bg-warning">Do you want to delete this?</div></div></div><div class="modal-footer" id="myModalFooter"><button type="button" class="btn btn-success btn-sm btn-flat" id="btnYesDelete" name="btnYesDelete" onclick="YesDelete()"><i class="fa fa-save"></i>&nbsp;&nbsp;Yes</button><button type="button" class="btn btn-warning btn-sm btn-flat" id="btnNoDelete" name="btnNoDelete" onclick="NoDelete()"><i class="fa fa-times"></i>&nbsp;&nbsp;No</button></div></div></div></div></div>');
	} else {
		$('#appDeleteModal').find("#appDeleteModalTitle").html('');
		$('#appDeleteModal').find("#appDeleteModalBody").html('');
	}
}

function CreateAppMessageModal() {
	if ($('#appMessageModal').length == 0) {
	    $(document.body).append('<div class="modal fade" id="appMessageModal" tabindex="-1" role="dialog" aria-labelledby="appMessageModalTitle" aria-hidden="true"><div class="modal-dialog"><div class="modal-content"><div class="modal-header"><button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button><h4 class="modal-title" id="appMessageModalTitle"></h4></div><div class="modal-body" id="appMessageModalBody"></div><div class="modal-footer" id="appMessageModalFooter"><button type="button" class="btn btn-primary" data-dismiss="modal">Ok</button></div></div></div></div>');
	} else {
		$('#appMessageModal').find("#appMessageModalTitle").html('');
		$('#appMessageModal').find("#appMessageModalBody").html('');
		//$('#appMessageModal').find("#appMessageModalFooter").html('');
	}
}

function CreateAppProgressModal() {
	if ($('#appProgressModal').length == 0) {
		$(document.body).append('<div class="modal fade" id="appProgressModal" tabindex="-1" role="dialog" aria-labelledby="appProgressModalTitle" aria-hidden="true"><div class="modal-dialog"><div class="modal-content"><div class="progess-bar"><img src="../../Content/loading.gif" alt="" /></div></div></div></div>');
	} else {}
}
//end Common, Delete, Message, Progress Funtion
//-----------------------------------------------------

$(document).ready(function () {

	CreateAppCommonModal();
	CreateAppDeleteModal();
	CreateAppMessageModal();
	CreateAppProgressModal();

	//-----------------------------------------------------
	//add Common
	$('#lnkAddCommon').click(function () {

		//change the title of the dialog
		var linkObj = $(this);
		var viewUrl = linkObj.attr('href');
		var modalTitle = linkObj.attr('title');
		var modalForm = "appCommonModalForm";

		LoadAppCommonModal(viewUrl, modalTitle, modalForm);

		return false;

	});
	//-----------------------------------------------------

	//-----------------------------------------------------
	//detail Common
	$('.lnkDetailCommon').click(function () {

		//change the title of the dialog
		var linkObj = $(this);
		var viewUrl = linkObj.attr('href');
		var modalTitle = linkObj.attr('title');

		LoadAppCommonModalWithoutForm(viewUrl, modalTitle);

		return false;

	});
	//-----------------------------------------------------

	//-----------------------------------------------------
	//edit Common
	$('.lnkEditCommon').click(function () {

		//change the title of the dialog
		var linkObj = $(this);
		var viewUrl = linkObj.attr('href');
		var modalTitle = linkObj.attr('title');
		var modalForm = "appCommonModalForm";

		LoadAppCommonModal(viewUrl, modalTitle, modalForm);

		return false;

	});
	//-----------------------------------------------------

	//-----------------------------------------------------
	//delete Common
	$('.lnkDeleteCommon').click(function () {

		//change the title of the dialog
		var linkObj = $(this);
		var viewUrl = linkObj.attr('href');
		var modalTitle = linkObj.attr('title');

		LoadAppDeleteModal(viewUrl, modalTitle);

		return false;

	});
	//-----------------------------------------------------

});