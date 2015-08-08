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


function _indexLayout_On_Ready() {
    jQuery(document).ready(function () {
        App.init(); // init the rest of plugins and elements
        UIModals.init();
    });
}
Add_JS_Content('_indexLayout_On_Ready();');


function LeftPanel_Dashboard_Click() {
    Track('Index', 'LeftPanel_Dashboard');
    window.location.href = App.baseUrl + 'Home/Index';

}
function LeftPanel_WOL_Click() {
    Track('Index', 'LeftPanel_WOL');
    window.location.href = App.baseUrl + 'Tool/WOL';
}