# BackendDevelopmentTask

### Configure Postgres before testing
- Set the Postgres connection string in `BackendDevelopmentTask/BackendDevelopmentTask/appsettings.Development.json` under `ConnectionStrings:Postgres`.
- Example:
```json
{
  "ConnectionStrings": {
    "Postgres": "Host=localhost;Port=5432;Database=BackendDevDb;Username=your_user_name;Password=your_password;"
  }
}
