using Microsoft.EntityFrameworkCore.Migrations;
using ODataSample.Model;

namespace ODataSample.Migrations
{
    public partial class Seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData("Authors", new string[] { "Id", "FirstName", "LastName" }, new object[,] {
                { 1, "Rafael", "Sabatini" },
                { 2, "Robert", "Heinlein" },
                { 3, "Isaac",  "Asimov" },
                { 4, "J.K.", "Rowling" },
                { 5, "Jillian", "Harris" },
                { 6, "Tori", "Wesszer" },
                { 7, "Greta", "Podleski" },
            });

            migrationBuilder.InsertData("Genres", new string[] { "Id", "Name" }, new object[,] {
                { 1, "Science Fiction"},
                { 2, "Fantasy"},
                { 3, "Magic"},
                { 4, "Math"},
                { 5, "Phisics"},
                { 6, "Food"},
            });

            migrationBuilder.InsertData("Books", new string[] { "Id", "Name", "Type" }, new object[,] {
                { 1, "FRAICHE FOOD, FULL HEARTS", (int)BookType.CookBook},
                { 2, "YUM & YUMMER", (int)BookType.CookBook},
            });

            migrationBuilder.InsertData("BookAuthors", new string[] { "BookId", "AuthorId" }, new object[,] {
                { 1, 5},
                { 1, 6},
                { 2, 7},
            });

            migrationBuilder.InsertData("BookGenres", new string[] { "BookId", "GenreId" }, new object[,] {
                { 1, 6},
                { 2, 6},
            });

            migrationBuilder.InsertData("CookBooks", new string[] { "Id", "Theme" }, new object[,] {
                { 1, "A COLLECTION OF RECIPES FOR EVERY DAY AND CASUAL C…"},
                { 2, "RIDICULOUSLY TASTY RECIPES THAT'LL BLOW YOUR MIND, BUT..."},
            });

            migrationBuilder.InsertData("CookRecipes", new string[] { "CookBookId", "Title", "Content" }, new object[,] {
                { 1, "Fluffy Pancakes", "Tall and fluffy. These pancakes are just right. Topped with strawberries and whipped cream, they are impossible to resist."},
                { 1, "Cheesy Amish Breakfast Casserole", "This hearty casserole has bacon, eggs, hash browns, and three different cheeses all baked into a comforting breakfast dish, perfect for feeding a crowd."},
                { 1, "Easy Sausage Gravy and Biscuits", "Hot jumbo buttermilk biscuits with creamy sausage gravy are ready in just 15 minutes for a hearty, family-favorite breakfast."},
                { 2, "Crustless Spinach Quiche", "I serve this in the summer for brunch with a side of sausage links and a fresh fruit bowl!"},
                { 2, "Perfect Pumpkin Pie", "The one and only! EAGLE BRAND® makes this traditional dessert the perfect ending to a Thanksgiving feast."},
                { 2, "Coconut Macaroons III", "This recipe has won many 1st place ribbons at my state fair. They are very simple to make."},
            });

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Cascade will delete all subobjects
            migrationBuilder.DeleteData("Books", new string[] { }, new object[] { });

            migrationBuilder.DeleteData("Authors", new string[] { }, new object[] { });
            migrationBuilder.DeleteData("Genres", new string[] { }, new object[] { });

        }
    }
}
