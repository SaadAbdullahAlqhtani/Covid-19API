using Microsoft.EntityFrameworkCore.Migrations;

namespace covid.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cases",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cases", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Cases",
                columns: new[] { "Id", "Description", "FirstName", "LastName", "Type" },
                values: new object[,]
                {
                    { 1, "Description", "John", "Doe", "Cured" },
                    { 2, "Description", "Jill", "Doe", "Cured" },
                    { 3, "Description", "Amy", "Doe", "Infected" },
                    { 4, "Description", "Steve", "Doe", "Cured" },
                    { 5, "Description", "Amy", "House", "Infected" },
                    { 6, "Description", "Sam", "Wood", "Deceased" },
                    { 7, "Description", "Alex", "Clay", "Deceased" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cases");
        }
    }
}
