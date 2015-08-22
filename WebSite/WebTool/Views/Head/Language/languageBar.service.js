(function () {
    "use strict";

    angular
    .module('mainApp')
    .factory('languageBarService', languageBarService);

    languageBarService.$inject = ['$window'];

    function languageBarService($window) {
        return {
            changeLanguage: function _changeLanguage(languageCode) {
                $window.Track('IndexHead', 'ChangeLanguage');
                console.log('Tracking ChangeLanguage...');

                $window.jQuery.cookie("WebToolLanguage", languageCode, {
                    expires: 10000,
                    path: '/'
                });

                $window.location.reload();
            }
        };
    }
}());