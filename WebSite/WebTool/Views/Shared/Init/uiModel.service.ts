"use strict";

module M {
    export class uiModelService{
        // methods
        public init(): void {
            this.initModals();
        }

        private initModals(): void {
            $.fn.modalmanager.defaults.resize = true;
            $.fn.modalmanager.defaults.spinner = '<div class="loading-spinner fade" style="width: 200px; margin-left: -100px;"><img src="/Content/assets/img/ajax-modal-loading.gif" align="middle">&nbsp;<span style="font-weight:300; color: #eee; font-size: 18px; font-family:Open Sans;">&nbsp;Loading...</span></div>';
        }
    }

    // init
    angular.module('mainApp')
        .service('uiModelService', uiModelService);
}