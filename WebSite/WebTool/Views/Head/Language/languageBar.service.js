var M;
(function (M) {
    "use strict";
    var languageBarService = (function () {
        // constructor
        function languageBarService($window, jQuery) {
            this.$window = $window;
            this.jQuery = jQuery;
        }
        // methods
        languageBarService.prototype.changeLanguage = function (languageCode) {
            this.$window.Track("IndexHead", "ChangeLanguage");
            console.log("Tracking ChangeLanguage...");
            this.jQuery.cookie("WebToolLanguage", languageCode, {
                expires: 10000,
                path: "/"
            });
            this.$window.location.reload();
        };
        // inject
        languageBarService.$inject = ["$window", "jQuery"];
        return languageBarService;
    })();
    M.languageBarService = languageBarService;
    // init
    angular.module("mainApp")
        .service("languageBarService", languageBarService);
})(M || (M = {}));
