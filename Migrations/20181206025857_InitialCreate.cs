using Microsoft.EntityFrameworkCore.Migrations;

namespace TestEFCoreOwned.Migrations
{
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
                    JapaneseInfo_Author = table.Column<string>(maxLength: 100, nullable: true),
                    JapaneseInfo_Memo = table.Column<string>(nullable: true),
                    ChineseInfo_Title = table.Column<string>(nullable: true),
                    ChineseInfo_Author = table.Column<string>(maxLength: 100, nullable: true),
                    ChineseInfo_Memo = table.Column<string>(nullable: true)
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
}
