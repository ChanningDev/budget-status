using Microsoft.EntityFrameworkCore.Migrations;

namespace BudgetStatus.Migrations
{
    public partial class migration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bdgfixmonth",
                columns: table => new
                {
                    Counter = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Byear = table.Column<int>(type: "int", nullable: false),
                    Bbudget = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Bmonth = table.Column<int>(type: "int", nullable: false),
                    Blongmonth = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Closed = table.Column<int>(type: "int", nullable: false),
                    Current = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bdgfixmonth", x => x.Counter);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bdgfixmonth");
        }
    }
}
