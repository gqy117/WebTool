(function () {
    angular
        .module('mainApp')
        .factory('registerService', registerService);

    function registerService() {
        return {
            submit: function _submit() {
                $('#FormRegister').submit();
                Track('Register', 'Register');
            },

            formRegister_Password_keyup: function _formRegister_Password_keyup($event) {
                if ($event.keyCode === 13) {
                    this.submit();
                }
            }
        }
    }
}());