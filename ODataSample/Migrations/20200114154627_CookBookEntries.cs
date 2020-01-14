using Microsoft.EntityFrameworkCore.Migrations;

namespace ODataSample.Migrations
{
    public partial class CookBookEntries : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CookBookBlogEntries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CookBookId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: true),
                    Content = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CookBookBlogEntries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CookBookBlogEntries_CookBooks_CookBookId",
                        column: x => x.CookBookId,
                        principalTable: "CookBooks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CookBookBlogEntries_CookBookId",
                table: "CookBookBlogEntries",
                column: "CookBookId");


            migrationBuilder.InsertData("CookBookBlogEntries", new string[] { "CookBookId", "Name", "Content" }, new object[,] {
                { 1, "John", "Tall and fluffy. These pancakes are just right. Topped with strawberries and whipped cream, they are impossible to resist."},
                { 1, "Bill", "This hearty casserole has bacon, eggs, hash browns, and three different cheeses all baked into a comforting breakfast dish, perfect for feeding a crowd."},
                { 1, "Mary", "Hot jumbo buttermilk biscuits with creamy sausage gravy are ready in just 15 minutes for a hearty, family-favorite breakfast."},
                { 2, "John", "I serve this in the summer for brunch with a side of sausage links and a fresh fruit bowl!"},
                { 2, "Bill", "The one and only! EAGLE BRAND® makes this traditional dessert the perfect ending to a Thanksgiving feast."},
                { 2, "Mary", "This recipe has won many 1st place ribbons at my state fair. They are very simple to make."},
            });

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CookBookBlogEntries");
        }
    }
}
