module M {
    "use strict";
    import WindowService = angular.IWindowService;
    import AngularEvent = angular.IAngularEvent;

    export class registerService {
        // inject
        static $inject = ["$window", "jQuery", "gaService"];

        // constructor
        constructor(private $window: WindowService, private jQuery: JQueryStatic, private gaService: gaService) { }

        // methods
        public submit(): void {
            this.jQuery("#FormRegister").submit();
            this.gaService.Track("Register", "Register");
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