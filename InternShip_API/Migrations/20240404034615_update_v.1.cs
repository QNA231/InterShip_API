using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InternShipAPI.Migrations
{
    /// <inheritdoc />
    public partial class updatev1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExpireTime",
                table: "RefreshToken_tbl");

            migrationBuilder.AddColumn<DateTime>(
                name: "ExpiredTime",
                table: "RefreshToken_tbl",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExpiredTime",
                table: "RefreshToken_tbl");

            migrationBuilder.AddColumn<string>(
                name: "ExpireTime",
                table: "RefreshToken_tbl",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
