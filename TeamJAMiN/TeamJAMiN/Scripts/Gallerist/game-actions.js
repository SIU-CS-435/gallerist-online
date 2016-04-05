//JS file for signalR communication

$(function () {
    var actionManager = $.connection.gameActionHub;
    actionManager.client.refresh = function () {
        window.location.reload(true);
    };
    $.connection.hub.logging = true;
    $.connection.hub.start().done(function () {
        actionManager.server.activate();
    });
});