"use strict";

module M {
    export class registerController {
        // inject
        static $inject = ["registerService"];

        // constructor
        constructor(private registerService: registerService) { }

        // methods
        public submit(): void {
            this.registerService.submit();
        }

        public formRegister_Password_keyup($event): void {
            this.registerService.formRegister_Password_keyup($event);
        }
    }

    // init
    angular.module("mainApp")
        .controller('registerController', registerController);

}