
var All_JS_Files = new Array();

var All_JS_Content = document.createElement("script");
All_JS_Content.type = "text/javascript";


// Add a script element as a child of the body
function Add_JS(src) {
    All_JS_Files.push(src);
}
function Add_JS_Content(content) {
    All_JS_Content.text += content;
}

function Add_Head_JS() {
    //Add_JS("@Url.Content("~/Content/assets/js/jquery-1.8.3.min.js")");
}



function checkReadyStatus() {
    if (!this.readyState || this.readyState == 'loaded' || this.readyState == 'complete') {
        add_JS_At_Onload();
    }
}

function add_JS_Content_At_Onload() {
    document.body.appendChild(All_JS_Content);
}


function add_JS_At_Onload() {

    if (0 == All_JS_Files.length) {
        add_JS_Content_At_Onload();
        return;
    }

    var element = document.createElement('script');
    element.type = "text/javascript";
    element.src = All_JS_Files[0];
    All_JS_Files.shift();
    element.onload = element.onreadystatechange = checkReadyStatus;
    document.body.appendChild(element);

}



Add_Head_JS();
//Add_Head_Css();
    
function ActiveCurrentPanel(id) {
    $("#" + id).addClass("active");
}
