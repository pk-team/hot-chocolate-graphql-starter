# Hot Chocolate Graphql Template

Hot Chocolate Graphql start template, with separate server, model and unit test projects.

## Setup

You will need the dotnet runtime and dotnet tools.

### 1. Development Appsettings 

```
touch App.Server/appsettings.Development.json
```

Then copy paste the following into `App.Server/appsettings.Development.json`

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "Default": "server=localhost,9302;database=activity;uid=sa;pwd=PetHappy870#"
  }
}
```

### 2. Start the database server

You will need Docker Desktop for this.

```yml
docker run -d \
    -p 9302:1433 \
    -e ACCEPT_EULA=1 \
    -e MSSQL_SA_PASSWORD="PetHappy870#" \
    --cap-add=SYS_PTRACE \
    --name gql-mssql \
    mcr.microsoft.com/azure-sql-edge    
```

### 3. Add initial migration

No initial migrations.

```
dotnet ef migrations add Initial --project App.Model -o src/Migrations
```

### 4. apply the initial migration
```bash
dotnet ef database update --project App.Model  --connection  "server=localhost,9302;database=activity;uid=sa;pwd=PetHappy870#"
```


### 5. Seed the database

```bash
dotnet run --project App.Seed "server=localhost,9302;database=activity;uid=sa;pwd=PetHappy870#"
```

### 6. Start App.Server

```bash
dotnet watch --no-hot-reload --project App.Server
```

### 7. Open the graphql playground

[Graphql playground](http://localhost:5200/graphql)

Sample query

```gql
query getTodos { 
  todos {
    title
    acivities {
      title
    }
  }
}
```



