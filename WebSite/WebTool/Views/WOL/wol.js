function WOL_Click() {
    Track('WOL', 'WOL');
}

Add_JS_Content('ActiveCurrentPanel("WOL");');

CreateTable("#WOLTable", App.baseUrl + 'Tool/WOLTable');