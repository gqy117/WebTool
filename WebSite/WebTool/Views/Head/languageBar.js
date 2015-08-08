function ChangeLanguage(languageCode) {
    Track('IndexHead', 'ChangeLanguage');
    $.cookie("WebToolLanguage", languageCode, {
        expires: 10000,
        path: '/'
    });
    location.reload();
}