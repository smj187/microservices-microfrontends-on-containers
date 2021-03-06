## HTTPS setup

```
// create pfx file
dotnet dev-certs https -ep $env:APPDATA\ASP.NET\Https\PaymentService.API.pfx -p crypticpassword

// open api folder
cd Services/PaymentService/PaymentService.API

// generate user secret
dotnet user-secrets -p ./PaymentService.API.csproj set "Kestrel:Certificates:Development:Password" "crypticpassword"
```

## Database migrations

Run this command at the root level inside ./Services/PaymentService

```

rmdir .\PaymentService.Infrastructure\Migrations\ -r ; dotnet ef migrations add Init --project PaymentService.Infrastructure -s PaymentService.API
dotnet ef database update --project PaymentService.Infrastructure -s PaymentService.API
```
