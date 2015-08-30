module M {
    "use strict";
    import WindowService = angular.IWindowService;

    export class sidebarService {
        // inject
        static $inject = ["$window"];

        // properties
        public activePanel: activePanel = new activePanel();

        // constructor
        constructor(private $window: WindowService) { }

        // methods
        public LeftPanel_Dashboard(): void {
            this.$window.Track("Index", "LeftPanel_Dashboard");
            this.$window.location.href = this.$window.App.baseUrl + "Home/Index";
        }

        public LeftPanel_WOL(): void {
            this.$window.Track("Index", "LeftPanel_WOL");
            this.$window.location.href = this.$window.App.baseUrl + "Tool/WOL";
        }
    }

    // init
    angular.module("mainApp")
        .service("sidebarService", sidebarService);
}