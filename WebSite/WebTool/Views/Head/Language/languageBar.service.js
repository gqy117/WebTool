(function (window) {
    "use strict";

    angular
    .module('mainApp')
    .factory('languageBarService', languageBarService);

    function languageBarService() {
        return {
            changeLanguage: function _changeLanguage(languageCode) {
                window.Track('IndexHead', 'ChangeLanguage');

                $.cookie("WebToolLanguage", languageCode, {
                    expires: 10000,
                    path: '/'
                });

                location.reload();
            }
        };
    }
}(window));