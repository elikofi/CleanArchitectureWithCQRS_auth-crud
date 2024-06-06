# Clean Architecture with CQRS, Mapster and MediatR.

#### This is a simple CRUD application in .NET 8 where I took advantage of some archtectual styles and design patterns. This project uses Clean architecture which is paired with domain driven design. Also, the main design pattern used in this project is the CQRS also known as the Command Query Responsibility Segregation.

## Why Clean Architecture?
I'm using CA because it has some amazing benefits such as separation of concerns (different laters of the software application handle different responsibilities) which helps in making the software understandable, testable, maintainable and easier to develop. It also organises the code into layers with clear responsibilities, reducing dependencies and increasing flexibility and robustness. Dependencies in CA happen inward and this ensures that low-level modules do not depend on high-level modules. In CA, there are mainly four different layers.

### Layers in Clean Architecture.

* Infrastructure Layer
    This layer has dependency on the Application layer and this layer also communicates with the database.
    The infrastructure layer is a class library in the main solution explorer which can contain these classes or folders.
    Folders/Classes:
    * Data folder where the database context class is created to communicate with the database.
    * Migration folder for all the entity framework core migrations for the application.
    * Repository folder where all the implementations of the interfaces created in the domain layer for the domain entity will be done.
    * Dependency Injection class where all the DI configurations will be done.
    * All nuget packages for database communications should be installed. Here are the ones I used:
        * EntityFrameworkCore, EFCore.Tools, Microsoft.Extensions.Configuration.Abstractions, Npgsql, Npgsql.EFCore.PostgreSQL.


* Application Layer
    The application layer is the only layer that has dependency on the domain layer.
    The application layer is a class library in the main solution explorer which can contain these classes or folders.
    Folders/Classes:
    * Commands and Queries folders or classes for the business entities.
    * Common folder where shared classes can be created in. Examples of such classes are; Mappings, exceptions and Behaviours.
    * * Dependency Injection class where all the DI configurations will be done.
    * All nuget packages for mappings and dependency injection should be installed here. Here are the ones I used:
        * FluentValidation.DependencyInjectionExtensions, Mapster, MediatR, Microsoft.Extensinos.DI.Abstractions.  


* Domain Layer
    * This layer is the inner-most layer in the clean architecture structure and doesn't have dependency on any other layer.
    * It is also a class library which contains all the Business Entities, interfaces, value objects, domain errors and domain events.
    * Depending on your usecase, you can install the Microsoft.Extensions.Identity.Stores nuget package.
 
* API Layer
    * This layer acts as a bridge between the outside world and the application's core business logic and it converts data from external sources (like HTTP requests) into a format that the inner layers can process and vice versa.
    * The API layer handles requests, calls the use cases for handling the logic, and then handles the formatting of the responses.
    * Controllers: are found in this layer and they are responsible for routing incoming requests to the appropriate handler, parse input data and validate it, invokes the relevant use case with the parsed data, and then preparing and sending the response back to the client.
 


## Why CQRS?
CQRS, which is Command Query Responsibility Segregation is a design pattern which enables developers to group all database commands (data modification) into a folder and all queries (reading of data) into another folder to reduce complexity, improve security, make data models flexible, enhance testing, optimize performance, separation of concerns and then improve scalability.


## Why MediatR and Mapster?
MediatR is used to manage commands, queries and notifications/Events which in turn helps in organizing the code in a clean, maintainable and testable manner.
Mapster is used for object mapping where we can map the DTO to the entity for data manipulation in the software.

##Setting Up The Project.
    * Create an empty solution.
    * Add API project to the solution.
    * Add three new class libraries to the solution namely, application, domain and infrastructure.

































