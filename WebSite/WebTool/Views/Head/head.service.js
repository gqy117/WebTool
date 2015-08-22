(function () {
    "use strict";

    angular
    .module('mainApp')
    .factory('headService', headService);

    headService.$inject = ['$window'];

    function headService($window) {
        return {
            brand: function _brand_() {
                $window.Track('IndexHead', 'brand');
            },

            myProfile: function _myProfile() {
                $window.Track('IndexHead', 'MyProfile');
            },

            logOut: function _logOut() {
                $window.Track('IndexHead', 'LogOut');
                $window.location.href = $window.App.baseUrl + "Account/Login";
            }
        };
    }
}());