using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InternShipAPI.Migrations
{
    /// <inheritdoc />
    public partial class updatev3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_tbl_RankCustomer_tbl_RankCustomerId",
                table: "User_tbl");

            migrationBuilder.AlterColumn<int>(
                name: "RankCustomerId",
                table: "User_tbl",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Point",
                table: "User_tbl",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_User_tbl_RankCustomer_tbl_RankCustomerId",
                table: "User_tbl",
                column: "RankCustomerId",
                principalTable: "RankCustomer_tbl",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_tbl_RankCustomer_tbl_RankCustomerId",
                table: "User_tbl");

            migrationBuilder.AlterColumn<int>(
                name: "RankCustomerId",
                table: "User_tbl",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Point",
                table: "User_tbl",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_User_tbl_RankCustomer_tbl_RankCustomerId",
                table: "User_tbl",
                column: "RankCustomerId",
                principalTable: "RankCustomer_tbl",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
