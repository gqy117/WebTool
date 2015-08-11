(function () {
    angular.module("mainApp")
         .controller('languageBarController', languageBarController);

    languageBarController.$inject = ['languageBarService'];

    function languageBarController(languageBarService) {

        this.changeLanguage = languageBarService.changeLanguage;
    }
}());