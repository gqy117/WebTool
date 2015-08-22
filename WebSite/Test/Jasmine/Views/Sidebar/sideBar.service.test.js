describe("sidebar.service.test", function () {

    sharedSetup();

    it("LeftPanel_Dashboard should set href to '/Home/Index'", inject(function (sidebarService) {
        var service = sidebarService;

        service.LeftPanel_Dashboard();

        expect($window.Track).toHaveBeenCalled();
        expect($window.location.href).toEqual('/Home/Index');
    }));

    it("LeftPanel_WOL should set href to '/Tool/WOL'", inject(function (sidebarService) {
        var service = sidebarService;

        service.LeftPanel_WOL();

        expect($window.Track).toHaveBeenCalled();
        expect($window.location.href).toEqual('/Tool/WOL');
    }));
});