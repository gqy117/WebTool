(function (window) {
    "use strict";

    angular
    .module('mainApp')
    .factory('headService', headService);

    function headService() {
        return {
            brand: function _brand_() {
                window.Track('IndexHead', 'brand');
            },

            myProfile: function _myProfile() {
                window.Track('IndexHead', 'MyProfile');
            },

            logOut: function _logOut() {
                window.Track('IndexHead', 'LogOut');
                window.location.href = App.baseUrl + "Account/Login";
            }
        };
    }
}(window));