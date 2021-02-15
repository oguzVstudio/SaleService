Project is created with .Net Framework 4.5

In the solution, there are Web Service is called "GeneraliSaleService" and UI is called "Generali.UI".
For this project single UI layer is enough(For test). Can develop and add different solution and design.
Web Service(WCF) is multi layer project. Service layer is used just for adapter, validations and decisions managed on Business Logic.
In this service project(includes layers) used DI (dependecy injection) with Simple Injector and used base style.
For validations used Fluent Validation and added some examples.
DataAccess is created for SQL ORM and EF 6 Code First. In DataAccess Project, need to change connectionString to create Database.
When database is created need to add an user/users to test this project. Because 
UI project requires user login and add default Customer to CustomerTable(Default id is defined "1") and customer is optional for development(can add customers and change view and controller to provide it). 
But at first, at least requires 1 customer.
In this folder there is a test example to add products.
After then can create sale or order(in this project called sale) and list them.
To list sales, used Telerik Kendo Grid, it has functionalities to responsive drag and drop columns to column groupping and also export to excel.


NOTE: Excel format must be as excel example in the root. Column order is not important bu title is important, even upper/lower case is important.

Author: Oğuz Ünlütaş

