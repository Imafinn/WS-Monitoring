function updatePerformance (objectId, cpuField, ramField) {
    const hub = $.connection.performanceController;
    console.log(hub);
    
    $.connection.hub.start().done(function () {

    });

    const service = hub.server.getServiceById(objectId);

    console.log(service);
    /*
    cpuField.innerHTML = service.PerformanceCPU;
    ramField.innerHTML = service.PerformanceRAM;
    */
});
