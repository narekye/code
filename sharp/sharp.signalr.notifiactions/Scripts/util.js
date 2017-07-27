$(function () {
	// alert($.connection);
	var notificationhub = $.connection.notificationHub;

	notificationhub.client.displayMessage = function (message) {

		$('#notification').html(message);
	};
	$.connection.hub.start();
});