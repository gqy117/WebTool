"use strict";

module M {
    export class homeService {
    }

    // Init
    angular.module("mainApp")
        .service("homeService", homeService);
}