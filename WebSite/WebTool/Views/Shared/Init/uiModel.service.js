var M;
(function (M) {
    "use strict";
    var uiModelService = (function () {
        function uiModelService() {
        }
        // methods
        uiModelService.prototype.init = function () {
            this.initModals();
        };
        uiModelService.prototype.initModals = function () {
            var spinner = "<div class='loading-spinner fade' style='width: 200px; margin-left: -100px;'>";
            spinner += "<img src='/Content/assets/img/ajax-modal-loading.gif' align='middle'>&nbsp;";
            spinner += "<span style='font-weight:300; color: #eee; font-size: 18px; font-family:Open Sans;'>&nbsp;Loading...</span>";
            spinner += "</div>";
            $.fn.modalmanager.defaults.resize = true;
            $.fn.modalmanager.defaults.spinner = spinner;
        };
        return uiModelService;
    }());
    M.uiModelService = uiModelService;
    // init
    angular.module("mainApp")
        .service("uiModelService", uiModelService);
})(M || (M = {}));
