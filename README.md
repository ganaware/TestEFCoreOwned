Only the 1st Owned Entity property can be configured by Fluent API

### Steps to reproduce

A complete code is here: https://github.com/ganaware/TestEFCoreOwned

I defined an entity Book that has three Owned Entity properties: EnglishInfo, JapaneseInfo and ChineseInfo.
The type of these properties is Info configured by fluend API.

```csharp
    public class Book {
        public int BookId { get; set; }
        public Info EnglishInfo { get; set; }
        public Info JapaneseInfo { get; set; }
        public Info ChineseInfo { get; set; }

        public static void OnModelCreating(ModelBuilder modelBuilder) {
            var e_tb = modelBuilder.Entity<Book>();
            e_tb.Property(e => e.BookId);
            e_tb.OwnsOne(e => e.EnglishInfo);
            e_tb.OwnsOne(e => e.JapaneseInfo);
            e_tb.OwnsOne(e => e.ChineseInfo);
        }
    }

    public class Info {
        public string Title { get; set; } // a general column
        public string Author { get; set; } // a column specified HasMaxLength() by fluent API
        string Memo { get; set; } // with fluent API, a column can be implemented by a private property

        public static void OnModelCreating(ModelBuilder modelBuilder) {
            EntityTypeBuilder<Info> e_tb = modelBuilder.Entity<Info>();
            e_tb.Property(e => e.Title);
            e_tb.Property(e => e.Author)
                .HasMaxLength(100);
            e_tb.Property(e => e.Memo);
        }
    }

    public class MyContext : DbContext {
        public DbSet<Book> Books { get; set; }

        public MyContext() {
        }

        public MyContext(DbContextOptions<MyContext> options)
            : base(options) {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            if (!optionsBuilder.IsConfigured) {
                optionsBuilder.UseSqlite(new SqliteConnection("DataSource=:memory:"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);
            Info.OnModelCreating(modelBuilder);
            Book.OnModelCreating(modelBuilder);
        }
    }

    public class MyContextForMigrationFactory : IDesignTimeDbContextFactory<MyContext> {
        public MyContext CreateDbContext(string[] args) {
            return new MyContext();
        }
    }
```

Then, I created a migration by dotnet command:

```sh
dotnet ef migrations add InitialCreate
```

The generated 20181206004616_InitialCreate.cs is:

```csharp
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    BookId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EnglishInfo_Title = table.Column<string>(nullable: true),
                    EnglishInfo_Author = table.Column<string>(maxLength: 100, nullable: true),
                    EnglishInfo_Memo = table.Column<string>(nullable: true),
                    JapaneseInfo_Title = table.Column<string>(nullable: true),
                    JapaneseInfo_Author = table.Column<string>(nullable: true),
                    ChineseInfo_Title = table.Column<string>(nullable: true),
                    ChineseInfo_Author = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.BookId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");
        }
    }
```

The problem is:

- JapaneseInfo_Author has no maxLength.
- JapaneseInfo_Memo is missing.
- ChineseInfo_Author has no maxLength.
- ChineseInfo_Memo is missing.

In short, Only the 1st Owned Entity property (EnglishInfo) can be configured by Fluent API.  Configurations for 2nd (JapaneseInfo) and 3rd (ChineseInfo) are ignored.

### Further technical details

EF Core version: 2.1.4, 2.2.0
Database Provider: Microsoft.EntityFrameworkCore.Sqlite 2.2.0, Pomelo.EntityFrameworkCore.MySql 2.1.4
Operationg system: Windows 7
IDE: Visual Studio 2017 15.8.7
