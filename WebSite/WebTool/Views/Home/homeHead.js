function MyProfile_Click() {
    Track('IndexHead', 'MyProfile');
}

function LogOut_Click() {
    Track('IndexHead', 'LogOut');
    window.location.href = App.baseUrl + "Account/Login";
}

function brand_Click() {
    Track('IndexHead', 'brand');
}