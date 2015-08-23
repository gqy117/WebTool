describe("sidebar.service.test", function () {
    var service;

    // setup
    beforeEach(inject(function (sidebarService) {
        service = sidebarService;
    }));


    it("LeftPanel_Dashboard should set href to '/Home/Index'", function () {
        service.LeftPanel_Dashboard();

        expect($window.Track).toHaveBeenCalled();
        expect($window.location.href).toEqual('/Home/Index');
    });

    it("LeftPanel_WOL should set href to '/Tool/WOL'", function () {
        service.LeftPanel_WOL();

        expect($window.Track).toHaveBeenCalled();
        expect($window.location.href).toEqual('/Tool/WOL');
    });
});