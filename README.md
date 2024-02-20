# CQRS Template with .NET 8 and Mediator

This CQRS Template is a starting point for building .NET 8 applications following the Command Query Responsibility Segregation (CQRS) design pattern. It utilizes the Mediator package to achieve clear separation of commands and queries, facilitating maintenance and scalability. The project includes examples of using both in-memory databases for rapid development and testing, as well as SQL Express for more persistent storage solutions.

## Features

- CQRS pattern implementation with Mediator for handling commands and queries.
- Examples of using both in-memory and SQL Lite databases.
- Integration with ASP.NET Core 8 for building RESTful APIs.
- Swagger/OpenAPI for API documentation and testing.

## Getting Started

### Prerequisites

- .NET 8 SDK
- Visual Studio 2022 or later, or an equivalent IDE that supports .NET 8.
- SQL Lite (for SQL database examples).

### Setup

1. Clone the repository:
   ```
   git clone https://github.com/steckdev/CqrsTemplate.git
   ```

2. Navigate to the project directory:
   ```
   cd CqrsTemplate
   ```

3. Restore dependencies:
   ```
   dotnet restore
   ```

4. Update the database (if using SQL Lite):
   ```
   dotnet ef database update
   ```

5. Run the application:
   ```
   dotnet run
   ```

## Usage

- The application is configured to start with Swagger UI to explore and test the API endpoints.
- Use the Swagger UI at `https://localhost:7105/swagger` to send requests to the application.

## Contributing

Contributions are welcome. Please open an issue to discuss proposed changes or open a Pull Request with detailed descriptions of your contributions.

## License

This project is licensed under the MIT License - see the LICENSE file for details.
