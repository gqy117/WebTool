"use strict";
var M;
(function (M) {
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
        headController.$inject = ["headService"];
        return headController;
    })();
    M.headController = headController;
})(M || (M = {}));

// init
angular.module("mainApp").controller("headController", M.headController);
//# sourceMappingURL=head.controller.js.map
