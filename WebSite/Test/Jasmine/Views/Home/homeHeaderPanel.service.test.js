describe("headerPanelService.service.test", function () {
    var service;

    // setup
    beforeEach(inject(function (headerPanelService) {
        service = headerPanelService;
    }));


    it("navigation1() should call 'Track'", inject(function (headerPanelService) {
        service.navigation1();

        expect($window.Track).toHaveBeenCalled();
    }));

    it("navigation2() hould call 'Track'", inject(function (headerPanelService) {
        service.navigation2();

        expect($window.Track).toHaveBeenCalled();
    }));
});