using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cronofy.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ProtectServiceAccountRefreshToken : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RefreshToken",
                table: "ServiceAccounts",
                newName: "ProtectedRefreshToken");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProtectedRefreshToken",
                table: "ServiceAccounts",
                newName: "RefreshToken");
        }
    }
}
