Application documentation 
i. Tools used 
ii. Api documentation
iii. Application workflow 
iv. Challenges 
v. Improvement 


i. Tools used
backend : C# , Asp.net core  net5.0
Db : Sql lite .. name : shopsRU.db
serilog is used for logging

dotnet ef migrations add InitialCreate --project "C:\Apps\Habaripay.ShopsRUs\Habaripay.ShopsRUs.Data"
 dotnet ef migrations script |  out-file ./Database/shopRU_migration01.sql
dotnet ef database update
visual stuido  - for API dev

ii. Api documentation 

Swagger documentation is used.
http://localhost:58011/swagger/index.html


iii. Application workflow 
 A simple clean achitecture is used.
 Application fullfill all requirements
 Application Flow starts from Controllers -- Customer | Discount | Invoice Controller
 Then services that are injected into the controllers 
 Then services process application logic.
 Data is seeded from a Faker class into Sqllitedb 
 To be viewed by db browser for sql lite
 Also, code first is used for db access.
  Application Usage.
  i. User startup the application.
  ii. Data can be seeded directly into the db from startup
  iii. Users the go to swagger to start testing APIs
  iv. User can then run invoice endpoint with a bill to get the invoice for a customer


  Application structure 
 - Restful API project - the contains the api controller , middleware and helpers and db scripts
 - Data library  - the contain the data or data context related componenet
 - Domain library - this contains sharable components 
 - Service library - this contains the logic of the application

