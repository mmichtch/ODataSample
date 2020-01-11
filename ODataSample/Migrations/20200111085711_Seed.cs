using Microsoft.EntityFrameworkCore.Migrations;

namespace ODataSample.Migrations
{
    public partial class Seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData("Authors", new string[] {"Id", "FirstName", "LastName" }, new object[,] {
                { 1, "Rafael", "Sabatini" },
                { 2, "Robert", "Heinlein" },
                { 3, "Isaac",  "Asimov" },
                { 4, "J.K.", "Rowling" },
            });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData("BookAuthor",new string[] { }, new object[] { });
            migrationBuilder.DeleteData("BookGenre", new string[] { }, new object[] { });
            migrationBuilder.DeleteData("CookRecipe", new string[] { }, new object[] { });
            migrationBuilder.DeleteData("RoadAtlas", new string[] { }, new object[] { });
            migrationBuilder.DeleteData("TextBook", new string[] { }, new object[] { });
            migrationBuilder.DeleteData("Authors", new string[] { }, new object[] { });
            migrationBuilder.DeleteData("Genres", new string[] { }, new object[] { });
            migrationBuilder.DeleteData("CookBook", new string[] { }, new object[] { });
            migrationBuilder.DeleteData("Books", new string[] { }, new object[] { });

        }
    }
}
