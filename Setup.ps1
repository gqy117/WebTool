npm install -g gulp@3.9.0
npm install -g karma
npm install -g karma-jasmine karma-chrome-launcher karma-jasmine-html-reporter karma-spec-reporter
npm install -g phantomjs
#npm install -g bower
#npm install -g bower-installer

npm install --prefix WebSite
#cd WebSite
#bower-installer
#cd ..

copy WebSite\WebTool\connectionStrings.template.config WebSite\WebTool\connectionStrings.config
copy WebSite\DataAccess\connectionStrings.template.config WebSite\DataAccess\connectionStrings.config