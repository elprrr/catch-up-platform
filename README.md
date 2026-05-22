# Catch-Up Platform (catch-up-platform)

## Overview

Catch-Up Platform is a small ASP.NET Core service that provides an API to manage users' favorite news sources. The project demonstrates a clean package structure separated into bounded contexts (news and shared) and follows simple command/query service patterns with Entity Framework Core persistence.

## Features

- API base route: `api/v1/favorite-sources` (kebab-case route naming convention)
- List favorite sources by `newsApiKey`
- Retrieve a favorite source by `id`
- Retrieve a favorite source by `newsApiKey` + `sourceId`
- Create (persist) a new favorite source
- Duplicate detection enforced at application and database level (`409 Conflict`)
- Validation responses with model-state payloads (`400 Bad Request`)
- Unexpected create errors returned as `ProblemDetails` (`500 Internal Server Error`)
- Entity Framework naming strategy for `snake_case` identifiers and plural table names
- Structured logging for diagnostics and observability

## Technologies

- C# 14 and .NET 10 (`net10.0`)
- ASP.NET Core Web API (REST controllers + Swagger/OpenAPI)
- Entity Framework Core 10 + MySQL provider (`MySql.EntityFrameworkCore`)
- Localization with `.resx` resources (`en`, `en-US`, `es`, `es-PE`)
- Structured logging with `ILogger<T>`
- PlantUML (architecture diagrams in `docs/`)

## Technical stories

The API-focused technical stories for frontend integration are in [`docs/user-stories.md`](docs/user-stories.md).

## Class diagram

A PlantUML class diagram that reflects the code structure and bounded contexts is available at [`docs/class-diagram.puml`](docs/class-diagram.puml).

## Getting started (quick)

### Prerequisites

- .NET SDK 10
- A reachable MySQL instance

### 1) Restore dependencies

```bash
dotnet restore catch-up-platform.sln
```

### 2) Configure connection string

By default, development uses `CatchUpPlatform.API/appsettings.Development.json`:

```json
"ConnectionStrings": {
  "DefaultConnection": "server=localhost;user=root;password=password;database=catch-up-wa"
}
```

### 3) Run the API

```bash
dotnet run --project CatchUpPlatform.API
```

Or from the API folder:

```bash
cd CatchUpPlatform.API
dotnet run
```

### Database initialization

The application automatically initializes the database schema on first run via `EnsureCreated()`.

- **Development**: Creates schema in the configured MySQL database.
- **First-time setup**: Ensure MySQL is running and the connection string points to an existing (empty or non-empty) database.
- **Constraints**: A unique composite index is enforced on `(NewsApiKey, SourceId)` to prevent duplicate favorites.
- **Schema changes**: For schema updates, manually drop and recreate the database, or use EF Core migrations (not currently configured).

### 4) Open Swagger UI

With the default launch profile, Swagger is available at:

- `http://localhost:5128/swagger`
- `https://localhost:7234/swagger`

### Production-style configuration

`CatchUpPlatform.API/appsettings.Production.json` supports environment variable expansion:

- `%DATABASE_URL%`
- `%DATABASE_USER%`
- `%DATABASE_PASSWORD%`
- `%DATABASE_SCHEMA%`

Set `ASPNETCORE_ENVIRONMENT=Production` before running with production settings.

## Error responses

The API returns standardized error responses:

- **400 Bad Request**: Request validation failed (includes model-state details).
- **404 Not Found**: Resource not found.
- **409 Conflict**: Duplicate `newsApiKey` + `sourceId` pair (detected before or during persistence).
- **500 Internal Server Error**: Unexpected server error (RFC7807 `ProblemDetails` format).

## Build and verify

```bash
dotnet build catch-up-platform.sln
```
