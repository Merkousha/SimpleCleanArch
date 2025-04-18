# SimpleCleanArch

A clean architecture implementation for a book management system built with .NET Core.

## Overview

SimpleCleanArch is a book management system that allows users to manage books, authors, categories, and keywords. The project follows clean architecture principles to ensure separation of concerns, maintainability, and testability.

## Architecture

The solution is structured using Clean Architecture principles with the following layers:

- **Domain Layer**: Contains the core business logic, entities, and interfaces
- **Application Layer**: Contains application services, DTOs, and interfaces
- **Infrastructure Layer**: Contains implementations of repositories, database context, and external services
- **Presentation Layer**: Contains the API controllers and UI components

## Features

- Book management (CRUD operations)
- Author management
- Category management
- Keyword management
- Book-Author relationships
- Book-Category relationships
- Book-Keyword relationships
- Related books functionality

## Technologies Used

- .NET Core 9.0
- Entity Framework Core
- AutoMapper
- FluentValidation
- SQL Server

## Getting Started

### Prerequisites

- .NET Core 9.0 SDK
- SQL Server
- Visual Studio 2022 or Visual Studio Code

### Installation

1. Clone the repository:
   ```
   git clone https://github.com/yourusername/SimpleCleanArch.git
   ```

2. Navigate to the project directory:
   ```
   cd SimpleCleanArch
   ```

3. Update the connection string in `src/Presentation/SimpleCleanArch.API/appsettings.json` to point to your SQL Server instance.

4. Run the database migrations:
   ```
   dotnet ef database update --project src/Infrastructure/SimpleCleanArch.Infrastructure --startup-project src/Presentation/SimpleCleanArch.API
   ```

5. Run the application:
   ```
   dotnet run --project src/Presentation/SimpleCleanArch.API
   ```

## API Endpoints

### Books

- `GET /api/books` - Get all books
- `GET /api/books/{id}` - Get a book by ID
- `GET /api/books/slug/{slug}` - Get a book by slug
- `GET /api/books/category/{categoryId}` - Get books by category
- `GET /api/books/author/{authorId}` - Get books by author
- `POST /api/books` - Create a new book
- `PUT /api/books/{id}` - Update a book
- `DELETE /api/books/{id}` - Delete a book

### Authors

- `GET /api/authors` - Get all authors
- `GET /api/authors/{id}` - Get an author by ID
- `GET /api/authors/book/{bookId}` - Get authors by book
- `POST /api/authors` - Create a new author
- `PUT /api/authors/{id}` - Update an author
- `DELETE /api/authors/{id}` - Delete an author

### Categories

- `GET /api/categories` - Get all categories
- `GET /api/categories/{id}` - Get a category by ID
- `GET /api/categories/slug/{slug}` - Get a category by slug
- `POST /api/categories` - Create a new category
- `PUT /api/categories/{id}` - Update a category
- `DELETE /api/categories/{id}` - Delete a category

### Keywords

- `GET /api/keywords` - Get all keywords
- `GET /api/keywords/{id}` - Get a keyword by ID
- `GET /api/keywords/book/{bookId}` - Get keywords by book
- `POST /api/keywords` - Create a new keyword
- `PUT /api/keywords/{id}` - Update a keyword
- `DELETE /api/keywords/{id}` - Delete a keyword

## Project Structure

```
SimpleCleanArch/
├── src/
│   ├── Core/
│   │   ├── SimpleCleanArch.Domain/         # Domain layer
│   │   └── SimpleCleanArch.Application/    # Application layer
│   ├── Infrastructure/
│   │   └── SimpleCleanArch.Infrastructure/ # Infrastructure layer
│   └── Presentation/
│       └── SimpleCleanArch.API/            # API layer
└── tests/
    └── SimpleCleanArch.Tests/              # Unit tests
```

## Clean Architecture Principles

This project follows these clean architecture principles:

1. **Dependency Rule**: Dependencies only point inward. Inner layers have no knowledge of outer layers.
2. **Separation of Concerns**: Each layer has a specific responsibility.
3. **Interface Segregation**: Interfaces are defined in the domain layer and implemented in the infrastructure layer.
4. **Single Responsibility**: Each class has a single responsibility.
5. **Open/Closed Principle**: The system is open for extension but closed for modification.

## License

This project is licensed under the MIT License - see the LICENSE file for details.

## Acknowledgments

- Clean Architecture by Robert C. Martin
- .NET Core documentation
- Entity Framework Core documentation 