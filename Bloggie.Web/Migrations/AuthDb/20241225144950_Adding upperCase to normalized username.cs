using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bloggie.Web.Migrations.AuthDb
{
    /// <inheritdoc />
    public partial class AddingupperCasetonormalizedusername : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cd24c75f-f7d2-4212-9334-25e0f9f40e42",
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8aea7b21-604b-4496-9d7d-8a3f6b2935b8", "SUPERADMIN@BLOGGIE.COM", "AQAAAAIAAYagAAAAENcNrAEeczm0qf/ReRhc47l3VsTiiqbPfX1V2gVceeZpoCL19dOf/9QREZWdK32/SA==", "0a69092a-45e4-4d1c-9373-c49c71bd6069" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cd24c75f-f7d2-4212-9334-25e0f9f40e42",
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e0f8211f-c6b0-48fd-a520-5140245c47a3", "superadmin@bloggie.com", "AQAAAAIAAYagAAAAEFh7zjeQjk2Yr9qoB0sUv3EzYGw/MIdIHf9Augc77R2OitCg9OkPr/Z6z2y2+NrnWw==", "e35e32b0-333c-43c8-b654-e53b1c53cbc9" });
        }
    }
}
