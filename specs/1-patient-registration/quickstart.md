# Quickstart: SDD Hospital API

## Prerequisites
- .NET 9 SDK
- Aspire (for orchestration, optional)

## Running the Solution

1. Restore dependencies:
   ```powershell
   dotnet restore
   ```
2. Build the solution:
   ```powershell
   dotnet build
   ```
3. Run the API project:
   ```powershell
   dotnet run --project src/SDD.Hospital.Api/SDD.Hospital.Api.csproj
   ```
4. Access Swagger UI:
   - Open your browser and navigate to: [http://localhost:5000/swagger](http://localhost:5000/swagger) (or the port shown in the console)

## Register a Patient
- Use the Swagger UI to POST to `/api/patients` with the required fields.

## Running Integration Tests

- From repo root run the integration test project:
   ```powershell
   dotnet test tests/SDD.Hospital.Api.IntegrationTests/SDD.Hospital.Api.IntegrationTests.csproj
   ```

## Database
- The API uses EF Core. Update connection string in `appsettings.json` if needed.

## Aspire
- To run with Aspire orchestration, follow Aspire documentation and ensure all services are configured.
