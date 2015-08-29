"use strict";

module M {
    export class headController {
        // inject
        static $inject = ["headService"];

        // constructor
        constructor(private  headService: headService) { }

        // methods
        public brand_Click(): void {
            this.headService.brand();
        }

        public myProfile_Click(): void {
            this.headService.myProfile();
        }

        public logOut_Click(): void {
            this.headService.logOut();
        }
    }
    
    // init
    angular.module("mainApp")
        .controller("headController", headController);
}