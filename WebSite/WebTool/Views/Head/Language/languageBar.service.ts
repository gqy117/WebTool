module M {
    "use strict";
    import WindowService = angular.IWindowService;

    export class languageBarService {
        // inject
        static $inject = ["$window", "jQuery"];

        // constructor
        constructor(private $window: WindowService, private jQuery: JQueryStatic) { }

        // methods
        public changeLanguage(languageCode: string): void {
            this.$window.Track("IndexHead", "ChangeLanguage");
            console.log("Tracking ChangeLanguage...");

            this.jQuery.cookie("WebToolLanguage", languageCode, {
                expires: 10000,
                path: "/"
            });

            this.$window.location.reload();
        }
    }

    // init
    angular.module("mainApp")
        .service("languageBarService", languageBarService);
}