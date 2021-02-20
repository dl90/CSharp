# ASP.NET Core

## mssql packages

```bash
# SqlServer variant
Install-Package Microsoft.EntityFrameworkCore.SqlServer

# migration/update-database
Install-Package Microsoft.EntityFrameworkCore.Tools

# dbContext, model/entity
Install-Package Microsoft.EntityFrameworkCore
```

## config

```C#
// startup.cs connection string
string connection = Configuration.GetConnectionString("DefaultConnection");
services.AddDbContext<TodoContext>(options => options.UseSqlServer(connection));
```

## code first (generate db from code)

```C#
// model class
public class ToDo {
    [Key]
    public int    Id          { get; set; }
    public string Description { get; set; }
    public bool   IsComplete  { get; set; }
}

// dbContext
public class TodoContext : DbContext
{
    public TodoContext(DbContextOptions<TodoContext> options) : base(options) { }
    public DbSet<ToDo> ToDos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Seed data. Auto-increment PK’s must still be specified in seed data.
        modelBuilder.Entity<ToDo>().HasData(
            new { Id = 1, Description = "Clean house", IsComplete = false, Priority = 1 },
            new { Id = 2, Description = "Bake cake", IsComplete = false, Priority = 3 }
        );
    }
}
```

```bash
Add-Migration <migration name>
Update-Database [<migration name>]
```
