describe("wakeUpPanel.service.test", function () {

    sharedSetup();

    it("hideMessage should set isShowAlertWakeUpSuccess to false", inject(function (wakeUpPanelService) {
        var service = wakeUpPanelService;

        service.hideMessage();

        expect(service.isShowAlertWakeUpSuccess).toEqual(false);
    }));

});