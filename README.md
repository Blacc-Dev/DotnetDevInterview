# DotnetDevInterview

In this task you are expected to develop an ASP.Net application with api services which shows data of basic e-commerce system. 

**** You must create branch which named {yourName-yourSurname} for your solution. ****

- Content 
  1) Entity framework core and code-first approach should be used. 
  2) MSSQL should be used and you should configure MSSQL in your code.  
  3) Your solution should have multi-layers which are Core, DataAccess, Entities, Business, API.  
  4) You should use swagger to serve your endpoints. 
  5) A json file is given for desinging models and creating database entities. Base entities are named as "Order", "Line" and "Cargo". If you need another classes you are free to create new one. 
  6) Given json file content should be saved in database. 
  7) You will implement 5 endpoints. 
  8) First endpoint triggers saving json data to database. 
  9) Second endpoint returns list of orders with order number, order date, amount(eg: 684,50), amount in turkish(eg: altıyüz seksen dört TL elli KR), status in turkish name, order source, cargo tracking number and cargo name. (Status enums given as status.txt in this repo.) This list also should have sort, search and pagination features. 
  10) Third endpoint returns order's lines as a list with product name, quantity, amount and amount in turkish(same as above).
  11) Fourth endpoint update cargo tracking number and cargo provider number. It takes 3 arguments which are order id, new cargo tracking number and cargo provider name. 
  12) Fifth endpoint should return best selling products with name and avarage monthly selling frequency. 


- Remarks
  1) Follow clean code fundamentals.
  2) Use OOP concepts when desinging and coding. 
  3) Try to use comments and readable parameters.  
  4) Please ask if you have any questions about the task. 
  5) You have 1 day to finish task. 
  6) After finishing your task please commit all your works. 
