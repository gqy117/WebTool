(function () {
    angular
    .module('mainApp')
    .factory('languageBarService', languageBarService);

    function languageBarService() {
        return {
            changeLanguage: function _changeLanguage(languageCode) {
                Track('IndexHead', 'ChangeLanguage');
                $.cookie("WebToolLanguage", languageCode, {
                    expires: 10000,
                    path: '/'
                });
                location.reload();
            }
        };
    }
}());