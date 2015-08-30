module M {
    "use strict";

    export class uiModelService {
        // methods
        public init(): void {
            this.initModals();
        }

        private initModals(): void {
            var spinner: string = "<div class='loading-spinner fade' style='width: 200px; margin-left: -100px;'>";
            spinner += "<img src='/Content/assets/img/ajax-modal-loading.gif' align='middle'>&nbsp;";
            spinner += "<span style='font-weight:300; color: #eee; font-size: 18px; font-family:Open Sans;'>&nbsp;Loading...</span>";
            spinner += "</div>";

            $.fn.modalmanager.defaults.resize = true;
            $.fn.modalmanager.defaults.spinner = spinner;
        }
    }

    // init
    angular.module("mainApp")
        .service("uiModelService", uiModelService);
}