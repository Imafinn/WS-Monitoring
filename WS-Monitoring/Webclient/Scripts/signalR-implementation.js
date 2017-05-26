var graphActive = {};
var data = {};
var graph = null;
var i = null;
var hoverdetail = null;

$(function () {
	var hub = $.connection.serviceController;
	console.log(hub);
	$('.button-start').each(function () {
		this.onclick = function () { startService(getServerId(this.id)); };
	});

	$('.button-restart').each(function () {
		this.onclick = function () { restartService(getServerId(this.id)); };
	});

	$('.button-stop').each(function () {
		this.onclick = function () { stopService(getServerId(this.id)); };
	});

	hub.client.onServiceStatusChanged = function (id, status) {
		console.log("ID:" + id + ",STATUS:" + status);
		var divId = '#section_' + id;
		var toUpdateDiv = $(divId);
		var statusText = toUpdateDiv.find($('#status-' + id))[0];
		statusText.innerHTML = status;
		statusText.className = 'status_' + status;

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


	hub.client.onPerformanceChanged = function (id, cpu, ram, servicename) {

		var divId = '#section_' + id;
		var toUpdateDiv = $(divId);
		var cpuText = toUpdateDiv.find($('#cpu-' + id))[0];
		var ramText = toUpdateDiv.find($('#ram-' + id))[0];

		console.log(cpu);
		console.log(ram);

		cpuText.innerHTML = cpu + " %";
		ramText.innerHTML = ram + " KB";

		/*if (!graphActive[id]) {
			console.log("hoihoi");
			i = 15;
			data = [{ x: 0, y: 0 }, { x: 1, y: 0 }, { x: 2, y: 0 }, { x: 3, y: 0 }, { x: 4, y: 0 },
			{ x: 5, y: 0 }, { x: 6, y: 0 }, { x: 7, y: 0 }, { x: 8, y: 0 }, { x: 9, y: 0 }, { x: 10, y: 0 },
			{ x: 11, y: 0 }, { x: 12, y: 0 }, { x: 13, y: 0 }, { x: 14, y: 0 }, { x: 15, y: 0 }];

			graph = new Rickshaw.Graph({
				element: document.querySelector('#graph-' + id),
				width: 400,
				height: 200,
				renderer: 'line',
				series: [{
					color: 'steelblue',
					data: data,
					name: servicename
				}]
			});

			graph.render();
			graphActive[id] = true;

			hoverDetail = new Rickshaw.Graph.HoverDetail({
				graph: graph
			});
			
		}

		console.log("x: " + i + ", y: " + ram)
		i++
		data.shift();
		data.push({ x: i, y: parseInt(ram) });
		graph.update();
		graph.render();*/

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
		return objectId.substr(objectId.indexOf('-') + 1, 1);
	}
});