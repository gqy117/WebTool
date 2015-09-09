describe("headerPanelService.service.test", function () {
    "use strict";

    var service;

    // setup
    beforeEach(inject(function (headerPanelService) {
        service = headerPanelService;
    }));


    it("navigation1() should call 'Track'", inject(function () {
        service.navigation1();

        expect($window.Track).toHaveBeenCalled();
    }));

    it("navigation2() hould call 'Track'", inject(function () {
        service.navigation2();

        expect($window.Track).toHaveBeenCalled();
    }));
});