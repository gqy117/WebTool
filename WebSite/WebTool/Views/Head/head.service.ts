module M {
    "use strict";
    import WindowService = angular.IWindowService;

    export class headService {
        // inject
        static $inject = ["$window", "gaService"];

        // constructor
        constructor(private $window: WindowService, private gaService: gaService) { }

        // methods
        public brand(): void {
            this.gaService.Track("IndexHead", "brand");
        }

        public myProfile(): void {
            this.gaService.Track("IndexHead", "MyProfile");
        }

        public logOut(): void {
            this.gaService.Track("IndexHead", "LogOut");
            this.$window.location.href = this.$window.App.baseUrl + "Account/Login";
        }
    }

    // init
    angular.module("mainApp")
        .service("headService", headService);
}