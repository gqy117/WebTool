describe("head.service.test", function () {

    sharedSetup();

    it("brand should call 'Track' method", inject(function (headService) {
        var service = headService;

        service.brand();

        expect($window.Track).toHaveBeenCalled();
    }));

    it("myProfile should call 'Track' method", inject(function (headService) {
        var service = headService;

        service.myProfile();

        expect($window.Track).toHaveBeenCalled();
    }));

    it("logOut should call 'Track' method, and set href = '/Account/Login'", inject(function (headService) {
        var service = headService;

        service.logOut();

        expect($window.Track).toHaveBeenCalled();
        expect($window.location.href).toEqual('/Account/Login');
    }));
});