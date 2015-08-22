describe("headerPanelService.service.test", function () {

    sharedSetup();

    it("navigation1 should call 'Track'", inject(function (headerPanelService) {
        var service = headerPanelService;

        service.navigation1();

        expect($window.Track).toHaveBeenCalled();
    }));

    it("navigation2 hould call 'Track'", inject(function (headerPanelService) {
        var service = headerPanelService;

        service.navigation2();

        expect($window.Track).toHaveBeenCalled();
    }));
});