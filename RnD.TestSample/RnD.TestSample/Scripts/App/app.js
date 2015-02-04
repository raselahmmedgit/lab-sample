$(document).ajaxStart(function () {
    $('#appLoading').show();
}).ajaxStop(function () {
    $('#appLoading').hide();
}).ajaxError(function () {
    $('#appLoading').hide();
}).ajaxComplete(function () {
    $('#appLoading').hide();
}).ajaxSuccess(function () {
    $('#appLoading').hide();
});