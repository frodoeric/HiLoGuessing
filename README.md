# README - .NET 7 Web API Solution for High-Low Guessing Game with Migration

This is a solution for a Web API developed in .NET 7, designed for a High-Low Guessing Game. The application utilizes Entity Framework Core for database management and includes the configuration and application of migrations to maintain and evolve the database schema.

Aplication on Azure:
https://hiloguessingwebapi20231111161433.azurewebsites.net/index.html

## Requirements

Make sure to have the following installed on your machine:

- [.NET SDK 7](https://dotnet.microsoft.com/download/dotnet/7.0)
- [Entity Framework Core Tools](https://docs.microsoft.com/ef/core/cli/dotnet) (to execute migration commands)

## Initial Setup

1. Clone this repository:

    ```bash
    git clone https://github.com/YourUser/YourProject.git
    ```

2. Navigate to the project directory:

    ```bash
    cd YourProject
    ```

3. Restore project dependencies:

    ```bash
    dotnet restore
    ```

## Database Configuration

Ensure to properly configure the database connection in the `appsettings.json` file of the startup project (`HiLoGuessing.WebAPI`, for example).

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "your_connection_string"
  },
  // other settings...
}
```

## Applying Migrations

To create and apply migrations to the database, use the following commands:

```bash
dotnet ef migrations add MigrationName --project HiloGuessing.Data --startup-project HiLoGuessing.WebAPI
```

Replace `MigrationName` with a meaningful name for the migration.

Then, run the following command to apply the migration to the database:

```bash
dotnet ef database update --project HiloGuessing.Data --startup-project HiLoGuessing.WebAPI
```

This command will create or update the database according to the pending migrations.

## Running the High-Low Guessing Game Application

Now that the database is configured, you can start the application:

```bash
dotnet run --project HiLoGuessing.WebAPI
```

The application, based on the High-Low Guessing Game, will be accessible at `https://localhost:(available port)` by default.

## Contribution

Feel free to contribute to this project. Open issues to report bugs or request new features.

Enjoy the development!
