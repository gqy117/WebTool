REM Create Web.config
Xcopy WebSite\WebTool\Web.template.config WebSite\WebTool\Web.config 

REM Install Gulp
npm install -g gulp

REM Install Dependencies
npm install --prefix WebSite gulp-typescript