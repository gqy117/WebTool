describe("head.service.test", function () {
    var service;

    // setup
    beforeEach(inject(function(headService) {
        service = headService;
    }));


    // test cases

    it("brand() should call 'Track' method", function () {
        service.brand();

        expect($window.Track).toHaveBeenCalled();
    });

    it("myProfile() should call 'Track' method", function () {
        service.myProfile();

        expect($window.Track).toHaveBeenCalled();
    });

    it("logOut() should call 'Track' method, and set href = '/Account/Login'", function () {
        service.logOut();

        expect($window.Track).toHaveBeenCalled();
        expect($window.location.href).toEqual('/Account/Login');
    });
});