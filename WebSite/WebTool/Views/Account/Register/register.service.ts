module M {
    "use strict";

    export class registerService {
        // inject
        static $inject = ["$window"];

        // constructor
        constructor(private $window) { }

        // methods
        public submit(): void {
            this.$window.jQuery("#FormRegister").submit();
            this.$window.Track("Register", "Register");
        }

        public formRegister_Password_keyup($event): void {
            if ($event.keyCode === 13) {
                this.submit();
            }
        }
    }

    // init
    angular.module("mainApp")
        .service("registerService", registerService);
}