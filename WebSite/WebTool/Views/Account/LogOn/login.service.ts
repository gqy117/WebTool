module M {
    "use strict";
    import AngularEvent = angular.IAngularEvent;
    import WindowService = angular.IWindowService;

    export class loginService {
        // inject
        static $inject = ["$window", "jQuery", "gaService"];

        // constructor
        constructor(private $window: WindowService, private jQuery: JQueryStatic, private gaService: gaService) { }

        //  methods
        public formLogOnSubmit(): void {
            this.gaService.Track("LogOn", "LogOn");
            this.jQuery("#FormLogin").submit();
        }

        public formLogOnPasswordKeyup($event: AngularEvent): void {
            if ($event.keyCode === 13) {
                this.formLogOnSubmit();
            }
        }

        public signUpNow(): void {
            this.gaService.Track("LogOn", "SignUpNow");
            this.$window.location.href = this.$window.App.baseUrl + "Register/Index";
        }
    }

    // init
    angular.module("mainApp")
        .service("loginService", loginService);
}