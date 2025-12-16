using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Redarbor.InfrastructureEF.Migrations
{
    /// <inheritdoc />
    public partial class seedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "CreatedOn", "DeletedOn", "Name", "UpdatedOn" },
                values: new object[] { new Guid("a2220b31-1402-485c-bcef-904b6dec977e"), new DateTime(2025, 12, 15, 0, 0, 0, 0, DateTimeKind.Utc), null, "Company test", null });

            migrationBuilder.InsertData(
                table: "Portals",
                columns: new[] { "Id", "CreatedOn", "DeletedOn", "Name", "UpdatedOn" },
                values: new object[] { new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6"), new DateTime(2025, 12, 15, 0, 0, 0, 0, DateTimeKind.Utc), null, "Portal test", null });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedOn", "DeletedOn", "Name", "UpdatedOn" },
                values: new object[] { new Guid("b0c4a2e9-61d0-459d-a35b-82d0e4a7f85e"), new DateTime(2025, 12, 15, 0, 0, 0, 0, DateTimeKind.Utc), null, "Administrador", null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("a2220b31-1402-485c-bcef-904b6dec977e"));

            migrationBuilder.DeleteData(
                table: "Portals",
                keyColumn: "Id",
                keyValue: new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("b0c4a2e9-61d0-459d-a35b-82d0e4a7f85e"));
        }
    }
}
