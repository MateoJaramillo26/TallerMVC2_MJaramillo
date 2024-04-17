using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TallerMVC2_MJ.Migrations
{
    /// <inheritdoc />
    public partial class Inicio1Bdd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Promo_Burger_BurgerId",
                table: "Promo");

            migrationBuilder.DropColumn(
                name: "BurguerID",
                table: "Promo");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Burger",
                newName: "BurgerId");

            migrationBuilder.AlterColumn<int>(
                name: "BurgerId",
                table: "Promo",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Promo_Burger_BurgerId",
                table: "Promo",
                column: "BurgerId",
                principalTable: "Burger",
                principalColumn: "BurgerId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Promo_Burger_BurgerId",
                table: "Promo");

            migrationBuilder.RenameColumn(
                name: "BurgerId",
                table: "Burger",
                newName: "Id");

            migrationBuilder.AlterColumn<int>(
                name: "BurgerId",
                table: "Promo",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "BurguerID",
                table: "Promo",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Promo_Burger_BurgerId",
                table: "Promo",
                column: "BurgerId",
                principalTable: "Burger",
                principalColumn: "Id");
        }
    }
}
