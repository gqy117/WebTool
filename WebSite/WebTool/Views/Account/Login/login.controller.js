(function () {
    angular.module("mainApp")
         .controller('loginController', loginController);

    loginController.$inject = ['loginService'];

    function loginController(loginService) {

        this.formLogin_Submit = loginService.formLogin_Submit;
        this.formLogin_Password_keyup = loginService.formLogin_Password_keyup;
        this.signUpNow = loginService.signUpNow;

        angular.element(document).ready(function () {
            App.initLogin();
        });
    }
}());
