WebTool
=======

A website contains brunches of best practices.


### 1. Reporitory layer
WebToolRepository
Reporitory layer: using **EntityFramework** as ORM.

### 2. Service Layer
(1) WebToolServiceBase
Base service layer of other services.

(2) WebToolService
WebTool related service layer.

(3) WebToolOtherService
Other services.

### 3.Tests
(1) BDD

Use **SpecFlow** as BDD framework.

(2) UITest

Use **Selenium** as Functional test framework.

(3) UnitTestProject

Use **MSTest** and **Moq** to do the unit tests.

(4) WebAndLoadTestProject

Load tests project.

### 4. Utilities
Common utilities such as **NLog**, **JSON.net**, **Enyim.Caching**(**Memcached** C# implementation).

### 5. WebToolCulture
Multilanguage project, display different language depending on browser settings and user selection.

### 6. WebTool
Main website.

(1) Use **Autofac** as **DI** framework.

(2) Use **Castle.Core** as **AOP** framework.

(3) Use **Glimpse** to debug.

(4) Use **StyleCop** to keep codes clean.

(5) Use **bootstrap** as UI framework.

(6) Use **knockout.js** to bind json data to the UI.

(7) Use **JqueryDataTables** as table control.
