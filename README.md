WebTool
=======

A demo website contains many best practices.

### 1. WebTool
Main website.

(1) Use **angular.js** as the javascript framework.

(2) Use **TypeScript** as a superset of javascript.

(3) Use **JqueryDataTables** as table control.

(4) Use **Autofac** as **DI** framework.

(5) Use **bootstrap** as UI framework.

(6) Use **Code Analysis/ Fxcop** to prevent the high **Cyclomatic Complexity** or something like that.

(7) Use **StyleCop** to keep codes clean.

(8) Use **jsHint** and **tsLint** to make javascript/TypeScript code clean and strong.

(9) Use some **Node.js** plugin such as **grunt**/**gulp** to auto watch file changes.

(10) Use **Castle.Core** as **AOP** framework.

(11) Use **Glimpse** to debug.

(12) Use **Google Analytics** to analyze users' behaviour.

### 2.Tests
(1) BDD

Use **SpecFlow** as BDD framework.

(2) UITest

Use **Selenium** as Functional test framework.

(3) Jasmine

Use **Jasmine** and **Karma** to test javascript code.

(4) UnitTestProject

Use **MSTest** and **Moq** to do the unit tests.

(5) WebAndLoadTestProject

**Load tests** project.

### 3. Utilities
Common utilities such as **NLog**, **JSON.net**, **Enyim.Caching**(**Memcached** C# implementation).

### 4. Repository layer
WebToolRepository
Repository layer: using **EntityFramework** as ORM.

### 5. WebToolDB.sln
Use **Db Project** to control versions of all the tables and stored procedure.

### 6. WebToolCulture
Multilanguage project, display different language depending on browser settings and user selection.

### 7. Service Layer
(1) WebToolServiceBase
Base service layer of other services.

(2) WebToolService
WebTool related service layer.

(3) WebToolOtherService
Other services.
