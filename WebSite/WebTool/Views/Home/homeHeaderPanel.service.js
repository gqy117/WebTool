"use strict";
var M;
(function (M) {
    var headerPanelService = (function () {
        // constructor
        function headerPanelService($window) {
            this.$window = $window;
        }
        // methods
        headerPanelService.prototype.navigation1 = function () {
            this.$window.Track('Index', 'Home');
            console.log('Tracking Home...');
        };

        headerPanelService.prototype.navigation2 = function () {
            this.$window.Track('Index', 'Dashboard');
            console.log('Tracking Dashboard...');
        };
        headerPanelService.$inject = ["$window"];
        return headerPanelService;
    })();
    M.headerPanelService = headerPanelService;

    // init
    angular.module('mainApp').service('headerPanelService', headerPanelService);
})(M || (M = {}));
//# sourceMappingURL=homeHeaderPanel.service.js.map
