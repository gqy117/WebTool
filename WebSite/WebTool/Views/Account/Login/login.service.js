(function () {
    angular
        .module('mainApp')
        .factory('loginService', loginService);

    function loginService() {
        return {

            formLogin_Submit: function _formLogin_Submit() {
                Track('Login', 'Login');
                $('#FormLogin').submit();
            },

            formLogin_Password_keyup: function _formLogin_Password_keyup($event) {
                if ($event.keyCode === 13) {
                    this.formLogin_Submit();
                }
            },

            signUpNow: function _signUpNow() {
                Track('Login', 'SignUpNow');
                window.location.href = App.baseUrl + 'Register/Index';
            }
        }
    }
}());