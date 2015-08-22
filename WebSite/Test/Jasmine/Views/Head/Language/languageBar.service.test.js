describe("languageBar.service.test", function () {

    sharedSetup();

    it("changeLanguage should set cookie to 'en'", inject(function (languageBarService) {
        var controller = languageBarService;

        controller.changeLanguage('en');

        expect($window.Track).toHaveBeenCalled();
        expect($window.location.reload).toHaveBeenCalled();
    }));
});