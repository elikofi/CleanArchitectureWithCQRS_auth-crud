# Clean Architecture with CQRS, Mapster and MediatR.

#### This project is a CRUD application built with .NET 8, leveraging established architectural styles and design patterns. It implements Clean Architecture in combination with Domain-Driven Design (DDD) principles. The primary design pattern utilized is Command Query Responsibility Segregation (CQRS), ensuring a clear separation between write and read operations.

## Why Clean Architecture?
Clean Architecture (CA) is employed in this project due to its significant advantages, such as promoting separation of concerns. Each layer of the application is assigned specific responsibilities, enhancing its clarity, testability, maintainability, and overall development efficiency. 

By structuring code into distinct layers with well-defined roles, Clean Architecture reduces dependencies, increases flexibility, and improves robustness. Dependency flow in CA is directed inward, ensuring that lower-level modules remain independent of higher-level modules. The architecture is organized into four primary layers, each with a specific focus and role.

### Layers in Clean Architecture.

### Infrastructure Layer

The **Infrastructure Layer** is responsible for interacting with external systems and has a dependency on the **Application Layer**. It serves as the communication bridge with the database and implements various services required by the application. This layer is represented as a class library in the solution structure and typically includes the following folders and classes:

#### Key Components:
- **Data Folder**: Contains the database context class, facilitating communication with the database.
- **Migrations Folder**: Stores Entity Framework Core migrations for managing database schema changes.
- **Repository Folder**: Hosts implementations of the repository interfaces defined in the **Domain Layer**, managing persistence operations for domain entities.
- **Dependency Injection (DI) Class**: Centralizes DI configurations for services used throughout the application.

#### Required NuGet Packages:
To enable database communication and related functionality, the following NuGet packages are installed:
- `Microsoft.EntityFrameworkCore`
- `Microsoft.EntityFrameworkCore.Tools`
- `Microsoft.Extensions.Configuration.Abstractions`
- `Npgsql` (PostgreSQL driver for .NET)
- `Npgsql.EntityFrameworkCore.PostgreSQL` (EF Core provider for PostgreSQL)

This layer ensures a clean separation of concerns by isolating infrastructure-specific details and dependencies, aligning with the principles of Clean Architecture.

### Application Layer

The **Application Layer** depends solely on the **Domain Layer** and encapsulates the core business use cases and logic. It is implemented as a class library within the solution and typically contains the following folders and classes:

#### Key Components:
- **Commands and Queries**: Organized folders or classes for handling business logic related to specific operations on business entities, aligning with the CQRS pattern.
- **Common Folder**: Contains shared classes such as:
  - **Mappings**: For mapping configurations between different objects.
  - **Exceptions**: Custom exceptions for business rules.
  - **Behaviors**: Middleware-like constructs to handle cross-cutting concerns, such as logging or validation.
- **Dependency Injection (DI) Class**: Centralizes DI configurations for application services.

#### Required NuGet Packages:
The following packages are used for mapping and dependency injection functionalities:
- `FluentValidation.DependencyInjectionExtensions`
- `Mapster`
- `MediatR`
- `Microsoft.Extensions.DependencyInjection.Abstractions`

### Domain Layer

The **Domain Layer** represents the core of the application and operates independently, without dependencies on any other layer. It is also a class library that contains the foundational elements of the business logic:

#### Key Components:
- **Business Entities**: Represent the domain objects and their rules.
- **Interfaces**: Define contracts for services and repositories.
- **Value Objects**: Immutable objects representing concepts in the domain.
- **Domain Errors**: Enumerations or classes to encapsulate domain-specific error conditions.
- **Domain Events**: Encapsulate changes or actions occurring within the domain.

#### Optional Dependencies:
Depending on the use case, the `Microsoft.Extensions.Identity.Stores` NuGet package can be included for identity-related functionalities.

### API Layer

The **API Layer** serves as the entry point for external interactions and acts as a bridge between the application's core business logic and the outside world. It processes incoming requests and formats responses appropriately. 

#### Key Responsibilities:
- **Request Handling**: Receives and validates HTTP requests, converting input data into a format understood by the core layers.
- **Business Logic Invocation**: Invokes appropriate use cases from the **Application Layer** to handle requests.
- **Response Formatting**: Formats and returns the output as HTTP responses.

#### Key Component:
- **Controllers**: These handle the following tasks:
  - Routing incoming requests to the appropriate handlers.
  - Parsing and validating input data.
  - Invoking relevant use cases with parsed data.
  - Preparing and sending the response back to the client.

This layered structure ensures clear separation of responsibilities, promoting scalability, maintainability, and testability in alignment with Clean Architecture principles.


## Why CQRS?

Command Query Responsibility Segregation (CQRS) is a design pattern that separates data modification (commands) from data retrieval (queries) into distinct paths, organized into separate folders. This separation offers several advantages:  

- **Reduced Complexity**: Simplifies the understanding and management of application logic by isolating read and write concerns.  
- **Improved Security**: Segregates the pathways for commands and queries, allowing tailored security measures for each.  
- **Flexibility in Data Models**: Enables the use of optimized models for reading and writing data.  
- **Enhanced Testing**: Isolates logic for easier unit and integration testing.  
- **Performance Optimization**: Allows independent optimization of read and write operations.  
- **Separation of Concerns**: Promotes clean code by distinctly managing different responsibilities.  
- **Scalability**: Supports horizontal scaling by independently handling read and write loads.

## Why MediatR and Mapster?

- **MediatR**: Facilitates the management of commands, queries, and notifications/events, ensuring clean, maintainable, and testable code organization. By decoupling components, it simplifies the flow of control and reduces dependencies.  
- **Mapster**: Provides efficient object mapping, enabling the transformation of Data Transfer Objects (DTOs) to entities and vice versa. This simplifies data manipulation and promotes consistency across the application.

## Setting Up the Project Using Visual Studio (Windows)

1. **Create an Empty Solution**: Start by creating a new solution in Visual Studio.  
2. **Add an API Project**: Create an API project as the entry point. Use the .NET 8 framework for this implementation.  
3. **Add Class Libraries**: Add four class libraries to the solution: `Application`, `Domain`, `Contracts`, and `Infrastructure`.  
4. **Install Required NuGet Packages**: Install the necessary NuGet packages for each class library based on their roles.  
5. **Set Up Project References**: Configure the project references to maintain the dependency flow in accordance with Clean Architecture principles.

## References in Clean Architecture

In Clean Architecture, dependencies flow inward, with outer layers referencing inner layers:  

1. **Domain Layer**: The innermost layer, which contains core business logic, has no references to other layers.  
2. **Application Layer**: Depends only on the **Domain Layer** and defines use cases.  
3. **Infrastructure Layer**: Relies on the **Application Layer** to provide implementations for external dependencies like database interactions.  
4. **Contracts Layer**: Also references the **Application Layer** and contains definitions for shared contracts and DTOs. Note: The **Infrastructure** and **Contracts Layers** together form the **Presentation Layer** in this architecture.  
5. **API Layer**: The outermost layer, responsible for interacting with external clients, references the **Application**, **Infrastructure**, and **Contracts Layers**. It serves as a bridge between the outside world and the business logic.

By adhering to this reference hierarchy, Clean Architecture ensures modularity, maintainability, and clear separation of concerns.


## Setting up the project Using Visual Studio Code and the donet CLI.
* Navigate to the folder you want to create the project in and run the following commands respectively:
  ```
  dotnet new sln -o SolutionName
  ```
  ```
  dotnet new webapi -o ApiName
  ```
  ```
  dotnet new classlib -o ContractsName
  ```
  ```
  dotnet new classlib -o InfrastructureName
  ```
  ```
  dotnet new classlib -o ApplicationName
  ```
  ```
  dotnet new classlib -o DomainName
  ```
  
* After setting up all the projects, add Project references as described above and build the solution.
* In the CLI you can run the command below to build the solution.
  ```
  dotnet build
  ```
* After building successfully, run the API project and Swagger UI should open in the browser.
* CLI command for running the project.
  ```
  dotnet run
  ```
Once the project is running, you are good to go.
Now let's talk about the project into details step by step and once class library at a time. We are going to start with the Application Layer class library.



### Enhanced Explanations

---

### Application Layer

The **Application Layer** is a core part of the Clean Architecture, responsible for implementing the use cases that orchestrate the application’s business logic. It serves as the boundary where the core logic interacts with external concerns (like the **Infrastructure Layer**) via well-defined interfaces. Here are the key components:

- **Use Cases**: Encapsulate business-specific actions, ensuring all rules for a particular feature are consistently applied. For example, creating a blog post or authenticating a user.
- **Commands and Queries**: Follow the CQRS design pattern to separate write operations (commands) from read operations (queries). This enhances scalability, performance, and code clarity.
- **External Interfaces**: Define the contracts (via interfaces) for interacting with external systems, databases, or services, ensuring dependency inversion.
- **Custom Exceptions**: Contain exceptions specific to application logic, such as validation or authorization errors, to provide clear feedback when business rules are violated.
- **Mappings**: Define mappings between domain entities and DTOs (Data Transfer Objects), ensuring clean separation between the **Domain Layer** and the external API.
- **Custom Errors**: Represent domain-agnostic errors that are not tied to a particular entity but are still critical for application behavior, such as "Record Not Found."

This layer depends on the **Domain Layer** but does not depend on the **Infrastructure Layer**, maintaining a clear separation of concerns.

---

### Contracts Layer

The **Contracts Layer** acts as a communication bridge between the **API Layer** and the **Application Layer**. It provides strongly typed structures, ensuring that data passed into the application is consistent and validated. Key components include:

- **Request Models**: Define the structure for incoming data from client requests. For instance:
  - `LoginRequest`: Encapsulates user login credentials.
  - `RegisterUserRequest`: Holds data for user registration, such as email, username, and password.
- **Response Models**: Specify the format of data sent back to the client. For example:
  - `AuthenticationResponse`: Returns user details along with a token post-authentication.

This layer promotes reusability and reduces duplication by decoupling the API contracts from the application logic.

---

### Domain Layer

The **Domain Layer** is the heart of the application and contains the core business logic and rules. This layer is completely isolated, ensuring it has no dependencies on external concerns. Key features include:

- **Entities**: Represent the core data structures of the application. For instance:
  - `Blog`: A class representing blog attributes (e.g., title, content, author).
  - `User`: A class encapsulating user details.
- **Value Objects**: Immutable, self-validating types used to represent concepts like email addresses or monetary amounts.
- **Common Folder**: Houses domain-related constructs like custom errors (e.g., validation errors).
- **Repositories**: Define abstractions (interfaces) for data persistence without exposing database-specific details.
  - For example, the `IBlogRepository` interface defines CRUD operations for blogs without tying them to a database.

This layer emphasizes domain-driven design principles, ensuring that business rules and logic are centralized and testable.

---

### Infrastructure Layer

The **Infrastructure Layer** supports the application by handling technical concerns such as database operations, authentication, and external services. Its components include:

- **Authentication Folder**: Implements JWT authentication, including token generation, validation, and configuration settings.
- **Data Folder**: Contains the `DatabaseContext` class, which uses Entity Framework Core to interact with the database.
- **Migrations Folder**: Manages EF Core migrations, tracking schema changes and maintaining database snapshots.
- **Repository Folder**: Implements interfaces defined in the **Domain Layer**, providing concrete data access logic for entities like `Blog` and `User`.
- **Services Folder**: Encapsulates reusable services, such as a `DateTimeProvider` for consistent time-related operations.

This layer depends on the **Application Layer**, ensuring a unidirectional flow of dependencies.

---

### API Layer

The **API Layer** is the entry point of the application, exposing endpoints to the external world. It bridges external requests with internal application logic. Components include:

- **Controllers**: Define endpoints that map HTTP requests to use cases in the **Application Layer**.
- **Mappings**: Facilitate transformations between API contracts (DTOs) and domain entities.
- **Configurations**: 
  - `appsettings.json`: Contains configuration data such as database connection strings, logging settings, and JWT keys.
  - `Program.cs`: Configures middleware, dependency injection, routing, logging, caching, and health checks.
- **Health Checks**: Provide insights into the application's operational status, helping monitor system health.

The **API Layer** orchestrates all interactions, ensuring that external concerns are cleanly separated from the core logic. It depends on the **Application Layer**, **Contracts Layer**, and **Infrastructure Layer**.

---

### Conclusion

This layered architecture enforces strong separation of concerns, making the application easier to maintain, test, and scale. Each layer plays a distinct role, ensuring the system remains robust and flexible as requirements evolve.
