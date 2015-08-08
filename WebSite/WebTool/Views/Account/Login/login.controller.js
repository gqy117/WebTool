(function () {
    angular.module("mainApp")
         .controller('loginController', ['loginService', loginController]);

    function loginController(loginService) {

        this.formLogin_Submit = loginService.formLogin_Submit;
        this.formLogin_Password_keyup = loginService.formLogin_Password_keyup;
        this.formLogin_forgetpassword_Click = loginService.formLogin_forgetpassword_Click;

        angular.element(document).ready(function () {
            App.initLogin();
        });
    }
}());
