var M;
(function (M) {
    "use strict";
    var activePanel = (function () {
        // constructor
        function activePanel() {
            this.dashboard = false;
            this.wol = false;
        }
        return activePanel;
    }());
    M.activePanel = activePanel;
})(M || (M = {}));

var M;
(function (M) {
    "use strict";
    var sidebarService = (function () {
        // constructor
        function sidebarService($window, gaService) {
            this.$window = $window;
            this.gaService = gaService;
            // properties
            this.activePanel = new M.activePanel();
        }
        // methods
        sidebarService.prototype.LeftPanel_Dashboard = function () {
            this.gaService.Track("Index", "LeftPanel_Dashboard");
            this.$window.location.href = this.$window.App.baseUrl + "Home/Index";
        };
        sidebarService.prototype.LeftPanel_WOL = function () {
            this.gaService.Track("Index", "LeftPanel_WOL");
            this.$window.location.href = this.$window.App.baseUrl + "Tool/WOL";
        };
        // inject
        sidebarService.$inject = ["$window", "gaService"];
        return sidebarService;
    }());
    M.sidebarService = sidebarService;
    // init
    angular.module("mainApp")
        .service("sidebarService", sidebarService);
})(M || (M = {}));

var M;
(function (M) {
    "use strict";
    var sidebarController = (function () {
        // constructor
        function sidebarController(sidebarService) {
            this.sidebarService = sidebarService;
            this.activePanel = this.sidebarService.activePanel;
        }
        // methods
        sidebarController.prototype.LeftPanel_Dashboard_Click = function () {
            this.sidebarService.LeftPanel_Dashboard();
        };
        sidebarController.prototype.LeftPanel_WOL_Click = function () {
            this.sidebarService.LeftPanel_WOL();
        };
        // inject
        sidebarController.$inject = ["sidebarService"];
        return sidebarController;
    }());
    M.sidebarController = sidebarController;
    // init
    angular.module("mainApp")
        .controller("sidebarController", sidebarController);
})(M || (M = {}));

var M;
(function (M) {
    "use strict";
    var headService = (function () {
        // constructor
        function headService($window, gaService) {
            this.$window = $window;
            this.gaService = gaService;
        }
        // methods
        headService.prototype.brand = function () {
            this.gaService.Track("IndexHead", "brand");
        };
        headService.prototype.myProfile = function () {
            this.gaService.Track("IndexHead", "MyProfile");
        };
        headService.prototype.logOut = function () {
            this.gaService.Track("IndexHead", "LogOut");
            this.$window.location.href = this.$window.App.baseUrl + "Account/Login";
        };
        // inject
        headService.$inject = ["$window", "gaService"];
        return headService;
    }());
    M.headService = headService;
    // init
    angular.module("mainApp")
        .service("headService", headService);
})(M || (M = {}));

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

var M;
(function (M) {
    "use strict";
    var languageBarService = (function () {
        // constructor
        function languageBarService($window, jQuery, gaService) {
            this.$window = $window;
            this.jQuery = jQuery;
            this.gaService = gaService;
        }
        // methods
        languageBarService.prototype.changeLanguage = function (languageCode) {
            this.gaService.Track("IndexHead", "ChangeLanguage");
            console.log("Tracking ChangeLanguage...");
            this.jQuery.cookie("WebToolLanguage", languageCode, {
                expires: 10000,
                path: "/"
            });
            this.$window.location.reload();
        };
        // inject
        languageBarService.$inject = ["$window", "jQuery", "gaService"];
        return languageBarService;
    }());
    M.languageBarService = languageBarService;
    // init
    angular.module("mainApp")
        .service("languageBarService", languageBarService);
})(M || (M = {}));

var M;
(function (M) {
    "use strict";
    var languageBarController = (function () {
        // constructor
        function languageBarController(languageBarService) {
            this.languageBarService = languageBarService;
        }
        // methods
        languageBarController.prototype.changeLanguage = function (languageCode) {
            this.languageBarService.changeLanguage(languageCode);
        };
        // inject
        languageBarController.$inject = ["languageBarService"];
        return languageBarController;
    }());
    M.languageBarController = languageBarController;
    // init
    angular.module("mainApp")
        .controller("languageBarController", languageBarController);
})(M || (M = {}));