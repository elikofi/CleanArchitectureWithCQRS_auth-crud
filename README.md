# Clean Architecture with CQRS, Mapster and MediatR.

## This is a simple CRUD application in .NET 8 where I took advantage of some archtectual styles and design patterns. This project uses Clean architecture which is paired with domain driven design. Also, the main design pattern used in this project is the CQRS also known as the Command Query Responsibility Segregation.

## Why Clean Architecture, CQRS, Mapster and MediatR?
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


* Application Layer
    The application layer is the only layer that has dependency on the domain layer.
    The application layer is a class library in the main solution explorer which can contain these classes or folders.
    Folders/Classes:
    * Commands and Queries folders or classes for the business entities.
    * Common folder where shared classes can be created in. Examples of such classes are; Mappings, exceptions and Behaviours.
    * * Dependency Injection class where all the DI configurations will be done.
    * All nuget packages for mappings and dependency injection should be installed here.
* 0.1
    * Initial Release
