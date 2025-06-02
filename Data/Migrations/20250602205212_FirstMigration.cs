using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace aspnetserver.Data.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    PostID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    Content = table.Column<string>(type: "TEXT", maxLength: 131080, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.PostID);
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "PostID", "Content", "Title" },
                values: new object[,]
                {
                    { 1, "This is the content for the first post. Kinda cool eh?", "First Post" },
                    { 2, "Well, this is awkward... not sure what to do.", "Post 2" },
                    { 3, "Der Post ist eine kleine Scheisse Post", "Poste Drei" },
                    { 4, "Merde! En Francais d'accord?", "Un Post Quatre" },
                    { 5, "So... Beethoven or Liquor?", "A fifth of Post" },
                    { 6, "The number of sick sheep in a bad tongue twister", "Six" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Posts");
        }
    }
}
