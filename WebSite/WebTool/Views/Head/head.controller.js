(function () {
    angular.module("mainApp")
         .controller('headController', ['headService', headController]);

    function headController(headService) {

        this.brand_Click = headService.brand;
        this.myProfile_Click = headService.myProfile;
        this.logOut_Click = headService.logOut;
    }
}());


function _indexLayout_On_Ready() {
    jQuery(document).ready(function () {
        App.init(); // init the rest of plugins and elements
        UIModals.init();
    });
}
_indexLayout_On_Ready();

