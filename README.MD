# Clean Architecture - Admission Test.

Backend Web API project in .NET Core 3.1 based on the <i>Clean Architecture software architecture model.</i>

## Features:

- Developed in .NET Core 3.1 (C # as a programming language).
- Compiled for Microsoft Visual Studio 2019 onwards and for Visual Studio Core.

### Restore Main Project

1. cd _Payment.Api_
2. _dotnet restore_

### Setting Connection To Database

1. Create a new Database in your sqlserver instance called "pagos"
2. Edit the project configuration file Payment.Api _appsettings.json_
3. Adjust the connection string called PaymentDbContext

### Run Migrations

1. cd _Payment.Api_
2. _dotnet ef migrations add FirstMigration --output-dir "Data/Migrations" --context PaymentDbContext_
3. _dotnet ef database update --context PaymentDbContext_

### Alternative to migration

1. In your instance of SQL Server you can run the script from the DATABASE.sql file

### Run Project

1. cd _Payment.Api_
2. _dotnet run_

### API

1. Create Payment
1. Swaguer run on : https://localhost:5001/swagger/index.html

##### Request

```http
POST https://localhost:5001/Payment
```

```javascript
{
  "userId": 1,
  "shippingAddress": "Calle 58 # 12-12",
  "detail": [
    {
      "productId": 1,
      "price": 3000
    },
    {
      "productId": 2,
      "price": 5000
    },
    {
      "productId": 3,
      "price": 5000
    }
  ]
}
```

#### Responses

Return a string with massage _"payment execute successfully"_

#### Status Codes

Returns the following status codes in its API:

| Status Code | Description             |
| :---------- | :---------------------- |
| 200         | `OK`                    |
| 409         | `CONFLICT`              |
| 500         | `INTERNAL SERVER ERROR` |
