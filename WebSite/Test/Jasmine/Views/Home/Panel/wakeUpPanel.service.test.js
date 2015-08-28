describe("wakeUpPanel.service.test", function () {
    var service;

    // setup
    beforeEach(inject(function (wakeUpPanelService) {
        service = wakeUpPanelService;
    }));


    // test cases
    it("wakeUp() should post '/Tool/WakeUp' as url, and call 'Track'", function () {
        service.wakeUp(function () { });

        $httpBackend.flush();

        expect($window.Track).toHaveBeenCalled();
    });
});