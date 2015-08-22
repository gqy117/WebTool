describe("wakeUpPanel.service.test", function () {

    sharedSetup();

    it("hideMessage() should set isShowAlertWakeUpSuccess to false", inject(function (wakeUpPanelService) {
        var service = wakeUpPanelService;

        service.hideMessage();
        expect(service.isShowAlertWakeUpSuccess).toEqual(false);
    }));

    it("wakeUp() should post '/Tool/WakeUp' as url, and call 'Track'", inject(function (wakeUpPanelService) {
        var service = wakeUpPanelService;

        service.wakeUp();

        expect($http.post).toHaveBeenCalledWith('/Tool/WakeUp');
        expect($window.Track).toHaveBeenCalled();
    }));
});