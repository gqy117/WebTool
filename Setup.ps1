npm install -g gulp
npm install --prefix WebSite
npm install -g karma
npm install -g karma-jasmine karma-chrome-launcher karma-jasmine-html-reporter karma-spec-reporter
npm install -g phantomjs
npm install -g bower
npm install -g bower-installer

copy WebSite\WebTool\connectionStrings.template.config WebSite\WebTool\connectionStrings.config
copy WebSite\DataAccess\connectionStrings.template.config WebSite\DataAccess\connectionStrings.config