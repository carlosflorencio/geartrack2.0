# Geartrack API 2.0

This api scraps these trackers:

- Sky56
- Correos Express
- Adicional
- Expresso24

Requests for the tracker data are retry 3 times before give up.
Response data is cached for 10 min.

### Stack
- .Net Core

### Run in CLI
- `dotnet restore`
- `dotnet run`

### Installation on Production
- Set env var `ASPNETCORE_ENVIRONMENT` to 'Production'
- Create `appsettings.Production.json` and set the logging types