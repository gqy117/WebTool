"use strict";

module M {
    export class headService {
        // inject
        static $inject = ["$window"];

        // constructor
        constructor(private $window) { }

        // methods
        public brand(): void {
            this.$window.Track("IndexHead", "brand");
        }

        public myProfile(): void {
            this.$window.Track("IndexHead", "MyProfile");
        }

        public logOut(): void {
            this.$window.Track("IndexHead", "LogOut");
            this.$window.location.href = this.$window.App.baseUrl + "Account/Login";
        }
    }

    // init
    angular.module("mainApp")
        .service("headService", headService);
}