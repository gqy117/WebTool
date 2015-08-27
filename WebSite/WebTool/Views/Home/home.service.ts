"use strict";

module M {
    export class homeService {
    }
}

// Init
angular.module("mainApp")
    .factory("homeService", M.homeService);