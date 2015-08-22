describe("languageBar.service.test", function () {

    sharedSetup();

    it("changeLanguage should set cookie to 'en'", inject(function (languageBarService) {
        var service = languageBarService;

        service.changeLanguage('en');

        expect($window.Track).toHaveBeenCalled();
        expect($window.jQuery.cookie).toHaveBeenCalled();
        expect($window.location.reload).toHaveBeenCalled();
    }));
});