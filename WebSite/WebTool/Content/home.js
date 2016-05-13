var M;
(function (M) {
    "use strict";
    var homeHeaderPanelService = (function () {
        // constructor
        function homeHeaderPanelService(gaService) {
            this.gaService = gaService;
        }
        // methods
        homeHeaderPanelService.prototype.navigation1 = function () {
            this.gaService.Track("Index", "Home");
            console.log("Tracking Home...");
        };
        homeHeaderPanelService.prototype.navigation2 = function () {
            this.gaService.Track("Index", "Dashboard");
            console.log("Tracking Dashboard...");
        };
        // inject
        homeHeaderPanelService.$inject = ["gaService"];
        return homeHeaderPanelService;
    }());
    M.homeHeaderPanelService = homeHeaderPanelService;
    // init
    angular.module("mainApp")
        .service("headerPanelService", homeHeaderPanelService);
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
    var homeService = (function () {
        function homeService() {
        }
        return homeService;
    }());
    M.homeService = homeService;
    // init
    angular.module("mainApp")
        .service("homeService", homeService);
})(M || (M = {}));

var M;
(function (M) {
    "use strict";
    var homeController = (function () {
        // constructor
        function homeController(homeService, sidebarService) {
            this.homeService = homeService;
            this.sidebarService = sidebarService;
            this.activePanel = this.sidebarService.activePanel;
            this.activePanel.dashboard = true;
        }
        // inject
        homeController.$inject = ["homeService", "sidebarService"];
        return homeController;
    }());
    M.homeController = homeController;
    // init
    angular.module("mainApp")
        .controller("homeController", homeController);
})(M || (M = {}));



var M;
(function (M) {
    "use strict";
    var wakeUpPanelService = (function () {
        // constructor
        function wakeUpPanelService($window, $http, gaService) {
            this.$window = $window;
            this.$http = $http;
            this.gaService = gaService;
        }
        // methods
        wakeUpPanelService.prototype.wakeUp = function (wakeUpStatus) {
            this.gaService.Track("Index", "Panel3_ViewMore");
            this.$http.post(this.$window.App.baseUrl + "Tool/WakeUp")
                .then(function () {
                wakeUpStatus.isShowAlertWakeUpSuccess = true;
            });
        };
        wakeUpPanelService.prototype.showSuccessMessage = function (wakeUpStatus) {
            wakeUpStatus.isShowAlertWakeUpSuccess = true;
        };
        wakeUpPanelService.prototype.hideSuccessMessage = function (wakeUpStatus) {
            wakeUpStatus.isShowAlertWakeUpSuccess = false;
        };
        // inject
        wakeUpPanelService.$inject = ["$window", "$http", "gaService"];
        return wakeUpPanelService;
    }());
    M.wakeUpPanelService = wakeUpPanelService;
    // init
    angular.module("mainApp")
        .service("wakeUpPanelService", wakeUpPanelService);
})(M || (M = {}));

var M;
(function (M) {
    "use strict";
    var wakeUpPanelController = (function () {
        // constructor
        function wakeUpPanelController(wakeUpPanelService) {
            this.wakeUpPanelService = wakeUpPanelService;
            // properties
            this.isShowAlertWakeUpSuccess = false;
        }
        // methods
        wakeUpPanelController.prototype.wakeUp_Click = function () {
            var context = this;
            this.wakeUpPanelService.wakeUp(context);
        };
        wakeUpPanelController.prototype.hideSuccessMessage = function () {
            var context = this;
            this.wakeUpPanelService.hideSuccessMessage(context);
        };
        wakeUpPanelController.prototype.showSuccessMessage = function () {
            var context = this;
            this.wakeUpPanelService.showSuccessMessage(context);
        };
        // inject
        wakeUpPanelController.$inject = ["wakeUpPanelService"];
        return wakeUpPanelController;
    }());
    M.wakeUpPanelController = wakeUpPanelController;
    // init
    angular.module("mainApp")
        .controller("wakeUpPanelController", wakeUpPanelController);
})(M || (M = {}));