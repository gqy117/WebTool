(function () {
    "use strict";

    angular.module("mainApp")
         .controller('registerController', registerController);

    registerController.$inject = ['registerService'];

    function registerController(registerService) {
        this.submit = registerService.submit;
        this.formRegister_Password_keyup = registerService.formRegister_Password_keyup;
    }

    angular.module("mainApp")
        .directive('form', function () {

        return {
            require: 'form',
            restrict: 'E',
            link: function (scope, elem, attrs, form) {
                form.$submit = function () {
                    form.$setSubmitted();
                    scope.$eval(attrs.ngSubmit);
                };
            }
        };
    });
}());
