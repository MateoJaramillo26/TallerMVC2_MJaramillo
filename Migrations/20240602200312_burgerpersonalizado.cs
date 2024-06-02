using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TallerMVC2_MJ.Migrations
{
    /// <inheritdoc />
    public partial class burgerpersonalizado : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MJBurger",
                columns: table => new
                {
                    MJBurgerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MJName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MJWithCheese = table.Column<bool>(type: "bit", nullable: false),
                    MJPrecio = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MJBurger", x => x.MJBurgerId);
                });

            migrationBuilder.CreateTable(
                name: "MJPromo",
                columns: table => new
                {
                    MJPromoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MJPromoDescripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MJFechaPromocion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MJBurgerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MJPromo", x => x.MJPromoId);
                    table.ForeignKey(
                        name: "FK_MJPromo_MJBurger_MJBurgerId",
                        column: x => x.MJBurgerId,
                        principalTable: "MJBurger",
                        principalColumn: "MJBurgerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MJPromo_MJBurgerId",
                table: "MJPromo",
                column: "MJBurgerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MJPromo");

            migrationBuilder.DropTable(
                name: "MJBurger");
        }
    }
}
