"use strict";

module M {
    export class sidebarService {
        // inject
        static $inject = ["$window"];

        // constructor
        constructor(public $window) { }

        // methods
        public LeftPanel_Dashboard(): void {
            this.$window.Track('Index', 'LeftPanel_Dashboard');
            this.$window.location.href = this.$window.App.baseUrl + 'Home/Index';
        }

        public LeftPanel_WOL(): void {
            this.$window.Track('Index', 'LeftPanel_WOL');
            this.$window.location.href = this.$window.App.baseUrl + 'Tool/WOL';
        }
    }
}

// init
angular.module('mainApp')
    .factory('sidebarService', M.sidebarService);