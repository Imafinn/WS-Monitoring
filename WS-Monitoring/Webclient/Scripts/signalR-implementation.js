$(function () {
    var hub = $.connection.serviceController;
    console.log(hub);
    $('.button-start').each(function () {
        this.onclick = function () { startService(getServerId(this.id)) };
    });

    $('.button-restart').each(function () {
        this.onclick = function () { restartService(getServerId(this.id)) };
    });

    $('.button-stop').each(function () {
        this.onclick = function () { stopService(getServerId(this.id)) };
    });

    hub.client.onServiceStatusChanged = function (id, status) {
        console.log("ID:" + id + ",STATUS:" + status);
        var divId = '#section_' + id;
        var toUpdateDiv = $(divId);
        console.log(toUpdateDiv);
        var statusFont = toUpdateDiv.find($('.status'));
        console.log(statusFont);
        statusFont.innerHTML = status;
    };

    $.connection.hub.start().done(function () {

    });

    function startService(id) {
        hub.server.startService(id);
    }

    function restartService(id) {
        hub.server.restartService(id);
    }

    function stopService(id) {
        hub.server.stopService(id);
    }

    function getServerId(objectId) {
        return objectId.substr(objectId.indexOf('-')+1, 1);
    }
});