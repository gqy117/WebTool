(function () {
    "use strict";

    angular.module('mainApp')
        .factory('uiModelService', uiModelService);

    function uiModelService() {
        var initModals = function() {
            $.fn.modalmanager.defaults.resize = true;
            $.fn.modalmanager.defaults.spinner = '<div class="loading-spinner fade" style="width: 200px; margin-left: -100px;"><img src="/Content/assets/img/ajax-modal-loading.gif" align="middle">&nbsp;<span style="font-weight:300; color: #eee; font-size: 18px; font-family:Open Sans;">&nbsp;Loading...</span></div>';
        };

        return {
            //main function to initiate the module
            init: function () {
                initModals();
            }

        };
    }
})();