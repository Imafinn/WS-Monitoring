$(function () {
    var hub = $.connection.serviceController;

    hub.client.onServerStatusChanged(service) {
    
    }

    $.connection.hub.start().done(function () {

    });
});