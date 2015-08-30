module M {
    "use strict";

    export class homeService {
    }

    // init
    angular.module("mainApp")
        .service("homeService", homeService);
}