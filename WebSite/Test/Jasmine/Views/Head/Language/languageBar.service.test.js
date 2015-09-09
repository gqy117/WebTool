describe("languageBar.service.test", function () {
    "use strict";

    var service;

    beforeEach(inject(function (languageBarService) {
        service = languageBarService;
    }));


    it("changeLanguage() should set cookie to 'en'", function () {
        service.changeLanguage('en');
        
        expect($window.Track).toHaveBeenCalled();
        expect($window.jQuery.cookie).toHaveBeenCalled();
        expect($window.location.reload).toHaveBeenCalled();
    });
});