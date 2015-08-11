(function () {
    angular.module("mainApp")
         .controller('headController', headController);

    headController.$inject = ['headService'];

    function headController(headService) {

        this.brand_Click = headService.brand;
        this.myProfile_Click = headService.myProfile;
        this.logOut_Click = headService.logOut;
    }


    jQuery(document).ready(function () {
        App.init(); // init the rest of plugins and elements
        UIModals.init();
    });

}());