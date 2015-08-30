module M {
    "use strict";

    export class homeService {
    }

    // Init
    angular.module("mainApp")
        .service("homeService", homeService);
}