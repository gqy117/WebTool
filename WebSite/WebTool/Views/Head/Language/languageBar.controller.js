"use strict";
var M;
(function (M) {
    var languageBarController = (function () {
        // constructor
        function languageBarController(languageBarService) {
            this.languageBarService = languageBarService;
        }
        // methods
        languageBarController.prototype.changeLanguage = function (languageCode) {
            this.languageBarService.changeLanguage(languageCode);
        };
        // inject
        languageBarController.$inject = ["languageBarService"];
        return languageBarController;
    })();
    M.languageBarController = languageBarController;
    // init
    angular.module("mainApp")
        .controller("languageBarController", languageBarController);
})(M || (M = {}));
