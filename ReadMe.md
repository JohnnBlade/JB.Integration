
Install-Package Microsoft.EntityFrameworkCore.SqlServer
Install-Package Microsoft.EntityFrameworkCore.Tools

Create migration code
Create seeder methods

Add to Migrate to program.cs, 
            CreateHostBuilder(args)
                .Build()
                .MigrateDatabase() //*
                .Run();

Add-Migration InitialCreate
Update-Database

Once db is auto created and seeded, create a integration test project
Install-Package Microsoft.AspNetCore.Mvc.Testing