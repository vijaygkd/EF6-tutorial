# EF6-tutorial
Entity Framework 6 - Tutorial

[Pluralsight tutorial](http://pluralsight.com/training/Player?author=scott-allen&name=aspdotnet-mvc5-fundamentals-m5-webapi2&mode=live&clip=0&course=aspdotnet-mvc5-fundamentals)


### Topics Learned:
- EF6 code first setup
- Entity & DbContext creation
- Async Controller api which use EF6 async methods
- Logging
- Glimpse diagnostics
- Migrations
- Migrations for multiple DbContext in same project
- How to use Migrations for database updates


### EF Database Migrations

Following commands are used in the Package Manager Console:

* __enable-migrations__

To enable db migrations for the project. This command will work if only one dbcontext is in the project. For multiple dbcontexts in the project, migrations need to be enabled separately into __different directories__

* enable-migrations -ContextTypeName BooksDb -MigrationsDirectory DataContexts\BookMigrations

To enable db migrations for BooksDb in DataContexts\BookMigrations dir

* enable-migrations -ContextTypeName ApplicationDbContext -MigrationsDirectory DataContexts\IdentityMigrations

* add-migration -ConfigurationTypeName Books.Web.DataContexts.BookMigrations.Configuration "InitialCreate"

Create a migration called InitialCreate. Since the db table is not created, this migration will create the table.

* add-migration -ConfigurationTypeName Books.Web.DataContexts.IdentityMigrations.Configuration "InitialCreate"

* update-database -ConfigurationTypeName Books.Web.DataContexts.BookMigrations.Configuration -verbose

Update database to run the migrations which are applicable. In this case create tables.

* update-database -ConfigurationTypeName Books.Web.DataContexts.IdentityMigrations.Configuration

* add-migrations -ConfigurationTypeName Books.Web.DataContexts.BookMigrations.Configuration "DefaultSchema"

This migration was created after changing the default table schema from "dbo" to "library" in the dbcontext class for Book entity. The scaffolding will detect with code change and generate db commands to change the table schema in the DefaultSchema migration.

* add-migration -ConfigurationTypeName Books.Web.DataContexts.BookMigrations.Configuration "DefaultSchema"

* update-database -ConfigurationTypeName Books.Web.DataContexts.BookMigrations.Configuration -verbose

Update db to run the pending migrations, in this case update the table schema.

* update-database -ConfigurationTypeName Books.Web.DataContexts.IdentityMigrations.Configuration


