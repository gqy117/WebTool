describe("wakeUpPanel.service.test", function () {
    "use strict";

    var service,
        wakeUpStatus;

    // setup
    beforeEach(inject(function (wakeUpPanelService) {
        service = wakeUpPanelService;
        wakeUpStatus = { isShowAlertWakeUpSuccess: null };
    }));


    // test cases
    it("wakeUp() should post '/Tool/WakeUp' as url, and call 'Track', and set isShowSuccessMessage = true", function () {
        service.wakeUp(wakeUpStatus);

        $httpBackend.flush();
        expect(wakeUpStatus.isShowAlertWakeUpSuccess).toEqual(true);
        expect(service.gaService.Track).toHaveBeenCalled();
    });

    it("showSuccessMessage() should set isShowAlertWakeUpSuccess = true", function () {
        service.showSuccessMessage(wakeUpStatus);

        expect(wakeUpStatus.isShowAlertWakeUpSuccess).toEqual(true);
    });

    it("hideSuccessMessage() should set isShowAlertWakeUpSuccess = false", function () {
        service.hideSuccessMessage(wakeUpStatus);

        expect(wakeUpStatus.isShowAlertWakeUpSuccess).toEqual(false);
    });
});