// Check for browser support of event handling capability
if (window.addEventListener) {
    window.addEventListener("load", add_JS_At_Onload, false);
}
else if (window.attachEvent) {
    window.attachEvent("onload", add_JS_At_Onload);
} else {
    window.onload = add_JS_At_Onload;
}