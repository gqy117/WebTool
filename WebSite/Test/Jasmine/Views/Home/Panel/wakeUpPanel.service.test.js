describe("wakeUpPanel.service.test", function () {
    var service;

    // setup
    beforeEach(inject(function (wakeUpPanelService) {
        service = wakeUpPanelService;
    }));


    // test cases
    it("hideMessage() should set isShowAlertWakeUpSuccess to false", function () {
        service.hideMessage();
        expect(service.isShowAlertWakeUpSuccess).toEqual(false);
    });

    it("wakeUp() should post '/Tool/WakeUp' as url, and call 'Track'", function () {
        service.wakeUp();

        $httpBackend.flush();

        expect(service.isShowAlertWakeUpSuccess).toEqual(true);
        expect($window.Track).toHaveBeenCalled();
    });
});