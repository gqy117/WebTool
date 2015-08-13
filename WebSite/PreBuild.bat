SET currentLocation=%~dp0
SET "projectLocation=%currentLocation%WebTool\"
SET "ajaxmin=%currentLocation%Dlls\MicrosoftAjaxMinifier\ajaxmin.exe"

%ajaxmin% "%projectLocation%Content\assets\css\style_default.css" -out "%projectLocation%Content\assets\css\style_default.min.css" -clobber
%ajaxmin% "%projectLocation%Content\assets\uniform\css\uniform.default.css" -out "%projectLocation%Content\assets\uniform\css\uniform.default.min.css" -clobber
%ajaxmin% "%projectLocation%Content\Site.css" -out "%projectLocation%Content\Site.min.css" -clobber
%ajaxmin% "%projectLocation%Content\assets\css\style_responsive.css" -out "%projectLocation%Content\assets\css\style_responsive.min.css" -clobber
%ajaxmin% "%projectLocation%Content\assets\font-awesome\css\font-awesome.css" -out "%projectLocation%Content\assets\font-awesome\css\font-awesome.min.css" -clobber

jshint "%currentLocation%WebTool"