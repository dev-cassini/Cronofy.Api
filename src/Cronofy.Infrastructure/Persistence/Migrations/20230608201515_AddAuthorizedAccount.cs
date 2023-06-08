using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cronofy.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddAuthorizedAccount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AuthorizedAccounts",
                columns: table => new
                {
                    Sub = table.Column<string>(type: "text", nullable: false),
                    ProfileId = table.Column<string>(type: "text", nullable: false),
                    EmailAddress = table.Column<string>(type: "text", nullable: false),
                    AccessToken = table.Column<string>(type: "text", nullable: false),
                    RefreshToken = table.Column<string>(type: "text", nullable: false),
                    AccessTokenExpiryDateTimeUtc = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    ServiceAccountId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorizedAccounts", x => x.Sub);
                    table.ForeignKey(
                        name: "FK_AuthorizedAccounts_ServiceAccounts_ServiceAccountId",
                        column: x => x.ServiceAccountId,
                        principalTable: "ServiceAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AuthorizedAccounts_ServiceAccountId",
                table: "AuthorizedAccounts",
                column: "ServiceAccountId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuthorizedAccounts");
        }
    }
}
