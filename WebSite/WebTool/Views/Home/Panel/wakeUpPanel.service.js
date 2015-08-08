(function () {
    angular
        .module('mainApp')
        .factory('wakeUpPanelService', wakeUpPanelService);


    function wakeUpPanelService() {
        return {

            hideMessage: function _hideMessage() {
                this.isShowAlertWakeUpSuccess = false;
            },

            wakeUp: function _wakeUp() {
                var context = this;

                Track('Index', 'Panel3_ViewMore');

                Post(
                    {
                        url: App.baseUrl + 'Tool/WakeUp',
                        //data: JSON.stringify(WOL),
                        success: function (message) {
                            context.isShowAlertWakeUpSuccess = true;
                        }
                    }
                );
            }
        }
    }
}());