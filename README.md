# On-premise

This is the on-premise version of Online Judge.

You can modify it by your own needs.

Please note that PostgreSQL version is not fully tested. If you encountered any problem, feel free to open an issue for us.

### Deployment - Directly on Ubuntu

Clone the source at `/usr/local/src/acm.xylab.fun/` by git, so that you can update the version by git pull easily.

Install judgehost with our modified version at `/opt/domjudge/`. (If you are installing on the same machine)

Create the published website via `publish.sh`, and go to `/opt/ccs/bin`.

Make a file called `appsettings.Production.json`.

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft": "Warning",
      "Microsoft.Hosting.Lifetime": "Information"
    }
  },
  "Mailing": {
    "Sender": "Your Name",
    "User": "admin@admin.com",
    "Key": "adminadminadmin",
    "Server": "smtp.qq.com",
    "Port": 587
  },
  "ConnectionStrings": {
    "ContestKeyword": "{Generate this by your self}",
    "PdfService": "http://{alvarcarto.url-to-pdf-api}:9000/api/render",
    "SqlServerDbConnection": "Server=tcp:{YourServer},1433;Initial Catalog={YourDatabaseName};Persist Security Info=False;User ID={YourUserName};Password={YourPassword};MultipleActiveResultSets=True;Encrypt=True;TrustServerCertificate=True;Connection Timeout=30;",
    "PostgresDbConnection": "User ID={YourUserName};Password={YourPassword};Host={YourServer};Port=5432;Database={YourDatabaseName};Pooling=true"
  },
  "FileUploadShortCircuit": false
}
```

For more usage and reference, please refer to the source code.

To choose the database provider, delete the unused one from the `ConnectionStrings` section.

To enable the PDF student report service, modify the `PdfService` item. Refer to [alvarcarto/url-to-pdf-api](https://github.com/alvarcarto/url-to-pdf-api).

If you are deploying this OJ and all the judgehosts on the same machine, turn `FileUploadShortCircuit` to `true`.

The mailing system is configured through `Mailing` section.

### Deployment - Docker compose

For SQL Server, you may use `docker-compose.sqlservr.yml`.

For PostgreSQL, you may use `docker-compose.postgres.yml`.