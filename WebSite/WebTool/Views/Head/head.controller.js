(function () {
    "use strict";

    angular.module("mainApp")
        .controller('headController', headController);

    headController.$inject = ['headService'];

    function headController(headService) {

        this.brand_Click = headService.brand;
        this.myProfile_Click = headService.myProfile;
        this.logOut_Click = headService.logOut;
    }
}());