(function () {
    "use strict";

    angular
        .module('mainApp')
        .factory('wakeUpPanelService', wakeUpPanelService);

    wakeUpPanelService.$inject = ['$window', '$http'];

    function wakeUpPanelService($window, $http) {
        return {
            hideMessage: function _hideMessage() {
                this.isShowAlertWakeUpSuccess = false;
            },

            wakeUp: function _wakeUp() {
                var context = this;
                $window.Track('Index', 'Panel3_ViewMore');

                $http.post($window.App.baseUrl + 'Tool/WakeUp')
                    .success(function () {
                        context.isShowAlertWakeUpSuccess = true;
                    });
            }
        };
    }
}());