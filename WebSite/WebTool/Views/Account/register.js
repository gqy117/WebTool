function FormRegister_Submit() {
    Track('Register', 'Register');
    $('#FormRegister').submit();
}

function Register_On_Ready() {
    $("#FormRegister_ConfirmPassword").keyup(function (event) {
        if (event.keyCode == 13) {
            FormRegister_Submit();
        }
    });
}
Add_JS_Content('Register_On_Ready();');