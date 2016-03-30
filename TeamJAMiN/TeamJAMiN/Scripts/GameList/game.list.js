
$(function () {
	var listManager = $.connection.gameListHub;
	listManager.client.updateListItem = function (openUrl, gameId) {
		alert('data: '+ openUrl + ', ' + gameId);
		$('#start-open-button-container-' + gameId).append('<a href="' + openUrl + '" class="btn-sm btn-success">Open</a>');
	};
	$.connection.hub.logging = true;
	$.connection.hub.start().done(function () {
		listManager.server.activate();
	});
});