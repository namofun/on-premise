# On-premise

This is the on-premise version of Online Judge.

You can modify it by your own needs.

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
    "PdfService": "http://localhost:9000/api/render", // Keep this line if you want to export the student report PDF. Refer to https://hub.fastgit.org/alvarcarto/url-to-pdf-api
    "UserDbConnection": "Server=tcp:127.0.0.1,1433;Initial Catalog={Your SQL Server Database Name};Persist Security Info=False;User ID={Your SQL Server User Name};Password={Your SQL Server Password};MultipleActiveResultSets=True;Encrypt=True;TrustServerCertificate=True;Connection Timeout=30;"
  },
  "FileUploadShortCircuit": true // Keep this line if you want to keep all files produced by DOMjudge judgehost
}
```

For more usage and reference, please refer to the source code.

### Deployment - Docker

Comming soon... [pigeon]