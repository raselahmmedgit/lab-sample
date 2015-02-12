//-----------------------------------------------------
//start Ajax Get Methods

function AjaxJsonGet(getUrl) {

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

function AjaxJsonGetWithParam(getUrl, paramValue) {

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

function AjaxJsonPost(postUrl) {

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

function AjaxJsonPostForDelete(postUrl) {

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

function AjaxJsonPostWithParam(postUrl, paramValue) {

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

function AjaxJsonPostForDeleteWithParam(postUrl, paramValue) {

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