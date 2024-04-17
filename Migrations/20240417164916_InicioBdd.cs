using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TallerMVC2_MJ.Migrations
{
    /// <inheritdoc />
    public partial class InicioBdd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Promo",
                columns: table => new
                {
                    PromoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PromoDescripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaPromocion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BurguerID = table.Column<int>(type: "int", nullable: false),
                    BurgerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Promo", x => x.PromoId);
                    table.ForeignKey(
                        name: "FK_Promo_Burger_BurgerId",
                        column: x => x.BurgerId,
                        principalTable: "Burger",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Promo_BurgerId",
                table: "Promo",
                column: "BurgerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Promo");
        }
    }
}
