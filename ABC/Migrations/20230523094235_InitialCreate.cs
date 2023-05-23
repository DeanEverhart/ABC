using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ABC.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "A",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    One = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Two = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Three = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_A", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "B",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    One = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Two = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Three = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_B", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "C",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AId = table.Column<int>(type: "int", nullable: false),
                    BId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_C", x => x.Id);
                    table.ForeignKey(
                        name: "FK_C_A_AId",
                        column: x => x.AId,
                        principalTable: "A",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_C_B_BId",
                        column: x => x.BId,
                        principalTable: "B",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_C_AId",
                table: "C",
                column: "AId");

            migrationBuilder.CreateIndex(
                name: "IX_C_BId",
                table: "C",
                column: "BId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "C");

            migrationBuilder.DropTable(
                name: "A");

            migrationBuilder.DropTable(
                name: "B");
        }
    }
}
