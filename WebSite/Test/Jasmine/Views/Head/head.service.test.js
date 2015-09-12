describe("head.service.test", function () {
    "use strict";

    var service;

    // setup
    beforeEach(inject(function(headService) {
        service = headService;
    }));


    // test cases

    it("brand() should call 'Track' method", function () {
        service.brand();

        expect(service.gaService.Track).toHaveBeenCalled();
    });

    it("myProfile() should call 'Track' method", function () {
        service.myProfile();

        expect(service.gaService.Track).toHaveBeenCalled();
    });

    it("logOut() should call 'Track' method, and set href = '/Account/Login'", function () {
        service.logOut();

        expect(service.gaService.Track).toHaveBeenCalled();
        expect($window.location.href).toEqual('/Account/Login');
    });
});