module M {
    "use strict";

    export class headerPanelController {
        // inject
        static $inject = ["headerPanelService"];

        // constructor
        constructor(private headerPanelService: IHeadPanelService) { }

        // methods
        public navigation1Click(): void {
            this.headerPanelService.navigation1();
        }

        public navigation2Click(): void {
            this.headerPanelService.navigation2();
        }
    }

    // init
    angular.module("mainApp")
        .service("headerPanelController", headerPanelController);
}