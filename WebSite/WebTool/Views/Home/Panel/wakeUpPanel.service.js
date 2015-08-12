(function (window) {
    "use strict";

    angular
        .module('mainApp')
        .factory('wakeUpPanelService', ['$http', wakeUpPanelService]);


    function wakeUpPanelService($http) {
        return {
            hideMessage: function _hideMessage() {
                this.isShowAlertWakeUpSuccess = false;
            },

            wakeUp: function _wakeUp() {
                var context = this;
                window.Track('Index', 'Panel3_ViewMore');

                $http.post(App.baseUrl + 'Tool/WakeUp')
                    .success(function() {
                        context.isShowAlertWakeUpSuccess = true;
                    });
            }
        };
    }
}(window));