using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Notifications.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddLogStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "EmailsLogs",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "EmailsLogs");
        }
    }
}
