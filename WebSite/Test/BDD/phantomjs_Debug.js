console.log('Hello, world!');

var webPage = require('webpage');
var page = webPage.create();

page.open('http://localhost:12598/', function(status) {
  var content = page.content;
  console.log('Content: ' + content);

  phantom.exit();
});