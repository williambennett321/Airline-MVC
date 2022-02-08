using Microsoft.EntityFrameworkCore.Migrations;

namespace Airline_MVC.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AirlineStaff",
                columns: table => new
                {
                    EmployeeNum = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeePosition = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeeWage = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AirlineStaff", x => x.EmployeeNum);
                });

            migrationBuilder.CreateTable(
                name: "AirlineTicket",
                columns: table => new
                {
                    TicketNum = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Class = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InitialAirport = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LandingAirport = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AirlineTicket", x => x.TicketNum);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AirlineStaff");

            migrationBuilder.DropTable(
                name: "AirlineTicket");
        }
    }
}
