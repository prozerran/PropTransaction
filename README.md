# CRUD example between C# .NET 5 WebApi and ReactJS

This project is a demonstration on how to write both a frontend and backend and the communcation between the two sides.
Both stack are meant to be separate and so is decoupled from each other, so that differernt backend/frontend technologies 
can be used to implement instead of what I did here. 

## Frontend Stack

- ReactJS and some Javascript.
- Some Bootstrap for layout abd styling
- Requires Node.js to run, so npm and it's dependencies need to be installed
- Basic HTML/CSS

### Backend Stack

- C# .NET 5 WebApi/MVC design
- Swagger for development and testing
- Dapper for connecting to DB instead of Entity Frameworks
- SQLite instead of SQL Server for simplicity
- Generalized code to refrain from depending on too much MS stack, such as SQL Server/EF

## Project Outline

- Allow registration of user by email
- Login process
- Simple CRUD for Properties and Transaction page

## Additional Notes

- Basic CRUD example
- Session management of logged in user
- Filterings are defined/used such as Actions/Authentication/Exception handling
- No TDD unit code exist yet, probably will add later, refer to Swagger for testing ATM
- No exception handling is applied yet, still in development so I can see errors in Swagger
- Serilog has replaced the standing MS logging in the controllers
- Not completely finished, frontend still work in progress


### How to Access

- Just compile, and run, all dependencies should be automatically downloaded
- For testing backend WebApi, please access using Swagger or Postman
	- https://localhost:44334/swagger/index.html

- For testing from frontend, please access the site root page
	- https://localhost:44334/index.html


### Comments

Finally, this is just a simple CRUD example between frontend and backend web development.
Use the code at your own risk, modify in any way you see fit.
I hope this will contribute to your knowledge and hopefully provide information on how general web development works.


### Donation

BTC:  12SH2Z2VvcTRTgZuhxV7VBkq3DXzThRtYN  
ETH:  0xe673f79da7f7f5497dba7182f5c272274299c235  
USDT: 0xe673f79da7f7f5497dba7182f5c272274299c235 (ERC20)  
