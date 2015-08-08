(function () {
    angular
        .module('mainApp')
        .factory('wakeUpPanelService', wakeUpPanelService);


    function wakeUpPanelService() {
        return {

            wakeUp: function _panel3_ViewMore() {
                Track('Index', 'Panel3_ViewMore');

                Post(
                    {
                        url: App.baseUrl + 'Tool/WakeUp',
                        //data: JSON.stringify(WOL),
                        success: function (message) {
                            $('#alertWakeUpSuccess').show();
                        }
                    }
                );
            }
        }
    }
}());