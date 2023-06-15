using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cronofy.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddDomainToServiceAccount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Domain",
                table: "ServiceAccounts",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Domain",
                table: "ServiceAccounts");
        }
    }
}
