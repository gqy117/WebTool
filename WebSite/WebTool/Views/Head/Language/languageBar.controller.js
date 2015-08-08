(function () {
    angular.module("mainApp")
         .controller('languageBarController', ['languageBarService', languageBarController]);

    function languageBarController(languageBarService) {

        this.changeLanguage = languageBarService.changeLanguage;
    }
}());