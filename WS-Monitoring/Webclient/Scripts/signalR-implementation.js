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
        var statusText = toUpdateDiv.find($('.status'))[0];
        statusText.innerHTML = status;

        if (status == "Running") {
            toUpdateDiv.find('.button-start')[0].disabled = true;
            toUpdateDiv.find('.button-stop')[0].disabled = false;
            toUpdateDiv.find('.button-restart')[0].disabled = false;
        } else if (status == "Stopped") {
            toUpdateDiv.find('.button-start')[0].disabled = false;
            toUpdateDiv.find('.button-stop')[0].disabled = true;
            toUpdateDiv.find('.button-restart')[0].disabled = true;
        }
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