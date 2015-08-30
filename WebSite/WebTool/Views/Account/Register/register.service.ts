module M {
    "use strict";
    import WindowService = angular.IWindowService;
    import AngularEvent = angular.IAngularEvent;

    export class registerService {
        // inject
        static $inject = ["$window"];

        // constructor
        constructor(private $window: WindowService) { }

        // methods
        public submit(): void {
            this.$window.jQuery("#FormRegister").submit();
            this.$window.Track("Register", "Register");
        }

        public formRegister_Password_keyup($event: AngularEvent): void {
            if ($event.keyCode === 13) {
                this.submit();
            }
        }
    }

    // init
    angular.module("mainApp")
        .service("registerService", registerService);
}