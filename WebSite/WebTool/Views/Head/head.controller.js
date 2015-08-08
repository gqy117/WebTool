(function () {
    angular.module("topApp")
         .controller('headController', ['headService', headController]);

    function headController(headService) {
        var head = headService;

        this.brand_Click = head.brand;
        this.myProfile_Click = head.myProfile;
        this.logOut_Click = head.logOut;
    }
}());


function _indexLayout_On_Ready() {
    jQuery(document).ready(function () {
        App.init(); // init the rest of plugins and elements
        UIModals.init();
    });
}
Add_JS_Content('_indexLayout_On_Ready();');


function LeftPanel_Dashboard_Click() {
    Track('Index', 'LeftPanel_Dashboard');
    window.location.href = App.baseUrl + 'Home/Index';

}
function LeftPanel_WOL_Click() {
    Track('Index', 'LeftPanel_WOL');
    window.location.href = App.baseUrl + 'Tool/WOL';
}