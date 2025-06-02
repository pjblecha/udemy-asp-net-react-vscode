# ASP.NET React Tutorial

### [Get Started with Swagger](https://learn.microsoft.com/en-us/aspnet/core/tutorials/getting-started-with-swashbuckle?view=aspnetcore-8.0&tabs=visual-studio-code)

## Build basic web API project:

### [Minimal API](https://learn.microsoft.com/en-us/aspnet/core/tutorials/min-web-api?view=aspnetcore-9.0&tabs=visual-studio-code)

### [Controller-based API](https://learn.microsoft.com/en-us/aspnet/core/tutorials/first-web-api?view=aspnetcore-9.0&tabs=visual-studio)

## Steps to build
```
dotnet new webapi -o <<Project Name>>
cd <<Project Name>>
dotnet add package Microsoft.EntityFrameworkCore.InMemory
dotnet add package Microsoft.EntityFrameworkCore.Sqlite
dotnet add package Microsoft.EntityFrameworkCore.Tools
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add <<Project Name>>.csproj package Swashbuckle.AspNetCore
dotnet dev-certs https --trust
```

Add SwaggerUI into Program.cs before running. 
Section 1 after AddOpenApi(), 
Section 2 after ```var app = builder.Build();``` line
```
builder.Services.AddSwaggerGen(swaggerGenOpts =>
{
    swaggerGenOpts.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "ASP.NET React Tutorial",
        Version = "v1"
    });
});

...

app.UseSwagger();
app.UseSwaggerUI(swaggerUIOpts =>
{
    swaggerUIOpts.DocumentTitle = "ASP.NET React Tutorial";
    swaggerUIOpts.SwaggerEndpoint("/swagger/v1/swagger.json", "Simple Web API for React");
    swaggerUIOpts.RoutePrefix = string.Empty;
});
```
### Finally, to run:
```
dotnet run --launch-profile https
```


## Adding Migration

```
dotnet ef migrations add FirstMigration -o "Data/Migrations"
```

## Add migration to DB

```
dotnet ef database update
```