WebTool
=======

A demo website contains many best practices.

Branch  | Build Status | Coverage Status|
-------- | :------------: | :------------: |
master | [![Build status](https://ci.appveyor.com/api/projects/status/8mk3pyahcejbfduv/branch/master?svg=true)](https://ci.appveyor.com/project/gqy117/webtool/branch/master) | [![Coverage Status](https://coveralls.io/repos/github/gqy117/WebTool/badge.png?branch=master)](https://coveralls.io/github/gqy117/WebTool?branch=master) |

### 1. WebTool
Main website.

(1) Use **angular.js** as the javascript framework.

(2) Use **TypeScript** as a superset of javascript.

(3) Use **Redis** as distributed cache.

(4) Use **JqueryDataTables** as table control.

(5) Use **Unity** as **DI** framework.

(6) Use **bootstrap** as UI framework.

(7) Use **Code Analysis/ Fxcop** to prevent the high **Cyclomatic Complexity** or something like that.

(8) Use **StyleCop** to keep codes clean.

(9) Use **jsHint** and **tsLint** to make javascript/TypeScript code clean and strong.

(10) Use some **Node.js** plugin such as **grunt**/**gulp** to auto watch file changes.

(11) Use **Castle.Core** as **AOP** framework.

(12) Use **Google Analytics** to analyze users' behaviour.

### 2.Tests
(1) BDD

Use **SpecFlow** as BDD framework.

(2) Jasmine

Use **Jasmine** and **Karma** to test javascript code.

(3) WebToolService.Test

Test project for WebToolService.csproj.

### 3. Utilities
Common utilities such as **NLog**, **JSON.net**, **Redis**.

### 4. Repository layer
WebToolRepository
Repository layer: using **EntityFramework** as ORM.

### 5. WebToolDB.sln
Use **Db Project** to control versions of all the tables and stored procedure.

### 6. WebToolCulture
Multilanguage project, display different language depending on browser settings and user selection.

### 7. Service Layer
(1) WebToolService
WebTool related service layer.

