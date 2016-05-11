var M;
(function (M) {
    "use strict";
    var headController = (function () {
        // constructor
        function headController(headService) {
            this.headService = headService;
        }
        // methods
        headController.prototype.brand_Click = function () {
            this.headService.brand();
        };
        headController.prototype.myProfile_Click = function () {
            this.headService.myProfile();
        };
        headController.prototype.logOut_Click = function () {
            this.headService.logOut();
        };
        // inject
        headController.$inject = ["headService"];
        return headController;
    }());
    M.headController = headController;
    // init
    angular.module("mainApp")
        .controller("headController", headController);
})(M || (M = {}));
