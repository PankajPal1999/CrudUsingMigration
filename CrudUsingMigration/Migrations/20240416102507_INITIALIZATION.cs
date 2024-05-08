using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CrudUsingMigration.Migrations
{
    /// <inheritdoc />
    public partial class INITIALIZATION : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Personid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Userid = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Personid);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Personid = table.Column<int>(type: "int", nullable: false),
                    personname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    personaddress = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Personid);
                    table.ForeignKey(
                        name: "FK_Persons_Users_Personid",
                        column: x => x.Personid,
                        principalTable: "Users",
                        principalColumn: "Personid",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
