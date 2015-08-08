(function () {
    angular
    .module('topApp')
    .factory('headService', headService);


    function headService() {
        return {
            brand: function _brand_() {
                Track('IndexHead', 'brand');
            },

            myProfile: function _myProfile() {
                Track('IndexHead', 'MyProfile');
            },

            logOut: function _logOut() {
                Track('IndexHead', 'LogOut');
                window.location.href = App.baseUrl + "Account/Login";
            }
        };
    }
}());