using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InternShipAPI.Migrations
{
    /// <inheritdoc />
    public partial class updatev2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ExpireTime",
                table: "ConfirmEmail_tbl",
                newName: "ExpiredTime");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ExpiredTime",
                table: "ConfirmEmail_tbl",
                newName: "ExpireTime");
        }
    }
}
