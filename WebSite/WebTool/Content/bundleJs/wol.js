var M;
(function (M) {
    "use strict";
    var wolHeaderPanelService = (function () {
        // constructor
        function wolHeaderPanelService(gaService) {
            this.gaService = gaService;
        }
        // methods
        wolHeaderPanelService.prototype.navigation1 = function () {
            this.gaService.Track("WOL", "WOL");
            console.log("Tracking WOL...");
        };
        wolHeaderPanelService.prototype.navigation2 = function () {
            this.gaService.Track("WOL", "WOL");
            console.log("Tracking WOL...");
        };
        // inject
        wolHeaderPanelService.$inject = ["gaService"];
        return wolHeaderPanelService;
    }());
    M.wolHeaderPanelService = wolHeaderPanelService;
    // init
    angular.module("mainApp")
        .service("headerPanelService", wolHeaderPanelService);
})(M || (M = {}));

var M;
(function (M) {
    "use strict";
    var headerPanelController = (function () {
        // constructor
        function headerPanelController(headerPanelService) {
            this.headerPanelService = headerPanelService;
        }
        // methods
        headerPanelController.prototype.navigation1Click = function () {
            this.headerPanelService.navigation1();
        };
        headerPanelController.prototype.navigation2Click = function () {
            this.headerPanelService.navigation2();
        };
        // inject
        headerPanelController.$inject = ["headerPanelService"];
        return headerPanelController;
    }());
    M.headerPanelController = headerPanelController;
    // init
    angular.module("mainApp")
        .service("headerPanelController", headerPanelController);
})(M || (M = {}));

var M;
(function (M) {
    "use strict";
    var wolService = (function () {
        function wolService() {
        }
        return wolService;
    }());
    M.wolService = wolService;
    // init
    angular.module("mainApp")
        .service("wolService", wolService);
})(M || (M = {}));

var M;
(function (M) {
    "use strict";
    var wolController = (function () {
        // constructor
        function wolController($window, wolService, sidebarService, myDataTableService) {
            this.$window = $window;
            this.wolService = wolService;
            this.sidebarService = sidebarService;
            this.myDataTableService = myDataTableService;
            this.activePanel = this.sidebarService.activePanel;
            this.activePanel.wol = true;
            this.myDataTableService.createTable("#WOLTable", this.$window.App.baseUrl + "Tool/WOLTable");
        }
        // inject
        wolController.$inject = ["$window", "wolService", "sidebarService", "myDataTableService"];
        return wolController;
    }());
    M.wolController = wolController;
    // init
    angular.module("mainApp")
        .controller("wolController", wolController);
})(M || (M = {}));