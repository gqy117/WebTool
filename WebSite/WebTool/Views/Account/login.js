function FormLogin_Submit() {
    Track('Login', 'Login');
    $('#FormLogin').submit();
}


function Login_On_Ready() {
    $("#FormLogin_Password").keyup(function (event) {
        if (event.keyCode == 13) {
            FormLogin_Submit();
        }
    });
}

function FormLogin_forgetpassword_Click() {
    Track('Login', 'SignUpNow');
    window.location.href = App.baseUrl + 'Register/Index';
}



Add_JS_Content('Login_On_Ready();');


function _loginLayout_On_Ready() {
    jQuery(document).ready(function () {
        App.initLogin();
    });
}

Add_JS_Content('_loginLayout_On_Ready();');