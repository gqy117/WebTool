"use strict";
var M;
(function (M) {
    var wolController = (function () {
        // constructor
        function wolController($window, wolService, sidebarService, myDataTableService) {
            this.$window = $window;
            this.wolService = wolService;
            this.sidebarService = sidebarService;
            this.myDataTableService = myDataTableService;
            this.activePanel = this.sidebarService.activePanel;
            this.activePanel.wol = true;
            this.myDataTableService.createTable("#WOLTable", this.$window.App.baseUrl + 'Tool/WOLTable');
        }
        // inject
        wolController.$inject = ["$window", "wolService", "sidebarService", "myDataTableService"];
        return wolController;
    })();
    M.wolController = wolController;
    // init
    angular.module("mainApp")
        .controller("wolController", wolController);
})(M || (M = {}));
