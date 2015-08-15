WebTool
=======

A demo website contains many best practices.

### 1. WebTool
Main website.

(1) Use **Autofac** as **DI** framework.

(2) Use **Castle.Core** as **AOP** framework.

(3) Use **Glimpse** to debug.

(4) Use **StyleCop** to keep codes clean.

(5) Use **Code Analysis/ Fxcop** to prevent the high Cyclomatic Complexity or something like that.

(6) Use **bootstrap** as UI framework.

(7) Use **angular.js** as the js framework.

(9) Use **jsHint** to make javascript code clean and strong.

(10) Use **JqueryDataTables** as table control.

(11) Use **Google Analytics** to analyze users' behaviour.

### 2.Tests
(1) BDD

Use **SpecFlow** as BDD framework.

(2) UITest

Use **Selenium** as Functional test framework.

(3) UnitTestProject

Use **MSTest** and **Moq** to do the unit tests.

(4) WebAndLoadTestProject

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
