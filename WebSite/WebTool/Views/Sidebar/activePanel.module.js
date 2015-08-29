"use strict";
var M;
(function (M) {
    var activePanel = (function () {
        // constructor
        function activePanel() {
            this.dashboard = false;
            this.wol = false;
        }
        return activePanel;
    })();
    M.activePanel = activePanel;
})(M || (M = {}));
