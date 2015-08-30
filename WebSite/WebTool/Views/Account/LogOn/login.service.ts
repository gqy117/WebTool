module M {
    "use strict";
    import AngularEvent = angular.IAngularEvent;
    import WindowService = angular.IWindowService;

    export class loginService {
        // inject
        static $inject = ["$window"];

        // constructor
        constructor(private $window: WindowService) { }

        //  methods
        public formLogOnSubmit(): void {
            this.$window.Track("LogOn", "LogOn");
            this.$window.jQuery("#FormLogin").submit();
        }

        public formLogOnPasswordKeyup($event: AngularEvent): void {
            if ($event.keyCode === 13) {
                this.formLogOnSubmit();
            }
        }

        public signUpNow(): void{
            this.$window.Track("LogOn", "SignUpNow");
            this.$window.location.href = this.$window.App.baseUrl + "Register/Index";
        }
    }

    // init
    angular.module("mainApp")
        .service("loginService", loginService);
}