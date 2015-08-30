module M {
    "use strict";
    import IAngularEvent = ng.IAngularEvent;

    export class registerController {
        // inject
        static $inject = ["registerService"];

        // constructor
        constructor(private registerService: registerService) { }

        // methods
        public submit(): void {
            this.registerService.submit();
        }

        public formRegister_Password_keyup($event: IAngularEvent): void {
            this.registerService.formRegister_Password_keyup($event);
        }
    }

    // init
    angular.module("mainApp")
        .controller("registerController", registerController);
}